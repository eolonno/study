
#include <iostream>
#include "myStack.h"
using namespace std;
int main()
{
	setlocale(LC_ALL, "Rus");
	int choice;
	Stack* myStk = new Stack; //выделение памяти для стека
	myStk->head = NULL; //инициализация первого элемента
	for (;;)
		{
		cout << "Выберите команду:" << endl;
		cout << "1 - Добавление элемента в стек" << endl;
		cout << "2 - Извлечение элемента из стека" << endl;
		cout << "3 - Вывод стека" << endl;
		cout << "4 - Удаляем числакратные 3 " << endl;
		cout << "5 - Выход" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите элемент: " << endl;
		cin >> choice;
		push(choice, myStk);
		break;
		case 2: choice = pop(myStk);
		if (choice != -1)
		cout << "Извлеченный элемент: " << choice <<endl;
		break;
		case 3: cout << "Весь стек: " << endl;
		show(myStk);
		break;
		case 4:cout << "Удаляем числакратные 3 "<<endl;
		delete3(myStk);
		break;
		case 5: return 0;
		break;
		} 
		}
		 

		
	return 0;
}
