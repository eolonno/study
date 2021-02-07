
// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "lab6.h"
#include "ChildView.h"

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
	ON_WM_TIMER()
	ON_WM_LBUTTONDOWN()
    ON_WM_LBUTTONUP()
	ON_WM_RBUTTONDOWN()
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
	
	if (theApp.Start == true)
	{
		theApp.SunSystem.GetRS(RS);
		RW=theApp.SunSystem.GetRW();
		SetMyMode(dc,RW,RS);
		theApp.SunSystem.Draw(dc);		
		dc.SetMapMode(MM_TEXT);
	}
}

void CChildView::OnTimer(UINT_PTR nIDEvent)
{
	theApp.SunSystem.SetNewCoords();
	Invalidate();
	CWnd::OnTimer(nIDEvent);

}

void CChildView::OnLButtonDown(UINT flags,CPoint point)
{	
		SetTimer(1,theApp.dT_Timer,NULL);
		theApp.From = point;
}

void CChildView::OnRButtonDown(UINT flags,CPoint point)
{
	KillTimer(1); 	
}
void CChildView::OnLButtonUp(UINT flags,CPoint point)
{	
	theApp.To = point;	
	theApp.m_pMainWnd->Invalidate();	
}