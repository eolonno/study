#include <iostream>  
#include <fstream>
#define LENGTH 15
#define QUALITY 30
#define EXAM 5
using namespace std;

//Прототипы функций
void enter_student();
void compare();
void output();
char check_char(char* pointer);
int check_int(int);

//Объявление структуры
struct Students
{
	char surname[LENGTH];
	char firstname[LENGTH];
	int exams=EXAM;
	int marks[EXAM];
};
struct Students results[QUALITY];
struct Students the_best_students[QUALITY];
int current_quality = 0;
int current_best=0;

int main()
{
	setlocale(LC_CTYPE, "ru");
	int choice;
	enter_student();
	compare();

	cout << "Вывести результаты студентов? (Выберите: 1 - да, 2 - нет)" << endl;
	cin >> choice;
	//Проверка
	check_int(choice);
	if (choice == 1)
		output();
	else
		cout << "Goodbye!" << endl;

	getchar();
	return 0;
}


//Ввод информации
void enter_student()
{
	int extend;
	
		if (current_quality < QUALITY)
		{
			cout << "Введите фамилию студента:" << endl;
			cin >> results[current_quality].surname;
			//Проверка
			check_char(results[current_quality].surname);

			cout << "Введите имя студента:" << endl;
			cin >> results[current_quality].firstname;
			//Проверка
			check_char(results[current_quality].firstname);

			cout << "Введите оценки за экзамены(по 5-и бальной системе):" << endl;
			for (int i = 0; i < results[current_quality].exams; i++)
			{
				cout << "Оценка за " << i + 1 << "-й экзамен" << endl;
				cin >> results[current_quality].marks[i];
				//Проверка
				check_int(results[current_quality].marks[i]);
			}
		}
		else
			cout << "Максивальное количество студентов." << endl;
		
		cout << "Данные введены" << endl;
		current_quality++;
		for (;;)
		{
			cout << "\nХотите добавить еще одного студента?(Введите: 1 - да, 2 - нет)" << endl;
			cin >> extend;
			if (extend == 2)
				break;
			else if (extend == 1)
			{
				enter_student();
				break;
			}
			else
			{
				cout << "Такого варианта нет" << endl;
				exit(0);
			}
		}

}

//Сравнение результатов
void compare()
{
	int counter = 0;
	for (int i = 0; i < current_quality; i++)
	{
		for (int j = 0; j < results[i].exams; j++)
		{
			if (results[i].marks[j] >= 4)
			{
				counter++;
			}

			if (counter == results[i].exams)
			{
				the_best_students[current_best] = results[i];
				current_best++;
			}
		}
		counter = 0;
	}
	float result_compare = ((float)current_best / (float)current_quality) * 100;
	cout << "Отношение числа студентов, сдавших экзамены на 4 и 5, к общему числу студентов: " << result_compare << "%" << endl;

}

//Вывод информации на консоль
void output()
{
	int ch;
	cout <<"\nВведите: " << endl;
	cout << "1-Вывод всех студентов" << endl;
	cout << "2-Вывод лучших студентов" << endl;
	cout << "Ваш выбор: ", cin >> ch;
	switch (ch)
	{
	case 1:

		for (int i = 0; i < current_quality; i++)
		{
			cout << "Фамилия: " << results[i].surname << endl;
			cout << "Имя: " << results[i].firstname << endl;
			cout << "Количество экзаменов: " << results[i].exams << endl;
			for (int j = 0; j < results[i].exams; j++)
			{
				cout << "Оценка за " << j + 1 << "-й экзамен: " << results[i].marks[j] <<endl;		
			}
		}
		cout << endl;
		break;

	case 2:

		for (int i = 0; i < current_best; i++)
		{
			cout << "Фамилия: " << the_best_students[i].surname << endl;
			cout << "Имя: " << the_best_students[i].firstname << endl;
			cout << "Количество экзаменов: " << the_best_students[i].exams << endl;
			for (int j = 0; j < the_best_students[i].exams; j++)
			{
				cout << "Оценка за " << j + 1 << "-й экзамен: " << the_best_students[i].marks[j] <<endl;		
			}
		}
		cout << endl;
		break;

	default:
		cout << "Такого пункта нет " << endl;
		break;
	}
	cout << "\nДо скорых встречь" << endl;
}


//Функции с проверками

char check_char(char* pointer)
{
	for (int i = 0; i < strlen(pointer); i++)
	{
		if (*(pointer + i) < 65 || (*(pointer + i) > 90 && *(pointer + i) < 97) || *(pointer + i) > 122)
		{
			cout << "\nНекорректный ввод" << endl;
			exit(0);
		}
	}


}

int check_int(int check)
{
	if (!cin || check>5)
	{
		cout << "Некорректный ввод" << endl;
		exit(0);
	}
}


