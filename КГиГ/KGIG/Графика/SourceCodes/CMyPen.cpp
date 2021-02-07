#include "stdafx.h"
#include "CMyPen.h"

CMyPen::CMyPen()
{
	SetParams(PS_SOLID, 1, RGB(0, 0, 0));
}

CMyPen::CMyPen(CMyPen & pen)
{
	m_Style = pen.m_Style;
	m_Width = pen.m_Width;
	m_Color = pen.m_Color;
}

CMyPen::CMyPen(int style, int width, COLORREF color)
{
	SetParams(style, width, color);
}

void CMyPen::SetParams(int style, int width, COLORREF color)
{
	SetStyle(style);
	SetWidth(width);
	SetColor(color);
}