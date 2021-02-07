#include "stdafx.h"
#include "LibChart2D.h"
#include "math.h"

using namespace std;

void SetMyMode(CDC& dc, CRect& RW, CRectD& RS)
{
  double dsx=RS.right-RS.left;
  double dsy=RS.top-RS.bottom;
  double xsL=RS.left;
  double ysL=RS.bottom;

  int dwx=RW.right-RW.left;
  int dwy=RW.bottom-RW.top;
  int xwL=RW.left;
  int ywH=RW.bottom;

  dc.SetMapMode(MM_ANISOTROPIC);
  dc.SetWindowExt((int)dsx,(int)dsy);
  dc.SetViewportExt(dwx,-dwy);
  dc.SetWindowOrg((int)xsL,(int)ysL);
  dc.SetViewportOrg(xwL,ywH);
}
 
void CRectD::SetRectD(double l,double t,double r,double b)
{
	left=l; 
	top=t; 
	right=r; 
	bottom=b; 
}

CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx=fabs(right-left);
	cz.cy=fabs(top-bottom);
	return cz;
}
CMatrix SpaceToWindow(CRectD& RS, CRect& RW)
{
	CMatrix M(3, 3);
	CSize sz = RW.Size();	 
	int dwx = sz.cx;	     
	int dwy = sz.cy;	     
	CSizeD szd = RS.SizeD(); 

	double dsx = szd.cx;    \
	double dsy = szd.cy;    

	double kx = (double)dwx / dsx;   
	double ky = (double)dwy / dsy;   

	M(0, 0) = kx;  M(0, 1) = 0;    M(0, 2) = (double)RW.left - kx*RS.left;				
	M(1, 0) = 0;   M(1, 1) = -ky;  M(1, 2) = (double)RW.bottom + ky*RS.bottom;		
	M(2, 0) = 0;   M(2, 1) = 0;    M(2, 2) = 1;
	return M;
}

CMatrix CreateTranslate2D(double dx, double dy)
{
	CMatrix TM(3,3);
	TM(0,0) = 1; 
	TM(0,2) = dx;
	TM(1,1) = 1;  
	TM(1,2) = dy;
	TM(2,2) = 1;
	return TM;
}

CMatrix CreateRotate2D(double fi)
{
	double fg = fmod(fi,360.);
	double ff = (fg/180.)*pi; 
	CMatrix RM(3,3);
	RM(0,0) = cos(ff); 
	RM(0,1) = -sin(ff);
	RM(1,0) = sin(ff);  
	RM(1,1) = cos(ff);
	RM(2,2) = 1;
	return RM;
}

CSunSystem::CSunSystem()            
{
	double rS = 30, rE = 20, rM = 10, rV = 15;     
	double RoE = 10*rS, RoM = 5*rE, RoV = 6*rS;		
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
	fiV = 0;
	wEarth = 5;	
	wMoon = 50;	
	wPlanet51 = -10;
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

	SBrush.CreateSolidBrush( RGB(250, 250, 0));
	EBrush.CreateSolidBrush( RGB(0, 128, 192));
	MBrush.CreateSolidBrush( RGB(255, 128, 64));
	VBrush.CreateSolidBrush( RGB(128, 64, 64));

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
// Возвращает область графика в мировой СК
	RSX.left = RS.left;
	RSX.top = RS.top;
	RSX.right = RS.right;
	RSX.bottom = RS.bottom;
}