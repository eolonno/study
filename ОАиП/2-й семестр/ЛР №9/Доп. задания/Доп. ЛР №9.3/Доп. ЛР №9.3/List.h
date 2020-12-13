#pragma once
#include <iostream>

struct List {
	List* prev = NULL;	// Указатель на предыдущий элемент
	List* next = NULL;	// Указатель на следующий элемент
	int data;			// Данные
	bool isFirst = false;

private:
	void pushAfter(int data);

public:
	void pushBack(int data);	// Запись данных в конец списка
	void print();				// Вывод списка в консоль
	void looping();				// Зацикливание списка
	void remove();				// Удаление элемента списка
};