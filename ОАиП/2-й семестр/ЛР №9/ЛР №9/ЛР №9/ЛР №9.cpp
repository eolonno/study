#include <iostream>
#include <fstream>
using namespace std;
const unsigned int NAME_SIZE = 30;
const unsigned int CITY_SIZE = 20;

struct Address
{
	char name[NAME_SIZE];
	char city[CITY_SIZE];
	Address* next;
	Address* prev;
};
//-----------------------------------------------------------
int menu(void)
{
	char s[80];  int c;
	cout << endl;
	cout << "1. Ввод имени" << endl;
	cout << "2. Удаление имени" << endl;
	cout << "3. Вывод на экран" << endl;
	cout << "4. Поиск" << endl;
	cout << "5. Удаление K первых элементов" << endl;
	cout << "6. Выход" << endl;
	cout << endl;
	do
	{
		cout << "Ваш выбор: ";
		std::cin.sync();
		gets_s(s);
		cout << endl;
		c = atoi(s);
	} while (c < 0 || c > 6);
	return c;
}
//-----------------------------------------------------------
void insert(Address* e, Address** phead, Address** plast) //Добавление в конец списка
{
	Address* p = *plast;
	if (*plast == NULL)
	{
		e->next = NULL;
		e->prev = NULL;
		*plast = e;
		*phead = e;
		return;
	}
	else
	{
		p->next = e;
		e->next = NULL;
		e->prev = p;
		*plast = e;
	}
}
//-----------------------------------------------------------
Address* setElement()      // Создание элемента и ввод его значений с клавиатуры 
{
	Address* temp = new  Address();
	if (!temp)
	{
		std::cerr << "Ошибка выделения памяти памяти";
		return NULL;
	}
	cout << "Введите имя: ";
	std::cin.getline(temp->name, NAME_SIZE - 1, '\n');
	std::cin.ignore(std::cin.rdbuf()->in_avail());
	std::cin.clear();
	cout << "Введите город: ";
	std::cin.getline(temp->city, CITY_SIZE - 1, '\n');
	std::cin.ignore(std::cin.rdbuf()->in_avail());
	std::cin.clear();
	temp->next = NULL;
	temp->prev = NULL;
	return temp;
}
//-----------------------------------------------------------
void outputList(Address** phead, Address** plast)      //Вывод списка на экран
{
	Address* t = *phead;
	while (t)
	{
		cout << t->name << ' ' << t->city << endl;
		t = t->next;
	}
	cout << "" << endl;
}
//-----------------------------------------------------------
void find(char name[NAME_SIZE], Address** phead)    // Поиск имени в списке
{
	Address* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name)) break;
		t = t->next;
	}
	if (!t)
		std::cerr << "Имя не найдено" << endl;
	else
		cout << t->name << ' ' << t->city << endl;
}
//-----------------------------------------------------------
void delet(char name[NAME_SIZE], Address** phead, Address** plast)  // Удаление имени {	struct Address *t = *phead;	
{
	Address* t = *phead;
	while (t)
{
	if (!strcmp(name, t->name))  break;
	t = t->next;
}
if (!t)
cerr << "Имя не найдено" << endl;
else
{
	if (*phead == t)
	{
		*phead = t->next;
		if (*phead)
			(*phead)->prev = NULL;
		else
			*plast = NULL;
	}
	else
	{
		t->prev->next = t->next;
		if (t != *plast)
			t->next->prev = t->prev;
		else
			*plast = t->prev;
	}
	delete t;
	cout << "Элемент удален" << endl;
}
}
//-----------------------------------------------------------
void deleteKFirst(int k, Address** phead) {
	if (*phead != NULL) {
		Address* next = (*phead)->next;
		Address* present = *phead;
		while (k-- && next != NULL)
		{
			delete present;
			present = next;
			next = present->next;
		}
		*phead = present;
		cout << "Элемент(ы) успешно удален(ы)" << endl;
	}
	else
		cout << "Список пуст!" << endl;
}
//-----------------------------------------------------------
int main(void)
{
	Address* head = NULL;
	Address* last = NULL;
	setlocale(LC_CTYPE, "Rus");
	while (true)
	{
		switch (menu())
		{
		case 1:  insert(setElement(), &head, &last);
			break;
		case 2: {	  char dname[NAME_SIZE];
			cout << "Введите имя: ";
			std::cin.getline(dname, NAME_SIZE - 1, '\n');
			std::cin.ignore(std::cin.rdbuf()->in_avail());
			std::cin.sync();
			delet(dname, &head, &last);
		}
			  break;
		case 3:  outputList(&head, &last);
			break;
		case 4: {	  char fname[NAME_SIZE];
			cout << "Введите имя: ";
			std::cin.getline(fname, NAME_SIZE - 1, '\n');
			std::cin.ignore(std::cin.rdbuf()->in_avail());
			std::cin.sync();
			find(fname, &head);
		}
			  break;
		case 5: 
		{
			char s[80];
			int k;
			cout << "Введите значение K: ";
			std::cin.sync();
			gets_s(s);
			k = atoi(s);
			deleteKFirst(k, &head);
		}
			break;
		case 6:  exit(0);
		default: exit(1);
		}
	}
	return 0;
}
