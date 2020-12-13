#include <iostream>
#include "myStack.h"
using namespace std;
int main()
{
	setlocale(LC_ALL, "Rus");
	int choice;
	Stack* myStk = new Stack; //выделение памяти для стека
	myStk->head = NULL;       //инициализация первого элемента	
	for (;;)
	{
		cout << "1 - Добавление элемента в стек" << endl;
		cout << "2 - Извлечение элемента из стека" << endl;
		cout << "3 - Вывод стека" << endl;
		cout << "4 - Очистить стек" << endl;
		cout << "5 - Удалить первый отричательный элемент стека" << endl;
		cout << "6 - Выход" << endl;
		cout << "$ ";
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите элемент: ";
			cin >> choice;
			push(choice, myStk);
			break;
		case 2: choice = pop(myStk);
			if (choice != -1)
				cout << "Извлеченный элемент: " << choice << endl;
			break;
		case 3: cout << "Весь стек: ";
			show(myStk);
			break;
		case 4: clear(myStk);
			myStk = new Stack;		  //выделение памяти для стека
			myStk->head = NULL;       //инициализация первого элемента
			break;
		case 5: del(myStk);
			break;
		case 6: return 0;
			break;
		}
	}
	return 0;
}
