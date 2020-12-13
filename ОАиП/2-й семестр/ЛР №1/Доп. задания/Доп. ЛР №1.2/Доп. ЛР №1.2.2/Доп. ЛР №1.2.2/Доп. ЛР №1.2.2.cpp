//Написать функцию kvadr с переменным числом параметров, которая определяет количество чисел, являющихся точными квадратами (2, 4, 9, 16,…) типа int. 
#include <iostream>
using namespace std;

void kvadr(int, ...);

int main()
{
	setlocale(LC_CTYPE, "rus");
	kvadr(2, 4, 12);
	kvadr(4, 84, 256, 45, 121);
	kvadr(3, 12, 9, 16);

	return 0;
}

void kvadr(int amount, ...)
{
	cout << "Числа, которые являются точными квадратами: ";
	int* num = &amount + 1;
	for (int i = 0; i < amount; i++)
	{
		if ((float)sqrt(*(num + i)) == sqrt(*(num + i)))
			cout << *(num + i) << ' ';
	}
	cout << endl;

}