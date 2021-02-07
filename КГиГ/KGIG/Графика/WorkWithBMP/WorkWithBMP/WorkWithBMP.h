
// WorkWithBMP.h : главный файл заголовка для приложения WorkWithBMP
//
#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"       // основные символы


// CWorkWithBMPApp:
// О реализации данного класса см. WorkWithBMP.cpp
//

class CWorkWithBMPApp : public CWinAppEx
{
public:
	CWorkWithBMPApp();


// Переопределение
public:
	virtual BOOL InitInstance();

// Реализация

public:
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CWorkWithBMPApp theApp;
