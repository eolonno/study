
// Lab01(2).h : главный файл заголовка для приложения Lab01(2)
//
#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"       // основные символы


// CLab012App:
// О реализации данного класса см. Lab01(2).cpp
//

class CLab012App : public CWinApp
{
public:
	CLab012App();


// Переопределение
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Реализация

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CLab012App theApp;
