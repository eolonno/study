//Все четные элементы целочисленного массива K(n) поместить в массив L(n), а нечетные – в массив М(n). Подсчитать количество тех и других.
#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	int k[11], l[11], m[11], counterc = 0, countern = 0;

	for (int i = 0; i < 11; i++)
	{
		k[i] = rand() % 99;
		if (k[i]%2==0)
		{
			counterc++;
			l[i] = k[i];
			cout << "Четное: " << l[i] << endl;
		}
		else if (k[i] % 2 == 1)
		{
			countern++;
			m[i] = k[i];
			cout << "Нечетное: " << m[i] << endl;
		}
	}

	cout << "Кол-во четных: " << counterc << endl << "Кол-во нечетных: " << countern << endl;
	return 0;
}