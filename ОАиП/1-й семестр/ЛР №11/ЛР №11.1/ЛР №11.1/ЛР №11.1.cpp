//Даны массивы A и B, состоящие из n элементов. Построить массив S, каждый элемент которого равен сумме соответствующих элементов массивов A и B.

#include <iostream>

using namespace std;

int main()
{
	int a[10], b[10], s[10];
	for (int i = 0; i < 10; i++)
	{
		a[i] = rand() % 100;
		b[i] = rand() % 100;
	}


	for (int i = 0; i < 10; i++)
	{
		s[i] = *(a + i) + *(b + i);
		cout << s[i] << endl;
	}

	return 0;
}