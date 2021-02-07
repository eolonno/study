#pragma once

class Vector3D
{
private:
	int m_x, m_y, m_z;
public:
	Vector3D();
	Vector3D(int x, int y, int z);

	Vector3D CalcSum(Vector3D vector);
	long CalcScalarProduct(Vector3D vector);
	Vector3D CalcVectorProduct(Vector3D vector);

	// static methods
	static Vector3D CreateFromSpherical(int r, double angelFiInGrad, double angelTetaInGrad);
};