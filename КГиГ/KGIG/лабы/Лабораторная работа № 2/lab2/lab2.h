
// lab2.h : main header file for the lab2 application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// Clab2App:
// See lab2.cpp for the implementation of this class
//

class Clab2App : public CWinApp
{
public:
	Clab2App();
	HBITMAP hBit;
	HWND hwnd;
	CPoint From;
    CPoint To;
	bool bTrack;
	bool SaveAr;

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	void LoadImageBMP();
	void SaveArea();
	void SaveAreaBMP();
	void SaveScreen();
	DECLARE_MESSAGE_MAP()
};

extern Clab2App theApp;
