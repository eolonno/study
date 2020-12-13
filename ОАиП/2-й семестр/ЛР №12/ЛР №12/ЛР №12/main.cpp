#include "Tree.h"
#include <fstream>
using namespace std;
struct NodeTree
{
	int  key;
};
//-------------------------------
btree::CMP cmpfnc(void* x, void* y)    // Сравнение
{
	btree::CMP rc = btree::EQUAL;
	if (((NodeTree*)x)->key < ((NodeTree*)y)->key)
		rc = btree::LESS;
	else
		if (((NodeTree*)x)->key > ((NodeTree*)y)->key)
			rc = btree::GREAT;
	return rc;
}
//-------------------------------
void printNode(void* x)               // Вывод при обходе
{
	cout << ((NodeTree*)x)->key << ends;
}
//-------------------------------
bool buildTree(btree::Object& tree) //Построение дерева из файла
{
	bool rc = true;
	FILE* inFile;
	fopen_s(&inFile, "G.txt", "r");
	if (inFile == NULL)
	{
		cout << "Ошибка открытия входного файла" << endl;
		rc = false; return rc;
	}
	while (!feof(inFile)) // заполнение дерева 
	{
		int num;
		fscanf_s(inFile, "%d", &num, 1);
		NodeTree* a = new NodeTree();
		a->key = num;
		tree.insert(a);
	}
	fclose(inFile);
	return rc;
}
FILE* outFile;
//-------------------------------
void saveToFile(void* x)              // Запись одного элемента в файл
{
	NodeTree* a = (NodeTree*)x;
	int q = a->key;
	fprintf(outFile, "%d\n", q);
}
//-------------------------------
void saveTree(btree::Object& tree)    //Сохранение дерева в файл 
{
	fopen_s(&outFile, "G.txt", "w");
	if (outFile == NULL)
	{
		cout << "Ошибка открытия выходного файла" << endl;
		return;
	}
	tree.Root->scanDown(saveToFile);
	fclose(outFile);
}
//-------------------------------
int main()
{
	setlocale(LC_CTYPE, "Russian");
	btree::Object demoTree = btree::create(cmpfnc);
	int k, choice;
	NodeTree a1 = { 1 }, a2 = { 2 }, a3 = { 3 }, a4 = { 4 }, a5 = { 5 }, a6 = { 6 };
	bool rc = demoTree.insert(&a4);   //           4  
	rc = demoTree.insert(&a1);        //   1             
	rc = demoTree.insert(&a6);        //                   6
	rc = demoTree.insert(&a2);        //      2     
	rc = demoTree.insert(&a3);        //         3
	rc = demoTree.insert(&a5);        //                 5	
	for (;;)
	{
		NodeTree* a = new NodeTree;
		cout << "1 - вывод дерева на экран" << endl;
		cout << "2 - добавление элемента" << endl;
		cout << "3 - удаление элемента" << endl;
		cout << "4 - сохранить в файл" << endl;
		cout << "5 - загрузить из файла" << endl;
		cout << "6 - очистить дерево" << endl;
		cout << "7 - прямой обход дерева" << endl;
		cout << "8 - смешанный обход дерева" << endl;
		cout << "9 - проверка дерева на сбалансированность" << endl;
		cout << "10 - кол-во листьев, которые являются правыми дочерними элементами" << endl;
		cout << "0 - выход" << endl;
		cout << "$ "; cin >> choice;
		switch (choice)
		{
		case 0:   	exit(0);
		case 1:  	if (demoTree.Root)
			demoTree.Root->scanByLevel(printNode);
			  else
			cout << "Дерево пустое" << endl;
			break;
		case 2: 	cout << "введите ключ" << endl;  cin >> k;
			a->key = k;
			demoTree.insert(a);
			break;
		case 3:  	cout << "введите ключ" << endl;  cin >> k;
			a->key = k;
			demoTree.deleteByData(a);
			break;
		case 4:   	saveTree(demoTree);
			break;
		case 5:  	buildTree(demoTree);
			break;
		case 6:	while (demoTree.Root)
			demoTree.deleteByNode(demoTree.Root);
			break;
		case 7: demoTree.Root->preOrder(); cout << endl; break;
		case 8: demoTree.Root->inOrder(); cout << endl; break;
		case 9: 
		{
			int right = 0, left = 0;
			demoTree.Root->isBalancedCounter(&right, &left);
			if (right - left == 1 || right - left == -1 || right - left == 0)
				cout << "Дерево сбалансировано" << endl;
			else cout << "Дерево не сбалансировано" << endl;
		}
		break;
		case 10: cout << "Найдено " << demoTree.Root->RightLeaves() << " листьев, которые являются правыми дочерними элементами" << endl; break;
		}
	}
	return 0;
}
