#include <iostream>
#include <cmath>
#include <Windows.h>
using namespace std;

template <typename T>
T modpow(T base, T exp, T modulus) {
	base %= modulus;
	T result = 1;
	while (exp > 0) {
		if (exp & 1) result = (result * base) % modulus;
		base = (base * base) % modulus;
		exp >>= 1;
	}
	return result;
}

uint64_t modinv(uint64_t u, uint64_t v)
{
	uint64_t inv, u1, u3, v1, v3, t1, t3, q;
	int64_t iter;
	u1 = 1;
	u3 = u;
	v1 = 0;
	v3 = v;
	iter = 1;
	while (v3 != 0)
	{
		q = u3 / v3;
		t3 = u3 % v3;
		t1 = u1 + q * v1;
		u1 = v1;
		v1 = t1;
		u3 = v3;
		v3 = t3;
		iter = -iter;
	}
	if (u3 != 1)
		return  0;
	if (iter < 0)
		inv = v - u1;
	else
		inv = u1;
	return inv;
}

int main()
{
	setlocale(LC_ALL, "RUSSIAN");

	//генерация ключей
	int p = 31;
	cout << "Первое простое число: " << p << endl;
	int q = 7;
	cout << "Второе простое число: " << q << endl;
	int n = p * q;
	cout << "Произведение простых чисел: " << n << endl;

	int f = (p - 1) * (q - 1);
	cout << "Функция Эйлера: " << f << endl;
	int e = 47;
	cout << "Открытая экспонента: " << e << endl;

	//int d = pow(e, -1);
	//double temp_d = pow(e, -1);
	//int d = (int)temp_d % f;

	int d = modinv(e, f);

	cout << "Секретная экспонента: " << d << endl;

	//ключи из таблицы(строка 10)
	e = 11;
	n = 779;
	d = 131;

	//шифрование
	int m = 100;			 //текст для зашифровки

	int c = modpow(m, e, n); //шифротекст 
	cout << "Зашифрованное сообщение: " << c << endl;

	//дешифрование
	/*double temp_de_m = pow(c, d);
	int de_m = (int)temp_de_m % n;*/
	int de_m = modpow(c, d, n);
	cout << "Расшифрованное сообщение: " << de_m << endl;
	cout << endl << endl << endl;
}



