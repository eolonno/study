#include "stdafx.h"
#include "DrawLineCyrcle.h"

// Создать функции для скалярного, векторного произведения векторов, пересчёт из сферической системы координат в декартову

// <-- Draw Line 

// Отрисовка линии, координаты которой подчиняются условию 0 <= y2 - y1 <= x2 - x1
void DrawLineSimple(CPaintDC &dc, int x1, int y1, int x2, int y2, COLORREF color)
{
	int 
		dx = x2 - x1,
		dy = y2 - y1,
		d = 2 * dy - dx,
		d1 = 2 * dy,
		d2 = 2 * (dy - dx);

	dc.SetPixel(x1, y1, color);

	for (int x = x1 + 1, y = y1; x <= x2; ++x) // Цикл слева направо
	{
		if (d > 0)
		{
			y += y2 < y1 ? -1 : 1;
			d += d2;
		}
		else { d += d1; }

		dc.SetPixel(x, y, color);
	}
}

// Рисовать линию
void DrawLine(CPaintDC &dc, int x1, int y1, int x2, int y2, COLORREF color)
{
	int dx = x2 > x1 ? x2 - x1 : x1 - x2, // модуль dx
		dy = y2 > y1 ? y2 - y1 : y1 - y2, // модуль dy
		t = 0; // временная переменная для обмена

	dc.SetPixel(x1, y1, color);

	if (dy <= dx) // Цикл по x
	{
		int d = 2 * dy - dx,
			d1 = 2 * dy,
			d2 = 2 * (dy - dx);

		if (x2 < x1) // x2 - x1 должно быть >= 0
		{
			t = x2; x2 = x1; x1 = t;
			t = y2; y2 = y1; y1 = t;
		}

		for (int x = x1 + 1, y = y1; x <= x2; ++x)
		{
			if (d > 0)
			{
				y += y2 < y1 ? -1 : 1;
				d += d2;
			}
			else { d += d1; }

			dc.SetPixel(x, y, color);
		}
	}
	else // Цикл по y
	{
		int d = 2 * dx - dy,
			d1 = 2 * dx,
			d2 = 2 * (dx - dy);

		if (y2 < y1) // y2 - y1 должно быть >= 0
		{
			t = x2; x2 = x1; x1 = t;
			t = y2; y2 = y1; y1 = t;
		}
		for (int x = x1, y = y1 + 1; y <= y2; ++y)
		{
			if (d > 0)
			{
				x += x2 < x1 ? -1 : 1;
				d += d2;
			}
			else { d += d1; }

			dc.SetPixel(x, y, color);
		}
	}
}

POINT circleCenter; // центр окружности

// Отрисовка "симметричных" точек окружности
void DrawCirclePoints(CPaintDC &dc, int x, int y, COLORREF color)
{
	dc.SetPixel(circleCenter.x + x, circleCenter.y + y, color);
	dc.SetPixel(circleCenter.x + y, circleCenter.y + x, color);
	dc.SetPixel(circleCenter.x + y, circleCenter.y - x, color);
	dc.SetPixel(circleCenter.x + x, circleCenter.y - y, color);
	dc.SetPixel(circleCenter.x - x, circleCenter.y - y, color);
	dc.SetPixel(circleCenter.x - y, circleCenter.y - x, color);
	dc.SetPixel(circleCenter.x - y, circleCenter.y + x, color);
	dc.SetPixel(circleCenter.x - x, circleCenter.y + y, color);
}

// Рисовать окружность
void DrawCircle(CPaintDC &dc, int xc, int yc, int radius, COLORREF color)
{
	int x = 0,
		y = radius,
		d = 1 - radius,
		d1 = 3,
		d2 = -2 * radius + 5;

	circleCenter.x = xc;
	circleCenter.y = yc;

	DrawCirclePoints(dc, x, y, color);

	for (; y > x; ++x, d1 += 2)
	{
		if (d < 0)
		{
			d += d1;
			d2 += 2;
		}
		else
		{
			d += d2;
			d2 += 4;
			--y;
		}

		DrawCirclePoints(dc, x, y, color);
	}
}

void FillCircle0(CPaintDC &dc, int xc, int yc, int radius, COLORREF color)
{
	while (radius-- > 0)
		DrawCircle(dc, xc, yc, radius, color);
}

void FillCircle(CPaintDC &dc, int xc, int yc, int radius, COLORREF color)
{
	int x = 0,
		y = radius,
		d = 1 - radius,
		d1 = 3,
		d2 = -2 * radius + 5;

	circleCenter.x = xc;
	circleCenter.y = yc;

	for (; y > x; ++x, d1 += 2)
	{
		if (d < 0)
		{
			d += d1;
			d2 += 2;
		}
		else
		{
			d += d2;
			d2 += 4;
			--y;
		}

		DrawLine(dc, circleCenter.x + x, circleCenter.y - y, circleCenter.x - x, circleCenter.y - y, color);
		DrawLine(dc, circleCenter.x + x, circleCenter.y + y, circleCenter.x - x, circleCenter.y + y, color);
		DrawLine(dc, circleCenter.x + y, circleCenter.y - x, circleCenter.x - y, circleCenter.y - x, color);
		DrawLine(dc, circleCenter.x + y, circleCenter.y + x, circleCenter.x - y, circleCenter.y + x, color);
	}
}

// Рисовать прямоугольник
void DrawRectangle(CPaintDC &dc, CRect rectangle, COLORREF color, bool drawDiagonals)
{
	DrawLine(dc, rectangle.left, rectangle.top, rectangle.right, rectangle.top, color);
	DrawLine(dc, rectangle.right, rectangle.top, rectangle.right, rectangle.bottom, color);
	DrawLine(dc, rectangle.right, rectangle.bottom, rectangle.left, rectangle.bottom, color);
	DrawLine(dc, rectangle.left, rectangle.bottom, rectangle.left, rectangle.top, color);

	if (drawDiagonals)
	{
		DrawLine(dc, rectangle.left, rectangle.top, rectangle.right, rectangle.bottom, color);
		DrawLine(dc, rectangle.left, rectangle.bottom, rectangle.right, rectangle.top, color);
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
//
//
//
// Рисовать линию (инкрементный восьмисвязный алгоритм Брезенхэма)
void DrawLine0(CPaintDC &dc, int x1, int y1, int x2, int y2, COLORREF color)
{
	int dx = x2 - x1, dy = y2 - y1, d;
	int incX = (dx >= 0) ? ((dx > 0) ? (1) : (0)) : (-1);
	int incY = (dy >= 0) ? ((dy > 0) ? (1) : (0)) : (-1);

	if (dx < 0) { dx = -dx; }
	if (dy < 0) { dy = -dy; }

	d = (dx > dy) ? (dx) : (dy);

	dc.SetPixel(x1, y1, color);

	for (int i = 0, x = x1, y = y1, xerr = 0, yerr = 0; i < d; ++i)
	{
		xerr += dx;
		yerr += dy;

		if (xerr > d)
		{
			xerr -= d;
			x += incX;
		}
		if (yerr > d)
		{
			yerr -= d;
			y += incY;
		}
		
		dc.SetPixel(x, y, color);
	}
}

// Рисовать окружность (инкрементный алгоритм Брезенхэма)
void DrawCircle0(CPaintDC &dc, int xc, int yc, int radius, COLORREF color)
{
	int x, y, dxt;
	long r2, dst, t, s, e, ca, cd, indx;

	r2 = (long)radius*(long)radius;
	dst = 4 * r2;
	dxt = (int)((double)radius / 1.414213562373);
	t = 0;
	s = -4 * r2 * (long)radius;
	e = (-s/2) - 3 * r2;
	ca = -6 * r2;
	cd = -10 * r2;
	x = 0;
	y = radius;

	dc.SetPixel(xc, yc + radius, color);
	dc.SetPixel(xc, yc - radius, color);
	dc.SetPixel(xc + radius, yc, color);
	dc.SetPixel(xc - radius, yc, color);

	for (indx = 1; indx <= dxt; ++indx)
	{
		++x;
		
		if (e >= 0)
		{
			e += t + ca;
		}
		else
		{
			--y;
			e += t - s + cd;
			s += dst;
		}

		t -= dst;

		dc.SetPixel(xc + x, yc + y, color);
		dc.SetPixel(xc + y, yc + x, color);
		dc.SetPixel(xc + y, yc - x, color);
		dc.SetPixel(xc + x, yc - y, color);
		dc.SetPixel(xc - x, yc - y, color);
		dc.SetPixel(xc - y, yc - x, color);
		dc.SetPixel(xc - y, yc + x, color);
		dc.SetPixel(xc - x, yc + y, color);
	}
}