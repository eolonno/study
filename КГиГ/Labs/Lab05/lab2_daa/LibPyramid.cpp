#include "stdafx.h"
#include "LibPyramid.h"
#include "CMatrix.h"
#include "LibGraph.h"
CPoint cross(CPoint a, CPoint b, CPoint c, CPoint d) //точки a и b концы первого отрезка  c и d второго
{
	if (((a.y - b.y)*(d.x - c.x) - (c.y - d.y)*(b.x - a.x)) == 0)
	{
		a.y += 1; c.y += 1;
	}
		CPoint T;
		T.x = ((a.x*b.y - b.x*a.y)*(d.x - c.x) - (c.x*d.y - d.x*c.y)*(b.x - a.x)) / ((a.y - b.y)*(d.x - c.x) - (c.y - d.y)*(b.x - a.x));
		T.y = ((c.y - d.y)*(-T.x) - (c.x*d.y - d.x*c.y)) / (d.x - c.x);
		return T;

	
}
CPyramid::CPyramid()
{
	Vertices.RedimMatrix(4,8);	// ABCD - основание, 
								
	Vertices(0,0)=6;	// A: x=10,y=0,z=0
	Vertices(0,3)=2;		// A': x=6,y=0,z=0
	Vertices(2,3)=6;		// A': x=6,y=0,z=10

	Vertices(1,1)=-6;	// B: x=0,y=-10,z=0
	Vertices(1,4)=-2;	// B': x=0,y=-6,z=0
	Vertices(2,4)=6;	// B': x=0,y=-6,z=10

	Vertices(0,2)=-6;	// C: x=-10,y=0,z=0
	Vertices(0,5)=-2;	// C': x=-6,y=0,z=0
	Vertices(2,5)=6;	// C': x=-6,y=0,z=10

	//Vertices(1,3)=6;		// D: x=0,y=10,z=0
	//Vertices(1,7)=2;		// D': x=0,y=6,z=0
	//Vertices(2,7)=6;		// D': x=0,y=6,z=10

	
}

void CPyramid::Draw(CDC& dc,CMatrix& PView,CRect& RW)
{
	CMatrix ViewCart=SphereToCart(PView);	
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));									
	CMatrix ViewVert=MV*Vertices; 
	CRectD RectView;
	GetRect(ViewVert,RectView);		
	CMatrix MW=SpaceToWindow(RectView,RW);
                                          
	CPoint MasVert[6];
	CMatrix V(3);
	V(2)=1;
	
	for(int i=0;i<6;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y		
		V=MW*V;			
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}
  CPen Pen(PS_SOLID, 2, RGB(0, 60, 120));
  CPen* pOldPen =dc.SelectObject(&Pen);  
  dc.MoveTo(MasVert[2]);
  for(int i = 0; i < 3; i++)//нижнее основание
  {
	  dc.LineTo(MasVert[i]);
  }
  dc.MoveTo(MasVert[5]);
  for(int i = 3; i < 6; i++)//верхнее основание
  {
	  dc.LineTo(MasVert[i]);
  }	
	for(int i=0;i<3;i++)	//ребра
	{
		dc.MoveTo(MasVert[i]);	
		dc.LineTo(MasVert[i+3]);
	}
// Координаты центра O 	пересечения диагоналей основания
	int A1x = (MasVert[1].x + MasVert[2].x) / 2;
	int A1y = (MasVert[1].y + MasVert[2].y) / 2;
	int B1x = (MasVert[0].x + MasVert[2].x) / 2;
	int B1y = (MasVert[0].y + MasVert[2].y) / 2;
	int C1x = (MasVert[1].x + MasVert[0].x) / 2;
	int C1y = (MasVert[1].y + MasVert[0].y) / 2;
	CPoint a(A1x, A1y);
	CPoint b;
	b = MasVert[0];
	CPoint c(B1x, B1y);
	CPoint d = MasVert[1];
	CPoint XY = cross(a, b, c, d);
	CPen Pen1(PS_DASH, 1, RGB(120, 60, 0));
	dc.SelectObject(&Pen1);
	//dc.MoveTo(x0,y0);
	//dc.LineTo(x0s,y0s);
	dc.MoveTo(MasVert[0]);	// Перо на вершину A
	dc.LineTo(A1x, A1y);	// Диагональ
	dc.MoveTo(MasVert[1]);	// Перо на вершину B
	dc.LineTo(B1x, B1y);	// Диагональ
	dc.MoveTo(MasVert[2]);	// Перо на вершину C
	dc.LineTo(C1x, C1y);
	A1x = (MasVert[4].x + MasVert[5].x) / 2;
	A1y = (MasVert[4].y + MasVert[5].y) / 2;
	B1x = (MasVert[3].x + MasVert[5].x) / 2;
	B1y = (MasVert[3].y + MasVert[5].y) / 2;
	C1x = (MasVert[4].x + MasVert[3].x) / 2;
	C1y = (MasVert[4].y + MasVert[3].y) / 2;
	a.x = A1x;
	a.y = A1y;
	b = MasVert[3];
	c.x = B1x;
	c.y = B1y;
	d = MasVert[4];
	CPoint XYup = cross(a, b, c, d);
	dc.MoveTo(MasVert[3]);	// Перо на вершину A
	dc.LineTo(A1x, A1y);	// Диагональ
	dc.MoveTo(MasVert[4]);	// Перо на вершину B
	dc.LineTo(B1x, B1y);	// Диагональ
	dc.MoveTo(MasVert[5]);	// Перо на вершину C
	dc.LineTo(C1x, C1y);
	dc.MoveTo(XY.x,XY.y);
	dc.LineTo(XYup.x,XYup.y);
	dc.SelectObject(pOldPen);
}

void CPyramid::Draw1(CDC& dc,CMatrix& PView,CRect& RW)
{
	CMatrix ViewCart=SphereToCart(PView);
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	
	CMatrix ViewVert=MV*Vertices; 
	CRectD RectView;
	GetRect(ViewVert,RectView);		
	CMatrix MW=SpaceToWindow(RectView,RW);
                                          
	CPoint MasVert[6];
	CMatrix V(3);
	V(2)=1;	
	for(int i=0;i<6;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y

		V=MW*V;	
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}

	CPen Pen(PS_SOLID, 2, RGB(0, 60, 120));
	CPen* pOldPen =dc.SelectObject(&Pen);
	CBrush Brus(RGB(120, 60, 0));
	CBrush* pOldBrush =dc.SelectObject(&Brus);	
	CMatrix R1(3),R2(3),VN(3);
	double sm;
	for(int i=0;i<3;i++)	
	{
		CMatrix VE=Vertices.GetCol(i + 3,0,2);
		int k;
		if(i==2) k=0;
		else k=i+1;
		R1=Vertices.GetCol(i,0,2);
		R2=Vertices.GetCol(k,0,2);
		CMatrix V1=R2-R1;			 
		CMatrix V2=VE-R1;			 
		VN=VectorMult(V2,V1);		 
		sm=ScalarMult(VN,ViewCart);  
		if(sm>=0) 
			{	
				dc.MoveTo(MasVert[i]);
				dc.LineTo(MasVert[k]);
				dc.LineTo(MasVert[k + 3]);
				dc.LineTo(MasVert[i + 3]);			
				dc.LineTo(MasVert[i]);
			}
	}

	VN=VectorMult(R1,R2);	
	sm=ScalarMult(VN,ViewCart);
	if(ViewCart(2)<0)
		dc.Polygon(MasVert, 3);	// нижнее основание
	else
	{
		CBrush *topBrush = new CBrush((COLORREF)0x1fffff);
		dc.SelectObject(topBrush);
		dc.Polygon(MasVert + 3, 3);	// верхнее основание
	}

	dc.SelectObject(pOldPen);
	dc.SelectObject(pOldBrush);
}

void CPyramid::GetRect(CMatrix& Vert,CRectD& RectView)
{
	CMatrix V=Vert.GetRow(0);		
	double xMin=V.MinElement();
	double xMax=V.MaxElement();
	V=Vert.GetRow(1);				
	double yMin=V.MinElement();
	double yMax=V.MaxElement();
	RectView.SetRectD(xMin,yMax,xMax,yMin);
}
