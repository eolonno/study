struct Stack
{
	
	int data; //информационный элемент
	Stack* head;
	//вершина стека
	Stack* next;
	//указатель на следующий элемент

};
void show(Stack* myStk); //прототип
int pop(Stack* myStk); //прототип
void push(int x, Stack* myStk); //прототип#pragma once
void delete3(Stack* myStk);