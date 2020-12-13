#pragma once
#include <iostream>
using namespace std;
struct Tree
{
	int key;			// ключ
	char text[5];		// данные
	Tree* Left, * Right;
};

Tree* makeTree(Tree* Root);								// Создание дерева
Tree* list(int i, char* s);								// Создание нового элемента
Tree* insertElem(Tree* Root, int key, char* s);			// Добавление нового элемента
Tree* search(Tree* n, int key);							// Поиск элемента по ключу 
Tree* delet(Tree* Root, int key);						// Удаление элемента по ключу
void view(Tree* t, int level);							// Вывод дерева 
int count(Tree* t, char letter);						// Подсчет количества слов
void delAll(Tree* t);									// Очистка дерева

int countEven(Tree* t, int level);						// Вариант №12
int countRight(Tree* t, int level);						// Вариант №15
int countLeaf(Tree* t, int level);						// Вариант №7
