#include <iostream>    //Вычислить max(x1+y1 , x1y1, y1*y2)+min(x1, y1, y2)

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");

	cout << "Введите три числа: ";
	float x1, y1, y2, max, min;
	cin >> x1 >> y1 >> y2;

	if (x1 + y1 >= x1 * y1 && x1 + y1 >= y1 * y2)
		max = x1 + y1;
	else if (x1 * y1 >= x1 + y1 && x1 * y1 >= y1 * y2)
		max = x1 * y1;
	else
		max = y1 * y2;

	if (x1 + y1 <= x1 * y1 && x1 + y1 <= y1 * y2)
		min = x1 + y1;
	else if (x1 * y1 <= x1 + y1 && x1 * y1 <= y1 * y2)
		min = x1 * y1;
	else
		min = y1 * y2;

	cout << "max(x1+y1 , x1*y1, y1*y2)+min(x1, y1, y2)=" << max + min << endl;

	return 0;
}

