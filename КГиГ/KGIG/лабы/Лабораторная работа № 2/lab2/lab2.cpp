
// lab2.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "afxwinappex.h"
#include "afxdialogex.h"
#include "lab2.h"
#include "MainFrm.h"
#include "GraphBitMap.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// Clab2App

BEGIN_MESSAGE_MAP(Clab2App, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, &Clab2App::OnAppAbout)
	ON_COMMAND(ID_FILE_LOADIMAGE, &Clab2App::LoadImageBMP)
	ON_COMMAND(ID_FILE_SAVEAREA, &Clab2App::SaveAreaBMP)
	ON_COMMAND(ID_FILE_SAVESCREEN, &Clab2App::SaveScreen)
END_MESSAGE_MAP()


// Clab2App construction
void Clab2App::LoadImageBMP()
{
	CFileDialog fileDialog((BOOL)TRUE);	//объект класса выбора файла
	fileDialog.m_ofn.lpstrFilter = (LPCTSTR)"images (.bmp)\0*.bmp\0\0";
	int result = fileDialog.DoModal();	//запустить диалоговое окно
	if (result==IDOK)	//если файл выбран
	{
		AfxMessageBox(fileDialog.GetPathName()); // показать полный путь
		CWnd *cwnd = AfxGetMainWnd();
		hwnd = cwnd->GetSafeHwnd();
		hBit = (HBITMAP)LoadImage(NULL, fileDialog.GetPathName().GetBuffer(), IMAGE_BITMAP,
			0, 0, LR_LOADFROMFILE |  LR_CREATEDIBSECTION);
		ShowBitMap(hwnd, hBit, From.x, From.y);
	}
}
void Clab2App::SaveArea()
{
	CFileDialog fileDialog((BOOL)FALSE, NULL, L"area.bmp");	//объект класса выбора файла
	fileDialog.m_ofn.lpstrFilter = (LPCTSTR)"images (.bmp)\0*.bmp\0\0";
	int result = fileDialog.DoModal();	//запустить диалоговое окно
	if (result==IDOK)	//если файл выбран
	{
		CWnd *cwnd = AfxGetMainWnd();
		HWND hwnd = cwnd->GetSafeHwnd();
		RECT r;
		r.left   = From.x;
		r.right  = To.x;
		r.top    = From.y;
		r.bottom = To.y;
		if(ClientRectToBmp(hwnd, (char*)fileDialog.GetPathName().GetBuffer(), r) == 0)
			AfxMessageBox(_T("Saved"));
		else
			AfxMessageBox(_T("Error"));
		
	}
}
void Clab2App::SaveScreen()
{
	CFileDialog fileDialog((BOOL)FALSE, NULL, L"screen.bmp");	//объект класса выбора файла
	fileDialog.m_ofn.lpstrFilter = (LPCTSTR)"images(.bmp)\0*.bmp\0\0";
	int result = fileDialog.DoModal();	//запустить диалоговое окно
	if (result==IDOK)	//если файл выбран
	{
		CWnd *cwnd = AfxGetMainWnd();
		HWND hwnd = cwnd->GetSafeHwnd();

		if(ClientToBmp(hwnd, (char*)fileDialog.GetPathName().GetBuffer()) == 0)
			AfxMessageBox(_T("Saved"));
		else
			AfxMessageBox(_T("Error"));
		
	}
}
void Clab2App::SaveAreaBMP()
{
	SaveAr = true;
}
Clab2App::Clab2App()
{
	From.x = From.y = 0;
	To.x = To.y = 0;
	SaveAr = false;
	// TODO: replace application ID string below with unique ID string; recommended
	// format for string is CompanyName.ProductName.SubProduct.VersionInformation
	SetAppID(_T("lab2.AppID.NoVersion"));

	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

// The one and only Clab2App object

Clab2App theApp;


// Clab2App initialization

BOOL Clab2App::InitInstance()
{
	CWinApp::InitInstance();


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

int Clab2App::ExitInstance()
{
	//TODO: handle additional resources you may have added
	return CWinApp::ExitInstance();
}

// Clab2App message handlers


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
void Clab2App::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

// Clab2App message handlers



