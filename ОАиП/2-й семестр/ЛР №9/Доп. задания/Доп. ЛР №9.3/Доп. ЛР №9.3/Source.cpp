#include "List.h"

int main()
{
	setlocale(LC_CTYPE, "rus");

	int count, which;
	printf("¬ведите количество человек: ");
	scanf_s("%d", &count);
	printf("¬ведите число K: ");
	scanf_s("%d", &which);

	List list;
	for (int i = 1; i <= count; i++)
		list.pushBack(i);
	list.looping();
	list.print();

	List* pList = &list;
	for (int i = 0; i < count - 1; i++)
	{
		int x = which;
		while (--x)
			pList = pList->next;
		if (pList->isFirst == true)
		{
			pList->remove();
			pList->print();
			continue;
		}
		pList = pList->next;
		pList->prev->remove();
		pList->print();
	}
	return 0;
}