#include "List.h"
#include<iostream>
int main()
{
	setlocale(LC_CTYPE, "Rus");
	Person* head = NULL;
	Person* last = NULL;
	char s[80];  int c;
	while (true)
	{
		cout << endl;
		cout << "1. Ввод элемента" << endl;
		cout << "2. Удаление имени" << endl;
		cout << "3. Вывод на экран" << endl;
		cout << "4. Поиск" << endl;
		cout << "5. Запись в файл" << endl;
		cout << "6. Вывод из файла" << endl;
		cout << "7. Удаление списка" << endl;
		cout << "8. Подсчет элементов" << endl;
		cout << "9. Выход" << endl;
		cout << endl;
		do
		{
			cout << "Ваш выбор: ";
			cin.sync();
			gets_s(s);
			cout << endl;
			c = atoi(s);
		} while (c < 0 || c > 8);

		switch (c)
		{
		case 1:  insert(setElement(), &head, &last);
			break;
		case 2: {	  char dname[NAME_SIZE];
			cout << "Введите имя: ";
			cin.getline(dname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			delet(dname, &head, &last);
		}
			  break;
		case 3:  outputList(&head, &last);
			break;
		case 4: {	  char fname[NAME_SIZE];
			cout << "Введите имя: ";
			cin.getline(fname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			find(fname, &head);
		}
			  break;
		case 5:
			writeToFile(&head);
			break;
		case 6:
			readFromFile(&head, &last);
			break;
		case 7:
			deleteList(&head, &last);
			break;
		case 8:
			countList(&head, &last);
			break;
		case 9:  exit(0);
			break;
		default: exit(1);
			break;
		}
	}
	return 0;
}
