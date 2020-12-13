#include<iostream>
using namespace std;

int main()
{

	//Извлечь 3 бита числа А, начиная с позиции n, и вставить в число В, начиная с позиции m.

	//setlocale(LC_CTYPE, "Russian");
	//char tmp[33];
	//int A, B, maskA,m,n;
	//cout << "Введите n и m" << endl;
	//cin >> n >> m;
	//cout << "Введите число А и число B" << endl;
	//cin >> A >> B;
	//_itoa_s(A, tmp, 2);
	//cout << "Число А в двоичном виде: " << tmp << endl;
	//maskA = (A >> n) & 7;
	//_itoa_s(B, tmp, 2);
	//cout << "Число B в двоичном виде: " << tmp << endl;
	//_itoa_s(B | (maskA << m), tmp, 2);
	//cout << "Измененное число B:" << tmp << endl;


	//Установить в ноль каждый третий значащий бит целого числа А.

	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, ch, n;
	cout << "Введите число " << endl;
	cin >> A;
	_itoa_s(A, tmp, 2);
	cout << tmp << endl;
	ch = strlen(tmp);
	n = 3;
	for (int i = ch; i >= 0; i--)
	{
		if (i == (ch - n))
		{
			tmp[i] = '0';
			n = n + 3;
		}
	}
	cout << tmp << endl;
	

	return 0;
}