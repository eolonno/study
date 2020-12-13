#include <iostream> //Напишите программу, которая определяет больше ли число, введенное с клавиатуры, 9999 и если это условие выполяется, то она выводит его на экран.
using namespace std;

void main()
{
	setlocale(LC_CTYPE, "Russian");
	int COUNT = 5;
	float b, m = 9999, num;
	for (int i = 1; i <= COUNT; i++)
	{
		cout << "Введите b" << i << endl;
		cin >> b;
		if (b < m) 
		{
			m = b;
			num = i;
		}
	}
	cout << "Ответ №" << num << " " << m << endl;
}
