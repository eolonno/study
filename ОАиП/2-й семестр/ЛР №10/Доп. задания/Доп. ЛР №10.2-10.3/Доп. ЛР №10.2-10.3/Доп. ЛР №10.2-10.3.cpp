#include <algorithm>
#include <iostream>
#include <fstream>
#include <Windows.h>

using namespace std;

#define n 5


void dop4(int* arr, int counter, int* temp)
{
	for (int i = 0; i < n; ++i)
		cout << arr[i] << " ";
	cout << endl;
	if (counter == 26)
		*temp = arr[n - 1];
	if (next_permutation(arr, arr + n))
		dop4(arr, ++counter, temp);
}

int main()
{
	setlocale(LC_ALL, "");
	int counter = 0, temp;
	int* arr = new int[n];
	for (int i = 0; i < n; i++) {
		*(arr + i) = i + 1;
	}
	dop4(arr, counter, &temp);
	cout << endl;
	cout << "Последний элемент строки 26: " << temp << endl;
	delete[] arr;
	return 0;
}