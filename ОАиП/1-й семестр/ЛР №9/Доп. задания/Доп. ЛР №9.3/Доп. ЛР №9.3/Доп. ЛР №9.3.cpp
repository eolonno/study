//Определить, содержится ли в заданном массиве хотя бы одно число Фибоначчи.

#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	int fib[10], arr[10], counter = 0;
	fib[0] = 1;
	fib[1] = 1;
	for (int i = 2; i < 10; i++)//заполнение массивов с числами Фибоначчи и с рандомными числами
		fib[i] = fib[i - 1] + fib[i - 2];
	for (int i = 0; i < 10; i++)
		arr[i] = rand() % 99;

	for (int i = 0; i < 10; i++)//сравнение значений двух массивов
	{
		for (int k = 0; k < 10; k++)
		{
			if (fib[i]==arr[k])
			{
				counter++;//добавление единицы к счетчику при совпадении
			}
		}
	}

	cout << "Найдено совпадений: " << counter << endl;

	return 0;
}