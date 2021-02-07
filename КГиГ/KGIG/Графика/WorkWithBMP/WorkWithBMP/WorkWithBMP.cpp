
// WorkWithBMP.cpp : Определяет поведение классов для приложения.
//

#include "stdafx.h"
#include "afxwinappex.h"
#include "WorkWithBMP.h"
#include "MainFrm.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CWorkWithBMPApp

BEGIN_MESSAGE_MAP(CWorkWithBMPApp, CWinAppEx)
	ON_COMMAND(ID_APP_ABOUT, &CWorkWithBMPApp::OnAppAbout)
END_MESSAGE_MAP()


// создание CWorkWithBMPApp

CWorkWithBMPApp::CWorkWithBMPApp()
{

	m_bHiColorIcons = TRUE;

	// TODO: добавьте код создания,
	// Размещает весь важный код инициализации в InitInstance
}

// Единственный объект CWorkWithBMPApp

CWorkWithBMPApp theApp;


// инициализация CWorkWithBMPApp

BOOL CWorkWithBMPApp::InitInstance()
{
	CWinAppEx::InitInstance();

	// Стандартная инициализация
	// Если эти возможности не используются и необходимо уменьшить размер
	// конечного исполняемого файла, необходимо удалить из следующего
	// конкретные процедуры инициализации, которые не требуются
	// Измените раздел реестра, в котором хранятся параметры
	// TODO: следует изменить эту строку на что-нибудь подходящее,
	// например на название организации
	SetRegistryKey(_T("Локальные приложения, созданные с помощью мастера приложений"));

	InitContextMenuManager();

	InitKeyboardManager();

	InitTooltipManager();
	CMFCToolTipInfo ttParams;
	ttParams.m_bVislManagerTheme = TRUE;
	theApp.GetTooltipManager()->SetTooltipParams(AFX_TOOLTIP_TYPE_ALL,
		RUNTIME_CLASS(CMFCToolTipCtrl), &ttParams);

	// Чтобы создать главное окно, этот код создает новый объект окна
	// рамки, а затем задает его как объект основного окна приложения
	CMainFrame* pFrame = new CMainFrame;
	if (!pFrame)
		return FALSE;
	m_pMainWnd = pFrame;
	// создайте и загрузите рамку с его ресурсами
	pFrame->LoadFrame(IDR_MAINFRAME,
		WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, NULL,
		NULL);






	// Одно и только одно окно было инициализировано, поэтому отобразите и обновите его
	pFrame->ShowWindow(SW_SHOW);
	pFrame->UpdateWindow();
	// вызов DragAcceptFiles только при наличии суффикса
	//  В приложении SDI это должно произойти после ProcessShellCommand
	return TRUE;
}


// обработчики сообщений CWorkWithBMPApp




// Диалоговое окно CAboutDlg используется для описания сведений о приложении

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Данные диалогового окна
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // поддержка DDX/DDV

// Реализация
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()

// Команда приложения для запуска диалога
void CWorkWithBMPApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

// CWorkWithBMPApp настройка методов загрузки и сохранения

void CWorkWithBMPApp::PreLoadState()
{
}

void CWorkWithBMPApp::LoadCustomState()
{
}

void CWorkWithBMPApp::SaveCustomState()
{
}

// обработчики сообщений CWorkWithBMPApp



