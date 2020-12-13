//Создать список, содержащий элементы вещественного типа. Найти среднее значение положительных элементов.

#include <iostream>
#include <fstream>
using namespace std;

struct list
{
	double symbol;
	list* next;
};

void insert(list*& p, double value);		//Добавление символа в начало списка
void printList(list* p);					//Вывод списка 
void toFile(list*& p);						//Запись в файл
void fromFile(list*& p);					//Считывание из файла
void del(list*& element, list*& p);			//Удаление элемента списка
void menu(void);							//Вывод меню 

int avg;									//Среднее значение положительных элементов списка
int counter = 0;							//Количество положительных чисел в списке

int main()
{
	setlocale(LC_CTYPE, "Russian");
	list* first = nullptr;
	list* tempL = new list;
	int choice; double value;
	menu();    // вывести меню 
	cout << " ? ";
	cin >> choice;
	while (choice != 5)
	{
		switch (choice)
		{
		case 1:  	cout << "Введите число с плавающей точкой: ";
			cin >> value;
			insert(first, value);
			printList(first);
			break;
		case 2:    toFile(first);
			break;
		case 3:    fromFile(first);
			break;
		case 4:		
			cout << "Введите число, которое вы хотите удалить: ";
			double temp;
			cin >> temp;
			tempL->next = first;
			while (tempL->symbol != temp)//Поиск элемента по его значению
				tempL = tempL->next;
			del(tempL, first);
			printList(first);
			break;
		default:   cout << "Неправильный выбор" << endl;
			menu(); break;
		}
		cout << "?  ";
		cin >> choice;
	}
	return 0;
}

void insert(list*& p, double value) //Добавление символа в начало списка
{
	list* newP = new list;
	if (newP != NULL)     //есть ли место?  
	{
		newP->symbol = value;
		newP->next = p;
		p = newP;
		if (newP->symbol > 0)
		{
			avg += newP->symbol;
			counter++;
			cout << "Среднее арифметическое положительных значений списка: " << avg / counter << endl;
		}
	}
	else
		cout << "Операция добавления не выполнена" << endl;
}

void printList(list* p)  //Вывод списка 
{
	if (p == NULL)
		cout << "Список пуст" << endl;
	else
	{
		cout << "Список:" << endl;
		while (p != NULL)
		{
			cout << "-->" << p->symbol;
			p = p->next;
		}
		cout << "-->NULL" << endl;
	}
}

void toFile(list*& p)
{
	list* temp = p;
	list buf;
	ofstream frm("mList.dat");
	if (frm.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	while (temp)
	{
		buf = *temp;
		frm.write((char*)&buf, sizeof(list));
		temp = temp->next;
	}
	frm.close();
	cout << "Список записан в файл mList.dat\n";
}

void fromFile(list*& p)          //Считывание из файла
{
	list buf, * first = nullptr;
	ifstream frm("mList.dat");
	if (frm.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	frm.read((char*)&buf, sizeof(list));
	while (!frm.eof())
	{
		insert(first, buf.symbol);
		cout << "-->" << buf.symbol;
		frm.read((char*)&buf, sizeof(list));
	}
	cout << "-->NULL" << endl;
	frm.close();
	p = first;
	cout << "\nСписок считан из файла mList.dat\n";
}

void del(list*& element, list*& first) {// Удаление элемента списка
	if (element->symbol > 0) {
		avg -= element->symbol;
		counter--;
		if (counter != 0)
			cout << "Среднее арифметическое положительных значений списка: " << avg / counter << endl;
	}

	list* prev = new list;
	list* nextElement = new list;
	prev = first;
	if (first == element)
	{
		first = nullptr;
		return;
	}
	while (prev->next != element && prev != NULL)
		prev = prev->next;
	if (nextElement != nullptr)
		nextElement = element->next;
	if (prev != nullptr)
		prev->next = nextElement;

}

void menu(void)     //Вывод меню 
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Ввод числа" << endl;
	cout << " 2 - Запись списка в файл" << endl;
	cout << " 3 - Чтение списка из файла" << endl;
	cout << " 4 - Удаление числа из списка" << endl;
	cout << " 5 - Выход" << endl;
}