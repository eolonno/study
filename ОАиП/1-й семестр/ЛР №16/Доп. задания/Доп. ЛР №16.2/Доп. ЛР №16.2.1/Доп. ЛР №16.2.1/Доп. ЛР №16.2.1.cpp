//Проверить, есть ли в матрице хотя бы одна строка, содержащая положительный элемент, и найти ее номер. Знаки элементов предыдущей строки изменить на противоположные.
#include <iostream>
using namespace std;

int** matrixBuilder(int, int);
bool* isPositiveBuilder(int, int, int**);
void output(int**, int, int);
int** change(int, int, bool*, int**);

int main()
{
	setlocale(LC_CTYPE, "rus");
	int rows, columns, counter = 0;
	cout << "Введите кол-во строк и столбцов матрицы ", cin >> rows >> columns;
	int** matrix = matrixBuilder(rows, columns);
	output(matrix, rows, columns);
	bool* IsPositive = isPositiveBuilder(rows, columns, matrix);
	change(rows, columns, IsPositive, matrix);
	output(matrix, rows, columns);

	cout << "Номер(а) строк(и) с хотя бы одним положительным элементом: ";
	for (int i = 0; i < rows; i++)
	{
		if (*(IsPositive+i))
			cout << i << " ";
	}

	for (int i = 0; i < rows; i++)//Освобождение памяти
		delete[] matrix[i];
	delete[] matrix;

	return 0;
}

int** matrixBuilder(int rows, int columns)
{
	int** matrix = new int* [rows];//Создание и заполнение матрицы
	for (int i = 0; i < rows; i++)
		matrix[i] = new int[columns];
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
			matrix[i][j] = rand() % 20 - 17;
	}

	return matrix;
}

bool* isPositiveBuilder(int rows, int columns, int** matrix)
{
	bool* ispositive = new bool[rows];
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			if (matrix[i][j] > 0)//Выбор строк с полжительными элементами
				ispositive[i] = true;
		}
	}
	return ispositive;
}

int** change(int rows, int columns, bool* Ispositive, int** matrix)
{
	for (int i = 0; i < rows; i++)//Замена знаков
	{
		if (Ispositive[i])
		{
			for (int j = 0; j < columns; j++)
			{
				if (i != 0)
				{
					if (matrix[i - 1][j] > 0)
						matrix[i - 1][j] -= 2 * matrix[i - 1][j];
					else if (matrix[i - 1][j] < 0)
						matrix[i - 1][j] += -2 * matrix[i - 1][j];
				}
			}
		}
	}
	return matrix;
}

void output(int** matrix, int rows, int columns)
{
	cout << endl << "----------------------------------------" << endl << endl;
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
			cout << matrix[i][j] << "\t";
		cout << endl << endl;
	}
}