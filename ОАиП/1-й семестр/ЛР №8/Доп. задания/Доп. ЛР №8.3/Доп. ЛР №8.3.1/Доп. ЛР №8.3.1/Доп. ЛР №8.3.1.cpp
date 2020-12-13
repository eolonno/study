#include <iostream>

using namespace std;

double func(double x)
{
	return exp(x) + 2;
}

int main()
{
	double a = 5, b = 11, n = 200;
	double h, s = 0, x = a;
	h = (b - a) / n;

	while (x < b)
	{
		s += h*(func(x) + func(x + h)) / 2;
		x += h;
	}

	cout << s;

	return 0;
}