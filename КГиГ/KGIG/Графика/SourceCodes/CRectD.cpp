#include "stdafx.h"
#include "CRectD.h"

CRectD::CRectD() : m_Left(0), m_Top(0), m_Right(0), m_Bottom(0) {}

CRectD::CRectD(CRectD & rect)
{
	m_Left = rect.m_Left;
	m_Top = rect.m_Top;
	m_Right = rect.m_Right;
	m_Bottom = rect.m_Bottom;
}

CRectD::CRectD(double left, double top, double right, double bottom)
{
	SetRect(left, top, right, bottom);
}
void CRectD::SetRect(double left, double top, double right, double bottom)
{
	SetLeft(left);
	SetTop(top);
	SetRight(right);
	SetBottom(bottom);
}

CMatrix SpaceToWindow(CRectD & rectSpace, CRect& rectWindow)
{
	CMatrix matr(3,3);

	//Размер области в окне
	int dwx = rectWindow.Width();
	int dwy = rectWindow.Height();
	
	// Размер области в мировых координатах
	double dsx = rectSpace.GetWidth();
	double dsy = rectSpace.GetHeight();

	double kx = (double)dwx / dsx;   // Масштаб по x
	double ky = (double)dwy / dsy;   // Масштаб по y

	matr(0,0) = kx;      
	matr(1,0) = 0;     
	matr(2,0) = 0;    
	matr(0,1) = 0;
	matr(1,1) = -ky;
	matr(2,1) = 0;
	matr(0,2) = (double)rectWindow.left - kx * rectSpace.GetLeft();
	matr(1,2) = (double)rectWindow.bottom + ky * rectSpace.GetBottom();
	matr(2,2) = 1;

	return matr;
}