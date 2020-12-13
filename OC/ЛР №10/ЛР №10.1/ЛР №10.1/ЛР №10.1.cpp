#include <iostream>
#include <string>
using namespace std;

struct people {
	char name[16];
	int old;
};

void info(people* e) {
	cout << "Name: " << e->name << endl << "Years old: " << e->old << "\n\n";
}

int main() {

	////Первое задание
	//string* str = new string[2];
	//str[0] = "Hello ";
	//str[1] = "World!";
	//cout << str[0] << str[1] << "\n\n";

	//delete[] str;

	
	//malloc для примера
	int SIZE;
	cout << "Enter size: ", cin >> SIZE;
	char** st = (char**)malloc(SIZE * sizeof(char*));

	for (int i = 0; i < SIZE; i++)
		st[i] = (char*)malloc(16 * sizeof(char));

	for (int i = 0; i < SIZE; i++)
		cout << "Enter the string: ", cin >> st[i];
	for (int i = 0; i < SIZE; i++)
		cout << st[i];
	cout << "\n\n";
	free(st);									

	//Второе задание
	people* human = (people*)malloc(sizeof(people) * 2);

	strcpy_s(human[0].name, "Gosha");
	human[0].old = 17;
	
	strcpy_s(human[1].name, "Petr");
	human[1].old = 24;

	info(&human[0]);
	info(&human[1]);

	free(human);

	//Третье задание
	int a, b;
	cout << "Введите размер массива структур: ";
	cin >> a;
	cin >> b;
	people** humans = (people**)malloc(a * sizeof(people*));
	for (int i = 0; i != a; i++)
		humans[i] = (people*)malloc(b * sizeof(people));

	char s[16];
	int o;
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			cout << "Enter name: ", cin >> s;
			strcpy_s(humans[i][j].name, s);
			cout << "Enter old: ", cin >> humans[i][j].old;
		}
	}
	cout << "\n\n";
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			cout << humans[i][j].name << endl;
			cout << humans[i][j].old << endl << endl;
		}
	}
	//Для того, чтобы поместить строку в поле name нужно воспользоваться функцией strcpy_s, в которой первым параметром передается
	//объект, который нужно заполнить, например в данном случае: humans[0][0].name

	/*for (int i = 0; i < 2; i++)
		free(humans[i]);
	free(humans);*/

	return 0;
}