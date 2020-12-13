#include <iostream> //ННайти  в  последовательности  n целых чисел и вывести порядковый номер первого отрицательного элемента.
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	float seq[] = { 1,2,3.4,5,-6.7,284,-48.56 };
	int counter = 0, sum = 0;

	for (int i = 0; i < 7; i++)
	{
		if (seq[i] == (int)seq[i])
		{
			counter += 1;
		}
		if (seq[i] < 0)
		{
			cout << "Номер первого отрицательного элемента: " << i + 1 << endl;
			break;
		}

	}
	cout << "Целых чисел: " << counter << endl;

	return 0;
}

