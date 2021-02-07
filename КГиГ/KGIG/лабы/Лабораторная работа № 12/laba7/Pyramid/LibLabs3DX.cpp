#include "stdafx.h"
void DrawPyramid(CDC& dc,CMatrix& VA,CMatrix& VB,CMatrix& VC,CMatrix& VD,CMatrix& PView)
// Рисует пирамиду БЕЗ УДАЛЕНИЯ НЕВИДИМЫХ РЕБЕР 
// в режиме MM_ANISOTROPIC - без собственного пересчета координат
// К моменту вызова функции режим и параметры режима должны быть установлены
// dc - ссылка на класс CDC MFC
// D - вершина пирамиды
// ABC - основание пирамиды
// VA,VB,VC - координаты вершин A,B,C в мировой системе координат
// PView - координаты точки наблюдения в мировой сферической системе координат
// (r,fi(град.), q(град.))

{
	double r=PView(0);
	double fi=PView(1);
	double q=PView(2);
	CMatrix MV=CreateViewCoord(r,fi,q);

	CMatrix Ve=MV*VA; // Координаты вершины А в видовых координатах
	int ax=(int)Ve(0);
	int ay=(int)Ve(1);

	Ve=MV*VB;         // Координаты вершины B в видовых координатах
	int bx=(int)Ve(0);
	int by=(int)Ve(1);

	Ve=MV*VC;         // Координаты вершины C в видовых координатах
	int cx=(int)Ve(0);
	int cy=(int)Ve(1);

	Ve=MV*VD;         // Координаты вершины D в видовых координатах
	int dx=(int)Ve(0);
	int dy=(int)Ve(1);

	CPen MyPen1,MyPen2;
	MyPen1.CreatePen(PS_SOLID,0, RGB(0,0,255)); 
	CPen* pOldPen= dc.SelectObject(&MyPen1);
	
	
	dc.MoveTo(ax,ay);	 // Точка A 	
	dc.LineTo(bx,by);  // Линия AB
	dc.LineTo(cx,cy);  // Линия BC
	dc.LineTo(ax,ay);  // Линия CA


	MyPen2.CreatePen(PS_SOLID,0, RGB(255,0,0)); 
	dc.SelectObject(&MyPen2);

	dc.LineTo(dx,dy);  // Линия AD
	dc.LineTo(bx,by);  // Линия DB
	dc.MoveTo(dx,dy);	 // Точка D
	dc.LineTo(cx,cy);  // Линия DC

	dc.SelectObject(pOldPen);

}

void DrawPyramid1(CDC& dc,CMatrix& VA,CMatrix& VB,CMatrix& VC,CMatrix& VD,CMatrix& PView)
// Рисует пирамиду С УДАЛЕНИЕМ НЕВИДИМЫХ РЕБЕР 
// в режиме MM_ANISOTROPIC - без собственного пересчета координат
// К моменту вызова функции режим и параметры режима должны быть установлены
// dc - ссылка на класс CDC MFC
// D - вершина пирамиды
// ABC - основание пирамиды
// VA,VB,VC - координаты вершин A,B,C в мировой системе координат
// PView - координаты точки наблюдения в мировой сферической системе координат
// (r,fi(град.), q(град.))
{
// Вычисляем декартовы координаты вектора точки наблюдения
	double r=PView(0);
	double fi=PView(1);						// Градусы
	double q=PView(2);						// Градусы
	double fi_rad=(fi/180.0)*pi;	// Перевод fi в радианы
	double q_rad=(q/180.0)*pi;		// Перевод q в радианы
	double zv=r*cos(q_rad);
	double xv=r*sin(q_rad)*cos(fi_rad);
	double yv=r*sin(q_rad)*sin(fi_rad);
	CMatrix VR(3);
	VR(0)=xv;  VR(1)=yv;     VR(2)=zv;
//----------Координаты вершин в видовых координатах -----------------------
	POINT A,B,C,D;
	CMatrix MV=CreateViewCoord(r,fi,q);	// Матрица пересчета в видовую систему координат
	CMatrix Ve=MV*VA; // Координаты вершины А в видовых координатах
	A.x=(int)Ve(0);
	A.y=(int)Ve(1);

	Ve=MV*VB;         // Координаты вершины B в видовых координатах
	B.x=(int)Ve(0);
	B.y=(int)Ve(1);

	Ve=MV*VC;         // Координаты вершины C в видовых координатах
	C.x=(int)Ve(0);
	C.y=(int)Ve(1);

	Ve=MV*VD;         // Координаты вершины D в видовых координатах
	D.x=(int)Ve(0);
	D.y=(int)Ve(1);
//-----------------------------------------------------------------

	CMatrix AD=VD-VA;                 // Вектор AD - размер 4
	CMatrix AC=VC-VA;                 // Вектор AC - размер 4
	CMatrix AB=VB-VA;                 // Вектор AB - размер 4
	CMatrix BD=VD-VB;                 // Вектор BD - размер 4
	CMatrix BC=VC-VB;                 // Вектор BC - размер 4
	//-- Удаляем последний элемент из векторов
	AD.RedimData(3);
	AC.RedimData(3);
	AB.RedimData(3);
	BD.RedimData(3);
	BC.RedimData(3);

	//double VR1[]={VR(0),VR(1),VR(2)};	//#############################################

	CMatrix VN=VectorMult(AC,AD);			// Вектор ВНЕШНЕЙ(!)нормали к грани ACD

	//double VN1[]={VN(0),VN(1),VN(2)};	//#############################################

	double sm=ScalarMult(VN,VR);      // Скалярное произведение вектора нормали к грани и
																		// и вектора точки наблюдения
	if(!(sm<0)) // Грань ACD видима - рисуем грань 
	{		
		POINT ACD[]={A,C,D,A};
		dc.Polyline(ACD,4);
	}

	VN=VectorMult(AD,AB);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани ADB
	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
														  // и вектора точки наблюдения
	if(!(sm<0)) // Грань ADB видима - рисуем грань 
	{		
		POINT ADB[]={A,B,D,A};
		dc.Polyline(ADB,4);
	}

	VN=VectorMult(AB,AC);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани ABC
	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
													  	// и вектора точки наблюдения
	if(!(sm<0)) // Грань ABC видима - рисуем грань 
	{		
		POINT ABC[]={A,B,C,A};
		dc.Polyline(ABC,4);
	}

	VN=VectorMult(BD,BC);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани BDC
	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
													  	// и вектора точки наблюдения
	if(!(sm<0)) // Грань BDC видима - рисуем грань 
	{		
		POINT BDC[]={B,D,C,B};
		dc.Polyline(BDC,4);
	}

}
double MyFunction2(double x,double y)
{
	/*
		double b=1,c=1;
		double r=sqrt(x*x+y*y);
		double z=cos(b*r)/(1+c*r);
		return z;
	*/	
		double z,q=10;
		double r=sqrt(x*x+y*y);
		if(r<0.00001) z=1;
		else z=sin(r)/r;
		return q*z;
}

double MyFunction1(double x,double y)
{
		double x0=10,y0=-5;
		double z=(x-x0)*(x-x0)+(y-y0)*(y-y0)-3;
		return z;
}

double MyFunction3(double x,double y)
{
		double x0=0,y0=0;
		double z=(x-x0)*(x-x0)-(y-y0)*(y-y0);
		return z;
}

////////////////////// СВЕТ ////////////////////////////////////////////////////////////

void DrawLightSphere(CDC& dc,double Radius,CMatrix& PView,CMatrix& PSourceLight,CRect RW,
					 COLORREF Color,int Index)
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

  CMatrix VSphere(3),VSphereNorm(3),V0(3),PV(4);
  COLORREF Col;
  double df=0.5;                            // Шаг по азимуту,градусы
  double dq=0.5;                            // Градусы	
  double kLight;
  VSphere(0)=Radius;	                    // Радиус сферы
  CMatrix VR=SphereToCart(PView);       	// Декартовы координаты точки наблюдения
  CMatrix VS=SphereToCart(PSourceLight);	// Декартовы координаты источника света
  CRectD  RV(-Radius,Radius,Radius,-Radius); // Область в видовых координатах в плоскости XY
                                            // для изображения проекции шара
  CMatrix MW=SpaceToWindow(RV,RW);		    // Матрица (3 на 3)пересчета в оконную систему
											// координат
  CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	//Матрица(4 на 4) пересчета  
									                        // в видовую систему координат	

  V0(0)=RV.left;	// Для пересчета координат в оконные, xL 
  V0(1)=RV.bottom;	// Для пересчета координат в оконные, yL, V0(2)=0 - в конструкторе	


//------ Проходим по точкам сферы  ---------------------------------------
  for(double fi=0;fi<360.0;fi+=df)			// Азимут
	for(double q=0;q<=180.0;q+=dq)			// q= 90 - угол места
	{
	  VSphere(1)=fi;  // Азимут,VSphere(0)==Radius 
	  VSphere(2)=q;
	  CMatrix VCart=SphereToCart(VSphere);	// Декартовы координаты точки сферы                                     
	  VSphereNorm=VCart;				    // Вектор НОРМАЛИ к поверхности СФЕРЫ!
	  double cos_RN=CosV1V2(VR,VSphereNorm); // Косинус угла между вектором точки наблюдения R
									         // и вектором нормали N к точке сферы
	  if(cos_RN>0)	  // Если точка видима наблюдателю...
		{ //=====
		  PV(0)=VCart(0);
		  PV(1)=VCart(1);
		  PV(2)=VCart(2);
		  PV(3)=1;
		  PV=MV*PV;        // Координаты точки в видовой системе координат
		  VCart(0)=PV(0);  // Xv
		  VCart(1)=PV(1);  // Yv
		  VCart(2)=1;
		  VCart=VCart-V0;  // Xv-xL, Yv-yL, 1
		  VCart=MW*VCart;  // Оконные координаты видимой точки сферы

		  CMatrix  VP=VS-VR;                 // Направление на источник света относительно 
		                                     // нормали к точке падения
		  double cos_PN=CosV1V2(VP,VSphereNorm); // Косинус угла падения луча ( между VP и 
		                                         // нормалью VSphereNorm
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
				  double cos_A=CosV1V2(RX,VR);  // Косинус угла между отраженным лучом и 
		                                        // вектором наблюдения
				  if(cos_A>0)kLight=cos_A*cos_A; 
				  else kLight=0;			  
				}
			  //Col=RGB(kLight*255,kLight*255,kLight*255);
			  Col=RGB(kLight*red,kLight*green,kLight*blue);
			  dc.SetPixel((int)VCart(0),(int)VCart(1),Col);
			}
		  else
			{
			  Col=RGB(0,0,0);
			  dc.SetPixel((int)VCart(0),(int)VCart(1),Col);
			}
		} //===========
//-----------------------------------------------------------------------
	}
}

