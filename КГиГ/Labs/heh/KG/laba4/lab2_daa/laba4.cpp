
#include "afxwin.h"						// MFC Основные и стандартные компоненты
#include "afxext.h"						// MFC Расширения
#include "resource.h"					// Идентификаторы ресурсов
#include "CMATRIX.H"
#include "LibChart2D.h"
#include "math.h"
#define IDR_MENU1		101

class CMainWnd : public CFrameWnd
{
public:
	CMainWnd();	
	CSunSystem SunSystem;
	int dT_Timer;
	CRect RW;       
	CRectD RS;
	bool Start;
	afx_msg void OnPaint();
	afx_msg void OnLButtonDown(UINT,CPoint);
	afx_msg void OnRButtonDown(UINT,CPoint);
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	int OnCreate(LPCREATESTRUCT lpCreateStruct);        
	void OnPlanetsModel();
	void MenuExit();
	~CMainWnd();		
private:    
	CMenu m_wndMenu;
	DECLARE_MESSAGE_MAP();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd) 
	ON_WM_PAINT()
	ON_WM_TIMER()
	ON_WM_LBUTTONDOWN()
	ON_WM_RBUTTONDOWN()
	ON_WM_CREATE()	
	ON_COMMAND(ID_FILE_OPEN,OnPlanetsModel)
	ON_COMMAND(ID_FILE_EXIT,MenuExit)
END_MESSAGE_MAP()

void CMainWnd::OnPaint()
{
	CPaintDC dc(this);   // Получить контекст устройства
	if (Start == true)
	{
		SunSystem.GetRS(RS);
		RW=SunSystem.GetRW();
		SetMyMode(dc,RW,RS);
		SunSystem.Draw(dc);		
		dc.SetMapMode(MM_TEXT);
	}
}

void CMainWnd::OnPlanetsModel()
{
	SunSystem.SetDT(0);	
	SunSystem.SetNewCoords();
	SunSystem.SetDT(0.1);
	dT_Timer=100;
	Start = true;
	Invalidate();
}

void CMainWnd::OnTimer(UINT_PTR nIDEvent)
{
	SunSystem.SetNewCoords();
	Invalidate();
}

void CMainWnd::OnLButtonDown(UINT flags,CPoint point)
{	
	SetTimer(1,dT_Timer,NULL);
}

void CMainWnd::OnRButtonDown(UINT flags,CPoint point)
{
	KillTimer(1); 	
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
	 Start = false;
	 return 0;
}

CMainWnd::CMainWnd()
{
	Create(NULL,"Laba4",(WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU/* | WS_MINIMIZEBOX | WS_MAXIMIZEBOX*/) &~(WS_THICKFRAME),rectDefault,NULL,NULL);	
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

