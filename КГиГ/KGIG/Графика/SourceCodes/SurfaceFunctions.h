#pragma once
#include "stdafx.h"

namespace SurfaceFunctions
{
	double Function1(double x, double y)
	{
		double z, q=10;
		double r=sqrt(y*y*x*x);
		if (r<0.00001)z=1;
		else z=sin(r)/r;
		return q*z;
	}
	// (x-x0)2-(y-y0)2
	double Function2(double x, double y)
	{
		double a=0.1, b=0.2;	
		return ((x-a)*(x-a) - (y-b)*(y-b));
	}
	// sin sqrt((x2+y2))/sqrt((x2+y2))
	double Function3(double x, double y)
	{
		double a=0.1, b=0.2;	
		return sin(sqrt(x*x+y*y))/sqrt(x*x+y*y);
	}
	// sqrt(x2+y2+ñ)
	double Function4(double x, double y) 
	{
		double c=0.01;
		return sqrt(x*x+y*y+c);
	}
	// sin sqrt((x2+y2))
	double Function5(double x, double y) 
	{
		return sin(sqrt(x*x+y*y));
	}
	// cos sqrt((x2+y2*c))
	double Function6(double x, double y) 
	{
		double c=0.1;
		return cos(sqrt(x*x+y*y*c));
	}
	// sin(c* sqrt(1-x2*y))
	double Function7(double x, double y) 
	{
		double c=0.2, d=0.3;
		return sin(c*sqrt(abs(1-x*x*y)));
	}

	double Function8(double x, double y)
	{
		double a=0.5, b=0.2;	
		return sin(sqrt(abs((x-a)*(x-a)+(y+x)*b)));
	}

}