#include "List.h"
#include<iostream>
void insert(Person* e, Person** phead, Person** plast) //Добавление в конец списка
{
	Person* p = *plast;
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

Person* setElement()      // Создание элемента и ввод его значений с клавиатуры 
{
	Person* temp = new  Person();
	if (!temp)
	{
		cerr << "Ошибка выделения памяти памяти";
		return NULL;
	}
	cout << "Введите имя: ";
	cin.getline(temp->name, NAME_SIZE - 1, '\n');
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	cout << "Введите возраст: ";
	cin >> temp->age;
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	temp->next = NULL;
	temp->prev = NULL;
	return temp;
}

void outputList(Person** phead, Person** plast)      //Вывод списка на экран
{
	Person* t = *phead;
	if (t == NULL)
	{
		cout << "Список пуст" << endl;
		return;
	}
	while (t)
	{
		cout << "Имя: " << t->name << " " << "Возраст: " << t->age << endl;
		t = t->next;
	}
	cout << endl;
}

void find(char name[NAME_SIZE], Person** phead)    // Поиск имени в списке
{
	Person* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name)) break;
		t = t->next;
	}
	if (!t)
		cerr << "Имя не найдено" << endl;
	else
		cout << t->name << ' ' << t->age << endl;
}

void delet(char name[NAME_SIZE], Person** phead, Person** plast) // Удаление имени
{
	struct Person* t = *phead;
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

void writeToFile(Person** phead)       //Запись в файл
{
	struct Person* t = *phead;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "wb");
	if (err)
	{
		cerr << "Файл не открывается" << endl;
		exit(1);
	}
	cout << "Сохранение в файл" << endl;
	while (t)
	{
		fwrite(t, sizeof(struct Person), 1, fp);
		t = t->next;
	}
	fclose(fp);
}

void readFromFile(Person** phead, Person** plast)          //Считывание из файла
{
	struct Person* t;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "rb");
	if (err)
	{
		cerr << "Файл не открывается" << endl;
		exit(1);
	}
	while (*phead)
	{
		*plast = (*phead)->next;
		delete* phead;
		*phead = *plast;
	}
	*phead = *plast = NULL;
	cout << "Загрузка из файла" << endl;
	while (!feof(fp))
	{
		t = new Person();
		if (!t)
		{
			cerr << "Ошибка выделения памяти" << endl;
			return;
		}
		if (1 != fread(t, sizeof(struct Person), 1, fp)) break;
		insert(t, phead, plast);
	}
	fclose(fp);
}

void deleteList(Person** phead, Person** plast) // Удаление списка
{
	struct Person* t = *phead;
	if (*phead == NULL)
	{
		cout << "Список пуст" << endl;
		return;
	}

	while (*phead != NULL)
	{
		*phead = t->next;
		t = t->next;
		if (*phead)
			(*phead)->prev = NULL;
		else
			*plast = NULL;

	}
	delete t;
	cout << "Элемент удален" << endl;
}
void countList(Person** phead, Person** plast)
{
	int counter = 0;
	struct Person* t = *phead;
	if (*phead == NULL)
	{
		cout << "Список пуст" << endl;
		return;
	}
	while (t != NULL)
	{
		t = t->next;
		counter++;
	}
	cout << "Количество элементов в списке: " << counter << endl;
}