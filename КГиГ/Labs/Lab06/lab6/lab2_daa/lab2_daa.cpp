
#include "afxwin.h"						// MFC Основные и стандартные компоненты
#include "afxext.h"						// MFC Расширения
#include "resource.h"					// Идентификаторы ресурсов
#include "CMatrix.h"
#include "LibGraph.h"
#include "LibSurface.h"
#include "math.h"

class CMainWnd : public CFrameWnd
{
public:
	CMainWnd();	
	int OnCreate(LPCREATESTRUCT lpCreateStruct);        
	void OnPaint();
	void MenuExit();
	~CMainWnd();
	double r,fi,q;
	CRect WRect;
	int Index;
	CPlot3D  Graph1,Graph2,Graph3;
	afx_msg void OnCPlot3DDef();
	afx_msg void OnCplot3dFunc1();
	afx_msg void OnCplot3dFunc2();
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
private:    
	CMenu m_wndMenu;
	DECLARE_MESSAGE_MAP();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd) 
	ON_WM_PAINT()
	ON_WM_CREATE()	
	ON_COMMAND(ID_FILE_DEFOU, &CMainWnd::OnCPlot3DDef)
	ON_COMMAND(ID_FILE_FUN1, &CMainWnd::OnCplot3dFunc1)
	ON_COMMAND(ID_FILE_FUN2, &CMainWnd::OnCplot3dFunc2)
	ON_WM_KEYDOWN()
	ON_COMMAND(ID_FILE_EXIT,MenuExit)
END_MESSAGE_MAP()

void CMainWnd::OnPaint()//////////
{
	CPaintDC dc(this);   // Получить контекст устройства
	if(Index == 1)Graph1.Draw(dc);
	if(Index == 2)Graph2.Draw(dc);
	if(Index == 3)Graph3.Draw(dc);	
}

void CMainWnd::OnCPlot3DDef()	//////////
{
	double dx = 0.25, dy = 0.25;	
	r = 1, fi = 30, q = 45;
	CRectD SpaceRect(-5,5,5,-5);//задаем область
	CRect  WinRect;
	GetClientRect(WinRect);
	WinRect.SetRect(WinRect.left + 50, WinRect.top + 50, WinRect.right - 50, WinRect.bottom - 50);
	Graph1.SetFunction(Function1,SpaceRect,dx,dy);	
	Graph1.SetViewPoint(r,fi,q);	
	Graph1.SetWinRect(WinRect);
	Index = 1;
	Invalidate();
}

void CMainWnd::OnCplot3dFunc1()/////////
{
	double dx = 0.25, dy = 0.25;	
	r = 1, fi = 30, q = 45;
	CRectD SpaceRect(-5,5,5,-5);
	CRect  WinRect;
	GetClientRect(WinRect);
	WinRect.SetRect(WinRect.left + 50, WinRect.top + 50, WinRect.right - 50, WinRect.bottom - 50);
	Graph2.SetFunction(Function2,SpaceRect,dx,dy); 
	Graph2.SetViewPoint(r,fi,q);
	Graph2.SetWinRect(WinRect);
	Index = 2;
	Invalidate();
}

void CMainWnd::OnCplot3dFunc2()////////
{	
	double dx = 0.25, dy = 0.25;	
	r = 1, fi = 30, q = 45;
	CRectD SpaceRect(-5,5,5,-5);
	CRect  WinRect;
	GetClientRect(WinRect);
	WinRect.SetRect(WinRect.left + 50, WinRect.top + 50, WinRect.right - 50, WinRect.bottom - 50);


	Graph3.SetFunction(Function3,SpaceRect,dx,dy);
	Graph3.SetViewPoint(r,fi,q);
	Graph3.SetWinRect(WinRect);
	Index = 3;
	Invalidate();
}

void CMainWnd::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
CMatrix P(3);
	 switch ( Index )
      {//
         case 1:
					{
						P = Graph1.GetViewPoint();
						break;
					}
			   case 2:
					{
						P = Graph2.GetViewPoint();
						break;
					}        
         case 3:
					{
						P = Graph3.GetViewPoint();
						break;
				 }			           
			}//

r = P(0), fi = P(1), q = P(2);
double delta_fi = 5, delta_q = 5;
		switch(nChar)
		{
			case VK_UP:
			{
				double qx = q-delta_q;
				if(qx>= 0)q = qx;
				break;
			}
			case VK_DOWN:
			{
				double qx = q+delta_q;
				if(qx<= 180)q = qx;
				break;
			}
			case VK_LEFT:
			{
				double fix = fi-delta_fi;
				if(fix>= 0)fi = fix;
				break;
			}
			case VK_RIGHT:
			{
				double fix = fi+delta_fi;
				if(fix<= 360)fi = fix;
				break;
			}
		}

		switch ( Index )
      {
         case 1:
					{
						Graph1.SetViewPoint(r,fi,q);
						break;
					}
			 
         case 2:
					{
						Graph2.SetViewPoint(r,fi,q);
						break;
					}
            
         case 3:
					{
						Graph3.SetViewPoint(r,fi,q);
						break;
					}			           
      }
Invalidate();
}

void CMainWnd::MenuExit()  
{	
	DestroyWindow(); 
}

int CMainWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
 {
	 if (CFrameWnd::OnCreate(lpCreateStruct) == -1)  return -1;
	 m_wndMenu.LoadMenu(IDR_MENU1);
	 SetMenu(&m_wndMenu);
	 Index=0;
	 return 0;
}

CMainWnd::CMainWnd()
{
	Create(NULL,"laba6",(WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX) &~(WS_THICKFRAME),rectDefault,NULL,NULL);	
}

CMainWnd::~CMainWnd()
{
}

class CMyApp : public CWinApp
{
public:
	CMyApp();				
	virtual BOOL InitInstance();	
};

CMyApp::CMyApp()
{}

BOOL CMyApp::InitInstance()		
{ 
	m_pMainWnd=new CMainWnd();	
	ASSERT(m_pMainWnd);		
	m_pMainWnd->ShowWindow(SW_SHOW);
	m_pMainWnd->UpdateWindow();	
	return TRUE;				
};

CMyApp theApp;	

