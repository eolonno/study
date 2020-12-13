#pragma once
#include <iostream>
namespace btree
{
	enum CMP
	{
		LESS = -1, EQUAL = 0, GREAT = 1
	};
	struct Node
	{
		Node* parent;            // указатель на родителя  
		Node* left;              // указатель на левую ветвь
		Node* right;             // указатель на правую ветвь
		void* data;              //  данные    
		Node(Node* p, Node* l, Node* r, void* d) // конструктор
		{
			parent = p;
			left = l;
			right = r;
			data = d;
		}
		Node* next();              // следующий по ключу
		Node* prev();              // предыдущий по ключу
		Node* min();               // минимум в поддереве
		Node* max();               // максимум в поддереве  
		void scanDown(void(*f)(void* n));    // обход поддерева сверху вниз     
		void scan(int(*f)(void* n));
		void scanLevel(void(*f)(void* n), int);
		int getLevel();
		void scanByLevel(void(*f)(void* n));
		void preOrder();		// Нисходящий обход обход
		void inOrder();
		void isBalancedCounter(int*, int*);
		int RightLeaves(bool isRight = false);
	};
	struct Object         // Интерфейс бинарного дерева 
	{
		Node* Root;                    // указатель на корень
		CMP(*compare)(void*, void*);   // функция сравнения	
		Object(CMP(*f)(void*, void*))
		{
			Root = NULL;
			compare = f;
		};
		bool isLess(void* x1, void* x2)	const
		{
			return compare(x1, x2) == LESS;
		};
		bool isGreat(void* x1, void* x2)const
		{
			return compare(x1, x2) == GREAT;
		};
		bool isEqual(void* x1, void* x2)const
		{
			return compare(x1, x2) == EQUAL;
		};
		bool insert(void* data);           // добавить элемент
		Node* search(void* d, Node* n);    // найти элемент
		Node* search(void* d)
		{
			return search(d, Root);
		};
		bool deleteByNode(Node* e);         // удалить по адресу элемента 
		bool deleteByData(void* data)       // удалить по ключу
		{
			return deleteByNode(search(data));
		};
	};
	Object create(CMP(*f)(void*, void*));      // Создать бинарное дерево    
};
