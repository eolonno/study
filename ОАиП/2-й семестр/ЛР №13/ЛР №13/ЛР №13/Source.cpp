#include "Heap.h"
#include <iostream>
using namespace std;
#define SecondHeapSize 5
heap::CMP cmpAAA(void* a1, void* a2)  //Функция сравнения
{
#define A1 ((AAA*)a1)
#define A2 ((AAA*)a2)
	heap::CMP
		rc = heap::EQUAL;
	if (A1->x > A2->x)
		rc = heap::GREAT;
	else
		if (A2->x > A1->x)
			rc = heap::LESS;
	return rc;
#undef A2
#undef A1 
}
//-------------------------------
int main()
{
	setlocale(LC_ALL, "rus");
	int k, choice;
	heap::Heap h1 = heap::create(30, cmpAAA);
	for (;;)
	{
		cout << "1 - вывод кучи на экран" << endl;
		cout << "2 - добавить элемент" << endl;
		cout << "3 - удалить максимальный элемент" << endl;
		cout << "4 - удалить минимальный элемент" << endl;
		cout << "5 - удалить i-тый элемент" << endl;
		cout << "6 - объединить две кучи" << endl;
		cout << "0 - выход" << endl;
		cout << "$ ";  cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1:  h1.scan(0);
			break;
		case 2: {	AAA* a = new AAA;
			cout << "введите ключ" << endl; 	cin >> k;
			a->x = k;
			h1.insert(a);
		}
			  break;
		case 3:   h1.extractMax(); break;
		case 4: h1.extractMin();
			break;
		case 5: printf("Введите номер элемента, который Вы хотите удалить: ");
			int n;
			scanf_s("%d", &n);
			h1.extractI(n);
			break;
		case 6: {
			static heap::Heap h2 = heap::create(30, cmpAAA);
			for (int i = 0; i < SecondHeapSize; i++)
			{
				AAA* b = new AAA;
				b->x = rand() % 20;
				h2.insert(b);
			}
			printf("Вторая куча создана автоматически. Ее содержимое:\n");
			h2.scan(0);
			heap::UnionHeap(&h1, &h2);
			printf("Содержимое итоговой кучи:\n");
			h1.scan(0);
		}
			break;
		default:  cout << endl << "Введены некорретные данные!" << endl;
		}
	} return 0;
}
