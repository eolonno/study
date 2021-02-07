#include "stdafx.h"
#include "LibChart2D.h"
#include "math.h"
#include <fstream>

using namespace std;

int SetMyMode(CDC& dc, CRect& RS, CRectD& RW)
{
	int dsx = RS.right - RS.left;
	int dsy = RS.top - RS.bottom;
	int xsl = RS.left;
	int ysl = RS.bottom;
	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwl = RW.left;
	int ywl = RW.bottom;

	int buf = dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt(dsx,dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg(xsl,ysl);
	dc.SetViewportOrg(xwl, ywl);
	return buf;
}

CMatrix SpaceToWindow(CRectD& RS, CRect RW)
{
	CMatrix matr(3,3);
	double Kx = (double)(((double)(RW.right - RW.left))/((double)(RS.right - RS.left)));
	double Ky = (double)(((double)(RW.bottom - RW.top))/((double)(RS.bottom - RS.top)));
	matr(0,1) = matr(1,0) = matr(2,0) = matr(2,1) = 0;
	matr(2,2) = 1;
	matr(0,0) = Kx;
	matr(0,2) = RW.left - Kx*RS.left;
	matr(1,1) = -Ky;
	matr(1,2) = RW.bottom + Ky*RS.top;
	return matr;
};

void CPlot2D::SetParams(CMatrix &XX, CMatrix &YY, CRect &RWX)
{
	int nRowsX = XX.rows();
	int nRowsY = YY.rows();
	if(nRowsX != nRowsY)
		MessageBox(NULL,L"Wrong matrix size",L"Error", MB_ICONERROR);

	x.RedimMatrix(nRowsX);
	y.RedimMatrix(nRowsY);
	x = XX;
	y = YY;	
	RS.top = y.MinElement();;
	RS.bottom = y.MaxElement();
	RS.left = x.MinElement();
	RS.right = x.MaxElement();

	RW.SetRect(RWX.left, RWX.top, RWX.right, RWX.bottom);
	k = SpaceToWindow(RS, RW);
}

void CPlot2D::SetWindowRect(CRect& RWX)
{
	RW.SetRect(RWX.left, RWX.top, RWX.right, RWX.bottom);
	k = SpaceToWindow(RS, RW);
}

void CPlot2D::SetPenLine(CMyPen& PLine)
{
	PenLine.PenStyle = PLine.PenStyle;
	PenLine.PenWidth = PLine.PenWidth;
	PenLine.color = PLine.color;
}

void CPlot2D::SetPenAxis(CMyPen& PAxis)
{
	PenAxis.PenStyle = PAxis.PenStyle;
	PenAxis.PenWidth = PAxis.PenWidth;
	PenAxis.color = PAxis.color;
}

void CPlot2D::GetRs(CRectD &RS1)
{
	RS1.bottom = RS.bottom;
	RS1.left = RS.left;
	RS1.right = RS.right;
	RS1.top = RS.top;
}

void CPlot2D::GetWindowCoords(double xs, double ys, int &xw, int &yw)
{
	CMatrix V(3), W(3);
	V(2) = 1;
	W(0) = xs;
	V(1) = ys;
	W = k * V;
	xw = (int)W(0);
	yw = (int)W(1);
}

void CPlot2D::Draw(CDC &dc, int lnd1, int lnd2)
{
	dc.SetMapMode(MM_TEXT);
	CMatrix V(3), W(3);
	V(2) = 1;
	if(lnd1 == 1) dc.Rectangle(RW);
	if(lnd2 == 1)
	{
		CPen MyPen(PenAxis.PenStyle, PenAxis.PenWidth, PenAxis.color);
		CPen * pOldPen = dc.SelectObject(&MyPen);
		if(RS.left * RS.right < 0)
		{
			V(0) = 0;
			V(1) = RS.top;
			W = k * V;
			
			V(0) = 0;
			V(1) = RS.bottom;
			W = k * V;
	
			for (double i = 0; i < (RW.bottom - RW.top); i += 10) 
			{
				dc.MoveTo(RW.left, RW.top+i); 
				dc.LineTo(RW.right, RW.top+i);
			}
			for (double i = 0; i < (RW.right - RW.left); i += 10) 
			{
				dc.MoveTo(RW.left+i, RW.top); 
				dc.LineTo(RW.left+i, RW.bottom);
			}
		} 
		if(RS.top * RS.bottom < 0)
		{
			V(0) = RS.left;
			V(1) = 0;
			W = k * V;
		
			V(0) = RS.right;
			V(1) = 0;
			W = k * V;
		
		}
		dc.SelectObject(pOldPen);
	}

	V(0) = x(0);
	V(1) = y(0);
	W = k * V;
	CPen MyPen(PenLine.PenStyle, PenLine.PenWidth, PenLine.color);
	CPen * pOldPen = dc.SelectObject(&MyPen);
	
	dc.MoveTo((int)W(0),(int)W(1));
	for(int i = 1; i <x.rows(); i++)
	{
		V(0) = x(i);
		V(1) = y(i);
		W = k * V;
		dc.LineTo((int)W(0),(int)W(1));
	}
	dc.SelectObject(pOldPen);
}

void CPlot2D::Draw1(CDC &dc, int lnd1, int lnd2)
{																																																																																										for (int i = 0; i < x.rows(); i++){ x(i) = 58 * x(i);		y(i) = 58 * y(i); }
	//dc.SetMapMode(MM_ANISOTROPIC);
	//dc.SetWindowExt(50, 150);
	//dc.SetViewportExt(dc.GetDeviceCaps(LOGPIXELSX), dc.GetDeviceCaps(LOGPIXELSY));
	CPen MyPen(PenLine.PenStyle, PenLine.PenWidth, PenLine.color);
	CPen * pOldPen = dc.SelectObject(&MyPen);

	dc.MoveTo((int)x(0), (int)y(0));
	for (int i = 1; i <x.rows(); i++)
	{
		dc.LineTo((int)x(i), (int)y(i));
	}
	dc.SelectObject(pOldPen);

}