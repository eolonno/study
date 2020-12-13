#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	//4
	int n;
	float p, sum = 0, s;
	cout << "Введите количество лет; n = ";
	cin >> n;
	cout << "Введите процент уценивания p = ";
	cin >> p;
	p = p / 100;
	for (int i = 1; i <= n; i++) {
		cout << "Стоимость оборудования за " << i << " год = ";
		cin >> s;
		sum += s;
		sum *= p;
	}
	cout << "Общая стоимость накопленного оборудования = " << sum;
}