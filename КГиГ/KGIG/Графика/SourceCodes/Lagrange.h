#pragma once
#include "CMatrix.h"

class Lagrange
{
private:
	double *m_x, *m_y; // Массивы координат интерполируемой функции
	unsigned int m_n;  // Размерность x, y

public:
	Lagrange(const double *x, const double *y, unsigned int n);
	Lagrange(CMatrix & x, CMatrix & y);
	~Lagrange();

	double F(double x) const; // Интерполированная функция y = f(x)
	void BuildLagrange(CMatrix & x, CMatrix & y, double xFrom, double xTo, double step);
};