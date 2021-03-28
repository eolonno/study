#include "Auxil.h"                            // вспомогательные функции 
#include <iostream>
#include <ctime>
#include <locale>
#define  CYCLE  1000000                       // количество циклов  
int main()
{
	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;
	setlocale(LC_ALL, "rus");
	auxil::start();                          // старт генерации 
	                           // фиксация времени 
	for (int j = 1; j <= 10; j++) {
		t1 = clock();
		for (int i = 0; i < j*CYCLE; i++)
		{
			av1 += (double)auxil::iget(-100, 100); // сумма случайных чисел 
			av2 += auxil::dget(-100, 100);         // сумма случайных чисел 
		}
		t2 = clock();                            // фиксация времени 
		std::cout << std::endl << "количество циклов:         " << CYCLE * j;
		std::cout << std::endl << "среднее значение (int):    " << av1 / (CYCLE*j);
		std::cout << std::endl << "среднее значение (double): " << av2 / (j*CYCLE);
		std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
		std::cout << std::endl << "                  (сек):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		std::cout << std::endl;
		av1 = 0;
		av2 = 0;
	}
	return 0;
}
