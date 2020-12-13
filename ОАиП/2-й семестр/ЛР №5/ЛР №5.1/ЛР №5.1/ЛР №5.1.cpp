//Горожанин.Ф.И.О., дата рождения, адрес, пол(м, ж). Выборка по году рождения. Дату рождения организовать с помощью битового поля,
//пол - с помощью перечисления.

//Реализовать функции ввода с клавиатуры, вывода на экран, удаления, поиска элементов. Интерфейс пользователя осуществить в виде меню.

#include <iostream>
#include <string>
#include <Windows.h>
using namespace std;

enum Esex
{
	m, f, nothing
};

struct date {
	int day : 5;
	int month : 4;
	int year : 11;
};

struct citizen {
	string FIO;
	string adress;
	Esex sex;
	date date;

	~citizen(){
		FIO = "";
		adress = "";
		sex = Esex::nothing;
		date.day = 0;
		date.month = 0;
		date.year = 0;
	}
};

void input(citizen*);
void citizen_del(citizen*, int);
void find(citizen*, int);
void info(citizen*, int);

int main() {
	setlocale(LC_CTYPE, "rus");
	int amount; 
	cout << "Сколько граждан вы хотите добавить? ", cin >> amount;

	citizen* citizens = new citizen[amount];
	for(int i = 0; i < amount; i++)
		input(&citizens[amount - 1]);

	int ans;

	do {
		cout << "1) Вывод информации о гражданах на экран\n2) Удаление гражданина из базы данных\n3) Поиск граждан по году рождения\n4) Выход\n\n", cin >> ans;
		switch (ans)
		{
		case 1: info(citizens, amount);
			break;
		case 2: citizen_del(citizens, amount);
			break;
		case 3: find(citizens, amount);
		default: "Введены некорректные данные!\n";
			break;
		}
	} while (ans != 4);

	return 0;
}

void input(citizen* citizen) {
	system("cls");
	cout << "Введите ФИО гражданина: ";
	getchar();
	getline(cin, citizen->FIO, '\n');
	cout << "Введите адрес гражданина: ";
	getchar();
	getline(cin, citizen->adress, '\n');
	char sex;
	cout << "Введите пол гражданина (m, f): ", cin >> sex;
	if (sex == 'm')
		citizen->sex = Esex::m;
	else if (sex == 'f')
		citizen->sex = Esex::f;
	else cout << "Введены некорректые данные";
	string date, info;
	int counter = 0;
	cout << "Введит дату рождения гражданина: ", cin >> date;
	for (int i = 0; i < date.size(); i++) {
		if (date[i] < 57 && date[i] > 48) {
			info += date[i];
		}
		else if (date[i] == '.') {
			switch (counter)
			{
			case 0: citizen->date.day = stoi(info);
				info = "";
				break;
			case 1: citizen->date.month = stoi(info);
				info = "";
				break;
			case 2: citizen->date.year = stoi(info);
				info = "";
				break;
			default: cout << "Введены неверные данные\n";
				break;
			}
			counter++;
		}
		else
			cout << "Введены неверные данные" << endl;
	}

}

void citizen_del(citizen* citizens, int amount) {//Удаление гражданина из базы данных
	system("cls");
	string FIO;
	cout << "Введите ФИО гражданина, которого следует удалить из базы данных: ", cin >> FIO;
	for (int i = 0; i < amount; i++)
	{
		if (FIO == citizens[i].FIO)
		{
			citizens[i].~citizen();
			break;
		}
		if (citizens[i].FIO != FIO && i - 1 == amount)
			cout << "Клиент не найден!\n";
	}
}

void find(citizen* citizens, int amount) {//Поиск граждан по году рождения
	system("cls");
	string year;
	cout << "Введите год рождения, по которому нужно осуществить поиск: ", cin >> year;
	for (int i = 0; i < amount; i++)
	{
		if (citizens[i].date.year == stoi(year))
		{
			cout << "ФИО гражданина: " << citizens[i].FIO << endl;
			cout << "Адрес проживания гражданина: " << citizens[i].adress << endl;
			cout << "Дата рождения гражданина: " << citizens[i].date.day  << '.' << citizens[i].date.month << citizens[i].date.year << endl;
			cout << "Пол гражданина: " << citizens[i].sex;
		}
		if (citizens[i].date.year != stoi(year) && i - 1 == amount)
			cout << "Клиент не найден!\n";

	}

}

void info(citizen* citizens, int amount) {//Вывод информации о всех гражданах
	system("cls");
	cout << "Информация о гражданах:\n\n";
	for (int i = 0; i < amount; i++)
	{
		if (citizens[i].FIO != "") {
			cout << "ФИО гражданина: " << citizens[i].FIO << endl;
			cout << "Адрес проживания гражданина: " << citizens[i].adress << endl;
			cout << "Дата рождения гражданина: " << citizens[i].date.day << '.' << citizens[i].date.month << citizens[i].date.year << endl;
			cout << "Пол гражданина: " << citizens[i].sex << "\n\n";
		}
	}
}
