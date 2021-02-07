#include "stdafx.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "math.h"

//void DrawPyramid(CDC& dc,CMatrix& VA,CMatrix& VB,CMatrix& VC,CMatrix& VD,CMatrix& PView)
//// Рисует пирамиду БЕЗ УДАЛЕНИЯ НЕВИДИМЫХ РЕБЕР 
//// в режиме MM_ANISOTROPIC - без собственного пересчета координат
//// К моменту вызова функции режим и параметры режима должны быть установлены
//// dc - ссылка на класс CDC MFC
//// D - вершина пирамиды
//// ABC - основание пирамиды
//// VA,VB,VC - координаты вершин A,B,C в мировой системе координат
//// PView - координаты точки наблюдения в мировой сферической системе координат
//// (r,fi(град.), q(град.))
//{
//	double r=PView(0);
//	double fi=PView(1);
//	double q=PView(2);
//	CMatrix MV=CreateViewCoord(r,fi,q);
//
//	CMatrix Ve=MV*VA; // Координаты вершины А в видовых координатах
//	int ax=(int)Ve(0);
//	int ay=(int)Ve(1);
//
//	Ve=MV*VB;         // Координаты вершины B в видовых координатах
//	int bx=(int)Ve(0);
//	int by=(int)Ve(1);
//
//	Ve=MV*VC;         // Координаты вершины C в видовых координатах
//	int cx=(int)Ve(0);
//	int cy=(int)Ve(1);
//
//	Ve=MV*VD;         // Координаты вершины D в видовых координатах
//	int dx=(int)Ve(0);
//	int dy=(int)Ve(1);
//
//	CPen MyPen1,MyPen2;
//	MyPen1.CreatePen(PS_SOLID,0, RGB(0,0,255)); 
//	CPen* pOldPen= dc.SelectObject(&MyPen1);
//	
//	dc.MoveTo(ax,ay);	 // Точка A 	
//	dc.LineTo(bx,by);  // Линия AB
//	dc.LineTo(cx,cy);  // Линия BC
//	dc.LineTo(ax,ay);  // Линия CA
//
//	MyPen2.CreatePen(PS_SOLID,0, RGB(255,0,0)); 
//	dc.SelectObject(&MyPen2);
//
//	dc.LineTo(dx,dy);  // Линия AD
//	dc.LineTo(bx,by);  // Линия DB
//	dc.MoveTo(dx,dy);	 // Точка D
//	dc.LineTo(cx,cy);  // Линия DC
//
//	dc.SelectObject(pOldPen);
//}
//
//void DrawPyramid1(CDC& dc,CMatrix& VA,CMatrix& VB,CMatrix& VC,CMatrix& VD,CMatrix& PView)
//// Рисует пирамиду С УДАЛЕНИЕМ НЕВИДИМЫХ РЕБЕР 
//// в режиме MM_ANISOTROPIC - без собственного пересчета координат
//// К моменту вызова функции режим и параметры режима должны быть установлены
//// dc - ссылка на класс CDC MFC
//// D - вершина пирамиды
//// ABC - основание пирамиды
//// VA,VB,VC - координаты вершин A,B,C в мировой системе координат
//// PView - координаты точки наблюдения в мировой сферической системе координат
//// (r,fi(град.), q(град.))
//{
//// Вычисляем декартовы координаты вектора точки наблюдения
//	double r=PView(0);
//	double fi=PView(1);						// Градусы
//	double q=PView(2);						// Градусы
//	double fi_rad=(fi/180.0)*pi;	// Перевод fi в радианы
//	double q_rad=(q/180.0)*pi;		// Перевод q в радианы
//	double zv=r*cos(q_rad);
//	double xv=r*sin(q_rad)*cos(fi_rad);
//	double yv=r*sin(q_rad)*sin(fi_rad);
//	CMatrix VR(3);
//	VR(0)=xv;  VR(1)=yv;     VR(2)=zv;
////----------Координаты вершин в видовых координатах -----------------------
//	POINT A,B,C,D;
//	CMatrix MV=CreateViewCoord(r,fi,q);	// Матрица пересчета в видовую систему координат
//	CMatrix Ve=MV*VA; // Координаты вершины А в видовых координатах
//	A.x=(int)Ve(0);
//	A.y=(int)Ve(1);
//
//	Ve=MV*VB;         // Координаты вершины B в видовых координатах
//	B.x=(int)Ve(0);
//	B.y=(int)Ve(1);
//
//	Ve=MV*VC;         // Координаты вершины C в видовых координатах
//	C.x=(int)Ve(0);
//	C.y=(int)Ve(1);
//
//	Ve=MV*VD;         // Координаты вершины D в видовых координатах
//	D.x=(int)Ve(0);
//	D.y=(int)Ve(1);
//
//	CMatrix AD=VD-VA;                 // Вектор AD - размер 4
//	CMatrix AC=VC-VA;                 // Вектор AC - размер 4
//	CMatrix AB=VB-VA;                 // Вектор AB - размер 4
//	CMatrix BD=VD-VB;                 // Вектор BD - размер 4
//	CMatrix BC=VC-VB;                 // Вектор BC - размер 4
//	//-- Удаляем последний элемент из векторов
//	AD.RedimData(3);
//	AC.RedimData(3);
//	AB.RedimData(3);
//	BD.RedimData(3);
//	BC.RedimData(3);
//
//	CMatrix VN=VectorMult(AC,AD);			// Вектор ВНЕШНЕЙ(!)нормали к грани ACD
//
//	double sm=ScalarMult(VN,VR);      // Скалярное произведение вектора нормали к грани и
//																		// и вектора точки наблюдения
//	if(!(sm<0)) // Грань ACD видима - рисуем грань 
//	{		
//		POINT ACD[]={A,C,D,A};
//		dc.Polyline(ACD,4);
//	}
//
//	VN=VectorMult(AD,AB);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани ADB
//	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
//														  // и вектора точки наблюдения
//	if(!(sm<0)) // Грань ADB видима - рисуем грань 
//	{		
//		POINT ADB[]={A,B,D,A};
//		dc.Polyline(ADB,4);
//	}
//
//	VN=VectorMult(AB,AC);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани ABC
//	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
//													  	// и вектора точки наблюдения
//	if(!(sm<0)) // Грань ABC видима - рисуем грань 
//	{		
//		POINT ABC[]={A,B,C,A};
//		dc.Polyline(ABC,4);
//	}
//
//	VN=VectorMult(BD,BC);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани BDC
//	sm=ScalarMult(VN,VR);       // Скалярное произведение вектора нормали к грани и
//													  	// и вектора точки наблюдения
//	if(!(sm<0)) // Грань BDC видима - рисуем грань 
//	{		
//		POINT BDC[]={B,D,C,B};
//		dc.Polyline(BDC,4);
//	}
//
//}
