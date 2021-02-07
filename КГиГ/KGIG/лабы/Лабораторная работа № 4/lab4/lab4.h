
// lab4.h : main header file for the lab4 application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols
#include "LibChart2D.h"

// Clab4App:
// See lab4.cpp for the implementation of this class
//

class Clab4App : public CWinApp
{
public:
	Clab4App();
	CPlot2D CPlot1;
	CPlot2D CPlot2;
	CPlot2D CPlot3;
	CPlot2D CPlot4;
	bool flag;
	int graf_type;
// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	
	
// Implementation

public:
	afx_msg void OnAppAbout();
	afx_msg void OnGraph();
	afx_msg void OnGraph1();
	afx_msg void OnGraph2();
	afx_msg void OnGraph3();
	afx_msg void OnGraph4();
	DECLARE_MESSAGE_MAP()
};

extern Clab4App theApp;
