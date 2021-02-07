
// ChildView.cpp : реализация класса CChildView
//

#include "stdafx.h"
#include "lab5.h"
#include "ChildView.h"
#define DIFFUSIAN_LIGHT 1
#define ZERKAL_LIGHT 2
#ifdef _DEBUG
#define new DEBUG_NEW
#endif
int DRAW_MODE=0;

int Light_Global_Teta=45;
int Light_Global_Fi=45;
CMatrix transform(4,4);
CMatrix transform2(4,4);
CMatrix bufer1(4,1);
CMatrix bufer2(4,1);
CChildView::CChildView()
{
	int radius=50;
	figura=new Sphere(radius);
	figura->CalculateMatrix(CRect(0,0,400,400),CRectD(-radius,-radius,radius,radius));
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_WM_KEYDOWN()
	ON_COMMAND(ID_32774, &CChildView::Svitch_to_diffusian)
	ON_COMMAND(ID_32775, &CChildView::svitch_to_zerkal)
END_MESSAGE_MAP()



// обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}
void Sphere::Draw(CDC& dc,bool light_mode)
{
		ExtPoint CurrentPoint;
		ExtPoint CoordCenter;
		ExtPoint CameraVector;
		ExtPoint LightVector;
		ExtPoint KraiCameraVector;
		ExtPoint KraiLightVector;
		LightParams Light;
		CoordCenter.Set(0,0,0);
		Light.intensivity=10000;
		Light.p=1;
		if(light_mode)
		{
			Light.KoefDifuz=0.7;
			Light.KoefStandart=0.3;
			Light.KoefZerkal=0;
		}
		else
		{
			Light.KoefDifuz=0;
			Light.KoefStandart=0;
			Light.KoefZerkal=1;
		}
		CameraVector=PointsOnVector(CoordCenter,SphereToCart(700,0,0));
		LightVector=PointsOnVector(CoordCenter,SphereToCart(700,Light_Global_Fi*pi/180,Light_Global_Teta*pi/180));
		CoordCenter.Set(0,0,0);
		ExtPoint RadiusVector;
		double light_result;
		int red=255;
		int green=255;
		int blue=0;
		double CosUgolCamNormal;
		double CosUgolLightNormal;
		for(double Fi=0;Fi<360;Fi+=0.30)
		{
			for(double Teta=0;Teta<180;Teta+=0.30)
			{
				CurrentPoint=SphereToCart(radius,Fi*pi/180,Teta*pi/180);
				RadiusVector=PointsOnVector(CoordCenter,CurrentPoint);
				CosUgolCamNormal=ScalarMultiply(CameraVector,RadiusVector);
				if(CosUgolCamNormal>0)
				{
					CosUgolLightNormal=ScalarMultiply(LightVector,RadiusVector);
					cord(0)=CurrentPoint.X;
					cord(1)=CurrentPoint.Y;
					rescord=transform*cord;
					if(CosUgolLightNormal>0)
					{
						light_result=GetDarkness(LightVector,CameraVector,RadiusVector,Light);
						dc.SetPixel(rescord(0),rescord(1),RGB(red*light_result,green*light_result,blue*light_result));
					}
					else
					{
						dc.SetPixel(rescord(0),rescord(1),RGB(0,0,0));
					}

				}
			}
		}
}
void CChildView::OnPaint() 
{
	CPaintDC dc(this); // контекст устройства для рисования
	
	if (DRAW_MODE==DIFFUSIAN_LIGHT)
	{figura->Draw(dc,true);
		//figura->DrawInvisible(dc);
	}
	if (DRAW_MODE==ZERKAL_LIGHT)
	{
		figura->Draw(dc,false);
		//figura->DrawLight(dc);
	}
}



void CChildView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: добавьте свой код обработчика сообщений или вызов стандартного

	if(nChar==65||nChar==68||nChar==87||nChar==83)
	{
		if(nChar==65) Light_Global_Fi-=10;//свет налево
		if(nChar==68) Light_Global_Fi+=10;//свет направо
		if(nChar==87) Light_Global_Teta-=10;//свет ввех
		if(nChar==83) Light_Global_Teta+=10;//свет вниз
		if(Light_Global_Fi<0) Light_Global_Fi+=360;
		if(Light_Global_Fi>360) Light_Global_Fi-=360;
		if(Light_Global_Teta<0) Light_Global_Teta+=360;
		if(Light_Global_Teta>360) Light_Global_Teta-=360;
		Invalidate();
	}
	CWnd::OnKeyDown(nChar, nRepCnt, nFlags);
}

void CChildView::Svitch_to_diffusian()
{
	DRAW_MODE=DIFFUSIAN_LIGHT;
	Invalidate();
}


void CChildView::svitch_to_zerkal()
{
	DRAW_MODE=ZERKAL_LIGHT;
	Invalidate();
}
