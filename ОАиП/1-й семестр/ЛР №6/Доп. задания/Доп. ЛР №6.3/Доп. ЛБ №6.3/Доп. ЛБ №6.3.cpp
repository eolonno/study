#include <iostream> //Дано  натуральное число n.  Получить его каноническое разложение (разложение на простые множители).

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");

	cout << "Введите число n: ";
	int n;
	cin >> n;
	int nfirst = n, intmdt = 1;
	int arr[5]{ 2,3,5,7,11 };

	bool per = true;
	int i = 4;
	cout << "n = ";
	while (per)
	{
		if (i == -1)
			i = 4;
		if (n % arr[i] == 0)
		{
			n /= arr[i];
			cout << arr[i] << " * ";
			intmdt *= arr[i];
		}
		i--;
		if (n % arr[0] != 0 && n % arr[1] != 0 && n % arr[2] != 0 && n % arr[3] != 0 && n % arr[4] != 0)
		{
			per = false;
			cout << nfirst / intmdt << endl;
		}
	}


	return 0;
}