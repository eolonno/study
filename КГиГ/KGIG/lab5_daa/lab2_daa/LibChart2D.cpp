#include "stdafx.h"
#include "LibChart2D.h"
#include "math.h"
#include <fstream>

using namespace std;

int SetMyMode(CDC& dc, CRect& RS, CRectD& RW)
{
// Устанавливает режим отображения MM_ANISOTROPIC и его параметры
// dc - ссылка на класс CDC MFC
// RS -  область в мировых координатах 
// RW -	 Область в оконных координатах - int  
	int dsx = RS.right - RS.left;
	int dsy = RS.top - RS.bottom;
	int xsl = RS.left;
	int ysl = RS.bottom;
	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwl = RW.left;
	int ywl = RW.bottom;

	int buf = dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt(dsx,dsy); //устанавливает смещение физической системы координат
	dc.SetViewportExt(dwx, -dwy); // реальные ширина и высота реального окна
	dc.SetWindowOrg(xsl,ysl); //установить начало логической системы координат
	dc.SetViewportOrg(xwl, ywl); //устанавливает смещение физической системы координат
	return buf;
}
CMatrix SpaceToWindow(CRectD& RS, CRect RW) //область окна
{
// Возвращает матрицу пересчета координат из мировых в оконные
// rs - область в мировых координатах - double
// rw - область в оконных координатах - int
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

void CPlot2D::SetParams(CMatrix &XX, CMatrix &YY, CRect &RWX) // установить параметры
{
// XX - вектор данных по X 
// YY - вектор данных по Y 
// RWX - область в окне 
	int nRowsX = XX.rows();
	int nRowsY = YY.rows();
	if(nRowsX != nRowsY)
		MessageBox(NULL,"Wrong matrix size","Error", MB_ICONERROR);

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

void CPlot2D::SetPenLine(CMyPen& PLine) //параметры графика
{
	PenLine.PenStyle = PLine.PenStyle;
	PenLine.PenWidth = PLine.PenWidth;
	PenLine.color = PLine.color;
}

void CPlot2D::SetPenAxis(CMyPen& PAxis) //параметры оси
{
	PenAxis.PenStyle = PAxis.PenStyle;
	PenAxis.PenWidth = PAxis.PenWidth;
	PenAxis.color = PAxis.color;
}

void CPlot2D::GetRs(CRectD &RS1)
{
// RS - структура, куда записываются параметры области графика
	RS1.bottom = RS.bottom;
	RS1.left = RS.left;
	RS1.right = RS.right;
	RS1.top = RS.top;
}

void CPlot2D::GetWindowCoords(double xs, double ys, int &xw, int &yw)
{
// Пересчитывает координаты точки из МСК в оконную
// xs - x- кордината точки в МСК
// ys - y- кордината точки в МСК
// xw - x- кордината точки в оконной СК
// yw - y- кордината точки в оконной СК
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
			dc.MoveTo((int)W(0),(int)W(1));
			V(0) = 0;
			V(1) = RS.bottom;
			W = k * V;
			dc.LineTo((int)W(0),(int)W(1));
		}
		if(RS.top * RS.bottom < 0)
		{
			V(0) = RS.left;
			V(1) = 0;
			W = k * V;
			dc.MoveTo((int)W(0),(int)W(1));
			V(0) = RS.right;
			V(1) = 0;
			W = k * V;
			dc.LineTo((int)W(0),(int)W(1));
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
{
	CMatrix V(3), W(3);
	V(2) = 1;
	SetWindowRect(RW);
	if(lnd1 == 1) dc.Rectangle(RW);
	if(lnd2 == 1)
	{
		CPen MyPen(PenAxis.PenStyle, PenAxis.PenWidth, PenAxis.color);
		CPen * pOldPen = dc.SelectObject(&MyPen);
		if(RS.left * RS.right < 0)// Нужна Ось Y
		{
			V(0) = 0;
			V(1) = RS.top;
			W = k * V;
			dc.MoveTo((int)W(0),(int)W(1));
			V(0) = 0;
			V(1) = RS.bottom;
			W = k * V;
			dc.LineTo((int)W(0),(int)W(1));
		}
		if(RS.top * RS.bottom < 0)// Нужна Ось X
		{
			V(0) = RS.left;
			V(1) = 0;
			W = k * V;
			dc.MoveTo((int)W(0),(int)W(1));
			V(0) = RS.right;
			V(1) = 0;
			W = k * V;
			dc.LineTo((int)W(0),(int)W(1));
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