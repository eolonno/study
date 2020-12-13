#include <iostream>
#include "myStack.h"
using namespace std;
void push(int x, Stack* myStk)   //Добавление элемента х в стек	
{
	Stack* e = new Stack;    //выделение памяти для нового элемента
	e->data = x;             //запись элемента x в поле v 
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}
int pop(Stack* myStk)   //Извлечение (удаление) элемента из стека
{
	if (myStk->head == NULL)
	{
		cout << "Стек пуст!" << endl;
		return -1;               //если стек пуст - возврат -1 
	}
	else
	{
		Stack* e = myStk->head;				//е - переменная для хранения адреса элемента
		int a = myStk->head->data;			//запись числа из поля data в переменную a 
		myStk->head = myStk->head->next;	//перенос вершины
		delete e;							//удаление временной переменной
		return a;							//возврат значения удаляемого элемента
	}
}
void show(Stack* myStk)    //Вывод стека
{
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		a = e->data;
		cout << a << " ";
		e = e->next;
	}
	cout << endl;
}

void clear(Stack* stk) {
	Stack* tmp = stk->head;
	while (tmp != NULL)
	{
		stk = tmp->next;
		delete[] tmp;
		tmp = stk;
	}
}

void del(Stack* myStk) {
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		a = e->data;
		if (a < 0 && e->head != NULL)
		{
			e->head->next = e->next;//Ошибка доступа
			delete[] e;
			cout << "Элемент успешно удален!" << endl;
			break;
		}
		else if (a < 0 && e->head == NULL)
		{
			myStk = e->next;
			e->next->head == NULL;
			delete[] e;
		}
		e = e->next;
	}
	cout << endl;
}
