//Дана целочисленная прямоугольная матрица. Определить номер первого из столбцов, содержащих хотя бы один нулевой элемент.
#include <iostream>
using namespace std;

int** builder(int*);
int num(int**, int*);
void output(int**, int*);

int main()
{
	setlocale(LC_CTYPE, "rus");
	int n;
	cout << "Введите число строк и столбцов матрицы: ", cin >> n;
	int** matrix = builder(&n);
	output(matrix, &n);
	if (num(matrix, &n) >= 0)
		cout << "Первый раз ноль встретился на " << num(matrix, &n) << " строке" << endl;
	else cout << "В матрице не найдено нулей" << endl;

	delete[] matrix;
	return 0;
}

int** builder(int* n)
{
	int** matrix = new int* [*n];
	for (int i = 0; i < *n; i++)
		*(matrix+i) = new int[*n];
	for (int i = 0; i < *n; i++)
	{
		for (int j = 0; j < *n; j++)
			*(*(matrix + i) + j) = rand() % 20 - 10;
	}
	return matrix;
}

int num(int** matrix, int* n)
{
	int str = -2;
	bool isNULL = false;
	for (int i = 0; i < *n; i++)
	{
		for (int j = 0; j < *n; j++)
		{
			if (*(*(matrix+i)+j) == NULL)
			{
				isNULL = true;
				str = i;
				break;
			}
		}
		if (isNULL)
			break;
	}
	return str+1;
}

void output(int** matrix, int* n)
{
	for (int i = 0; i < *n; i++)
	{
		for (int j = 0; j < *n; j++)
			cout << *(*(matrix+i)+j) << "\t";
		cout << endl;
	}

}