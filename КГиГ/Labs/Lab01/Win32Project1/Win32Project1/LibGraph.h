#pragma once
#include "CMatrix.h"
#include <afxwin.h>

void PrintMatrix(CDC& dc, int x, int y, CMatrix& M);
class CChildView
{
public:
	CMatrix*A;
	CMatrix*B;
	CMatrix*V1;
	CMatrix*V2;
	CChildView( )
	{
		A = new CMatrix(3, 3);
		B = new CMatrix(3, 3);
		V1 = new CMatrix(3);
		V2 = new CMatrix(3);
	}
};

CMatrix VectorMult(CMatrix& V1, CMatrix& V2);
double ScalarMult(CMatrix& V1, CMatrix& V2);
double ModVec(CMatrix& V);
double CosV1V2(CMatrix& V1, CMatrix& V2);
CMatrix SphereToCart(CMatrix& PView);