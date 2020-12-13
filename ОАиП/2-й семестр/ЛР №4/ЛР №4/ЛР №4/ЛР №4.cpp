//В программу должны войти функции :
//	ввод элементов структуры с клавиатуры;
//	вывод элементов структуры в консольное окно;
//	удаление заданной структурированной переменной;
//	поиск информации;
//	запись информации в файл;
//	чтение данных из файла.
//Список клиентов гостиницы. Паспортные данные, даты приезда и отъезда, номер, тип размещения(люкс, одноместный, двухместный, трехместный, апартаменты).
//Поиск гостя по фамилии.
#include <iostream>
#include <string>
#include <fstream>
#include <Windows.h>
using namespace std;

#define NumberOfPlaces 20

bool numsIsFree[NumberOfPlaces];

struct Client {
	string lastName;
	string passportData;
	string dateOfArrival;
	string deparure;
int num;
string typeOfAllocation;

~Client() {//Деструктор
	lastName = "";
	passportData = "";
	dateOfArrival = "";
	deparure = "";
	num = 0;
	typeOfAllocation = "";
}
};

void add_client(Client*, int*);
void client_del(Client*);
void find(Client*);
void info(Client*);
void inFile(Client*);
void readFile(Client*);


int main() {
	setlocale(LC_CTYPE, ".1251");
	bool inMenu = true;
	Client* BD = new Client[NumberOfPlaces];
	int index = 0;
	int answer;
	for (int i = 0; i < NumberOfPlaces; i++)
		numsIsFree[i] = true;


	do
	{
		cout << "\n1) Добавить клиента в гостиницу\n2) Вывести информацию о всех клиентах\n3) Удалить клиента из списка\n4) Поиск клиента по фамилии\n5) Запись информации о клиентах в файл\n6) Просмотр ранее записанных данных из файла\n7) Заверешение работы\nВаш выбор: ";
		cin >> answer;
		switch (answer)
		{
		case 1: add_client(BD, &index);
			break;
		case 2: info(BD);
			break;
		case 3: client_del(BD);
			break;
			case 4: find(BD);
				break;
			case 5: inFile(BD);
				break;
			case 6: readFile(BD);
				break;
		case 7: inMenu = false;
			break;

		default: cout << "Введите корректные данные!" << endl;
			break;
		}
	} while (inMenu);

	return 0;
}

void add_client(Client* BD, int* index) {//Добавление клиента в базу данных 
	for (int i = 0; i < NumberOfPlaces; i++)//Первый свободный номер становится занятым
	{
		if (numsIsFree[i])
		{
			BD[*index].num = i + 1;
			numsIsFree[i] = false;
			break;
		}
	}

	system("cls");
	cout << "\nВведите данные клиента!\n";//Заполнение данных о постояльцах при помощи консоли
	cout << "Фамилия: ", cin >> BD[*index].lastName;
	cout << "Паспортные данные: ", cin >> BD[*index].passportData;
	cout << "Дата прибытия: ", cin >> BD[*index].dateOfArrival;
	cout << "Дата отъезда: ", cin >> BD[*index].deparure;
	cout << "Тип размещения: ", cin >> BD[*index].typeOfAllocation;

	system("cls");
	cout << "Клиент успешно добавлен!\n";
	cout << "Номер данного клиента: " << BD[*index].num << endl;
	(*index)++;
}

void client_del(Client* BD) {//Удаление клиента из базы данных
	system("cls");
	string LastName;
	cout << "Введите фамилию пользователя, который съезжает: ", cin >> LastName;
	for (int i = 0; i < NumberOfPlaces; i++)
	{
		if (LastName == BD[i].lastName)
		{
			numsIsFree[BD[i].num - 1] = true;
			BD[i].~Client();
			break;
		}
		if (BD[i].lastName != LastName && i - 1 == NumberOfPlaces)
			cout << "Клиент не найден!\n";
	}
}

void find(Client* BD) {//Поиск постояльца по фамилии
	system("cls");
	string LastName;
	cout << "Введите фамилию клиента: ", cin >> LastName;
	for (int i = 0; i < NumberOfPlaces; i++)
	{
		if (BD[i].lastName == LastName)
		{
			cout << "Паспортные данные: " << BD[i].passportData;
			cout << "\nДата прибытия: "<< BD[i].dateOfArrival;
			cout << "\nДата отъезда: " << BD[i].deparure;
			cout << "\nТип размещения: " << BD[i].typeOfAllocation;
			cout << "\nЗаселен в " << BD[i].num << " номер\n";
			break;
		}
		if (BD[i].lastName != LastName && i - 1 == NumberOfPlaces)
			cout << "Клиент не найден!\n";

	}

}

void info(Client* BD) {//Вывод информации о всех клиентах
	system("cls");
	cout << "Информация о постояльцах:\n\n";
	for (int i = 0; i < NumberOfPlaces; i++)
	{
		if (BD[i].lastName != "") {
			cout << "Фамилия клиента: " << BD[i].lastName;
			cout << "\nПаспортные данные: " << BD[i].passportData;
			cout << "\nДата прибытия: " << BD[i].dateOfArrival;
			cout << "\nДата отъезда: " << BD[i].deparure;
			cout << "\nТип размещения: " << BD[i].typeOfAllocation;
			cout << "\nЗаселен в " << BD[i].num << " номер\n\n";
		}
	}
}

void inFile(Client* BD) {//Создание файла с данными о постояльцах
	system("cls");
	fstream file;
	file.open("datebase.txt", fstream::out);


	if (!file.is_open())
		cout << "Ошибка открытия файла!";

	for (int i = 0; i < NumberOfPlaces; i++)
	{
		if (BD[i].lastName != "") {
			file << "Customer last name: " << BD[i].lastName;
			file << "\nPassport data: " << BD[i].passportData;
			file << "\nArrival date: " << BD[i].dateOfArrival;
			file << "\nDeparture date: " << BD[i].deparure;
			file << "\nType of allocation: " << BD[i].typeOfAllocation;
			file << "\nLives at " << BD[i].num << " room\n\n";
		}
	}
	cout << "Данные успешно записаны!\n";
	file.close();
}

void readFile(Client* BD) {//Чтение и вывод на экран данных из файла
	system("cls");
	fstream file;
	file.open("datebase.txt", fstream::in);

	if (!file.is_open())
		cout << "Ошибка открытия файла!";

	string datebase;
	while (!file.eof()) {
		datebase = "";
		getline(file, datebase);
		cout << datebase << endl;
	}
	file.close();
}