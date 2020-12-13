//Даны массивы A и B, состоящие из n элементов. Построить массив S, каждый элемент которого равен сумме соответствующих элементов массивов A и B.
#include<iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "ru");
	const int n = 10;
	int A[n], B[n], S[n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = 0 + rand() % 20;
		cout << *(A + i) << " ";
	}
	cout << " - Массив A " << endl;

	for (int i = 0; i < n; i++)
	{
		*(B + i) = 0 + rand() % 20;
		cout << *(B + i) << " ";
	}
	cout << " - Массив B " << endl;
	
	for (int i = 0; i < n; i++)
	{
		*(S + i) = *(A + i) + *(B + i);
		cout << *(S + i) << " ";

	}
	cout << " - Массив S " << endl;


	return 0;
}