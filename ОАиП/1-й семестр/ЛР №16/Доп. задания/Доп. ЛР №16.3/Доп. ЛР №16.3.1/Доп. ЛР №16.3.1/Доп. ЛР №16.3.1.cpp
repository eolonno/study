//Дана целочисленная квадратная матрица. Определить сумму элементов в тех строках, которые не содержат отрицательных элементов.
#include <iostream>
using namespace std;

void output(int**, int*);
void sum(int**, bool*, int*);

int main()
{
	setlocale(LC_CTYPE, "rus");
	int n;
	cout << "Введите количество строк и столбцов: ", cin >> n;

	int** matrix = new int*[n];//создание матрицы
	for (int i = 0; i < n; i++)
		matrix[i] = new int[n];
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
			*(*(matrix + i) + j) = rand() % 10 - 2;
	}

	bool* IsNegative = new bool[n];//создание массива-показателя наличия отрицательных чисел
	for (int i = 0; i < n; i++)
		*(IsNegative + i) = NULL;
	output(matrix, &n);
	sum(matrix, IsNegative, &n);


	for (int i = 0; i < n; i++)//освобождение памяти
		delete[] matrix[i];
	delete[] matrix;
	return 0;
}

void output(int** matrix, int* rows)//вывод матрицы на экран
{
	for (int i = 0; i < *rows; i++)
	{
		for (int j = 0; j < *rows; j++)
			cout << *(*(matrix+i)+j) << '\t';
		cout << endl << endl;
	}
}

void sum(int** matrix, bool* IsNegative, int* rows)
{
	for (int i = 0; i < *rows; i++)//заполнение массива-показателя наличия отрицательных чисел
	{
		for (int j = 0; j < *rows; j++)
		{
			if (*(*(matrix+i)+j) <= 0)
				*(IsNegative + i) = true;
		}
	}

	for (int i = 0; i < *rows; i++)//поиск суммы чисел, при отсутствии отрицательных чисел в строке
	{
		int sum = 0;
		int negative = 0;
		for (int j = 0; j < *rows; j++)
		{
			sum += *(*(matrix + i) + j);
			if (*(IsNegative + i) == true)
				negative++;
			else if (j==*rows-1 && !negative)
				cout << "Сумма элементов " << i+1 << " строки равна: " << sum << endl;//вывод на экран ответа
		}
	}

}