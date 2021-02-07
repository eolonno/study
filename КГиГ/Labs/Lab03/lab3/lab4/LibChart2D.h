#pragma once
#include "CMATRIX.H"

struct CMyPen
{
	int PenStyle;
	int PenWidth;
	COLORREF color;
	CMyPen()
	{
		PenStyle = PS_SOLID;
		PenWidth = 1;
		color = RGB(0,0,0);
	}

	void Set(int PS, int PW, COLORREF col)
	{
		PenStyle = PS;
		PenWidth = PW;
		color = col;
	}
};

class CRectD
{		
public:
	double top,bottom,left,right;
	CRectD()
	{
		top = bottom = left = right = 0;
	}
	CRectD(double t, double b, double l, double r)
	{
		top = t;
		bottom = b;
		left = l;
		right = r;
	};
};

int SetMyMode(CDC& dc, CRect& RS, CRectD& RW);
CMatrix SpaceToWindow(CRectD& RW, CRect RS);

class CPlot2D
{
	CMatrix x,y,k;
	CRect RW;
	CRectD RS;

	CMyPen PenLine;
	CMyPen PenAxis;
public:
	CPlot2D()
	{
		//x.RedimMatrix(3,3);
		//y.RedimMatrix(3,3);
		k.RedimMatrix(3,3);
	};
	void SetParams(CMatrix& XX, CMatrix& YY, CRect& RWX);
	void SetWindowRect(CRect& RWX);
	void GetWindowCoords(double xs, double ys, int &xw, int &yw);
	void SetPenLine(CMyPen & PLine);
	void SetPenAxis(CMyPen& PAxis);
	void Draw(CDC& dc, int lnd1,int lnd2);
	void Draw1(CDC& dc, int lnd1,int lnd2);
	void GetRs(CRectD & RS1);
	//void DrawBezier();
};
