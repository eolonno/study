#include <iostream>
#include <iomanip>

using namespace std;

int main()

{

	setlocale(LC_ALL, "Russian");

	char v;

	cout << "Введите символ: ";

	cin >> v;
	cout << setw(59) << setfill(' ') << ' ' << setw(2) << setfill(v) << v << endl;
	cout << setw(58) << setfill(' ') << ' ' << setw(4) << setfill(v) << v << endl;
	cout << setw(57) << setfill(' ') << ' ' << setw(6) << setfill(v) << v << endl;
	cout << setw(56) << setfill(' ') << ' ' << setw(8) << setfill(v) << v << endl;
	cout << setw(55) << setfill(' ') << ' ' << setw(10) << setfill(v) << v << endl;
	cout << setw(54) << setfill(' ') << ' ' << setw(12) << setfill(v) << v << endl;
	cout << setw(53) << setfill(' ') << ' ' << setw(14) << setfill(v) << v << endl;
	cout << setw(52) << setfill(' ') << ' ' << setw(16) << setfill(v) << v << endl;
	cout << setw(51) << setfill(' ') << ' ' << setw(18) << setfill(v) << v << endl;
	cout << setw(50) << setfill(' ') << ' ' << setw(20) << setfill(v) << v << endl;
	cout << setw(49) << setfill(' ') << ' ' << setw(22) << setfill(v) << v << endl;
	cout << setw(48) << setfill(' ') << ' ' << setw(24) << setfill(v) << v << endl;
	cout << setw(47) << setfill(' ') << ' ' << setw(26) << setfill(v) << v << endl;
	cout << setw(46) << setfill(' ') << ' ' << setw(28) << setfill(v) << v << endl;
	cout << setw(45) << setfill(' ') << ' ' << setw(30) << setfill(v) << v << endl;
	cout << setw(44) << setfill(' ') << ' ' << setw(32) << setfill(v) << v << endl;
	cout << setw(43) << setfill(' ') << ' ' << setw(34) << setfill(v) << v << endl;
	cout << setw(42) << setfill(' ') << ' ' << setw(36) << setfill(v) << v << endl;
	cout << setw(41) << setfill(' ') << ' ' << setw(38) << setfill(v) << v << endl;
	cout << setw(40) << setfill(' ') << ' ' << setw(40) << setfill(v) << v << endl;
	cout << setw(39) << setfill(' ') << ' ' << setw(42) << setfill(v) << v << endl;
	cout << setw(38) << setfill(' ') << ' ' << setw(44) << setfill(v) << v << endl;
	cout << setw(37) << setfill(' ') << ' ' << setw(46) << setfill(v) << v << endl;
	cout << setw(36) << setfill(' ') << ' ' << setw(48) << setfill(v) << v << endl;
	cout << setw(35) << setfill(' ') << ' ' << setw(50) << setfill(v) << v << endl;
	cout << setw(34) << setfill(' ') << ' ' << setw(52) << setfill(v) << v << endl;

	return 0;
}