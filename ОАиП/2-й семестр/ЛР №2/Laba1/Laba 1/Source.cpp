#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#define ROW 3
#define COLUMN 3
#define SIZE 5
using namespace std;
//   Задание 1


// Создание матрицы и запись ее в файл "Matrix.txt"
float CreateF()	
{
	errno_t err;
	float matrix[ROW][COLUMN];
	FILE* fp;
	err = fopen_s(&fp, "Matrix.txt", "w");
	if (err != 0)
	{
		perror("Невозможно создать файл\n");
		return EXIT_FAILURE;
	}
	for (int i = 0; i < ROW; i++)
	{
		for (int j = 0; j < COLUMN; j++)
		{
			*(*(matrix + i) + j) = 1 + rand() % 100;
			fprintf(fp, "%f\t", *(*(matrix + i) + j));

		}
		fprintf(fp, "\n");
	}
	printf("%s", "Матрица записана в файл 'Matrix.txt'\n");
	fclose(fp);

}

//Запись матрицы из файла "Matrix.txt" в файл "Result.txt"
float RecordF()
{
	errno_t errM;
	errno_t errR;
	float arr[ROW][COLUMN];
	int k = 0;
	FILE* fr;
	FILE* fm;

	printf("%s", "Введите номер строки: ");
	scanf_s("%d", &k);
	if (k >= ROW || k < 0)
	{
		printf("Такой строки не существует");
		exit(1);
	}

	errM = fopen_s(&fm, "Matrix.txt", "r");
	if (errM != 0)
	{
		perror("Невозможно создать файл\n");
		return EXIT_FAILURE;
	}

	errR = fopen_s(&fr, "Result.txt", "w");
	if (errR != 0)
	{
		perror("Невозможно создать файл\n");
		return EXIT_FAILURE;
	}

	for (int i = 0; i < ROW; i++)
	{
		for (int j = 0; j < COLUMN; j++)
			fscanf_s(fm, "%f", &arr[i][j]);

	}

	printf("%s", "Элементы считаны с файла 'Matrix.txt'\n");
	fclose(fm);

	for (int i = 0; i < COLUMN; i++)
	{
		fprintf(fr, "%f\t", arr[k][i]);
	}

	printf("%s", "Строка записана в файл 'Result.txt'");
	fclose(fr);


}   


//   Задание 2

int Task2()
{
	int arrD[ROW][SIZE];
	FILE* fA, * fB, * fC, * fD;
	errno_t errA, errB, errC, errD;
	errA = fopen_s(&fA,"FileA.txt","r");
	errB = fopen_s(&fB, "FileB.txt", "r");
	errC = fopen_s(&fC, "FileC.txt", "r");
	errD = fopen_s(&fD, "FileD.txt", "w");

	if (errA != 0 || errB != 0 || errC != 0 || errD!=0)
	{
		perror("Невозможно создать файл\n");
		return EXIT_FAILURE;

	}

	for (int i = 0; i < ROW; i++)
	{
		for (int j = 0; j < SIZE; j++)
		{
			if (i == 0) {
				fscanf_s(fA, "%d", &arrD[i][j]);
			}
			else if (i==1)
			{
				fscanf_s(fB, "%d", &arrD[i][j]);
			}
			else if (i==2)
			{
				fscanf_s(fC, "%d", &arrD[i][j]);
			}
		}

	}

	int min[SIZE];
	for (int i = 0; i < SIZE; i++)
	{
		min[i] = arrD[1][i];

	}

	for (int i = 0, j = 0; j < SIZE; i++)
	{
		if (i == ROW)
		{
			
				j++;
				i = 0;
				if (j >= SIZE)
					break;
			
			
		}

		if (min[j] > arrD[i][j])
		{
			min[j] = arrD[i][j];

		}
	}

	for (int i = 0; i < SIZE; i++)
	{
		fprintf(fD, "%d", min[i]);
		fprintf(fD, "%s", " ");
	}


	printf("%s", "Числа записаны в файл 'FileD.txt'\n");
	fclose(fA);
	fclose(fB);
	fclose(fC);
	fclose(fD);

}




int main()
{
	setlocale(LC_CTYPE, "Russian");
	
	int n;
	cout << "Введите номер задания" << endl, cin >> n;
	switch (n)
	{
	case 1:
		CreateF();
		RecordF();
		break;

	case 2:	
		Task2();
		break;

	default:
		cout << "Такого задания у меня нет(" << endl;
	}

	
	return 0;
}