#include <iostream> //Найти  в  последовательности  n целых чисел и вывести значение суммы четных элементов.
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	float seq[] = { 1,2,3.4,5,6.7,284,48.56 };
	int chetchik = 0, sum = 0;

	for (int i = 0; i < 7; i++)
	{
		if (seq[i] == (int)seq[i])
		{
			chetchik += 1;
			if ((int)seq[i] % 2 == 0)
			{
				sum += seq[i];
			}
		}
		
	}
	cout << "Целых чисел: " << chetchik << endl << "Сумма четных чисел: " << sum << endl;

	return 0;
}

