
#include "afxwin.h"						// MFC Основные и стандартные компоненты
#include "afxext.h"						// MFC Расширения
#include "resource.h"					// Идентификаторы ресурсов
#include "CMatrix.h"
#include "LibGraph.h"
#include "LibPyramid.h"
#include "math.h"

#define IDR_MENU1		101

class CMainWnd : public CFrameWnd
{
public:
	CMainWnd();	
	int OnCreate(LPCREATESTRUCT lpCreateStruct);        
	void OnPaint();
	void MenuExit();
	~CMainWnd();
	CPyramid PIR;	
	CRect WinRect;	
	CMatrix PView;	
	int Index;
	afx_msg void OnPyramidPyramid1();
	afx_msg void OnPyramidPyramid2();
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	afx_msg void OnSize(UINT nType, int cx, int cy);
private:    
	CMenu m_wndMenu;
	DECLARE_MESSAGE_MAP();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd) 
	ON_WM_PAINT()
	ON_WM_CREATE()	
	ON_COMMAND(ID_PYRAMID_PIRAMID1,&CMainWnd::OnPyramidPyramid1)
	ON_WM_KEYDOWN()
	ON_WM_SIZE()
	ON_COMMAND(ID_PYRAMID_PIRAMID2,&CMainWnd::OnPyramidPyramid2)
	ON_COMMAND(ID_FILE_EXIT,MenuExit)
END_MESSAGE_MAP()

void CMainWnd::OnPaint()
{
	CPaintDC dc(this);   // Получить контекст устройства
	if(Index==1)PIR.Draw(dc,PView,WinRect);
	if(Index==2)PIR.Draw1(dc,PView,WinRect);
}

void CMainWnd::OnPyramidPyramid1()	
{
	PView(0)= 10;	PView(1)=315;	PView(2)=45;
	Index=1;
	Invalidate();
}

void CMainWnd::OnPyramidPyramid2()
{
	PView(0)= 10;	PView(1)=315;	PView(2)=45;
	Index=2;
	Invalidate();
}

void CMainWnd::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	if((Index==1)||(Index==2))
  {
	switch(nChar)
	{
	  case VK_UP:
		{
		  double d=PView(2)-5;
		  if(d>=0)PView(2)=d;
		  break;
		}
	  case VK_DOWN:
		{
		  double d=PView(2)+5;
		  if(d<=180)PView(2)=d;
		  break;
		}
	  case VK_LEFT:
		{
		  double d=PView(1)-10;
		  if(d>=-180)PView(1)=d;
		  else PView(1)=d+360;
		  break;
		}
	  case VK_RIGHT:
		{
		  double d=PView(1)+10;
		  if(d<=180)PView(1)=d;
		  else PView(1)=d-360;
		  break;
		}
	}
	Invalidate();
  }
}

void CMainWnd::OnSize(UINT nType, int cx, int cy)
{
	WinRect.SetRect(100,100,cx - 100, cy - 50);
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
	 PView.RedimMatrix(3);
	 return 0;
}

CMainWnd::CMainWnd()
{
	Create(NULL,"lab7",(WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX) &~(WS_THICKFRAME),rectDefault,NULL,NULL);	
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

