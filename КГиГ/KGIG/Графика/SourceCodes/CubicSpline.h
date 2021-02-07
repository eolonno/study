#pragma once
#include "CMatrix.h"
#include <limits>

class CubicSpline
{
private:
	struct spline_tuple // Структура, описывающая сплайн на каждом сегменте сетки
	{
		double a, b, c, d, x;
	};
 
	spline_tuple *m_splines; // Сплайн
	unsigned int m_n;        // Количество узлов сетки

public:
	CubicSpline(const double *x, const double *y, unsigned int n);
	CubicSpline(CMatrix & x, CMatrix & y);
	~CubicSpline();

	double F(double x) const; // Интерполированная функция y = f(x)
	void BuildSpline(CMatrix & x, CMatrix & y, double xFrom, double xTo, double step);

private:

	void x_BuildSpline(  // Построение сплайна
		const double *x,     // узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
		const double *y,     // значения функции в узлах сетки
		unsigned int n       // количество узлов сетки
	);
	void x_FreeMemory();
};