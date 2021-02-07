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
struct CSizeD
	{
	  double cx;
	  double cy;
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
	void SetRectD(double l, double t, double r, double b);
	CSizeD SizeD();
};

void SetMyMode(CDC& dc, CRect& RW, CRectD& RS);
CMatrix SpaceToWindow(CRectD& RW, CRect RS);

const double pi = 3.14;

CMatrix CreateTranslate2D(double dx, double dy);

CMatrix CreateRotate2D(double fi);

class CSunSystem
{
	CRect Sun;
	CRect Earth;
	CRect Moon;	
	
	CRect EarthOrbit;
	CRect MoonOrbit;
	
	CMatrix ECoords;
	CMatrix MCoords;
	CMatrix VCoords;
	CRect RW;		
	CRectD RS;		
	double wEarth;		// Угловая скорость Земли относительно Солнца, град./сек.
	double wMoon;			// Угловая скорость Луны относительно Солнца, град./сек.

	double fiE;			  // Угловое положение Земли в системе кординат Солнца, град
	double fiM;			  // Угловое положение Луны в системе кординат Земли, град
	double fiV;
	double dt;				// Интервал дискретизации, сек.
 public:
	CSunSystem();
	void SetDT(double dtx)
	{
		// Установка интервала дискретизации
		dt=dtx;
	};	
	void SetNewCoords();
	void GetRS(CRectD& RSX);	
	CRect GetRW()
	{
		return RW;
	};	
	void Draw(CDC& dc);		
};