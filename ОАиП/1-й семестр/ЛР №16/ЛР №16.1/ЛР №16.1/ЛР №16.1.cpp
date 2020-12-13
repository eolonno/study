//Программа первого задания должна использовать динамические массивы, функции и ссылки. 
//Дана целочисленная прямоугольная матрица. Определить количество строк, содержащих хотя бы один нулевой элемент.

#include <iostream>
using namespace std;

void checker(int* rows, bool* bd, int* counter);

int main()
{
	setlocale(LC_CTYPE, "rus");
	int rows = rand() % 50 + 1, columns = rand() % 50 + 1;
	int** matrix = new int* [rows];
	for (int i = 0; i < rows; i++)
	{
		matrix[i] = new int[columns];
	}
	bool* bd = new bool[rows];
	for (int i = 0; i < rows; i++)
		bd[i] = 0;

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			matrix[i][j] = rand() % 20 - 10;
			if (matrix[i][j]==0)
				bd[i] = true;
		}
	}

	int counter = 0;
	checker(&rows, bd, &counter);

	cout << "Количество строк, имеющих хотя бы один нулевой элемент " << counter << endl;

	for (int i = 0; i < rows; i++)
		delete[] matrix[i];
	delete[] matrix;
	delete[] bd;
	return 0;
}

void checker(int* rows, bool* bd, int* counter)
{
	for (int i = 0; i < *rows; i++)
	{
		if (*(bd+i) == 1)
			*counter += 1;
	}
}
