#include <iostream>
using namespace std;

void arr(void);
void matrix(void);

int main()
{
	setlocale(LC_CTYPE, "rus");
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

void arr()
{
	//Задан массив A из n элементов. Проверить, есть ли в нём отрицательные элементы. Если есть, найти наибольшее k, при котором A[k]<0.

	int n, max = -151, counter = 0, index;
	cout << "Введеите количество элементов массива: ", cin >> n;
	int* arr = new int[n];//Объявление динамического массива
	for (int i = 0; i < n; i++)//Заполнение динамического массива случайными числами
	{
		arr[i] = rand() % 150 - 50;
		cout << arr[i] << " ";
		if (arr[i] < 0)//Проверка на наличие отрицательных чисел
		{
			counter++;
			index = i;
		}
	}

	//Вывод ответа на экран
	cout << endl;
	if (counter)
		cout << "Наибольшее k, при котором A[k] < 0 равно " << index << endl;
	else
		cout << "Отрицательных чисел не найдено" << endl;

	delete[] arr;
}

void matrix()
{
	//Дана вещественная матрица размером 5x4. Переставляя ее строки и столбцы, добиться того, чтобы наибольший элемент (один из них) оказался в верхнем левом углу.

	cout << endl;
	double** matrix = new double*[5];
	double A[5][4];
	for (int i = 0; i < 5; i++)
	{
		matrix[i] = new double[4];
	}
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			matrix[i][j] = (double)(rand() % 100) / (double)100 + (double)(rand() % 100);
			A[i][j] = matrix[i][j];
		}
	}

	for (int i = 0; i < 5; i++)//Вывод матрицы на экран
	{
		for (int j = 0; j < 4; j++)
		{
			cout << matrix[i][j] << "\t";
		}
		cout << endl << endl;
	}

	int coords[2] = { 0,0 };
	double max = matrix[0][0];
	for (int i = 0; i < 5; i++)//Определение координат максимального отрицательного числа в матрице
	{
		for (int j = 0; j < 4; j++)
		{
			if (matrix[i][j] > max)
			{
				max = matrix[i][j];
				coords[0] = i, coords[1] = j;
			}
		}
	}

	//Манипуляции со строками и столбцами
	for (int i = 0; i < 4; i++)
	{
		matrix[0][i] = A[coords[0]][i];
		matrix[coords[0]][i] = A[0][i];
	}

	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 4; j++)
			A[i][j] = matrix[i][j];
	}

	for (int i = 0; i < 5; i++)
	{
		matrix[i][0] = A[i][coords[1]];
		matrix[i][coords[1]] = A[i][0];
	}

	cout << endl << "----------------------------------------" << endl << endl;
	for (int i = 0; i < 5; i++)//Вывод ответа на экран
	{
		for (int j = 0; j < 4; j++)
		{
			cout << matrix[i][j] << "\t";
		}
		cout << endl << endl;
	}

	for (int i = 0; i < 4; i++)
		delete[] matrix[i]; 
	delete[] matrix;
}