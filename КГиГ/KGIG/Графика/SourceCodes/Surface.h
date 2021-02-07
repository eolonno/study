#pragma once
#include "CRectD.h"
#include "CMatrix.h"

class Surface
{
public:
	Surface(void);~Surface(void);

	typedef double (*SurfaceFunction)(double, double);	// функция рассчитывает набор точек на поверхности
	SurfaceFunction Sf;
	CRectD RD;
	CRect RW;
	CRectD RV;
	CMatrix PView;
	int Nx, Ny;
	POINT **MasPoint;
	//pfunc2 PF;
	CMatrix MW;
	bool st;
	////
	// (формирует матрицу для отображения точек на поверхности)
	POINT **CreateSurfaceMatrix(SurfaceFunction Func, CRectD &RS, int Nx, int Ny, CRect &RW, CMatrix &PView);
	void GetProjection(CRectD &RS, CMatrix Data, CMatrix PView, CRectD &PR);
	void DrawSurface(CDC &dc);// функция прорисовки поверхности
	void PreDraw(double fi , double teta,SurfaceFunction sf);	
	void PreDraw(double fi , double teta){PreDraw(fi,teta,Sf);}
	
};

