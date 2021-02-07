#pragma once
#include "CMatrix.h"

class Bezier
{
private:
	double *m_x, *m_y; // Массивы
	unsigned int m_n;  // Размерность x, y

public:
	Bezier(const double *x, const double *y, unsigned int n);
	Bezier(CMatrix & x, CMatrix & y);
	~Bezier();

	void BuildBezier(CMatrix & x, CMatrix & y, double step);
};