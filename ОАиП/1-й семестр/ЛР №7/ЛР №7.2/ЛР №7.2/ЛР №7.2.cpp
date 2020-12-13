#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	cout << "Факториал какого числа вы хотите вычилисть? ";
	int times, ans = 0;
	cin >> times;
	for (int i = 0; i < times; i++)
	{
		ans += i;
	}
	cout << "Ответ: " << ans;

	return 0;
}
