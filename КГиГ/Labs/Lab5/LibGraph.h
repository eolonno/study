#pragma once

struct CSizeD
{
	double cx;
	double cy;
};

struct CRectD
{
	double Left;
	double Top;
	double Right;
	double Bottom;
	CRectD();
	CRectD(double, double, double, double);
	void setRectD(double, double, double, double);
	CSizeD sizeD();
};

CMatrix getConverterWorldToWindow(CRectD& rs, CRect& rw);

CMatrix getConverterWorldToView(double, double, double);