//Скопировать в файл FILE2 только те строки из FILE1,  которые начинаются с буквы «А». Подсчитать количество слов в FILE2.
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main() {
	setlocale(LC_CTYPE, "rus");
	fstream FILE1, FILE2;
	FILE1.open("FILE1.txt", fstream::in);//Открываем файлы
	FILE2.open("FILE2.txt", fstream::out);

	if (FILE1.is_open())//Вылаыливаем ошибки при открытии файлов
		cout << "Файл FILE1.txt успешно открыт" << endl;
	else
	{
		cout << "Ошибка открытия файла FILE1.txt" << endl;
		return 1;
	}

	if (FILE2.is_open()) 
		cout << "Файл FILE2.txt успешно открыт" << endl;
	else
	{
		cout << "Ошибка открытия файла FILE2.txt" << endl;
		return 2;
	}

	
	string str;
	int counter = 0;
	while (!FILE1.eof()) {
		str = "";
		getline(FILE1, str);//Запись строки из файла в переменную str
		if (str[0] == 'A')
		{
			FILE2 << str << '\n';
			for (int i = 0; i < str.size(); i++) {//Подсчет слов
				if (str[i] == ' ' || str[i] == '\n')
					counter++;

			}
			counter++;//Добавление слова при переносе строки
		}
	}
	
	cout << "FILE2.txt содержит " << counter + 1 << " слов." << endl;

	FILE1.close();//Закрытие файлов
	FILE2.close();

	return 0;
}