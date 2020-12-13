//Заданы два массива А(n) и В(n). Подсчитать в них количество элементов, меньших значения t, и первым на печать вывести массив, имеющий наибольшее их количество.

#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	int a[10], b[10], counterA = 0, counterB = 0;

	for (int i = 0; i < 10; i++)
	{
		a[i] = rand() % 100;
		b[i] = rand() % 100;
	}

	cout << "Введите число t: ";
	int t;
	cin >> t;

	for (int i = 0; i < 10; i++)
	{
		if (*(a + i) < t)
			counterA++;
		if (*(b + i) < t)
			counterB++;
	}
	
	for (int i = 0; i < 10; i++)
	{
		if (counterA == counterB)
		{
			cout << "В массивах равное количество чисел, меньших t";
			break;
		}
		else if (counterA > counterB)
			cout << *(a + i) << " ";
		else
			cout << *(b + i) << " ";
	}

	return 0;
}