#include "stdafx.h"
#include "Bezier.h"

Bezier::Bezier(const double *x, const double *y, unsigned int n) : m_n(n)
{
	::memcpy(m_x, x, n);
	::memcpy(m_y, y, n);
}

Bezier::Bezier(CMatrix & x, CMatrix & y)
{
	m_n = x.cols() * x.rows();

	m_x = new double[m_n];
	m_y = new double[m_n];

	for (unsigned int i = 0; i < m_n; ++i)
	{
		m_x[i] = x(i);
		m_y[i] = y(i);
	}
}

Bezier::~Bezier()
{
	delete[] m_x, m_y;
}

void Bezier::BuildBezier(CMatrix & x, CMatrix & y, double step)
{
	unsigned int sz = 1 / step + 1, g = 0, i;

	x.RedimMatrix(sz);
	y.RedimMatrix(sz);
	
	for(double t = 0; t < 1.0001; t += step, ++g)
	{
		double** mas = new double*[2];

		for(i = 0; i < m_n; ++i)
		{
			mas[i] = new double[2];
		}

		for(i = 0; i < m_n; ++i)
		{
			mas[i][0] = m_x[i];
			mas[i][1] = m_y[i];
		}

		for(unsigned int k = m_n, j; k > 0; --k)
		{
			for(j = 0; j < k - 1; ++j)
			{
				mas[j][0] = mas[j][0] * (1 - t) + mas[j + 1][0] * t;
				mas[j][1] = mas[j][1] * (1 - t) + mas[j + 1][1] * t;
			}
		}

		x(g) = mas[0][0];
		y(g) = mas[0][1];

		for(i = 0; i < m_n; ++i)
		{
			delete[] mas[i];
		}
	}
}