#include "stdafx.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "LibPyramid.h"
#include "math.h"

void DrawLightSphere(CDC& dc,double Radius,CMatrix& PView,CMatrix& PSourceLight,CRect RW,COLORREF Color,int Index)
// Рисует сферу с учетом освещенности
// Radius - Радиус сферы
// PView - координаты точки наблюдения в мировой сферической системе координат
// (r,fi(град.), q(град.))
// PSourceLight - координаты источника света в мировой сферической системе координат
// (r,fi(град.), q(град.))
// RW - область в окне для отображение шара
// Color - цвет источника света
// Ks - коэффициент, формирующий модель освещения Ks=(0...1)-
// Index=0 -  Диффузионная модель отражения света :cos(e)
// Index=1 -  Зеркальная модель отражения света :[cos(a)]^2
// e - угол падения луча света - относительно нормали к точке падения
// a - угол между отраженным лучом и вектором наблюдения
{
  BYTE red=GetRValue(Color);
  BYTE green=GetGValue(Color);
  BYTE blue=GetBValue(Color);

  CMatrix VSphere(3),VSphereNorm(3),PV(4);  // V0(3)
  COLORREF Col;
  double df=0.7;                            // Шаг по азимуту,градусы
  double dq=0.9;                            // Градусы	
  double kLight;
  VSphere(0)=Radius;	                    // Радиус сферы
  CMatrix VR=SphereToCart(PView);       	// Декартовы координаты точки наблюдения
  CMatrix VS=SphereToCart(PSourceLight);	// Декартовы координаты источника света
  CRectD  RV(-Radius,Radius,Radius,-Radius); // Область в видовых координатах в плоскости XY для изображения проекции шара
  CMatrix MW=SpaceToWindow(RV,RW);		    // Матрица (3 на 3)пересчета в оконную систему координат
  CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	//Матрица(4 на 4) пересчета  

  for(double fi=0;fi<=360.0;fi+=df)			// Азимут
	for(double q=0;q<=360.0;q+=dq)			// q= 90 - угол места
	{
	  VSphere(1)=fi;  // Азимут,VSphere(0)==Radius 
	  VSphere(2)=q;
	  CMatrix VCart=SphereToCart(VSphere);	// Декартовы координаты точки сферы                                     
	  VSphereNorm=VCart;				    // Вектор НОРМАЛИ к поверхности СФЕРЫ!
	  double cos_RN=CosV1V2(VR,VSphereNorm); // Косинус угла между вектором точки наблюдения R и вектором нормали N к точке сферы
	  //if(cos_RN>0)	  // Если точка видима наблюдателю...
	  if(1)
	  {
		  PV(0)=VCart(0);
		  PV(1)=VCart(1);
		  PV(2)=VCart(2);
		  PV(3)=1;
		  PV=MV*PV;        // Координаты точки в видовой системе координат
		  VCart(0)=PV(0);  // Xv
		  VCart(1)=PV(1);  // Yv
		  VCart(2)=1;
		  VCart=MW*VCart;  // Оконные координаты видимой точки сферы

		  CMatrix  VP=VS-VR;                 // Направление на источник света относительно нормали к точке падения
		  double cos_PN=CosV1V2(VP,VSphereNorm); // Косинус угла падения луча ( между VP и нормалью VSphereNorm
		  if(cos_PN>0)	// Если точка сферы освещается...
			{
			  if(Index==0) // Диффузионная модель отражения
				{
				  kLight=cos_PN;
				}
			  if(Index==1) // Зеркальная модель отражения
				{
				  double xx=2*ModVec(VP)*cos_PN/ModVec(VSphereNorm);
				  CMatrix RX=VSphereNorm*xx-VP; //Отраженный луч
				  double cos_A=CosV1V2(RX,VR);  // Косинус угла между отраженным лучом и вектором наблюдения
				  if(cos_A>0)kLight=cos_A*cos_A; 
				  else kLight=0;			  
				}
			  Col=RGB(kLight*255,kLight,kLight);
			  dc.SetPixel((int)VCart(0),(int)VCart(1),Col);
			}
		  else
			{
			  Col=RGB(0,0,0);
			  dc.SetPixel((int)VCart(0),(int)VCart(1),Col);
			}
		}
	}
}


