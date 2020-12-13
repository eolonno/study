#include <iostream>

using namespace std;

double func(double x)
{
	return 5-(x*x);
}

int main()
{
	double a = 8, b = 12, n = 200;
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