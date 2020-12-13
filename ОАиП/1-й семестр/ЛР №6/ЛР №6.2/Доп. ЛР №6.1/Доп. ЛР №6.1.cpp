#include <iostream> //Используя перебор значений найти сумму целых положительных чисел, кратных 3 и меньших 200.
using namespace std;

int main()
{
	int sum = 0;
	for (int i = 0; i < 200; i++)
	{
		if (i % 3 == 0)
			sum += i;
	}
	cout << "Answer: " << sum << endl;

	return 0;
}