
// lab4.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "afxwinappex.h"
#include "afxdialogex.h"
#include "lab4.h"
#include "MainFrm.h"
#include "CMATRIX.H"
#include "LibChart2D.h"
#include "math.h"
#include <iostream>
#include <fstream>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


using namespace std;

// Clab4App

BEGIN_MESSAGE_MAP(Clab4App, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, &Clab4App::OnAppAbout)
	ON_COMMAND(ID_FILE_GRAPHICS, &Clab4App::OnGraph)
	ON_COMMAND(ID_32772, &Clab4App::OnGraph1)
	ON_COMMAND(ID_32773, &Clab4App::OnGraph2)
	ON_COMMAND(ID_32774, &Clab4App::OnGraph3)
	ON_COMMAND(ID_32775, &Clab4App::OnGraph4)
END_MESSAGE_MAP()

void Clab4App::OnGraph1()
{
	CMyPen MP;
	MP.Set(PS_SOLID, 1, RGB(255,0,0));
	CMyPen MP_LINE;
	MP_LINE.Set(PS_SOLID, 1, RGB(0,0,0));
	CPlot1.SetPenLine(MP);
	CPlot1.SetPenAxis(MP_LINE);



	CRect Rect(50,50,450,450);

	ifstream F1;
	F1.open("F1.txt");
	CMatrix M1X(F1);
	CMatrix M1Y(F1);
	F1.close();

	CPlot1.SetParams(M1X, M1Y, Rect);		
	Rect.SetRect(550, 300, 650, 750);

	graf_type = 1;
	theApp.m_pMainWnd->Invalidate();
}

void Clab4App::OnGraph2()
{
	CMyPen MP;
	MP.Set(PS_SOLID, 1, RGB(0,255,0));
	CMyPen MP_LINE;
	MP_LINE.Set(PS_SOLID, 1, RGB(0,0,0));
	CPlot2.SetPenLine(MP);
	CPlot2.SetPenAxis(MP_LINE);
	CRect Rect(50,50,450,450);

	ifstream F2;
	F2.open("F2.txt");
	CMatrix M2X(F2);
	CMatrix M2Y(F2);
	F2.close();

	CPlot2.SetParams(M2X, M2Y, Rect);
	Rect.SetRect( 100, 6,  160, 28);

	graf_type = 2;
	theApp.m_pMainWnd->Invalidate();
}

void Clab4App::OnGraph3()
{
	CMyPen MP;
	MP.Set(PS_DASHDOT, 3, RGB(255, 0, 0));
	CMyPen MP_LINE;
	MP_LINE.Set(PS_SOLID, 1, RGB(0,0,0));
	CPlot3.SetPenLine(MP);
	CPlot3.SetPenAxis(MP_LINE);
	CRect Rect(0,-90,192,100);

	ifstream F3;
	F3.open("F3.txt");
	CMatrix M3X(F3);
	CMatrix M3Y(F3);
	F3.close();
	CPlot3.SetParams(M3X, M3Y, Rect);		
	Rect.SetRect( 50, 34, 160, 62);

	graf_type = 3;
	theApp.m_pMainWnd->Invalidate();
}

void Clab4App::OnGraph4()
{
	CMyPen MP;
	MP.Set(PS_SOLID, 2, RGB(255,0,0));
	CMyPen MP_LINE;
	MP_LINE.Set(PS_SOLID, 1, RGB(0,0,0));
	CPlot4.SetPenLine(MP);
	CPlot4.SetPenAxis(MP_LINE);
	CRect Rect(50,50,450,450);

	ifstream F4;
	F4.open("F4.txt");
	CMatrix M4X(F4);
	CMatrix M4Y(F4);
	F4.close();

	Rect.SetRect( 100, 34, 560, 362);
	CPlot4.SetParams(M4X, M4Y, Rect);

	graf_type = 4;
	theApp.m_pMainWnd->Invalidate();
}

// Clab4App construction
void Clab4App::OnGraph()
{
	CMyPen MP1;
	CMyPen MP2;
	CMyPen MP3;
	CMyPen MP4;

	MP1.Set(PS_SOLID, 1, RGB(0,0,0));
	MP2.Set(PS_SOLID, 1, RGB(0,0,0));
	MP3.Set(PS_SOLID, 1, RGB(0,0,0));
	MP4.Set(PS_SOLID, 1, RGB(0,0,0));


	CMyPen MP1_LINE;
	CMyPen MP2_LINE;
	CMyPen MP3_LINE;
	CMyPen MP4_LINE;

	MP1_LINE.Set(PS_SOLID, 2, RGB(250,0,0));
	CPlot1.SetPenLine(MP1_LINE);
	MP2_LINE.Set(PS_SOLID, 3, RGB(250,0,0));
	CPlot2.SetPenLine(MP2_LINE);
	MP3_LINE.Set(PS_SOLID, 2, RGB(250,0,0));
	CPlot3.SetPenLine(MP3_LINE);
	MP4_LINE.Set(PS_SOLID, 3, RGB(250,0,0));
	CPlot4.SetPenLine(MP4_LINE);

	CPlot1.SetPenAxis(MP1);
	CPlot2.SetPenAxis(MP2);
	CPlot3.SetPenAxis(MP3);
	CPlot4.SetPenAxis(MP4);

	CRect Rect(50,50,350,250);


	ifstream F1;
	F1.open("F1.txt");
	CMatrix M1X(F1);
	CMatrix M1Y(F1);
	F1.close();

	ifstream F2;
	F2.open("F2.txt");
	CMatrix M2X(F2);
	CMatrix M2Y(F2);
	F2.close();

	ifstream F3;
	F3.open("F3.txt");
	CMatrix M3X(F3);
	CMatrix M3Y(F3);
	F3.close();

	ifstream F4;
	F4.open("F4.txt");
	CMatrix M4X(F4);
	CMatrix M4Y(F4);
	F4.close();

	CPlot1.SetParams(M1X, M1Y, Rect);		
	Rect.SetRect(50, 350, 350, 550);		
	CPlot2.SetParams(M2X, M2Y, Rect);
	Rect.SetRect( 450, 50,  760, 250);
	CPlot3.SetParams(M3X, M3Y, Rect);		
	Rect.SetRect( 450, 350, 760, 550);
	CPlot4.SetParams(M4X, M4Y, Rect);
	graf_type = 5;
	theApp.m_pMainWnd->Invalidate();

}
Clab4App::Clab4App()
{
	// TODO: replace application ID string below with unique ID string; recommended
	// format for string is CompanyName.ProductName.SubProduct.VersionInformation
	SetAppID(_T("lab4.AppID.NoVersion"));

	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

// The one and only Clab4App object

Clab4App theApp;


// Clab4App initialization

BOOL Clab4App::InitInstance()
{
	CWinApp::InitInstance();
	flag = false;
	EnableTaskbarInteraction(FALSE);

	// AfxInitRichEdit2() is required to use RichEdit control	
	// AfxInitRichEdit2();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	// of your final executable, you should remove from the following
	// the specific initialization routines you do not need
	// Change the registry key under which our settings are stored
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));


	// To create the main window, this code creates a new frame window
	// object and then sets it as the application's main window object
	CMainFrame* pFrame = new CMainFrame;
	if (!pFrame)
		return FALSE;
	m_pMainWnd = pFrame;
	// create and load the frame with its resources
	pFrame->LoadFrame(IDR_MAINFRAME,
		WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, NULL,
		NULL);






	// The one and only window has been initialized, so show and update it
	pFrame->ShowWindow(SW_SHOW);
	pFrame->UpdateWindow();
	// call DragAcceptFiles only if there's a suffix
	//  In an SDI app, this should occur after ProcessShellCommand
	return TRUE;
}

int Clab4App::ExitInstance()
{
	//TODO: handle additional resources you may have added
	return CWinApp::ExitInstance();
}

// Clab4App message handlers


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()

// App command to run the dialog
void Clab4App::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

// Clab4App message handlers



