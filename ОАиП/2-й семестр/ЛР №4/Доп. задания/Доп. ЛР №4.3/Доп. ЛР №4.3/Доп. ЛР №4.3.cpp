//Определить структуру для представления информации о наличии санаторных путевок, содержащую следующие поля: Название санатория, Место расположения,
//Лечебный профиль, Количество путевок.Представить введенные данные в виде таблицы, сгруппировав их по лечебным профилям санаториев.
//В пределах каждой группы данные отсортировать по названиям санаториев. Организовать поиск информации и вывод результатов.
#include <iostream>
#include <string>
using namespace std;

struct voucher {
	string name;
	string place;
	string profile;
	int count;
};

void input(voucher*, int);

int main() {
	setlocale(LC_CTYPE, "rus");
	int count;
	cout << "Сколько путевок вы хотите ввести: ", cin >> count;
	voucher* vouchers = new voucher[count];
	

	return 0;
}

void input(voucher** vouchers, int count) {
	for (int i = 0; i < count; i++)
	{
		do {
			cout << "Введите название санатория №" << i + 1 << ": ", cin >> vouchers[i]->name;
		} while (isLetters(vouchers[i]->name) == false && cout << "Введите корректные данные" << endl);
		cout << "Введите место расположения санатория №" << i + 1 << ": ", cin >> vouchers[i]->place;
		cout << "Введите лечебный профиль санатория №" << i + 1 << ": ", cin >> vouchers[i]->profile;
		cout << "Введите количество путевок в санатории №" << i + 1 << ": ", cin >> vouchers[i]->count;
	}
}

bool isLetters(string str) {
	int counter = 0;
	for (int i = 0; i < str.size; i++)
	{
		if ((str[i] >= 192 && str[i] <= 255) || (str[i] >= 65 && str[i] <= 122))
			counter++;
	}
	if (counter == str.size)
		return true;
	else
		return false;
}