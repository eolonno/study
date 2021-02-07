#pragma once
#include "CMatrix.h"
#include <cmath>

class CRectD
{
private:
	double m_Left;
	double m_Top;
	double m_Right;
	double m_Bottom;
public:
	CRectD();
	CRectD(CRectD & rect);
	CRectD(double left, double top, double right, double bottom);

	void SetLeft(double left) { m_Left = left; }
	void SetTop(double top) { m_Top = top; }
	void SetRight(double right) { m_Right = right; }
	void SetBottom(double bottom) { m_Bottom = bottom; }
	void SetRect(double left, double top, double right, double bottom);

	double GetLeft() const { return m_Left; }
	double GetTop() const { return m_Top; }
	double GetRight() const { return m_Right; }
	double GetBottom() const { return m_Bottom; }

	double GetWidth() const { return fabs(m_Right - m_Left); }
	double GetHeight() const { return fabs(m_Top - m_Bottom); }
 };

// Пересчет мировых координат в оконные
CMatrix SpaceToWindow(CRectD & rectSpace, CRect& rectWindow);