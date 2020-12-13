#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	float num1, num2, num3;

	cout << "Введите три числа: ";
	cin >> num1 >> num2 >> num3;

	if (num1 == num2 || num1 == num3 || num2 == num3)
		cout << "Хотябы два числа совпадают";

	else
		cout << "Нет совпадающих чисел";

	return 0;
}



