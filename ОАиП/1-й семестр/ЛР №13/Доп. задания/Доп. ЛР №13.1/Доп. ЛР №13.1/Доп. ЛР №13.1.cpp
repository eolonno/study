//Путем перестановки элементов квадратной вещественной матрицы добиться того, чтобы ее максимальный элемент находился в левом верхнем углу,
//следующий по величине - в позиции (2,2), следующий по величине  в позиции (3,3) и т. д., заполнив таким образом всю главную диагональ.
#include <iostream>
using namespace std;

int main()
{
	const int N = 3;
	double A[N][N], B[N][N];//Объявление матрицы и массива с координатами всех чисел по убыванию, а также заполнение матрицы случайными числами от 1 до 100
	int k = 0;
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++, k += 3)
		{
			A[i][j] = (double)(rand() % 100) / (double)100 + (double)(rand() % 100);
			B[i][j] = A[i][j];
		}
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++, k += 3)
		{
			cout << A[i][j] << "\t";
		}
		cout << endl;
	}
	cout << "---------------------------" << endl;

	double max[N];
	for (int i = 0; i < N; i+=3)
		max[i] = -1;
	int coords[N] = { 0,0 };


	for ( int i = 0; i < N; i++)//Определение первого максимального числа
	{
		for (int j = 0; j < N; j++)
		{
			if (A[i][j] > max[0])
			{
				max[0] = A[i][j];
				coords[0] = i;
				coords[1] = j;
			}
		}
	}
	for (int i = 0; i < N; i++)//Приравнивание двух матриц
	{
		for (int j = 0; j < N; j++, k += 3)
			B[i][j] = A[i][j];
	}
	A[0][0] = B[coords[0]][coords[1]];//Замена значений двух матриц
	A[coords[0]][coords[1]] = B[0][0];
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++, k += 3)
			B[i][j] = A[i][j];
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (A[i][j] < max[0] && A[i][j] > max[1])
			{
				max[1] = A[i][j];
				coords[0] = i;
				coords[1] = j;
			}
		}
	}
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++, k += 3)
			B[i][j] = A[i][j];
	}
	A[1][1] = B[coords[0]][coords[1]];
	A[coords[0]][coords[1]] = B[1][1];
	

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (A[i][j] < max[0] && A[i][j] < max[1] && A[i][j] > max[2])
			{
				max[2] = A[i][j];
				coords[0] = i;
				coords[1] = j;
			}
		}
	}
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++, k += 3)
			B[i][j] = A[i][j];
	}
	A[2][2] = B[coords[0]][coords[1]];
	A[coords[0]][coords[1]] = B[2][2];

	for (int i = 0; i < N; i++)//Вывод ответа
	{
		for (int j = 0; j < N; j++)
		{
			cout << A[i][j] << "\t";
		}
		cout << endl;
	}


	return 0;
}