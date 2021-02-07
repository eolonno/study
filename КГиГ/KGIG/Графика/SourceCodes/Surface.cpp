#include "StdAfx.h"
#include "Surface.h"
#include "GraphicFunctions.h"

using namespace GraphicFunctions;

Surface::Surface(void)
{
	Nx=100, Ny=100;
	MasPoint=NULL;
	PView.RedimMatrix(3);
	PView(0)=1; PView(1)=300; PView(2)=80;
	RD.SetRectD(-10,-10,10,10);
	RW.SetRect(100,100,500,500);
	st=true;
	MW.RedimMatrix(3,3);
}

void Surface::PreDraw(double fi , double teta,SurfaceFunction sf)
{
	if (MasPoint!=NULL) {for (int i=0;i<Nx;i++){delete MasPoint[i];} delete MasPoint;}
	PView(0)=1; PView(1)=fi; PView(2)=teta;		
	MasPoint=CreateSurfaceMatrix(sf, RD, Nx, Ny, RW, PView); 
}
Surface::~Surface(void)
{
}
POINT** Surface::CreateSurfaceMatrix(SurfaceFunction MyF, CRectD &RS, int Nx, int Ny, CRect &RW, CMatrix &PView)
{
	// MyF - функция поверхности, RS - область в мировых координтах на которую опирается поверхность,
	// Nx, Ny - число точек на осях x - y для вычисления значений,
	// RW - область отображения на экране, PView - параметры точки наблюдения

	// определение дальнего угла
	double xL, yL, ddx;
	CMatrix RR = SphereToCart(PView);
	double xv=RR(0), yv=RR(1), zv=RR(2);

	// определим шаги по x и y (вычисление точек поверхности) - нужно реальное расстояние, поэтому - нужен модуль
	double dx= (RS.right - RS.left)/(Nx-1);
	double dy= (RS.top - RS.bottom)/(Ny-1);

	// точка наблюдения (непосредственное вычисление точки наблюдения)
	double y=RS.bottom+(RS.top-RS.bottom)*(xv-RS.left)/(RS.right-RS.left);
	// определить дальнюю точку
	yL=RS.bottom;
	if (yv<y) {xL=RS.left;ddx=dx;}
	else {xL=RS.right;ddx=-dx;}

	// матрица заполнения значений функции
	CMatrix F(Nx,Ny);
	for (int i=0;i<Nx;i++)
	{
		double xi=xL+i*ddx;
		for (int j=0;j<Ny;j++)
		{
			double yj=yL+j*dy;
			double Zij=MyF(xi,yj);
			F(i,j)=Zij;
		}
	}

	if (st)
	{
		// определим охватывающий прямоугольник по крайним точкам фигуры
		GetProjection(RS, F, PView, RV);
		// пересчет в оконную систему координат
		MW=SpaceToWindow(RV, RW);st=false;
	}
	//CMatrix MW=SpaceToWindow(RV, RW);
	CMatrix V(3); V(2)=1;
	// матрица пересчета в видовую
	CMatrix MV=CreateViewCoord(PView(0), PView(1), PView(2));
	CMatrix PS(4); PS(3)=1;
	POINT **MasPoint=NULL;
	MasPoint=new POINT*[Nx];


	for (int i=0;i<Nx;i++) {MasPoint[i]=new POINT [Ny];}
	for (int i=0;i<Nx;i++)
	{
		double xi=xL+i*ddx;
		PS(0)=xi;
		for (int j=0;j<Ny;j++)
		{
			double yi=yL+j*dy;
			double Zij=F(i,j);
			PS(1)=yi;
			PS(2)=Zij;
			CMatrix PV=MV*PS;
			V(0)=PV(0); V(1)=PV(1);	V=MW*V;

			MasPoint[i][j].x=(int)V(0);
			MasPoint[i][j].y=(int)V(1);
		}
	}

	return MasPoint;
}

void Surface::DrawSurface(CDC &dc)//, POINT** MasPoint, int Nx, int Ny)
{
	POINT pt[4];
	for(int i=0;i<Nx-1;i++)
	{
		for (int j=0;j<Ny-1;j++)
		{
			pt[0].x=MasPoint[i][j].x;
			pt[0].y=MasPoint[i][j].y;
			pt[1].x=MasPoint[i][j+1].x;
			pt[1].y=MasPoint[i][j+1].y;
			pt[2].x=MasPoint[i+1][j+1].x;
			pt[2].y=MasPoint[i+1][j+1].y;
			pt[3].x=MasPoint[i+1][j].x;
			pt[3].y=MasPoint[i+1][j].y;
			dc.Polygon(pt,4);
		}
	}
}
// получить проекции
void Surface::GetProjection(CRectD &RS, CMatrix Data, CMatrix PView, CRectD &PR)
{
	double Zmax=Data.MaxElement();
	double Zmin=Data.MinElement();
	CMatrix PS(4,4);
	PS(3,0)=1; PS(3,1)=1; PS(3,2)=1; PS(3,3)=1;
	CMatrix MV=CreateViewCoord(PView(0), PView(1), PView(2)); 

	PS(0,0)=RS.left; PS(0,1)=RS.left; PS(0,2)=RS.right; PS(0,3)=RS.right; 
	PS(1,0)=RS.top; PS(1,1)=RS.bottom; PS(1,2)=RS.top; PS(1,3)=RS.bottom;
	PS(2,0)=Zmax; PS(2,1)=Zmax;  PS(2,2)=Zmax; PS(2,3)=Zmax;

	CMatrix Q=MV*PS;
	CMatrix V=Q.GetRow(0);
	double Xmin=V.MinElement();
	double Xmax=V.MaxElement();
	V=Q.GetRow(1);
	double Ymax=V.MaxElement();

	PS(2,0)=Zmin; PS(2,1)=Zmin;  PS(2,2)=Zmin; PS(2,3)=Zmin;

	Q=MV*PS; V=Q.GetRow(1);
	double Ymin=V.MinElement();


	PR.SetRectD(Xmin, Ymax, Xmax, Ymin);
}