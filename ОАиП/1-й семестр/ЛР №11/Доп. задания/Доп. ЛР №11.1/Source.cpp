//14
//Даны два массива x и y.Найти количество одинаковых элементов в этих массивах, т.е.количество пар x[i] = y[j] для некоторых i и j.

#include<iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "ru");
	const int n = 10;
	int x[n], y[n], equal = 0;
	for (int i = 0; i < n; i++)
	{
		*(x + i) = 0 + rand() % 20;
		cout << *(x + i) << " ";
	}
	cout << " - Массив х" << endl;

	for (int i = 0; i < n; i++)
	{
		*(y + i) = 0 + rand() % 20;
		cout << *(y + i) << " ";
	}
	cout << " - Массив y" << endl;

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (*(x + i) == *(y + j))
				equal++;

		}

	}
	cout << "Число равных элементов двух массивов равно " << equal << endl;
	



	return 0;
}