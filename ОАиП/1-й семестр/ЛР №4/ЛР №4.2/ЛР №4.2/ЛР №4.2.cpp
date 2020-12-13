#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");

	cout << "Кто из президентов США написал свой собственный рассказ про Шерлока Холмса?" << endl << "1. Джон Кеннеди" << endl << "2.Франклин Рузвельт" << endl << "3. Рональд Рейган" << endl << "Ваш ответ:";
	int answer;
	cin >> answer;
	switch(answer)
	{
		case 1: puts("Неверный ответ"); break;
		case 2: puts("Верный ответ"); break;
		case 3: puts("Неверный ответ"); break;
		default: puts("Введены некорректные данные"); break;
	}

	cout << "Какую пошлину ввели в XII  веке в Англии для того чтобы заставить мужчин пойти на войну?" << endl << "1. Налог на тунеядство" << endl << "2. Налог на трусость" << endl << "3. Налог на отсутствие сапог" << endl << "Ваш ответ: ";
	cin >> answer;
	switch (answer)
	{
		case 1: puts("Неверный ответ"); break;
		case 2: puts("Верный ответ"); break;
		case 3: puts("Неверный ответ"); break;
		default: puts("Введены некорректные данные"); break;
	}

	return 0;
}

