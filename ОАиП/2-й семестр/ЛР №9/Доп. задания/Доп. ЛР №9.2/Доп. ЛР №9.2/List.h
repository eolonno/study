#pragma once
#include <iostream>
#include <Windows.h>

struct Student
{
	char surname[15];		// Фамилия
	char name[10];			// Имя
	int year;				// Год рождения
	int course;				// Курс
	int group;				// Группа
	int OSMark;				// Оценка по ОС
	int englishMark;		// Оценка по английскому
	int boitMark;			// Оценка по ОИТ
	int oapMark;			// Оценка по ОАП
	int chemistryMark;		// Оценка по химии
	Student* next;
};

struct Element
{
	Element* Prev;
	Element* Next;
	void* Data;
	Element(Element* prev, void* data, Element* next)
	{
		Prev = prev;
		Data = data;
		Next = next;
	}
};

struct Object 
{
	Element* Head;
	Object()
	{
		Head = NULL;
	};

	bool Insert(void* data);
	void PrintList(void(*f)(void*));
	int CountList();
	int CountList(int);
	bool sortCourse();
	bool sortSurname();
	bool findAverage();
	bool findOldest();
	bool findYoungest();
	bool findBest();
	void insertAll();
};

Object Create();   // создать список

void print(void* b);
int menu();
void Example(Object*);