//Дана действительная матрица A(N, N) . Найти сумму  и  мах  значение  среди элементов, расположенных в заштрихованной части матрицы
#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_CTYPE, "rus");
	const int N = 5;
	int A[N][N], counter = 0, sum = 0;
	for (int i = 0; i < N; i++)//Заполнение матрицы случайными числами
	{
		for (int j = 0; j < N; j++)
		{
			A[i][j] = rand() % 100;
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

	for (int i = 0; i < N; i++)//Перебор матрицы с заполнениями переменных суммы и счетчика нужных чисел
	{
		for (int j = 0; j < N; j++)
		{
			if (i==0 || i==4)
			{
				sum += A[i][j];
				counter++;
			}
			if (i == 1 || i == 3)
			{
				if(j == 1 || j == 2 || j == 3)
					sum += A[i][j];
					counter++;
			}
			if (i == 2 && j == 2)
			{
				sum += A[i][j];
				counter++;
			}

		}
	}
	cout << "---------------------------------------------------" << endl;
	cout << "Сумма взятых элементов равна " << sum << endl;
	cout << "Среднее  арифметическое взятых эелементов равно " << sum / counter << endl;
	cout << "---------------------------------------------------" << endl;

	return 0;
}