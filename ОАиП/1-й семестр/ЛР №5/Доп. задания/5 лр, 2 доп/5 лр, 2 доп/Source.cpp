#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	//2

	int p, q, n = 0;
	cout << "¬ведите доход магазина за первый день" << endl;
	cin >> p;
	cout << "¬ведите желаемый доход " << endl;
	cin >> q;
	while (p < 10000) {
		n++;
		p = p * 1.3;

		if (p > q) {
			cout << "ћагазин достигнет желаемого дохода через " << n << " дней" << endl;
			cout << p << " ƒоход магазина в день, когда фирма достигнет желаемого дохода " << endl;
			break;
		}


	}
}