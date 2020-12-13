#pragma once
#include <iostream>
#define MYQUEUE1_EQE  0x0000  // возврат в случае пустоты очереди 

struct Queue               // Блок управления очередью 
{
	int Head;           // голова очереди
	int Tail;           // хвост очереди
	int Size;           // размер очереди (макс. колич.+1)
	void** Data;        // хранилище данных очереди 
	Queue(int size)     // физический размер очереди  
	{
		Head = Tail = 0;
		Data = new void* [Size = size + 1];
	}
	bool isFull() const;       // очередь заполненa ?
	bool isEmpty()const;       // очередь пустa ? 
};

Queue createQueue(int n);            // n – макс. количество 
Queue createQueue(const Queue& pq);  // создать очередь по образцу 
bool  enQueue(Queue& q, void* x);    // добавить x 
void* delQueue(Queue& q);            // удалить элемент 
void* peekQueue(const Queue& q);     // получить первый элемент
int clearQueue(Queue& q);            // очистить очередь
void releaseQueue(Queue& q);         // освободить ресурсы 
void task(Queue& q);
