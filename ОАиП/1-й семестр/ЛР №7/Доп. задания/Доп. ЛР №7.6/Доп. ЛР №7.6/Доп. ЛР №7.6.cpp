//Найти  в  последовательности  n целых чисел  максимальный положительный и максимальный отрицательный элементы.
#include <iostream> 
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	float seq[] = { 1,-2,3.45,5.98,-6,28,-48 };
	float max0, max = seq[0], counter = 0;
	for (int i = 0; i < 7; i++)
	{
		if (seq[i] < 0)
			max0 = seq[i];
	}
	for (int i = 0; i < 7; i++)
	{
		if (seq[i] >= max && seq[i]>0)
			max = seq[i];
		if (seq[i] >= max0 && seq[i]<0)
			max0 = seq[i];
	}

	cout << "Макчимальное положительное число: " << max << endl << "Максимальное отрицательное: " << max0 << endl;

	return 0;
}


