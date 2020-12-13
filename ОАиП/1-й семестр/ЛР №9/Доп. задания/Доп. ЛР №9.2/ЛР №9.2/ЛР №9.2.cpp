//Подсчитать количество пар соседних элементов массива с одинаковыми значениями.
#include <iostream>

using namespace std;

int main()
{
	int arr[10], counter = 0;
	for (int i = 0; i < 10; i++)
		arr[i] = rand() % 3;
	for (int i = 0; i < 10; i++)
	{
		if (arr[i] == arr[i + 1])
			counter++;
	}

	cout << counter << endl;
	return 0;
}