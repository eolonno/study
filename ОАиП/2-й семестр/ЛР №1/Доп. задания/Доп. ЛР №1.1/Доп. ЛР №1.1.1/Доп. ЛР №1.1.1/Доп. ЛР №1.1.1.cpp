#include <iostream>
using namespace std;

float func1(float x)
{
	return pow(x, 2) + 4 * x - 2;
}
float func2(float x) {
	return sin(x) + 0.1;
}


float dichotomy_method(float a, float b, float(*func)(float)) {   //а - первая координата по иксу, которая ближе к минус бесконечности
																  //b - вторая переменная по иксу, которая ближе к плюс бесконечности
																  //func - функция, которая содержит функцию, от которой мы берем интеграл
	float x = a, e = 0.001;

	while (abs(a - b) > 2 * e)
	{
		x = (a + b) / 2;
		if (func(x) * func(a) <= 0)
			b = x;
		else
			a = x;
	}
	return x;
}

int main() {

	cout << dichotomy_method(0, 1, func1) << endl;
	cout << dichotomy_method(0.2, -0.2, func2);

	return 0;
}