#include "stdafx.h"

CRectD::CRectD(double l,double t,double r,double b)
{
  left=l; 
  top=t; 
  right=r; 
  bottom=b; 
}
//------------------------------------------------------------------------------
void CRectD::SetRectD(double l,double t,double r,double b)
{
  left=l; 
  top=t; 
  right=r; 
  bottom=b; 
}

//------------------------------------------------------------------------------
CSizeD CRectD::SizeD()
{
  CSizeD cz;
  cz.cx=fabs(right-left);	// Ширина прямоугольной области
  cz.cy=fabs(top-bottom);	// Высота прямоугольной области
  return cz;
}




