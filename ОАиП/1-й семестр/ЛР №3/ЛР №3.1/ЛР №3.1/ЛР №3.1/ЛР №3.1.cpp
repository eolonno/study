#include <iostream>
#include <iomanip>


using namespace std;

int main()

{

	setlocale(LC_ALL, "ru");

	char v;

	cout << "Введите символ ";

	cin >> v;

	cout << setw(45) << setfill(' ') << ' ' << setw(30) << setfill(v) << v << endl;
	cout << setw(44) << setfill(' ') << ' ' << setw(32) << setfill(v) << v << endl;
	cout << setw(43) << setfill(' ') << ' ' << setw(34) << setfill(v) << v << endl;
	cout << setw(42) << setfill(' ') << ' ' << setw(36) << setfill(v) << v << endl;
	cout << setw(41) << setfill(' ') << ' ' << setw(38) << setfill(v) << v << endl;
	cout << setw(40) << setfill(' ') << ' ' << setw(40) << setfill(v) << v << endl;
	cout << setw(41) << setfill(' ') << ' ' << setw(38) << setfill(v) << v << endl;
	cout << setw(42) << setfill(' ') << ' ' << setw(36) << setfill(v) << v << endl;
	cout << setw(43) << setfill(' ') << ' ' << setw(34) << setfill(v) << v << endl;
	cout << setw(44) << setfill(' ') << ' ' << setw(32) << setfill(v) << v << endl;
	cout << setw(45) << setfill(' ') << ' ' << setw(30) << setfill(v) << v << endl;
	
	return 0;
}