//Найти  в  последовательности  n целых чисел сумму положительных и произведение отрицательных.
#include <iostream> 
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	float seq[] = { -1,2,-3,5,-6.7,284,-48.56 };
	int counter = 0, sum = 0, pr = 1;

	for (int i = 0; i < 7; i++)
	{
		if (seq[i] == (int)seq[i])
		{
			if (seq[i]<0)
			{
				pr *= seq[i];
			}
			else if (seq[i]>0)
			{
				sum += seq[i];
			}
		}

	}
	cout << "Сумма положительных: " << sum << endl << "Произведение отрицательных: " << pr << endl;

	return 0;
}

