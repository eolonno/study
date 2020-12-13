#include <iostream>

using namespace std;

double func(double x)
{
	return 1 + pow(x, 3);
}

int main()
{
	double a = 1, b = 6, n = 200, s1 = 0, i = 1, h, x, z, s2 = 0;
	h = (b - a) / (2 * n);
	x = a + 2 * h;

	while (i < n)
	{
		s2 += func(x);
		x += h;
		s1 += func(x);
		x += h;
		i++;
	}

	z = (h / 3) * (func(a) + 4 * func(a + h) + 4 * s1 + 2 * s2 + func(b));

	cout << z;


	return 0;
}