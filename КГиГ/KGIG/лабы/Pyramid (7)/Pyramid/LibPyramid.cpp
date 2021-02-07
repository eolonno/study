#include "stdafx.h"


////////////////////////// Конструктор ///////////////////////////////////
CPyramid::CPyramid()
{
	Vertices.RedimMatrix(4,9);	// ABCDE: ABCD - основание, E - вершина
	                            // Координаты вершин - столбцы
	Vertices(0,0)=10;		// A: x=10,y=0,z=0
	Vertices(1,1)=-10;	// B: x=0,y=-10,z=0
	Vertices(0,2)=-10;	// C: x=-10,y=0,z=0
	Vertices(1,3)=10;		// D: x=0,y=10,z=0
	Vertices(0,4)=5;
	Vertices(2,4)=10;
	Vertices(1,5)=-5;
	Vertices(2,5)=10;
	Vertices(0,6)=-5;
	Vertices(2,6)=10;
	Vertices(1,7)= 5;
	Vertices(2,7)=10;
    Vertices(2,8)=10;
	for(int i=0;i<9;i++)Vertices(3,i)=1; 
}

//////////////////////// Draw1(...) ///////////////////////////////

void CPyramid::Draw1(CDC& dc,CMatrix& PView,CRect& RW)
// Рисует пирамиду С УДАЛЕНИЕМ невидимых ребер
// Самостоятельный пересчет координат из мировых в оконные (MM_TEXT)
// dc - ссылка на класс CDC MFC
// PView - координаты точки наблюдения в мировой сферической системе координат
// (r,fi(град.), q(град.))
// RW - область в окне для отображения
{
	CMatrix ViewCart=SphereToCart(PView);		// Декартовы координаты точки наблюдения
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	//Матрица(4x4) для пересчета в видовую СК 
	CMatrix ViewVert=MV*Vertices; // Координаты вершин пирамиды в видовой СК
	CRectD RectView;
	GetRect(ViewVert,RectView);		// Получаем охватывающий прямоугольник
	CMatrix MW=SpaceToWindow(RectView,RW); 	// Матрица (3x3) для пересчета в оконную систему координат
// Готовим массив оконных координат для рисования
	CPoint MasVert[9];	// Массив оконных координат вершин
	CMatrix V(3); //V0(3);
	V(2)=1;

// Цикл по количеству вершин - вычисляем оконные координаты вершин
	for(int i=0;i<9;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y		
		V=MW*V;			// Оконные координаты точки
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}
// Рисуем

	CPen Pen(PS_SOLID, 2, RGB(0, 0, 255));
    CPen* pOldPen =dc.SelectObject(&Pen);
	CBrush Brus(RGB(255, 0, 0));
    CBrush* pOldBrush =dc.SelectObject(&Brus);
	CMatrix VE=Vertices.GetCol(4,0,2);	// Вершина E
	CMatrix VE1=Vertices.GetCol(5,0,2);
	CMatrix VE2=Vertices.GetCol(6,0,2);
	CMatrix R1(3),R2(3),VN(3),VN1(3),VN2(3),VN3(3);
	double sm;
	for(int i=0;i<4;i++)	
	{	
		int k,p=7;
		int l=4, m=7;
		if(i==0) 
		{
			k=1; l=5; m=4; p=4;
		}
		if(i==1) 
		{
			k=2; l=6; m=5; p=5;
		}
		if(i==2) 
		{
			k=3; l=7; m=6; p=6;
		}
		if(i==3) 
		{
			k=0; l=4; m=7; p=7;
		}
	
		CMatrix VE3=Vertices.GetCol(p,0,2);
		R1=Vertices.GetCol(i,0,2);
		R2=Vertices.GetCol(k,0,2);		
		CMatrix V1=R2-R1;			      // Вектор - ребро в основании
		CMatrix V2=VE3-R1;			      // Вектор - ребро к вершине E 		
		VN=VectorMult(V2,V1);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани
		sm=ScalarMult(VN,ViewCart);  // Скалярное произведение вектора 
		                             //нормали к грани и вектора точки наблюдения 
			
		if(sm>=0) // Грань видима - рисуем боковую грань
			{	
				dc.MoveTo(MasVert[i]);	// Перо 
				dc.LineTo(MasVert[k]);
				dc.LineTo(MasVert[l]);
				dc.LineTo(MasVert[m]);
				dc.LineTo(MasVert[i]);

			}
		else
			{	
				dc.MoveTo(MasVert[p]);	// Перо 
				dc.LineTo(MasVert[p+1]);
		}

	}
	VN=VectorMult(R1,R2);	
	sm=ScalarMult(VN,ViewCart);
	if(sm>=0)
	dc.Polygon(MasVert, 4);	// Основание
	dc.SelectObject(pOldPen);
	dc.SelectObject(pOldBrush);
}


////////////////////////// Draw(...) ///////////////////////////////
void CPyramid::Draw(CDC& dc,CMatrix& PView,CRect& RW)
// Рисует пирамиду БЕЗ удаления невидимых ребер
// Самостоятельный пересчет координат из мировых в оконные (MM_TEXT)
// dc - ссылка на класс CDC MFC
// PView - координаты точки наблюдения в мировой сферической системе координат
// (r,fi(град.), q(град.))
// RW - область в окне для отображения
{ 	

	CMatrix ViewCart=SphereToCart(PView);		// Декартовы координаты точки наблюдения
	//double zz=ViewCart(2);
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	//Матрица(4x4) 
														                     //для пересчета в видовую СК 
	CMatrix ViewVert=MV*Vertices; // Координаты вершин пирамиды в видовой СК
	CRectD RectView;
	GetRect(ViewVert,RectView);		// Получаем охватывающий прямоугольник
	CMatrix MW=SpaceToWindow(RectView,RW);	// Матрица (3x3) для пересчета 
                                          // в оконную систему координат
// Готовим массив оконных координат для рисования
	CPoint MasVert[9];	// Массив оконных координат вершин
	CMatrix V(3); //V0(3);
	V(2)=1;
	
// Цикл по количеству вершин - вычисляем оконные координаты вершин
	for(int i=0;i<9;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y
		//V=V-V0;			// x-xL, y-yL, 1
		V=MW*V;			// Оконные координаты точки
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}
// Рисуем

	CPen Pen(PS_SOLID, 2, RGB(50, 30, 255));
  CPen* pOldPen =dc.SelectObject(&Pen);
	dc.Polygon(MasVert, 4);	// Основание
		dc.MoveTo(MasVert[4]);	// Перо на вершину E
		dc.LineTo(MasVert[0]);
		dc.MoveTo(MasVert[5]);	// Перо на вершину E
		dc.LineTo(MasVert[1]);
		dc.MoveTo(MasVert[6]);	// Перо на вершину E
		dc.LineTo(MasVert[2]);
		dc.MoveTo(MasVert[7]);	// Перо на вершину E
		dc.LineTo(MasVert[3]);
		dc.MoveTo(MasVert[4]);	// Перо на вершину E
		dc.LineTo(MasVert[5]);
		dc.MoveTo(MasVert[5]);	// Перо на вершину E
		dc.LineTo(MasVert[6]);
		dc.MoveTo(MasVert[6]);	// Перо на вершину E
		dc.LineTo(MasVert[7]);
		dc.MoveTo(MasVert[7]);	// Перо на вершину E
		dc.LineTo(MasVert[4]);

	

		
	//}
// Координаты центра O 	пересечения диагоналей основания
	int x0=(MasVert[0].x+MasVert[2].x)/2;
	int y0=(MasVert[0].y+MasVert[2].y)/2;
// Рисуем диагонали и линию из E в O 
	CPen Pen1(PS_DASHDOTDOT, 1, RGB(255, 0, 50));
	dc.SelectObject(&Pen1);
	dc.MoveTo(MasVert[8]);	// Перо на вершину E
	dc.LineTo(x0,y0);				// Линия EO
	dc.MoveTo(MasVert[0]);	// Перо на вершину A
	dc.LineTo(MasVert[2]);	// Диагональ
	dc.MoveTo(MasVert[1]);	// Перо на вершину B
	dc.LineTo(MasVert[3]);	// Диагональ
	dc.MoveTo(MasVert[4]);	// Перо на вершину A1
	dc.LineTo(MasVert[6]);	// Диагональ
	dc.MoveTo(MasVert[5]);	// Перо на вершину B1
	dc.LineTo(MasVert[7]);	// Диагональ
	dc.SelectObject(pOldPen);
}

	
////////////////////////// ColorDraw(...) ///////////////////////////////

void CPyramid::ColorDraw(CDC& dc,CMatrix& PView,CRect& RW,COLORREF Color){

	BYTE red = GetRValue(Color);
	BYTE green = GetGValue(Color);
	BYTE blue = GetBValue(Color);
	CMatrix ViewCart = SphereToCart(PView);
	CMatrix MV = CreateViewCoord(PView(0), PView(1), PView(2));
	CMatrix ViewVert = MV*Vertices;
	CRectD RectView;
	GetRect(ViewVert, RectView);
	CMatrix MW = SpaceToWindow(RectView, RW);
	CPoint MasVert[9];
	CMatrix V(3);
	V(2) = 1;
	for (int i = 0; i<9; i++)
	{
		V(0) = ViewVert(0, i); // x
		V(1) = ViewVert(1, i); // y
		V = MW*V;
		MasVert[i].x = (int)V(0);
		MasVert[i].y = (int)V(1);
	}


	CMatrix VE = Vertices.GetCol(4, 0, 2);
	CMatrix VE1 = Vertices.GetCol(5, 0, 2);
	CMatrix VE2 = Vertices.GetCol(6, 0, 2);
	CMatrix R1(3), R2(3), VN(3), VN1(3), VN2(3), VN3(3);
	double sm;
	for (int i = 0; i<4; i++)
	{
		int k, p = 7;
		int l = 4, m = 7;
		if (i == 0)
		{
			k = 1; l = 5; m = 4; p = 4;
		}
		if (i == 1)
		{
			k = 2; l = 6; m = 5; p = 5;
		}
		if (i == 2)
		{
			k = 3; l = 7; m = 6; p = 6;
		}
		if (i == 3)
		{
			k = 0; l = 4; m = 7; p = 7;
		}

		CMatrix VE3 = Vertices.GetCol(p, 0, 2);
		R1 = Vertices.GetCol(i, 0, 2);
		R2 = Vertices.GetCol(k, 0, 2);
		CMatrix V1 = R2 - R1;			      // Вектор - ребро в основании
		CMatrix V2 = VE3 - R1;			      // Вектор - ребро к вершине E 		
		VN = VectorMult(V2, V1);		  	// Вектор ВНЕШНЕЙ(!)нормали к грани
		sm = ScalarMult(VN, ViewCart);  // Скалярное произведение вектора 
										//нормали к грани и вектора точки наблюдения 

		if (sm >= 0)
		{
			CPen Pen(PS_SOLID, 2, RGB(sm*sm*red, sm*sm*green, sm*sm*blue));
			CPen* pOldPen = dc.SelectObject(&Pen);
			CBrush Brus(RGB(sm*sm*red, sm*sm*green, sm*sm*blue));
			CBrush* pOldBrush = dc.SelectObject(&Brus);
			CPoint MasVertR[4] = { MasVert[i],MasVert[k],MasVert[l],MasVert[m]};
			dc.Polygon(MasVertR, 4);	// Ребро
			dc.SelectObject(pOldBrush);
			dc.SelectObject(pOldPen);

		}
		else
		{
			CPen Pen(PS_SOLID, 2, RGB(sm*sm*red, green, sm*sm*blue));
			CPen* pOldPen = dc.SelectObject(&Pen);
			CBrush Brus(RGB(sm*red, green, sm*sm*blue));
			CBrush* pOldBrush = dc.SelectObject(&Brus);
			CPoint MasVertR[4] = { MasVert[4],MasVert[5],MasVert[6],MasVert[7] };
			dc.Polygon(MasVertR, 4);
			dc.MoveTo(MasVert[p]);	// Перо 
			dc.LineTo(MasVert[p + 1]);
		}
	}
	VN = VectorMult(R1, R2);
	sm = CosV1V2(VN, ViewCart);
	if (sm >= 0)
	{
		CPen Pen(PS_SOLID, 2, RGB(sm*sm*red, sm*sm*green, sm*sm*blue));
		CPen* pOldPen = dc.SelectObject(&Pen);
		CBrush Brus(RGB(sm*sm*red, sm*sm*green, sm*sm*blue));
		CBrush* pOldBrush = dc.SelectObject(&Brus);
		dc.Polygon(MasVert, 4);	// Основание
		dc.SelectObject(pOldBrush);
		dc.SelectObject(pOldPen);
	}

}

////////////////////////// GetRect(...) ///////////////////////////

void CPyramid::GetRect(CMatrix& Vert,CRectD& RectView)
// Вычисляет координаты прямоугольника,охватывающего проекцию 
// пирамиды на плоскость XY в ВИДОВОЙ системе координат
// Ver - координаты вершин (в столбцах)
// RectView - проекция - охватывающий прямоугольник
{
	CMatrix V=Vert.GetRow(0);					// x - координаты
	double xMin=V.MinElement();
	double xMax=V.MaxElement();
	V=Vert.GetRow(1);									// y - координаты
	double yMin=V.MinElement();
	double yMax=V.MaxElement();
	RectView.SetRectD(xMin,yMax,xMax,yMin);
	
	
}

//---------------------------------------------------------------------