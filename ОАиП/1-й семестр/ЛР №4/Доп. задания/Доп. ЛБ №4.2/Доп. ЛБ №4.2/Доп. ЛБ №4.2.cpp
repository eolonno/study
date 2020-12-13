#include <iostream> //Можно ли коробку размером a*b*c упаковать в посылку размером r*s*t? «Углом» укладывать нельзя.

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	cout << "Введите длину, ширину и высоту коробки: ";
	float a, b, c, r, s, t;
	cin >> a >> b >> c;
	cout << endl << "Введите длину, ширину и высоту посылки: ";
	cin >> r >> s >> t;
	if (a >= r && b >= s && c >= t)
		cout << endl << "В коробку можно вместить посылку.";
	else
		cout << endl << "В коробку нельзя вместить посылку.";


	return 0;
}

