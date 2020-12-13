#include <iostream>
#include <fstream>
using namespace std;
const unsigned int NAME_SIZE = 30;

struct Person
{
	char name[NAME_SIZE];
	int age;
	Person* next;
	Person* prev;
};
void insert(Person* e, Person** phead, Person** plast); //Добавление в конец списка
Person* setElement();
void outputList(Person** phead, Person** plast);      //Вывод списка на экран
void find(char name[NAME_SIZE], Person** phead);    // Поиск имени в списке
void delet(char name[NAME_SIZE], Person** phead, Person** plast);  // Удаление имени
void writeToFile(Person** phead);       //Запись в файл
void readFromFile(Person** phead, Person** plast);          //Считывание из файла
void deleteList(Person** phead, Person** plast);
void countList(Person** phead, Person** plast);