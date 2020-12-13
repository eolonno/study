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


//В одномерном массиве, состоящем из n вещественных элементов, вычислить номер минимального элемента массива и сумму элементов массива, расположенных между первым
//и вторым отрицательными элементами.
void arr()
{
	int n, min, findex = 0, sindex = 0, counter = 0, minindex = 0;
	float sum = 0;
	bool incycle = 0;
	cout << "Введите количество n элементов: ", cin >> n;
	cout << endl;
	float* arr = new float[n];
	cout << "Массив: ";
	for (int i = 0; i < n; i++)
	{
		arr[i] = (float)(rand() % 200) / (float)200 + (float)(rand() % 200) - 100;//Заполнение массива
		cout << arr[i] << " ";
		if (i == 0)
			min = arr[i];
		if (arr[i] <= min)//Поиск минимального числа
		{
			min = arr[i];
			minindex = i;
		}
	}

	for (int i = 0; i < n; i++)
	{
		if (arr[i] < 0)//Подсчет чисел между двумя отрицательными числами
		{
			findex = ++i;
			for (int j = ++i; j < n; j++)
			{
				incycle = true;
				if (j >= 0)
					counter++;
				else break;
			}
		}
		if (incycle)
			break;
	}

	for (int i = findex; i <= counter; i++)//Подсчет суммы
		sum += arr[i];

	//Вывод ответа
	cout << endl << "Номер минимального элемента массива: " << minindex << endl << "Сумма элементов, расположенных между первым и вторым отрицательными элементами массива: " << sum << endl;

	delete[] arr;
}


//Дана целочисленная прямоугольная матрица. Определить количество столбцов, не содержащих ни одного нулевого элемента.
void matrix()
{
	int rows, columns, counter = 0;
	cout << "Введите кол-во строк и столбцов матрицы ", cin >> rows >> columns;
	bool* isnull = new bool[rows];//Заполнение массива, отвечающего за присутствие нуля
	for (int i = 0; i < rows; i++)
		isnull[i] = false;
	int** matrix = new int* [rows];//Создание и заполнение матрицы
	for (int i = 0; i < rows; i++)
		matrix[i] = new int[columns];
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			matrix[i][j] = rand() % 20 - 10;
			cout << matrix[i][j] << "\t";
		}
		cout << endl << endl;
	}

	for (int i = 0; i < rows; i++)//Поиск элементов, равных нулю
	{
		for (int j = 0; j < columns; j++)
		{
			if (matrix[i][j] == 0)
				isnull[i] = true;
		}
	}

	for (int i = 0; i < rows; i++)//Подсчет элементов, равных нулю
	{
		if (!isnull[i])
			counter++;
	}

	cout << "Кол-во столбцов, не содержащих ни одного нулевого элемента: " << counter << endl;

	for (int i = 0; i < rows; i++)//Освобождение памяти
		delete[] matrix[i];
	delete[] matrix;
}