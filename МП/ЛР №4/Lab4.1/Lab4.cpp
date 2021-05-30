#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"

int main()
{
	setlocale(LC_ALL, "rus");
	clock_t t1 = 0, t2 = 0, t3, t4;
	char x[301], y[251];

	srand(time(0));

	for (int i = 0; i < 300; i++)
	{
		x[i] = ('a' + rand() % ('z' - 'a'));
		std::cout << x[i];
	}

	std::cout << std::endl;

	for (int i = 0; i < 250; i++)
	{
		y[i] = ('a' + rand() % ('z' - 'a'));
		std::cout << y[i];
	}

	int  lx = sizeof(x) - 1, ly = sizeof(y) - 1;
	std::cout << std::endl;
	std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
	std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---" << std::endl;
	for (int i = 0; i < 250; i++)
	{
		if (i < 13) { t1 = clock(); levenshtein_r(i, x, i, y); t2 = clock(); }
		t3 = clock(); levenshtein(i, x, i, y); t4 = clock();
		std::cout << std::right << std::setw(2) << i << "/" << std::setw(3) << i
			<< "        ";
		if (i < 13) std::cout << std::left << std::setw(10) << (t2 - t1);
		else std::cout << std::left << std::setw(10) << "null";
		std::cout << "   " << std::setw(10) << (t4 - t3) << std::endl;
	}
	system("pause");
	return 0;
}