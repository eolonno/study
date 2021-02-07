
// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "lab4.h"
#include "MainFrm.h"
#include <Windows.h>
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_CREATE()
	ON_WM_SETFOCUS()
	ON_COMMAND(ID_32776, &CMainFrame::On32776)
END_MESSAGE_MAP()

// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	// create a view to occupy the client area of the frame
	if (!m_wndView.Create(NULL, NULL, AFX_WS_DEFAULT_VIEW,
		CRect(0, 0, 0, 0), this, AFX_IDW_PANE_FIRST, NULL))
	{
		TRACE0("Failed to create view window\n");
		return -1;
	}
	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	cs.dwExStyle &= ~WS_EX_CLIENTEDGE;
	cs.lpszClass = AfxRegisterWndClass(0);
	return TRUE;
}

// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}
#endif //_DEBUG


// CMainFrame message handlers

void CMainFrame::OnSetFocus(CWnd* /*pOldWnd*/)
{
	// forward focus to the view window
	m_wndView.SetFocus();
}

BOOL CMainFrame::OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo)
{
	// let the view have first crack at the command
	if (m_wndView.OnCmdMsg(nID, nCode, pExtra, pHandlerInfo))
		return TRUE;

	// otherwise, do default handling
	return CFrameWnd::OnCmdMsg(nID, nCode, pExtra, pHandlerInfo);
}

int ClientRectToBmp(HWND hWnd, char* name, RECT r)
	{
		HANDLE fh = CreateFile ((LPCWSTR)name, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN, NULL);
	if (fh == INVALID_HANDLE_VALUE) 
		return 2;
	BITMAPINFOHEADER bi;
		ZeroMemory (&bi, sizeof (BITMAPINFOHEADER));
	bi.biSize = sizeof (BITMAPINFOHEADER);
	bi.biWidth = r.right - r.left;
	bi.biHeight = r.bottom - r.top;
	bi.biPlanes = 1; 
	bi.biBitCount = 32; //16;
	bi.biSizeImage = (bi.biWidth * bi.biBitCount + 31)/32*4*bi.biHeight;

	BITMAPFILEHEADER bmfHdr;
		ZeroMemory (&bmfHdr, sizeof (BITMAPFILEHEADER));
	bmfHdr.bfType = 0x4D42; //BM  ('M'<<8)|'B';
	bmfHdr.bfSize = bi.biSizeImage + sizeof (BITMAPFILEHEADER) + bi.biSize;
	bmfHdr.bfReserved1 = bmfHdr.bfReserved2 = 0;
	bmfHdr.bfOffBits = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)bi.biSize;

	HDC hDC = GetDC (hWnd);
	HDC hDCMem = CreateCompatibleDC (hDC);
	HBITMAP hBitmap = CreateCompatibleBitmap (hDC, bi.biWidth, bi.biHeight);
	HBITMAP oldBitmap = (HBITMAP)SelectObject (hDCMem, hBitmap);
	BitBlt (hDCMem, 0, 0, bi.biWidth, bi.biHeight, hDC, r.left, r.top, SRCCOPY);
	hBitmap = (HBITMAP)SelectObject (hDCMem, oldBitmap);

	HANDLE hDIB = GlobalAlloc (GHND /*GMEM_FIXED*/, bi.biSizeImage);
	char* lp = (char*)GlobalLock (hDIB);
	GetDIBits (hDC, hBitmap, 0, bi.biHeight, lp, (LPBITMAPINFO)&bi, DIB_RGB_COLORS);	// не используется?
	DWORD dwWritten = sizeof (BITMAPFILEHEADER);
		WriteFile(fh, (LPSTR)&bmfHdr, sizeof(BITMAPFILEHEADER), &dwWritten, NULL);
	dwWritten = sizeof (BITMAPINFOHEADER);
		WriteFile (fh, (LPSTR)&bi, sizeof (BITMAPINFOHEADER), &dwWritten, NULL);
	dwWritten = bi.biSizeImage;
		WriteFile (fh, lp, bi.biSizeImage, &dwWritten, NULL);

	GlobalUnlock(hDIB);    
	GlobalFree(hDIB);

	DeleteObject(hBitmap);
	//GlobalFree (GlobalHandle (lp));
	lp = NULL;
	CloseHandle (fh);
	ReleaseDC (hWnd, hDCMem);
	ReleaseDC (hWnd, hDC);
	DeleteDC (hDCMem);
	DeleteDC (hDC);
	if (dwWritten == 2) return 2;
	//counter++;
	return 0;
	}

int ClientToBmp(HWND hWnd, char *Name)
{
	RECT r;
	GetClientRect (hWnd, &r);
	return ClientRectToBmp (hWnd, Name, r);
}


void CMainFrame::On32776()
{
		CFileDialog fileDialog(FALSE,NULL,L"screen.bmp");	//объект класса выбора файла
	fileDialog.m_ofn.lpstrFilter = L"images(.bmp)\0*.bmp\0\0";
	int result = fileDialog.DoModal();	//запустить диалоговое окно
	if (result==IDOK)	//если файл выбран
	{
		CWnd *cwnd = AfxGetMainWnd();
		HWND hwnd = cwnd->GetSafeHwnd();

		if(ClientToBmp(hwnd, (char*)fileDialog.GetPathName().GetBuffer()) == 0)
			AfxMessageBox(L"Сохранено");
		else
			AfxMessageBox(L"Ошибка");
		
	}

}
