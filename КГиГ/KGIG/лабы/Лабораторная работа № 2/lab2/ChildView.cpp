
// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "lab2.h"
#include "ChildView.h"
#include "GraphBitMap.h"
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
	ShowBitMap(theApp.hwnd, theApp.hBit, 0, 0);
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

}