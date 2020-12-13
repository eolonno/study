#include <iostream>
#include <ctime>
using namespace std;

void arr(void);
void matrix(void);
int Stroki(int**, int, int);
int Max(int**, int, int);
int Second(int**, int, int, int);
int Cnt(int**, int, int, int);
void Search(int**, int, int);

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


//Задан массив A из n элементов. Найти количество элементов этого массива, больших среднего арифметического всех его элементов.
void arr()
{
	int n, counter = 0;
	float avg = 0;
	cout << "Введите число n элементов массива: ", cin >> n;
	float* A = new float[n];//Создание и заполнение массива 
	cout << "Массив: ";
	for (int i = 0; i < n; i++)
	{
		A[i] = rand() % 10;
		cout << A[i] << " ";
		avg += A[i];
	}
	avg /= n;//Вычисление среднего арифметического

	for (int i = 0; i < n; i++)//Подсчет чисел, которые больше среднего арифметического всех чисел массива
	{
		if (A[i] > avg)
			counter++;
	}

	cout << endl << "Количество элементов массива больше среднего арифметического всех его элементов: " << counter;//Вывод ответа

}

//дана целочисленная прямоугольная матрица. определить количество строк, не содержащих ни одного нулевого элемента и максимальное из чисел, 
//встречающихся в заданной матрице более одного раза.

void matrix()
{
	int** mas = NULL, n, m;

	cout << "Введите кол-во строк и столбцов матрицы: ";
	cin >> n;
	m = n;

	mas = new int* [n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = new int[m];
	}

	cout << "\nМатрица:\n";

	srand((int)time(NULL));

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			mas[i][j] = rand() % 10;
			cout << mas[i][j] << "\t";
		}
		if (i != n)
			cout << "\n\n";
	}

	cout << "Строк с нулем: " << Stroki(mas, n, m);

	Search(mas, n, m);

	delete[] mas;
}


int Stroki(int** arr, int n, int m)
{
	int res = 0, fl;

	for (int i = 0; i < n; i++)
	{
		fl = 0;
		for (int j = 0; j < m; j++)
		{
			if (arr[i][j] == 0)
			{
				fl = 1;
			}
		}
		if (!fl) res++;
	}
	return res;
}

int Cnt(int** arr, int n, int m, int elem)
{
	int cnt = 0;

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (arr[i][j] == elem)
				cnt++;
		}
	}
	return cnt;
}


int Max(int** arr, int n, int m)
{
	int max = arr[0][0];

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (arr[i][j] > max)
				max = arr[i][j];
		}
	}
	return max;
}

int Second(int** arr, int n, int m, int max)
{
	int second = max - 1;

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (arr[i][j] >= second && arr[i][j] < max)
			{
				second = arr[i][j];
			}
		}
	}
	return second;
}


void Search(int** arr, int n, int m)
{
	int max, sec, cnt = 0;

	bool flag = false;

	max = Max(arr, n, m);
	for (int i = 0; i < n * m; i++)
	{
		sec = Second(arr, n, m, max);
		cnt = Cnt(arr, n, m, max);
		if (cnt > 1)
		{
			cout << "\nЧисло " << max;
			cout << " встречается " << cnt << " раз(а)";
			flag = true;
			break;
		}
		else
			max = sec;
	}

	if (!flag)
		cout << "\nНе найдено макcимального числа, повторяющегося хотя бы дважды.";
}