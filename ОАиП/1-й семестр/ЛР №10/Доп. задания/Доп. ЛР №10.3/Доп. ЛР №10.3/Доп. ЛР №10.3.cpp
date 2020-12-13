#include <iostream>
using namespace std;

int main()
{
	//Ввести целое число A.Извлечь 2 бита числа A, начиная с пятого и вставить их в число B, начиная также с пятого бита. 

	setlocale(LC_CTYPE, "rus");
	char tmp[33];
	int A, B, n, p;
	cout << "Введите A: ", cin >> A;
	cout << "Введите B: ", cin >> B;

	_itoa_s(A, tmp, 2); cout << "Число A = " << tmp << endl;
	_itoa_s(B, tmp, 2); cout << "Число B = " << tmp << endl;

	if (A & (1 << 5)) {
		B |= (1 << 5);
	}
	else B &= ~(1 << 5);

	if (A & (1 << 6)) B |= (1 << 6);
	else B &= ~(1 << 6);
	_itoa_s(B, tmp, 2); cout << "B = " << tmp << endl;


	cout << "Введите p: ", cin >> p;
	cout << "Введите n: ", cin >> n;


	//Инвертировать в числе А n битов вправо от позиции p.

	for (int i = 0; i < n; i++) {

		A ^= (1 << p);
		p--;
	}
	_itoa_s(A, tmp, 2);
	cout << "A = " << tmp << endl;

	return 0;
}
