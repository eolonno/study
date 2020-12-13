//Программа второго задания должна содержать функцию пользователя с переменным числом параметров и не менее трех обращений к ней с различным количеством параметров.
//Написать функцию fsum с переменным числом параметров, которая находит сумму чисел типа int по формуле: S=a1*a2+a2*a3+a3*a4+ . . . .
#include <iostream>
using namespace std;

int fsum(int amount, ...);

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
	int* ptr = &amount + 1;
	int s = 0, counter = 1, index = 0;
	int* sums = new int[amount / 2 + 1];
	while (amount--)
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
		sums[index] = *(ptr-1);
		index++;
	}
	for (int i = 0; i < index; i++)
	{
		s += sums[i];
	}
	delete[] sums;
	return s;
}
