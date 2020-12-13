#include <iostream>
using namespace std;

void arr(void);
void matrix(void);

int main()
{
	setlocale(LC_ALL, "rus");
	int ans;
	do//Организация меню через switch
	{
		cout << "Решение какой задачи Вы хотите увидеть?" << endl << "1. С динамическим массивом" << endl << "2. С динамической матрицей" << endl << "3. Выход" << endl << "Ваше решение: ", cin >> ans;
		switch (ans)
		{
		case 1: arr(); break;
		case 2: matrix(); break;
		case 3: ans = 0; break;
		default: cout << "Введите корректные данные" << endl;
			break;
		}
		cout << endl << "----------------------------------------" << endl << endl;
	} while (ans);

	return 0;
}


//Задан массив A из n элементов. Подсчитать, сколько раз встречается в нем максимальное число.
void arr()
{
	int n, max, counter = 0;
	cout << "Введите кол-во элементов массива: ", cin >> n;
	int* A = new int[n];
	cout << "Массив: ";
	for (int i = 0; i < n; i++)
	{
		A[i] = rand() % 20 - 10;
		cout << A[i] << " ";
		if (i == 0 || max < A[i])
			max = A[i];
	}
	cout << endl;

	for (int i = 0; i < n; i++)
	{
		if (max == A[i])
			counter++;
	}

	cout << "Максимальное число встречается " << counter << " раз(a)" << endl;

}

//Проверить, есть ли в матрице хотя бы одна строка, содержащая положительный элемент, и найти ее номер.
//Знаки элементов предыдущей строки изменить на противоположные.
void matrix()
{
	int rows, columns, counter = 0;
	cout << "Введите кол-во строк и столбцов матрицы ", cin >> rows >> columns;
	bool* ispositive = new bool[rows];
	for (int i = 0; i < rows; i++)
		ispositive[i] = false;
	int** matrix = new int* [rows];//Создание и заполнение матрицы
	for (int i = 0; i < rows; i++)
		matrix[i] = new int[columns];
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			matrix[i][j] = rand() % 20 - 17;
			cout << matrix[i][j] << "\t";
			if (matrix[i][j] > 0)//Выбор строк с полжительными элементами
				ispositive[i] = true;
		}
		cout << endl << endl;
	}

	for (int i = 0; i < rows; i++)//Замена знаков
	{
		if (ispositive[i])
		{
			for (int j = 0; j < columns; j++)
			{
				if (i!=0)
				{
					if (matrix[i-1][j] > 0)
						matrix[i-1][j] -= 2 * matrix[i-1][j];
					else if (matrix[i-1][j] < 0)
						matrix[i-1][j] += -2 * matrix[i-1][j];
				}
			}
		}
	}
	cout << endl << "----------------------------------------" << endl << endl;
	
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
			cout << matrix[i][j] << "\t";
		cout << endl << endl;
	}

	cout << "Номер(а) строк(и) с хотя бы одним положительным элементом: ";
	for (int i = 0; i < rows; i++)
	{
		if (ispositive[i])
			cout << i << " ";
	}

	for (int i = 0; i < rows; i++)//Освобождение памяти
		delete[] matrix[i];
	delete[] matrix;
}