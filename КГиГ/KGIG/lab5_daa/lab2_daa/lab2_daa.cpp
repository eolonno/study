
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
	int OnCreate(LPCREATESTRUCT lpCreateStruct);        
	void OnGraph();
	void MenuExit();
	~CMainWnd();		
	afx_msg void OnPaint();
	CPlot2D CPlot1;
	CPlot2D CPlot2;
	CPlot2D CPlot3;
	CPlot2D CPlot4;
	bool flag;
private:    
	CMenu m_wndMenu;

	DECLARE_MESSAGE_MAP();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd) 
 ON_WM_PAINT()
 ON_WM_CREATE()					
 ON_COMMAND(ID_FILE_OPEN, &CMainWnd::OnGraph)
 ON_COMMAND(ID_FILE_EXIT,MenuExit)
END_MESSAGE_MAP()

void CMainWnd::OnPaint()
{
	CPaintDC dc(this);   // Получить контекст устройства
		if(flag==true)
	{
		CPlot1.Draw(dc,1,1);
		CPlot2.Draw(dc,1,1);	//l t r b
		int buf = SetMyMode(dc, CRect(1,1,2,2), CRectD(1,10,5,10));
													//   t b l r
		CPlot3.Draw1(dc,1,1);
		CPlot4.Draw1(dc,1,1);
		dc.SetMapMode(buf);
	}
}

void CMainWnd::OnGraph()
{
	CMyPen MP;
	MP.Set(PS_SOLID, 0, RGB(10,10,10));
	CPlot1.SetPenLine(MP);
	CPlot2.SetPenLine(MP);
	CPlot3.SetPenLine(MP);
	CPlot4.SetPenLine(MP);
	MP.Set(PS_SOLID, 1, RGB(0,110,200));
	CPlot1.SetPenAxis(MP);
	CPlot2.SetPenAxis(MP);
	CPlot3.SetPenAxis(MP);
	CPlot4.SetPenAxis(MP);
	CRect Rect(50,50,350,250);
	CMatrix mX1(21), mY1(21),
			mX2(21), mY2(21);
	for(int x = -10, i = 0; x < 11; x++, i++)
	{
		mX1(i) = mX2(i)= x;
		mY1(i) = exp((double)x);
		mY2(i) = x*x-50;
	}
	CPlot1.SetParams(mX1, mY1, Rect);		
	Rect.SetRect(50, 300, 350, 550);		
	CPlot2.SetParams(mX2, mY2, Rect);
	Rect.SetRect( 100, 6,  160, 28);
	CPlot3.SetParams(mX1, mY1, Rect);		
	Rect.SetRect( 100, 34, 160, 62);
	CPlot4.SetParams(mX2, mY2, Rect);
	flag = true;
	Invalidate();

}

void CMainWnd::MenuExit()  
{	
	DestroyWindow(); // Уничтожить окно   
}

int CMainWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
 {
  if (CFrameWnd::OnCreate(lpCreateStruct) == -1)  return -1;
  m_wndMenu.LoadMenu(IDR_MENU1);
  SetMenu(&m_wndMenu);
  flag = false;
  return 0;
}

CMainWnd::CMainWnd()
{
 Create(NULL,"lab5",WS_OVERLAPPEDWINDOW,rectDefault,NULL,NULL);	
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

