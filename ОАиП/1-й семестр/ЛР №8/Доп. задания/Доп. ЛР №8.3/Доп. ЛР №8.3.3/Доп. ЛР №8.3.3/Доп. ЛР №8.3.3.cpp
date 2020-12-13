#include <iostream>

using namespace std;

double func(double x)
{
	return exp(x)+2*pow(x,2)-3;
}

double derfunc(double x)
{
	return exp(x) + 4 * x;
}

int main()
{
	setlocale(LC_CTYPE, "ru");
	cout << "Метод касательных: ";

	double e = 0.0001, a = 0, b = 1, x = a, x1 = a;

	if (func(a) * derfunc(a) > 0)
		x1 = a;
	else
		x1 = b;
	while (abs(x1 - x) > e)
	{
		x = x1;
		x1 = x - func(x) / derfunc(x);
	}

	cout << x1 << endl << "Метод дихиотомии: ";

	e = 0.0001, a = 0, b = 1;

	while (abs(a - b) > 2 * e)
	{
		x = (a + b) / 2;
		if (func(x) * func(a) <= 0)
			b = x;
		else
			a = x;
	}

	cout << x << endl;

	return 0;
}