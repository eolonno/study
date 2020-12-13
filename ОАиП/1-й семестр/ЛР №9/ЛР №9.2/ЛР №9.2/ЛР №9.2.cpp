//Поменять местами минимальный и максимальный элементы массива. 
#include <iostream>

using namespace std;

int main()
{
	int arr[10];

	for (int i = 0; i < 10; i++)
	{
		arr[i] = rand() % 99;
		cout << arr[i] << " ";
	}
	int max = arr[0], min = arr[0], mini = 0, maxi = 0;

	for (int i = 0; i < 10; i++)
	{
		if (arr[i]>=max)
		{
			maxi = i;
			max = arr[i];
		}
		if (arr[i]<=min)
		{
			mini = i;
			min = arr[i];
		}
	}

	cout << endl;

	arr[mini] = max;
	arr[maxi] = min;
	
	for (int i = 0; i < 10; i++)
	{
		cout << arr[i] << " ";
	}


	return 0;
}