#include "stdafx.h"
#include "LibPyramid.h"
#include "CMatrix.h"
#include "LibGraph.h"

CPyramid::CPyramid()
{
	Vertices.RedimMatrix(4,8);	// ABCD - основание, 
								// A'B'C'D' верхнее основание
	Vertices(0,0)=6;		// A: x=10,y=0,z=0
	Vertices(0,4)=4;		// A': x=6,y=0,z=0
	Vertices(2,4)=6;		// A': x=6,y=0,z=10

	Vertices(1,1)=-6;	// B: x=0,y=-10,z=0
	Vertices(1,5)=-4;	// B': x=0,y=-6,z=0
	Vertices(2,5)=6;	// B': x=0,y=-6,z=10

	Vertices(0,2)=-6;	// C: x=-10,y=0,z=0
	Vertices(0,6)=-4;	// C': x=-6,y=0,z=0
	Vertices(2,6)=6;	// C': x=-6,y=0,z=10

	Vertices(1,3)=6;		// D: x=0,y=10,z=0
	Vertices(1,7)=4;		// D': x=0,y=6,z=0
	Vertices(2,7)=6;		// D': x=0,y=6,z=10

	//for(int i=0;i<8;i++)
	//	Vertices(3,i)=1; 
}

void CPyramid::Draw(CDC& dc,CMatrix& PView,CRect& RW)
{
	CMatrix ViewCart=SphereToCart(PView);	
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));									
	CMatrix ViewVert=MV*Vertices; 
	CRectD RectView;
	GetRect(ViewVert,RectView);		
	CMatrix MW=SpaceToWindow(RectView,RW);
                                          
	CPoint MasVert[8];
	CMatrix V(3);
	V(2)=1;
	
	for(int i=0;i<8;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y		
		V=MW*V;			
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}
  CPen Pen(PS_SOLID, 3, RGB(71, 126, 128));// рисование
  CPen* pOldPen =dc.SelectObject(&Pen);  
  dc.MoveTo(MasVert[3]);
  for(int i = 0; i < 4; i++)//нижнее основание
  {
	  dc.LineTo(MasVert[i]);
  }
  dc.MoveTo(MasVert[7]);
  for(int i = 4; i < 8; i++)//верхнее основание
  {
	  dc.LineTo(MasVert[i]);
  }	
	for(int i=0;i<4;i++)	//ребра
	{
		dc.MoveTo(MasVert[i]);	
		dc.LineTo(MasVert[i+4]);
	}
// Координаты центра O 	пересечения диагоналей основания
	int x0=(MasVert[0].x+MasVert[2].x)/2;
	int y0=(MasVert[0].y+MasVert[2].y)/2;
	int x0s=(MasVert[4].x+MasVert[6].x)/2;
	int y0s=(MasVert[4].y+MasVert[6].y)/2;

	CPen Pen1(PS_DASH, 1, RGB(94, 92, 144));
	dc.SelectObject(&Pen1);
	dc.MoveTo(x0,y0);
	dc.LineTo(x0s,y0s);
	dc.MoveTo(MasVert[0]);	// Перо на вершину A
	dc.LineTo(MasVert[2]);	// Диагональ
	dc.MoveTo(MasVert[1]);	// Перо на вершину B
	dc.LineTo(MasVert[3]);	// Диагональ

	dc.MoveTo(MasVert[4]);	// Перо на вершину A'
	dc.LineTo(MasVert[6]);	// Диагональ
	dc.MoveTo(MasVert[5]);	// Перо на вершину B'
	dc.LineTo(MasVert[7]);	// Диагональ
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
                                          
	CPoint MasVert[8];
	CMatrix V(3);
	V(2)=1;	
	for(int i=0;i<8;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y

		V=MW*V;	
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}

	CPen Pen(PS_SOLID, 3, RGB(71, 126, 128));
	CPen* pOldPen =dc.SelectObject(&Pen);
	CBrush Brus(RGB(94, 92, 144));
	CBrush* pOldBrush =dc.SelectObject(&Brus);	
	CMatrix R1(3),R2(3),VN(3);
	double sm;
	for(int i=0;i<4;i++)	
	{
		CMatrix VE=Vertices.GetCol(i + 4,0,2);
		int k;
		if(i==3) k=0;
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
				dc.LineTo(MasVert[k + 4]);
				dc.LineTo(MasVert[i + 4]);			
				dc.LineTo(MasVert[i]);
			}
	}

	VN=VectorMult(R1,R2);	
	sm=ScalarMult(VN,ViewCart);
	if(sm>=0)
		dc.Polygon(MasVert, 4);	// нижнее основание
	else
	{
		CBrush *topBrush = new CBrush((COLORREF)0x12ffee);
		dc.SelectObject(topBrush);
		dc.Polygon(MasVert + 4, 4);	// верхнее основание
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
