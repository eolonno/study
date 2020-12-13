#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	cout << "Введите два числа: ";
	float num1, num2;
	cin >> num1 >> num2;
	cout << endl << "Что Вы хотите с ними сделать? \t(1.*\t2./\t3.+\t4.-\t5.%)" << endl;
	int x;
	cin >> x;
	switch (x)
	{
		case 1: cout << "Ответ: " << num1 * num2; break;
		case 2: cout << "Ответ: " << num1 / num2; break;
		case 3: cout << "Ответ: " << num1 + num2; break;
		case 4: cout << "Ответ: " << num1 - num2; break;
		case 5: cout << "Ответ: " << int(num1) % int(num2); break;

		default: cout << "Вы ввели некорректное число" << endl;
		break;
	}

	return 0;
}
