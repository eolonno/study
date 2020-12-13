#include <iostream>
//Составьте программу, которая будет находить сумму 4, введенных с клавиатуры чисел.

using namespace std;

void main()
{
	setlocale(LC_CTYPE, "Russian");
	float a, sum = 0; int i, pr;
	const int size = 4;
	for (i = 1; i <= size; i++)
	{
		cout << "Введите a" << i << endl;
		cin >> a;
		sum = sum + pow(a,2);
		pr *= a;
	}
	cout << "Сумма квадратов: " << sum << endl << "Произведение: " << pr << endl;
}
