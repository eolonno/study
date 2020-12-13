#include <iostream> 
using namespace std;

int main()
{
	//Вывести 6 бит целого числа А, начиная со 2 - ого.

	/*setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, maskA;
	cout << "Введите число A " << endl;
	cin >> A;
	_itoa_s(A, tmp, 2);
	cout << "Число A в двоичном виде " << tmp << endl;
	maskA = (A >> 2) & 63;
	_itoa_s(maskA, tmp, 2);
	cout << tmp << endl;*/


	//Инвертировать в числе А n битов влево от позиции p.

	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, ch, p, n, maskA;
	cout << "Введите число A " << endl;
	cin >> A;
	_itoa_s(A, tmp, 2);
	cout << "Число A в двоичном виде " << tmp << endl;
	cout << "Введите количество битов n: " << endl;
	cin >> n;
	cout << "Введитие позицию p: " << endl;
	cin >> p;
	for (int i = strlen(tmp)-p--; i > p + n; i--)
	{
		if (tmp[i] == '1') tmp[i] = '0';
		else tmp[i] = '1';
	}
	cout << "Измененное число A: " << tmp << endl;
	
	return 0;
}