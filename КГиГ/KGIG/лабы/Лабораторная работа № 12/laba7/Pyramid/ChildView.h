// ChildView.h : interface of the CChildView class
//


#pragma once
// CChildView window

class CChildView : public CWnd
{
// Construction
public:
	CChildView();

// Attributes
public:
	CPyramid PIR;		// Пирамида
	CRect WinRect;	// Область в окне
	CMatrix PView;	// Точка наблюдения в сферической СК
	int Index;
	

// Operations
public:

// Overrides
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Implementation
public:
	virtual ~CChildView();

	// Generated message map functions
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnPyramidPyramid1();
public:
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
public:
	afx_msg void OnSize(UINT nType, int cx, int cy);
public:
	afx_msg void OnPyramidPyramid2();
public:
	afx_msg void OnPyramidPyramid3();
	afx_msg void OnPyramidPyramid4();
};

