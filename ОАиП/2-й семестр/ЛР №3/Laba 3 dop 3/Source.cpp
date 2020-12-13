#include <iostream>
#include <string>
#include <fstream>
#include <Windows.h>
#include <iomanip>
using namespace std;
int zapis(string, int);
int perezapis(int, int);
int out();
void vvod(int);
void vivod();
void del();
void poisk();
void poisk2();
void poisk3();

//Создание стуктур
struct sanatorii				
{
	string nazvanie;
	string mesto;
	string lechebpr;
	int kol;
	string poisk;
};
sanatorii sant[255];
sanatorii bad;
string path = "spisok.txt";
int dele = 0, kole;

void main() {
	setlocale(LC_ALL, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int a, k, choice;
	do
	{
		cout << endl << "Введите:" << endl;
		cout << "1-для записи" << endl;
		cout << "2-для удаления записи" << endl;
		cout << "3-для изменения записи" << endl;
		cout << "4-для вывода записи(ей)" << endl;
		cout << "5-для ввода новой записи" << endl;
		cout << "6-для поиска по названию" << endl;
		cout << "7-для поиска по месту" << endl;
		cout << "8-для поиска по лечебному профилю" << endl;
		cout << "9-для выхода" << endl;
		cout << "Ваш выбор: ";
		cin >> choice;
		switch (choice)
		{
		case 1:
			cout << "Введите количество санаториев: ";
			cin >> a;
			vvod(a);
			break;
		case 2:
			del();
			break;
		case 3:  int n;
			cout << "Введите номер ученика: ";
			cin >> n;
			perezapis(n - 1, 0);
			break;
		case 4:  vivod();	break;
		case 5: perezapis(kole, 1); break;
		case 6: poisk(); break;
		case 7: poisk2(); break;
		case 8: poisk3(); break;
		}
	} while (choice != 9);
}

//Ввод данных
void vvod(int kol) {				
	string mus;
	int x;
	for (int i = 0; i < kol; i++)
	{
		sant[i].nazvanie = "";
		cout << "";
		cout << "Название: ";
		getline(cin, mus);
		getline(cin, sant[i].nazvanie);
		cout << endl << "Место расположения: ";
		getline(cin, sant[i].mesto);
		cout << endl << "Метод лечения: ";
		getline(cin, sant[i].lechebpr);

		cout << endl << "Количество путёвок: ";
		cin >> sant[i].kol;
	}
	zapis(path, kol);

}

//Запись данных в файл
int zapis(string path, int kol) {					
	ofstream fout;
	fout.open(path);
	if (!fout.is_open()) {
		printf_s("%s", "не удалось открыть файл");
		return -1;
	}
	for (int i = 0; i < kol; i++)
	{
		fout << (sant[i].nazvanie) << "\n";
		fout << (sant[i].mesto) << "\n";
		fout << (sant[i].lechebpr) << "\n";
		fout << sant[i].kol;
		if (i != kol - 1)
			cout << "\n";
	}
	fout.close();
	return 0;
}

//Сканирование файла и запись информации в структуру
int out() {									
	setlocale(LC_ALL, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	ifstream fin;
	int i = 0;
	fin.open(path);
	if (!fin.is_open()) {                       
		printf_s("%s", "ошибка открытия файла");
		return EXIT_FAILURE;
	}
	else {
		printf_s("%s", "Файл открыт\n");
	}
	while (!fin.eof()) {

		getline(fin, sant[i].nazvanie);
		getline(fin, sant[i].mesto);
		getline(fin, sant[i].lechebpr);
		fin >> sant[i].kol;
		i++;
	}
	fin.close();
	kole = i;
}

//Удаление указанной записи
void del() 
{					
	out();
	int del;
	cout << "Введите номер санатория, который нужно удалить: ";
	dele++;
	cin >> del;
	for (int i = del - 1; i < kole - 1; i++) {
		sant[i].nazvanie = sant[i + 1].nazvanie;
		sant[i].mesto = sant[i + 1].mesto;
		sant[i].lechebpr = sant[i + 1].lechebpr;
		sant[i].kol = sant[i + 1].kol;
	}
	zapis(path, kole - dele);
}

//Вывод данных из файла
void vivod() {								
	setlocale(LC_ALL, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	out();
	cout << setw(32) << "Название" << setw(30) << "Место" << setw(30) << "Способ лечения" << setw(30) << "Количество путёвок" << endl;
	for (int i = 0; i < kole; i++)
	{
		cout << i + 1 << ".";
		cout << setw(30) << (sant[i].nazvanie);
		cout << setw(30) << (sant[i].mesto);
		cout << setw(30) << (sant[i].lechebpr);
		cout << setw(20) << (sant[i].kol);
		cout << endl;
	}
}

//Запись объекта
int perezapis(int n, int r)
{						
	out();
	int x;
	cout << "Название: ";
	getline(cin, sant[n].nazvanie);
	cout << endl << "Место расположения: ";
	getline(cin, sant[n].mesto);
	cout << endl << "Количество путёвок: ";
	getline(cin, sant[n].lechebpr);
	zapis(path, kole + r);
	return 0;
}
void poisk() {
	out();
	string mus;
	getline(cin, mus);
	cout << "Ведите название санатория: ";
	getline(cin, sant[0].poisk);
	for (int i = 0; i < kole; i++) {
		if (sant[i].nazvanie == sant[0].poisk) {
			cout << setw(32) << "Название" << setw(30) << "Место" << setw(30) << "Способ лечения" << setw(30) << "Количество путёвок" << endl;
			cout << i + 1 << ".";
			cout << setw(30) << (sant[i].nazvanie);
			cout << setw(30) << (sant[i].mesto);
			cout << setw(30) << (sant[i].lechebpr);
			cout << setw(20) << (sant[i].kol);
			cout << endl;
		}
	}

}
void poisk2() {
	out();
	string mus;
	getline(cin, mus);
	cout << "Введите название санатория: ";
	getline(cin, sant[0].poisk);
	for (int i = 0; i < kole; i++) {
		if (sant[i].mesto == sant[0].poisk) {
			cout << setw(32) << "Название" << setw(30) << "Место" << setw(30) << "Способ лечения" << setw(30) << "Количество путёвок" << endl;
			cout << i + 1 << ".";
			cout << setw(30) << (sant[i].nazvanie);
			cout << setw(30) << (sant[i].mesto);
			cout << setw(30) << (sant[i].lechebpr);
			cout << setw(20) << (sant[i].kol);
			cout << endl;
		}
	}

}
void poisk3() {
	out();
	string mus;
	getline(cin, mus);
	cout << "Введите название санатория: ";
	getline(cin, sant[0].poisk);
	for (int i = 0; i < kole; i++) {
		if (sant[i].lechebpr == sant[0].poisk) {
			cout << setw(32) << "Название" << setw(30) << "Место" << setw(30) << "Способ лечения" << setw(30) << "Количество путёвок" << endl;
			cout << i + 1 << ".";
			cout << setw(30) << (sant[i].nazvanie);
			cout << setw(30) << (sant[i].mesto);
			cout << setw(30) << (sant[i].lechebpr);
			cout << setw(20) << (sant[i].kol);
			cout << endl;
		}
	}

}
