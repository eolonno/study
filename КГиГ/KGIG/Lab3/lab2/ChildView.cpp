
// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "lab2.h"
#include "ChildView.h"
#include "GraphBitMap.h"
#include "Math.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()

	ON_WM_LBUTTONDOWN()
    ON_WM_LBUTTONUP()
	ON_COMMAND(ID_EDIT_TESTLINE, &CChildView::OnEditTestlines)
END_MESSAGE_MAP()



// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	if (theApp.hwnd)
	{
		ShowBitMap(theApp.hwnd, theApp.hBit, 0, 0);
	}
	if(theApp.GetCurrentMode() == ID_EDIT_LINE)
		MyLine(*(GetWindowDC()), theApp.From.x,theApp.From.y, theApp.To.x, theApp.To.y, (COLORREF)0);
	if(theApp.GetCurrentMode() == ID_EDIT_CIRCLE)
	{
		CPoint p;
		p.x = theApp.From.x;
		p.y = theApp.From.y;
		int r = sqrt(pow((double)(theApp.From.x - theApp.To.x), 2) + pow((double)(theApp.From.y - theApp.To.y), 2));
		MyCircle(*(GetWindowDC()), p, r, (COLORREF)0);
	}
	// TODO: Add your message handler code here
	
	// Do not call CWnd::OnPaint() for painting messages
}

void CChildView::OnLButtonDown(UINT flags,CPoint point)
{
	theApp.From = point;
}

void CChildView::OnLButtonUp(UINT flags,CPoint point)
{
    theApp.To = point;
	if (theApp.SaveAr) 
	{
		theApp.SaveArea();
		theApp.SaveAr = false;
		theApp.From.x = 0;
		theApp.From.y = 0;
		theApp.To.x = 0;
		theApp.To.y = 0;
	}
	CWnd *cwnd = AfxGetMainWnd();
	theApp.hwnd = cwnd->GetSafeHwnd();
	ClientToBmp(theApp.hwnd, "..\\screen.bmp");
	theApp.hBit = (HBITMAP)LoadImage(NULL, "..\\screen.bmp", IMAGE_BITMAP,
			0, 0, LR_LOADFROMFILE |  LR_CREATEDIBSECTION);

	theApp.m_pMainWnd->Invalidate();
}
void CChildView::OnEditTestlines()
{
	// TODO: Add your command handler code here
	MyLine(*(GetWindowDC()), 100, 100, 300, 100, (COLORREF)0);
	MyLine(*(GetWindowDC()), 300, 100, 300, 300, (COLORREF)0);
	MyLine(*(GetWindowDC()), 300, 300, 100, 300, (COLORREF)0);
	MyLine(*(GetWindowDC()), 100, 300, 100, 100, (COLORREF)0);
	MyLine(*(GetWindowDC()), 100, 100, 300, 300, (COLORREF)0);
	MyLine(*(GetWindowDC()), 100, 300, 300, 100, (COLORREF)0);
}