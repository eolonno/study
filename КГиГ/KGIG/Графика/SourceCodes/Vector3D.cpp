#include "stdafx.h"
#include "Vector3D.h"
#include "MathHelper.h"
#include <cmath>

Vector3D::Vector3D() : m_x(0), m_y(0), m_z(0)
{
}

Vector3D::Vector3D(int x, int y, int z)
{
	m_x = x;
	m_y = y;
	m_z = z;
}

Vector3D Vector3D::CalcSum(Vector3D vector)
{
	return Vector3D(m_x + vector.m_x, m_y + vector.m_y, m_z + vector.m_z);
}

long Vector3D::CalcScalarProduct(Vector3D vector)
{
	return // x1*x2 + y1*y2 + z1*z2
		(m_x * vector.m_x + m_y * vector.m_y, m_z * vector.m_z);
}

Vector3D Vector3D::CalcVectorProduct(Vector3D vector)
{
	// ( |y1 z1|  -|x1 z1|  |x1 y1| )
	// ( |y2 z2|,  |x2 z2|, |x2 y2| )
	return 
		Vector3D(m_y * vector.m_z - m_z * vector.m_y, -(m_x * vector.m_z - m_z * vector.m_x), m_x * vector.m_y - m_y * vector.m_x);
}

Vector3D Vector3D::CreateFromSpherical(int r, double angelFiInGrad, double angelTetaInGrad)
{
	double fi = MathHelper::ConvertFromGradToRad(angelFiInGrad);
	double teta = MathHelper::ConvertFromGradToRad(angelTetaInGrad);

	return Vector3D(
		r * sin(teta) * cos(fi),
		r * sin(teta) * sin(fi),
		r * cos(teta));
}