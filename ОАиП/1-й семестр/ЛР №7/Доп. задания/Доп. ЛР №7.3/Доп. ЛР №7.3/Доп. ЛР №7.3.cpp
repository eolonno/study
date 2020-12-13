#include <iostream> //Найти  в  последовательности  n чисел с плавающей точкой количество элементов стоящих  между   минимальным  и  максимальным значениями.
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	float seq[] = { 1.56,2.6,3.45,5.98,-6.7,28.4,-48.56 };
	float min = seq[0], max = seq[0], counter = 0;

	for (int i = 0; i < 7; i++)
	{
		if (seq[i] >= max)
			max = seq[i];
		if (seq[i] <= min)
			min = seq[i];
	}

	for (int i = 0; i < 7; i++)
	{
		if (seq[i] == min || seq[i] == max)
			counter++;
	}
	cout << 7-counter << endl;

	return 0;
}