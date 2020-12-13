// Заданы два массива А(n) и В(n).Подсчитать в них количество элементов, меньших значения t, и первым на печать вывести массив, имеющий наибольшее их количество.
#include<iostream>;
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "ru");
	const int n = 10;
	int A[n], B[n], t, lessA = 0,lessB=0;
	for (int i = 0; i < n; i++)
	{
		*(A + i) = 0 + rand() % 20;
		cout << *(A + i) << " ";
	}
	cout << " - Массив A " << endl;

	for (int i = 0; i < n; i++)
	{
		*(B + i) = 0 + rand() % 20;
		cout << *(B + i) << " ";
	}
	cout << " - Массив B " << endl;

	cout << " Введите число t ", cin >> t;

	for (int i = 0; i < n; i++)
	{
		if (*(A + i) < t)
			lessA++;
		if (*(B + i) < t)
			lessB++;
	}

	cout << lessA << " - Кол-во элементов массива А меньших числа t " << endl;
	cout << lessB << " - Кол-во элементов массива B меньших числа t " << endl;

	if (lessA >= lessB)
	{
		for (int i = 0; i < n; i++)
			cout << *(A + i) << " ";
		cout << " - Массив A " << endl;

		for (int i = 0; i < n; i++)
			cout << *(B + i) << " ";
		cout << " - Массив B " << endl;
	}
	else
	{
		for (int i = 0; i < n; i++)
			cout << *(B + i) << " ";
		cout << " - Массив B " << endl;

		for (int i = 0; i < n; i++)
			cout << *(A + i) << " ";
		cout << " - Массив A " << endl;
	}


	return 0;
}
