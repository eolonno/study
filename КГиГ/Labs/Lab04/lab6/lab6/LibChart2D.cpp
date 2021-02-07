#include "stdafx.h"
#include "LibChart2D.h"
#include "math.h"
#include <fstream>

using namespace std;

void SetMyMode(CDC& dc, CRect& RW, CRectD& RS)
{
	double dsx = RS.right - RS.left;
	double dsy = RS.top - RS.bottom;
	double xsL = RS.left;
	double ysL = RS.bottom;

	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwL = RW.left;
	int ywH = RW.bottom;

	dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt((int)dsx, (int)dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg((int)xsL, (int)ysL);
	dc.SetViewportOrg(xwL, ywH);
}
CMatrix SpaceToWindow(CRectD& RS, CRect RW)
{
	CMatrix matr(3, 3);
	double Kx = (double)(((double)(RW.right - RW.left)) / ((double)(RS.right - RS.left)));
	double Ky = (double)(((double)(RW.bottom - RW.top)) / ((double)(RS.bottom - RS.top)));
	matr(0, 1) = matr(1, 0) = matr(2, 0) = matr(2, 1) = 0;
	matr(2, 2) = 1;
	matr(0, 0) = Kx;
	matr(0, 2) = RW.left - Kx*RS.left;
	matr(1, 1) = -Ky;
	matr(1, 2) = RW.bottom + Ky*RS.top;
	return matr;
};

void CPlot2D::SetParams(CMatrix &XX, CMatrix &YY, CRect &RWX)
{
	int nRowsX = XX.rows();
	int nRowsY = YY.rows();
	if (nRowsX != nRowsY)
		MessageBox(NULL, "Wrong matrix size", "Error", MB_ICONERROR);

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
void CPlot2D::SetParams1(CMatrix &XX, CMatrix &YY, CRect &RWX, int l, int t, int r, int b)
{
	int nRowsX = XX.rows();
	int nRowsY = YY.rows();
	if (nRowsX != nRowsY)
		MessageBox(NULL, "Wrong matrix size", "Error", MB_ICONERROR);

	x.RedimMatrix(nRowsX);
	y.RedimMatrix(nRowsY);
	x = XX;
	y = YY;
	RS.top = t;
	RS.bottom = b;
	RS.left = l;
	RS.right = r;

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
	CMatrix V(3), W(3);
	V(2) = 1;
	if (lnd1 == 1) dc.Rectangle(RW);
	if (lnd2 == 1)
	{
		CPen MyPen(PenAxis.PenStyle, PenAxis.PenWidth, PenAxis.color);
		CPen * pOldPen = dc.SelectObject(&MyPen);
		if (RS.left * RS.right < 0)
		{
			V(0) = 0;
			V(1) = RS.top;
			W = k * V;
			dc.MoveTo((int)W(0), (int)W(1));
			V(0) = 0;
			V(1) = RS.bottom;
			W = k * V;
			dc.LineTo((int)W(0), (int)W(1));
		}
		if (RS.top * RS.bottom < 0)
		{
			V(0) = RS.left;
			V(1) = 0;
			W = k * V;
			dc.MoveTo((int)W(0), (int)W(1));
			V(0) = RS.right;
			V(1) = 0;
			W = k * V;
			dc.LineTo((int)W(0), (int)W(1));
		}
		dc.SelectObject(pOldPen);
	}

	V(0) = x(0);
	V(1) = y(0);
	W = k * V;
	CPen MyPen(PenLine.PenStyle, PenLine.PenWidth, PenLine.color);
	CPen * pOldPen = dc.SelectObject(&MyPen);

	dc.MoveTo((int)W(0), (int)W(1));
	for (int i = 1; i < x.rows(); i++)
	{
		V(0) = x(i);
		V(1) = y(i);
		W = k * V;
		dc.LineTo((int)W(0), (int)W(1));
	}
	dc.SelectObject(pOldPen);
}

void CPlot2D::Draw1(CDC &dc, int lnd1, int lnd2)
{
	CMatrix V(3), W(3);
	V(2) = 1;
	SetWindowRect(RW);
	if (lnd1 == 1) dc.Rectangle(RW);
	if (lnd2 == 1)
	{
		CPen MyPen(PenAxis.PenStyle, PenAxis.PenWidth, PenAxis.color);
		CPen * pOldPen = dc.SelectObject(&MyPen);
		if (RS.left * RS.right < 0)
		{
			V(0) = 0;
			V(1) = RS.top;
			W = k * V;
			dc.MoveTo((int)W(0), (int)W(1));
			V(0) = 0;
			V(1) = RS.bottom;
			W = k * V;
			dc.LineTo((int)W(0), (int)W(1));
		}
		if (RS.top * RS.bottom < 0)
		{
			V(0) = RS.left;
			V(1) = 0;
			W = k * V;
			dc.MoveTo((int)W(0), (int)W(1));
			V(0) = RS.right;
			V(1) = 0;
			W = k * V;
			dc.LineTo((int)W(0), (int)W(1));
		}
		dc.SelectObject(pOldPen);
	}

	V(0) = x(0);
	V(1) = y(0);
	W = k * V;
	CPen MyPen(PenLine.PenStyle, PenLine.PenWidth, PenLine.color);
	CPen * pOldPen = dc.SelectObject(&MyPen);

	dc.MoveTo((int)W(0), (int)W(1));
	for (int i = 1; i < x.rows(); i++)
	{
		V(0) = x(i);
		V(1) = y(i);
		W = k * V;
		dc.LineTo((int)W(0), (int)W(1));
	}
	dc.SelectObject(pOldPen);
}
double LaGrange(double x, CMatrix &X, CMatrix &Y)
{
	double y = 0, lj;
	int nPts = X.rows();
	for (int j = 0; j < nPts; j++)
	{
		lj = 1;
		for (int i = 0; i < nPts; i++)
			if (i != j)
				lj *= (x - X(i)) / (X(j) - X(i));
		y += Y(j)*lj;
	}
	return y;
}

CSpline::CSpline()
{
	splines = NULL;
}

CSpline::~CSpline() {}

void CSpline::build_spline(CMatrix &x, CMatrix &y)
{
	this->n = x.rows();
	splines = new spline_data[n];
	for (int i = 0; i < n; i++)
	{
		splines[i].x = x(i);
		splines[i].a = y(i);
	}
	splines[0].c = 0.;

	double *alpha = new double[n - 1];
	double *beta = new double[n - 1];
	double A, B, C, F, h_i, h_i1, z;
	alpha[0] = beta[0] = 0.;
	for (int i = 1; i < n - 1; i++)
	{
		h_i = x(i) - x(i - 1);
		h_i1 = x(i + 1) - x(i);
		A = h_i;
		C = 2 * (h_i + h_i1);
		B = h_i1;
		F = 6 * ((y(i + 1) - y(i)) / h_i1 - (y(i) - y(i - 1)) / h_i);
		z = (A * alpha[i - 1] + C);
		alpha[i] = -B / z;
		beta[i] = (F - A * beta[i - 1]) / z;
	}

	splines[n - 1].c = (F - A * beta[n - 2]) / (C + A * alpha[n - 2]);

	for (int i = n - 2; i > 0; i--)
		splines[i].c = alpha[i] * splines[i + 1].c + beta[i];

	for (int i = n - 1; i > 0; i--)
	{
		double h_i = x(i) - x(i - 1);
		splines[i].d = (splines[i].c - splines[i - 1].c) / h_i;
		splines[i].b = h_i * (splines[i].c - h_i*splines[i].d / 3) / 2 + (y(i) - y(i - 1)) / h_i;
	}
}

double CSpline::get(int x) const
{
	spline_data *s;
	if (x <= splines[0].x)
		s = splines + 1;
	else if (x >= splines[n - 1].x)
		s = splines + n - 1;
	else
	{
		int i = 0, j = n - 1;
		int k;
		while (i + 1 < j)
		{
			k = i + (j - i) / 2;
			if (x <= splines[k].x)
				j = k;
			else
				i = k;
		}
		s = splines + j;
	}

	double dx = (x - s->x);
	return s->a + (s->b + (s->c / 2 + s->d * dx / 6) * dx) * dx;
}
void CPlot2D::DrawBezier(CDC& dc, int nDots)
{
	CPen MyPen(PenLine.PenStyle, PenLine.PenWidth, PenLine.color);
	CPen* pOldPen = dc.SelectObject(&MyPen);
	CMatrix V(3), W(3);
	V(2) = 1;
	double dt = 1. / nDots;
	int N = x.rows();
	CMatrix RX(N), RY(N);
	RX = x;
	RY = y;
	V(0) = x(0);
	V(1) = y(0);
	W = k * V;
	dc.MoveTo(W(0), W(1));
	for (int g = 1; g <= nDots; g++)
	{
		double t = g*dt;
		for (int j = N - 1; j > 0; j--)
		{
			for (int i = 0; i < j; i++)
			{
				RX(i) = RX(i) + t*(RX(i + 1) - RX(i));
				RY(i) = RY(i) + t*(RY(i + 1) - RY(i));
			}
		}

		V(0) = RX(0);
		V(1) = RY(0);
		W = k * V;
		dc.LineTo(W(0), W(1));
	}
	dc.SelectObject(pOldPen);
}

void CRectD::SetRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}

CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx = fabs(right - left);
	cz.cy = fabs(top - bottom);
	return cz;
}

CMatrix CreateTranslate2D(double dx, double dy)
{
	CMatrix TM(3, 3);
	TM(0, 0) = 1;
	TM(0, 2) = dx;
	TM(1, 1) = 1;
	TM(1, 2) = dy;
	TM(2, 2) = 1;
	return TM;
}

CMatrix CreateRotate2D(double fi)
{
	double fg = fmod(fi, 360.);
	double ff = (fg / 180.)*pi;
	CMatrix RM(3, 3);
	RM(0, 0) = cos(ff);
	RM(0, 1) = -sin(ff);
	RM(1, 0) = sin(ff);
	RM(1, 1) = cos(ff);
	RM(2, 2) = 1;
	return RM;
}

CSunSystem::CSunSystem()
{
	double rS = 30, rE = 20, rM = 10, rV = 15;
	double RoE = 10 * rS, RoM = 5 * rE, RoV = 6 * rS;
	double d = RoE + RoM + rM + RoV;
	RS.SetRectD(-d, d, d, -d);
	RW.SetRect(100, -100, 800, 600);
	Sun.SetRect(-rS, rS, rS, -rS);
	Earth.SetRect(-rE, rE, rE, -rE);
	Moon.SetRect(-rM, rM, rM, -rM);
	Planet51.SetRect(-rV, rV, rV, -rV);
	EarthOrbit.SetRect(-RoE, RoE, RoE, -RoE);
	MoonOrbit.SetRect(-RoM, RoM, RoM, -RoM);
	Planet51Orbit.SetRect(-RoV, RoV, RoV, -RoV);
	fiE = 0;
	fiM = 0;
	fiV = 1;
	wEarth = 5;
	wMoon = 50;
	wPlanet51 = -8;
	dt = .1;
	ECoords.RedimMatrix(3);
	MCoords.RedimMatrix(3);
	VCoords.RedimMatrix(3);
	ECoords(2) = 1;
	MCoords(2) = 1;
	VCoords(2) = 1;
}

void CSunSystem::SetNewCoords()
{
	double RoM = (MoonOrbit.right - MoonOrbit.left) / 2;
	double ff = (fiM / 180.) * pi;
	double x = RoM * cos(ff);
	double y = RoM * sin(ff);
	MCoords(0) = x;
	MCoords(1) = y;
	fiM += wMoon * dt;
	CMatrix P = CreateRotate2D(fiM);
	MCoords = P * MCoords;

	double RoE = (EarthOrbit.right - EarthOrbit.left) / 2;
	ff = (fiE / 180.) * pi;
	x = RoE * cos(ff);
	y = RoE * sin(ff);
	ECoords(0) = x;
	ECoords(1) = y;
	P = CreateTranslate2D(x, y);
	MCoords = P * MCoords;

	double RoV = (Planet51Orbit.right - Planet51Orbit.left) / 2;
	ff = (fiV / 180.) * pi;
	x = RoV * cos(ff);
	y = RoV * sin(ff);
	VCoords(0) = x;
	VCoords(1) = y;

	fiE += wEarth * dt;
	P = CreateRotate2D(fiE);
	MCoords = P * MCoords;
	ECoords = P * ECoords;

	fiV += wPlanet51 * dt;
	P = CreateRotate2D(fiV);
	VCoords = P * VCoords;
}


void CSunSystem::Draw(CDC& dc)
{
	CBrush SBrush, EBrush, MBrush, VBrush, *pOldBrush;
	CRect R;

	SBrush.CreateSolidBrush(RGB(250, 250, 0));
	EBrush.CreateSolidBrush(RGB(0, 128, 192));
	MBrush.CreateSolidBrush(RGB(255, 128, 64));
	VBrush.CreateSolidBrush(RGB(128, 64, 64));

	dc.SelectStockObject(NULL_BRUSH);
	dc.Ellipse(EarthOrbit);
	dc.Ellipse(Planet51Orbit);

	int d = MoonOrbit.right;
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.Ellipse(R);

	pOldBrush = dc.SelectObject(&SBrush);
	dc.Ellipse(Sun);

	d = Earth.right;
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.SelectObject(&EBrush);
	dc.Ellipse(R);

	d = Moon.right;
	R.SetRect(MCoords(0) - d, MCoords(1) + d, MCoords(0) + d, MCoords(1) - d);
	dc.SelectObject(&MBrush);
	dc.Ellipse(R);

	d = Planet51.right;
	R.SetRect(VCoords(0) - d, VCoords(1) + d, VCoords(0) + d, VCoords(1) - d);
	dc.SelectObject(&VBrush);
	dc.Ellipse(R);

	dc.SelectObject(pOldBrush);
}

void CSunSystem::GetRS(CRectD& RSX)
{
	RSX.left = RS.left;
	RSX.top = RS.top;
	RSX.right = RS.right;
	RSX.bottom = RS.bottom;
}