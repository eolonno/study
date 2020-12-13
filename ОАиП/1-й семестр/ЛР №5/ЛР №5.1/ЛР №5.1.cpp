
#include <iostream>
#include <cmath>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "Russian");
	
	cout << "FOR: " << endl;
	for (int i = 0; i <= 2; i++)

	{
		double c = 2.1, m = 7, r = 4e-4, j[] = { 4.2,0.3,0.7 }, h, y;
		h = (10 * r - j[i]) / (c * c + exp(-m));
		y = (h * m - j[i] * j[i]) + pow(c, 2);
		cout << "При j=" << j[i] << " h=" << h << " и y=" << y << endl;
	}

	cout << "WHILE: " << endl;
	float j = 0;
	while (j <= 1.7)
	{
		double h, y, c = 2.1, m = 7, r = 4e-4;
		h = (10 * r - j) / (c * c + exp(-m));
		y = (h * m - pow(j, 2)) + c*c;
		cout << "При j=" << j << " h=" << h << " и y=" << y << endl;
		j += 0.1;
	}

	cout << "Двойной цикл: " << endl;
	
	for (int i = 0; i <= 3; i++)
	{
		double h, y, c = 2.1, r = 4e-4, j[4] = { 9,1.8,15,-3 }, m = 1;
		while (m <= 2)
		{
			h = (10 * r - j[i]) / (c * c + exp(-m));
			y = (h * m - j[i] * j[i]) + pow(0.1 * c, 2);
			cout << "При m=" << m << " и j=" << j[i] << " h=" << h << " и y=" << y << endl;
			m += 0.5;
		}
	}

	return 0;
}