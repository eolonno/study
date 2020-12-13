#include "Tree.h"

int menu();

int main()
{
	setlocale(0, "rus");
	int key, n;
	Tree* rc; char s[5], letter;
	Tree* Root = NULL;
	for (;;)
	{
		
		switch (menu())
		{
		case 1:  Root = makeTree(Root);	break;
		case 2:  cout << "\nВведите ключ: "; cin >> key;
			cout << "Введите слово: "; cin >> s;
			insertElem(Root, key, s); break;
		case 3:  cout << "\nВведите ключ: ";  cin >> key;
			rc = search(Root, key);
			cout << "Найденное слово= ";
			puts(rc->text); break;
		case 4:  cout << "\nВведите удаляемый ключ: "; cin >> key;
			Root = delet(Root, key);  break;
		case 5:
			if (Root->key >= 0)
			{
				cout << "Дерево повернуто на 90 град. влево" << endl;
				view(Root, 0);
			}
			else
				cout << "Дерево пустое\n";
			break;
		case 6:  cout << "\nВведите букву: "; cin >> letter;
			n = count(Root, letter);
			cout << "Количество слов, начинающихся с буквы " << letter;
			cout << " равно " << n << endl; break;
		case 7:  delAll(Root);
			Root = NULL;
			cout << "Дерево очищено" << endl;
			break;
		case 8:
			cout << endl << "Количество узлов с четными ключами равно: " << countEven(Root, 0) << endl << endl;
			break;
		case 9:
			cout << endl << "Количество узлов в правой ветви: " << countRight(Root, 0) << endl << endl;
			break;
		case 10:
			cout << endl << "Количество листьев в дереве: " << countLeaf(Root, 0) << endl << endl;
			break;
		case 11:
			exit(0);
			break;
		default:
			cout << "Введены некорректные данные!" << endl;
			break;
		}
	}
	return 0;
}

int menu()
{
	int choice;
	cout << "1 - Создание дерева\n";
	cout << "2 - Добавление элемента\n";
	cout << "3 - Поиск по ключу\n";
	cout << "4 - Удаление элемента\n";
	cout << "5 - Вывод дерева\n";
	cout << "6 - Подсчет количества букв\n";
	cout << "7 - Очистка дерева\n";
	cout << "8 - Подсчет узлов с четными ключами\n";
	cout << "9 - Подсчет узлов в правой ветви\n";
	cout << "10 - Подсчет количества листьев дерева\n";
	cout << "11 - Выход\n";
	cout << "$ ", cin >> choice;
	cout << "\n";
	return choice;
}