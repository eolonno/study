#include "myQueue.h"
Queue createQueue(int n)          // Выделить ресурс для очереди
{
	return *(new Queue(n));
};
Queue createQueue(const Queue& pq)   // Создать очередь 
{
	Queue* rc = new Queue(pq.Size - 1);
	rc->Head = pq.Head;
	rc->Tail = pq.Tail;
	for (int i = 0; i < pq.Size; i++)
		rc->Data[i] = pq.Data[i];
	return *rc;
}
bool Queue::isFull() const         // Очередь заполненa?
{
	return (Head % Size == (Tail + 1) % Size);
}
bool Queue::isEmpty()const         // Очередь пустa?
{
	return (Head % Size == Tail % Size);
}
bool enQueue(Queue& q, void* x)      // Добавить элемент x 
{
	bool rc = true;
	if (rc = !q.isFull())
	{
		q.Data[q.Tail] = x;
		q.Tail = (q.Tail + 1) % q.Size;
	}
	else
		rc = false;
	return rc;
};

void* delQueue(Queue& q)               // Удалить элемент 
{
	void* rc = (void*)MYQUEUE1_EQE;
	if (!q.isEmpty())
	{
		rc = q.Data[q.Head];
		q.Head = (q.Head + 1) % q.Size;
	}
	else
		rc = NULL;
	return rc;
}

void* peekQueue(const Queue& q)  // Получить первый элемент очереди
{
	void* rc = (void*)MYQUEUE1_EQE;
	if (!q.isEmpty())
		rc = q.Data[q.Head];
	else
		rc = NULL;
	return rc;
}

int  clearQueue(Queue& q)       // Очистить очередь
{
	int rc = (q.Tail - q.Head) >= 0 ? q.Tail - q.Head : (q.Size - q.Head + q.Tail + 1);
	q.Tail = q.Head = 0;
	return rc;     // колич. элементов до очистки
}
void releaseQueue(Queue& q)     // Освободить ресурсы очереди
{
	delete[] q.Data;
	q.Size = 1;
	q.Head = q.Tail = 0;
}

void task(Queue& q)
{

}
