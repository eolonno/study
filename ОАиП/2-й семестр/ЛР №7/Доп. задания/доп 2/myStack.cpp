#include <iostream>
#include "MyStack.h"
#include<fstream>
#include <string>
using namespace std;
string path="123.txt";
void push(int x, int i, Stack* myStk)   //Добавление элемента х в стек	
{
	Stack* e = new Stack;    //выделение памяти для нового элемента
	e->data = x;             //запись элемента x в поле v 
	e->num = i;
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}

int fromFile(Stack* myStk)      
{	
	int buf;
	ifstream fin;
	Stack* e = myStk->head;
	
	fin.open(path);
	if (!fin.is_open()) {
		printf_s("%s", "не удалось открыть файл");
		return -1;
	}
	int i = 0;
	while (!fin.eof())
	{
		string buf;
		int num=0;
		getline(fin, buf);
		num = buf.length();
		push(num, i, myStk);
		i++;
	}
	fin.close();
	return 0;
	
}

int myFunct(Stack* myStk)
{
	Stack* e = myStk->head;    

	if (e == NULL) 
	{
		cout << "Стек пуст!" << endl;
		return 0;
	}
	int raz = e->data;
	int number = e->num;
	while (e != NULL)
	{
		if (raz > (e->data))
		{
			number = e->num;
			raz = e->data;
		}
		e = e->next;
	}
	cout << "\nномер самой короткой строки: " << number + 1<<"\nдлинна самой короткой строки: "<<raz + 1;

	cout << endl;
	return 0;
}


void show(Stack* myStk)    
{
	Stack* e = myStk->head;    
	
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
								         
		cout << e->data << " ";
		e = e->next;
	}
	cout << endl;
}
