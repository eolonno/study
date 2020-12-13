#include <iostream>
using namespace std;

int main()
{
	//Извлечь 5 битов числа A, начиная со второго и вставить их в число B, начиная с третьего бита.

	unsigned char A = 53;//00110101
	unsigned char B = 47;//00101111
	unsigned char mask = 124;//01111100

	A &= mask;
	A <<= 1;//01101000
	mask <<= 1;
	A &= mask;//01101000
	mask >>= 5;
	B &= mask;//00000111
	B |= A;//01101111   (111)

	cout << (int)B << endl;



	//Включить в числе А n битов вправо от позиции p.

	unsigned char a = 144;//10010000
	int pos = 2, n = 3;
	unsigned char Mask = 0, formask = 1;

	for (int i = 0; i < 3; i++)
	{
		Mask |= formask;
		Mask <<= 1;
	}
	Mask <<= pos - 1;

	a |= Mask;//10011100  (156)

	cout << (int)a;


	return 0;
}