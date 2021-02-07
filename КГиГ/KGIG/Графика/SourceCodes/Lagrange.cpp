#include "stdafx.h"
#include "Lagrange.h"

Lagrange::Lagrange(const double *x, const double *y, unsigned int n) : m_n(n)
{
	::memcpy(m_x, x, n);
	::memcpy(m_y, y, n);
}

Lagrange::Lagrange(CMatrix & x, CMatrix & y)
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

Lagrange::~Lagrange()
{
	delete[] m_x, m_y;
}

double Lagrange::F(double x) const
{
	double c, y = 0;

	for (unsigned int i = 0, j; i < m_n; ++i)
	{
		for (j = 0, c = 1; j < m_n; ++j)
		{
			if (i != j)
			{
				c *= (x - m_x[j]) / (m_x[i] - m_x[j]);
			}
		}
		y += c * m_y[i];
	}
	return y;
}

void Lagrange::BuildLagrange(CMatrix & x, CMatrix & y, double xLeft, double xRight, double step)
{
	int k = (int)((xRight - xLeft) / step + 1);

	x.RedimMatrix(k);
	y.RedimMatrix(k);

	for (int i = 0; i < k; ++i)
	{
		x(i) = xLeft + i * step;
		y(i) = this->F(x(i));
	}
}