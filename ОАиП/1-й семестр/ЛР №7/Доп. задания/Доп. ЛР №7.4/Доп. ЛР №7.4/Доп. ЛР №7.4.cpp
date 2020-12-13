#include <iostream> //В последовательности найти число чередований знака, то есть число переходов с минуса на плюс или с плюса на минус. 

using namespace std;

int main()
{
	int eq[] = { 0, -2, 0, -10, 2, -1, 0, 0, 3, 2, -3 }, counter = 0;
	for (int i = 0; i < 11; i++)
	{
		if (eq[i] > 0 && eq[i + 1] < 0)
			counter++;
		else if (eq[i] < 0 && eq[i + 1] > 0)
			counter++;
		else continue;
	}

	cout << counter << endl;

	return 0;
}