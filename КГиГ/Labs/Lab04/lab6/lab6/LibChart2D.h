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
	void SetParams1(CMatrix& XX, CMatrix& YY, CRect& RWX, int l, int t, int r, int b);
	void SetWindowRect(CRect& RWX);
	void GetWindowCoords(double xs, double ys, int &xw, int &yw);
	void SetPenLine(CMyPen & PLine);
	void SetPenAxis(CMyPen& PAxis);
	void Draw(CDC& dc, int lnd1,int lnd2);
	void Draw1(CDC& dc, int lnd1,int lnd2);
	void GetRs(CRectD & RS1);
	void DrawBezier(CDC& dc,int nDots);
};
double LaGrange(double x, CMatrix &X, CMatrix &Y);

class CSpline
{
private:
	// Структура, описывающая сплайн на каждом сегменте сетки
    struct spline_data
    {
		double a, b, c, d, x;
    };
 
    spline_data *splines; // Сплайн
	int n; // Количество узлов сетки
 
public:
    CSpline(); //конструктор
    ~CSpline(); //деструктор
 
    // Построение сплайна
    // x - узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
    // y - значения функции в узлах сетки
    // n - количество узлов сетки
    void build_spline(CMatrix &x, CMatrix &y);
 
    // Вычисление значения интерполированной функции в произвольной точке
    double get(int x) const;
};
const double pi = 3.14;

	CMatrix CreateTranslate2D(double dx, double dy);

	CMatrix CreateRotate2D(double fi);

	class CSunSystem
	{
		CRect Sun;
		CRect Earth;
		CRect Moon;	
		CRect Planet51;

		CRect EarthOrbit;
		CRect MoonOrbit;
		CRect Planet51Orbit;

		CMatrix ECoords;
		CMatrix MCoords;
		CMatrix VCoords;

		CRect RW;		
		CRectD RS;	

		double wEarth;	
		double wMoon;	
		double wPlanet51;

		double fiE;		
		double fiM;	
		double fiV;
		double dt;	

	 public:
		CSunSystem();
		void SetDT(double dtx)
		{
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