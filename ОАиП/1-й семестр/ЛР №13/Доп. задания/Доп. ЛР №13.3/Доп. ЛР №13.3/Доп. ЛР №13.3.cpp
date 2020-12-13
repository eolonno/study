//Для заданной матрицы размером 6 на 6 найти такие значения к, что k-я строка матрицы совпадает с k-м столбцом.
//Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "rus");
	const int N = 6;
	int A[N][N], B[N][N];
	for (int i = 0; i < N; i++)//Заполнение матрицы случайными числами за исключением третьей строки и третьего столбца
	{
		for (int j = 0; j < N; j++)
		{
			A[i][j] = rand() % 120 - 20;
			if (j==3)
				A[i][j] = i;
			if (i==3)
				A[i][j] = j;
		}
	}

	for (int i = 0; i < N; i++)//Вывод матрицы на экран
	{
		for (int j = 0; j < N; j++)
		{
			cout << A[i][j] << "\t";
		}
		cout << endl << endl;
	}

	int counter = 0, index;//Объявление счетчика, индекса k и показателя присутствия отрицательных чисел в строке
	bool negative[6] = { 0,0,0,0,0,0 };

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			for (int k = 0; k < N; k++)
			{
				for (int m = 0; m < N; m++)
				{
					if (A[i][j]==A[m][k] && i == k)//Нахождение искомого значения k
					{
						counter++;
						if (counter == 6)
							index = k + 1;
					}
				}
			}
			if (A[i][j] < 0)//Нахождение рядов в отрицательными значениями
				negative[i] = true;
		}
	}

	//Вывод ответов на экран
	cout << "-------------------------------" << endl;
	cout << "K = " << index << endl;
	cout << "-------------------------------" << endl;

	for (int i = 0; i < N; i++)
	{
		if (negative[i])
		{
			int sum = 0;
			for (int j = 0; j < N; j++)
				sum += A[i][j];
			cout << "Сумма числе в строке №" << i+1 << " равна " << sum << endl;
		}
	}

	return 0;
}