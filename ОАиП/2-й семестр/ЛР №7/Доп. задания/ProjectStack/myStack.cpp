
#include <iostream>
#include "myStack.h"
using namespace std;
void push(int x, Stack* myStk) //Добавление элемента х в стек
{
	Stack* e = new Stack; //выделение памяти для нового элемента
	e->data = x; //запись элемента x в поле v
	e->next = myStk->head; //перенос вершины на следующий элемент
	myStk->head = e; //сдвиг вершины на позицию вперед
}
int pop(Stack* myStk) //Извлечение (удаление) элемента из стека
{
	if (myStk->head == NULL)
	{
		cout << "Стек пуст!" << endl;
		return -1; //если стек пуст - возврат -1
	}
	else
	{
		Stack* e = myStk->head; //е - переменная для хранения адреса элемента
			int a = myStk->head->data; //запись числа из поля data в переменную a
			myStk->head = myStk->head->next; //перенос вершины
		delete e; //удаление временной переменной
		return a; //возврат значения удаляемого элемента
	}
}
void show(Stack* myStk) //Вывод стека
{
	Stack* e = myStk->head; //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		a = e->data; //запись значения в переменную a
		cout << a << " ";
		e = e->next;
	}
	cout << endl;
}
void delete3(Stack* myStk) 
{
	Stack* e = myStk->head;
	Stack* pred = e;
	Stack* temp;
	Stack* start = myStk->head;
	while (start != NULL) {
		temp = start;
		if ((start->data) % 3 == 0)
		{
			pred->next = start->next;
			start = start->next;
			delete temp;
		}
		else {
			if ((start->next) != 0) {
				start = start->next;
			}
			else {
				start = NULL;
			}
		}
	}
	cout << "Лишние значения удалены!" << endl;

}
	
