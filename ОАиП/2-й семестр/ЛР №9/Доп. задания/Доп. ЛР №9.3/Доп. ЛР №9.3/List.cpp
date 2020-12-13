#include "List.h"

void List::pushAfter(int data)
{
	if(this->prev == NULL)
		isFirst = true;
	this->data = data;
	this->next = new List;
	this->next->prev = this;
}

void List::pushBack(int data)
{
	List* current = this;
	while (current->next != NULL)
		current = current->next;
	current->pushAfter(data);
}

void List::print()
{
	List* current = this;
	if (current == NULL)
		return;
	while (current->isFirst != true)
		current = current->prev;
	int WasFirst = 0;
	while (current->next != NULL)
	{
		if (current->isFirst)
		{
			WasFirst++;
			if(WasFirst == 2)
			{
				std::cout << std::endl;
				return;
			}
		}
		printf("%d ", current->data);
		current = current->next;
	}
	std::cout << std::endl;
}

void List::looping()
{
	List* current = this;
	while (current->next != NULL)
		current = current->next;
	current = current->prev;
	current->next = this;
	this->prev = current;
}

void List::remove()
{
	if (this->isFirst == true)
	{
		this->data = this->next->data;
		List* tmp = this->next;
		this->next->next->prev = this;
		this->next = this->next->next;
		delete tmp;
		return;
	}
	this->prev->next = this->next;
	this->next->prev = this->prev;
	delete this;
}