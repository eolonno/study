
// lab6.h : main header file for the lab6 application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols
#include "LibChart2D.h"


// Clab6App:
// See lab6.cpp for the implementation of this class
//

class Clab6App : public CWinApp
{
public:
	Clab6App();
	CSunSystem SunSystem;
	int dT_Timer;
	CPoint From;
    CPoint To;
	bool Start;

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	afx_msg void OnPlanetsModel();
	DECLARE_MESSAGE_MAP()
};

extern Clab6App theApp;
