//Определить структуру для представления информации о сданных студентом экзаменах, содержащую поля: ФИО студента, число экзаменов, полученные оценки.
//Определить функции для обработки отдельного объекта (например, для проверки, сданы ли все экзамены на 4 и 5).
//Написать функцию для обработки массива структур. В результате обработки требуется вычислить характеристику успеваемости студентов,
//то есть отношение числа студентов, сдавших экзамены на 4 и 5, к общему числу студентов, в процентах. 
#include <iostream>
#include <string>
using namespace std;

struct Student {
	string FIO;
	int exams;
	int* marks = new int[exams];
};

bool isStudent(Student*);
float progress(Student*);

int main() {
	setlocale(0, "rus");

	Student stud1 = { "Исаков Людвиг Эдуардович", 5 };
	Student stud2 = { "Самсонова Майя Эдуардовна", 5 };
	Student stud3 = { "Копылов Вадим Рубенович", 4 };

	for (int i = 0; i < 5; i++)
	{
		stud1.marks[i] = rand() % 9;
		stud2.marks[i] = rand() % 9;
		if (i < stud3.exams)
			stud3.marks[i] = rand() % 9;
	}

	cout << "Успеваемость: " << (progress(&stud1) + progress(&stud2) + progress(&stud3)) / 3;

	return 0;
}

bool isStudent(Student* stud) {
	for (int i = 0; i < stud->exams; i++)
	{
		if (stud->marks[i] < 4)
			return false;
	}
	return true;
}

float progress(Student* stud) {
	int avg = 0;
	for (int i = 0; i < stud->exams; i++)
		avg += stud->marks[i];
	return avg / stud->exams;
}