#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	//5
	int a, f, ff, k = 0, x;
	cout << "Введите число " << endl;
	cin >> x;
	if (x >= 0) f = 1;
	else if (x < 0) f = 0;

	while (true) {
		cout << "Введите число " << endl;
		cin >> a;
		if (a == 0) {
			cout << "Конец ввода" << endl;
			break;
		}
		if (a >= 0) ff = 1;
		else if (a < 0) ff = 0;
		if (ff != f) k++;
		x = a;
		f = ff;
	}
}