//Описать структуру с именем TRAIN, содержащую поля: названия пункта назначения, номер поезда, время отправления.
//Написать программу, выполняющую ввод с клавиатуры данных в массив, состоящий из восьми элементов типа TRAIN
//(записи должны быть размещены в алфавитном порядке по названиям пунктов назначения); вывод на экран информации о поездах,
//отправляющихся после введенного с клавиатуры времени (если таких поездов нет, то вывести сообщение об этом).
#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <sstream>

using namespace std;

#define NumOfTrains 2

struct TRAIN {//Описанаие структуры
	string destination;
	int trainNumber;
	string departureTime;
};

void input(TRAIN*);
bool compare(string, TRAIN*);
void output(TRAIN*);

int main() {
	setlocale(0, "rus");
	TRAIN trains[NumOfTrains];
	vector <string> destinations(NumOfTrains);
	for (int i = 0; i < NumOfTrains; i++){
		input(&trains[i]);
		destinations[i] = trains[i].destination;
	}
	sort(destinations.begin(), destinations.end());//Сортировка по алфавиту

	int i;
	for (auto a : destinations) {//Вывод по алфавиту
		i = 0;
		while (trains[i].destination != a)
			i++;
		cout << "Пункт отправления: " << trains[i].destination;
		cout << "\nВремя отправления: " << trains[i].departureTime;
		cout << "\nНомер поезда: " << trains[i].trainNumber << endl;
	}

	string time;
	int counter = 0;
	cout << "\nВведите время, позже которого вы хотите увидеть рейсы: ", cin >> time;
	for (int i = 0; i < NumOfTrains; i++)
	{
		if (compare(time, &trains[i]))
		{
			output(&trains[i]);
			counter++;
		}
	}
	if (counter == 0)
		cout << "Рейсы не найдены!\n";

	return 0;
}

void input(TRAIN* instance) {//Ввод с клавиатуры данных
	cout << "Введите пункт прибытия поезда: ", cin >> instance->destination;
	cout << "Введите номер поезда: ", cin >> instance->trainNumber;
	cout << "Введите время прибытия поезда: ", cin >> instance->departureTime, cout << endl;
}

bool compare(string time, TRAIN* instance) {//Сравнение времени
	int hours, minutes, hoursOfInstance, minutesOfInstance;
	hours = (time[0] - 48) * 10 + time[1] - 48;
	minutes = (time[3] - 48) * 10 + time[4] - 48;
	hoursOfInstance = (instance->departureTime[0] - 48) * 10 + instance->departureTime[1] - 48;
	minutesOfInstance = (instance->departureTime[3] - 48) * 10 + instance->departureTime[4] - 48;

	if (hours > hoursOfInstance)
		return false;
	else if (hours < hoursOfInstance)
		return true;
	else if (hours <= hoursOfInstance)
	{
		if (minutes >= minutesOfInstance)
			return false;
		else if (minutes < minutesOfInstance)
			return true;
	}
}

void output(TRAIN* train) {
	cout << "Время отправления: " << train->departureTime;
	cout << "\nПункт отправления: " << train->destination;
	cout << "\nНомер поезда: " << train->trainNumber << endl;
}