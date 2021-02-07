
// lab5.h : главный файл заголовка для приложения lab5
//
#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"       // основные символы


// Clab5App:
// О реализации данного класса см. lab5.cpp
//

class Clab5App : public CWinApp
{
public:
	Clab5App();


// Переопределение
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Реализация

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern Clab5App theApp;
