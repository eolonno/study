// ProectQueue.cpp: определяет точку входа для консольного приложения.
//
#include "MyQueue.h"
#include <iostream>
using namespace std;

struct myQue
{
	int a;
	char b;
};
void printQueue(Queue& s)    // Вывод на экран с очисткой очереди    
{
	while (!(s.isEmpty()))
	{
		cout << ((myQue*)peekQueue(s))->a << "  " << ((myQue*)peekQueue(s))->b << endl;
		delQueue(s);
	}
}
int main()
{
	Queue q1 = createQueue(4);
	myQue a1 = { 1, 'q' }, a2 = { 2, 'w' }, a3 = { 3, 'e' };
	enQueue(q1, &a1);
	enQueue(q1, &a2);
	enQueue(q1, &a3);
	myQue* a4 = new myQue;
	a4->a = 4;
	a4->b = 'r';
	enQueue(q1, a4);
	printQueue(q1);
	return 0;
}
