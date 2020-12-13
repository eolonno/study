//Написать функцию fsum с переменным числом параметров, в которой определяется сумма чисел типа int по формуле: S=a1*a2+a2*a3+a3*a4+ . . . 
#include <iostream>
using namespace std;

int fsum(int amount, ...);//Прототип функции

int main()
{
	cout << fsum(3, 5, 76, 23) << endl;
	cout << fsum(5, 12, 7, 6, 87, 90) << endl;
	cout << fsum(2, 15, 30) << endl;

	return 0;
}

int fsum(int amount, ...)
{
	int amount1 = amount;
	int* ptr = &amount + 1;//Объявление указателя на первый элемент массива аргументов
	int s = 0, counter = 1, index = 0;
	int* sums = new int[amount / 2 + 1];
	while (amount--)//Вычисление ответа по формуле
	{
		if (counter % 2 == 0)
		{
			sums[index] = *ptr * *(ptr - 1);
			index++;
		}
		counter++;
		ptr++;
	}
	if (amount1 % 2 == 1)
	{
		sums[index] = *(ptr - 1);
		index++;
	}
	for (int i = 0; i < index; i++)
	{
		s += sums[i];
	}
	delete[] sums;
	return s;
}
