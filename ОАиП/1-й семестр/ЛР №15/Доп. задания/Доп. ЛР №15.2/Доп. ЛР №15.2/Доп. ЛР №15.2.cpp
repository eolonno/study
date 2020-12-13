//В соответствии со своим вариантом написать программу решения уравнения из лабораторной работы № 8.
//Операторы метода вычисления корня оформить в виде функции пользователя, уравнение также записать в виде функции пользователя.
//В основной программе предусмотреть ввод исходных данных, обращение к функциям и вывод результатов. Использовать указатель на функцию. 
#include <iostream>
using namespace std;

double func(double*);
double derfunc(double*);
void first(void);
void second(void);

int main()
{
	setlocale(LC_CTYPE, "ru");
	int ans;
	do
	{
		cout << "Каким методом вы хотите найти корень? " << endl << "1. Метод касательных" << endl << "2. Метод дихиотомии" << endl << "3. Выход" << endl << "Ваше решение: ", cin >> ans, cout << endl;;
		switch (ans)
		{
		case 1: first(); break;
		case 2: second(); break;
		case 3: ans = 0; break;
		default: cout << "Введите корректные данные" << endl;
			break;
		}
	} while (ans);


	return 0;
}

double func(double* x)
{
	return pow(*x, 3) + 2 * *x - 1;
}

double derfunc(double* x)
{
	return 3 * pow(*x, 2) + 2;
}

void first()
{
	cout << "Метод касательных: ";

	double e = 0.0001, a = 0, b = 1, x = a, x1 = a;

	if (func(&a) * derfunc(&a) > 0)
		x1 = a;
	else
		x1 = b;
	while (abs(x1 - x) > e)
	{
		x = x1;
		x1 = x - func(&x) / derfunc(&x);
	}
	cout << x << endl;
}

void second()
{
	double e = 0.0001, a = 5.5, b = 6.5, x = a, x1 = a;
	e = 0.0001, a = 0, b = 1;
	cout << "Метод дихиотомии: ";

	while (abs(a - b) > 2 * e)
	{
		x = (a + b) / 2;
		if (func(&x) * func(&a) <= 0)
			b = x;
		else
			a = x;
	}

	cout << x << endl;
}
