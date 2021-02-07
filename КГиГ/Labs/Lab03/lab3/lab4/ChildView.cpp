
// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "lab4.h"
#include "ChildView.h"
#include "CMATRIX.H"
#include "LibChart2D.h"

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
	CPaintDC dc(this); 
	CWnd* m_Wnd = AfxGetApp()->GetMainWnd();
	//m_Wnd->MoveWindow(0, 0, 960, 780);
	if(theApp.graf_type == 5)
	{
		theApp.CPlot1.Draw(dc,1,1);
		theApp.CPlot2.Draw(dc,1,1);	
		theApp.CPlot3.Draw(dc,1,1);
		theApp.CPlot4.Draw(dc,1,1);
	}
	if(theApp.graf_type == 1)
	{
		theApp.CPlot1.Draw(dc,1,1);
		int buf = SetMyMode(dc, CRect(1,1,2,2), CRectD(1,10,5,10));
		dc.SetMapMode(buf); 
	}
	if(theApp.graf_type == 2)
	{
		theApp.CPlot2.Draw(dc,1,1);
		int buf = SetMyMode(dc, CRect(1,1,2,2), CRectD(1,10,5,10));
		dc.SetMapMode(buf);
	}
	if(theApp.graf_type == 3)
	{
		int buf = SetMyMode(dc, CRect(1,1,2,2), CRectD(100,180,50,150));
		dc.SetMapMode(buf);
		theApp.CPlot3.Draw1(dc,1,1);

	}
	if(theApp.graf_type == 4)
	{
		
		int buf = SetMyMode(dc, CRect(1,1,2,2), CRectD(1,10,5,10));
		dc.SetMapMode(buf);
		theApp.CPlot4.Draw(dc,1,1);
	}
	// TODO: Add your message handler code here
	
	// Do not call CWnd::OnPaint() for painting messages
}

