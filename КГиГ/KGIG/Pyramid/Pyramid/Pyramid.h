// Pyramid.h : main header file for the Pyramid application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CPyramidApp:
// See Pyramid.cpp for the implementation of this class
//

class CPyramidApp : public CWinApp
{
public:
	CPyramidApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CPyramidApp theApp;