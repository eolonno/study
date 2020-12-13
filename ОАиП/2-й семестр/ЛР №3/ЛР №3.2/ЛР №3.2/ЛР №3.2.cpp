//Ввести с клавиатуры строку символов, состоящую из групп цифр и нулей, и записать ее в файл. Прочитать из файла данные и вывести самую короткую группу. 
#include <iostream>
#include <string>
#include <fstream>
#include <Windows.h>

using namespace std;

int main() {
	setlocale(LC_CTYPE, "rus");
	fstream file;
	file.open("file.txt", fstream::out);

	if (!file.is_open())
	{
		cout << "Ошибка открытия файла!\n";
		return 1;
	}

	string str;
	cout << "Введите строку символов: ";
	cin >> str;
	file << str;
	file.close();

	file.open("file.txt", fstream::in);
	str = ""; 
	file >> str;
	file.close();

	string minStr;
	string justStr;
	int minCounter = 0;
	int justCounter = 0;
	bool isFirst = true;
	for (int i = 0; i <= str.size(); i++)
	{
		if (str[i] != '0' && isFirst && str[i] != '\0')
		{
			minStr += str[i];
			minCounter++;
		}
		else if (isFirst)
		{
			isFirst = false;
			continue;
		}

		if (!isFirst && str[i] != '0' && str[i] != '\0')
		{
			justStr += str[i];
			justCounter++;

		}
		else
		{
			if (justCounter < minCounter && !isFirst)
			{
				minCounter = justCounter;
				minStr = justStr;
			}
			justCounter = 0;
			justStr = "";

		}
	}

	cout << "Ответ: " << minStr << endl;
	

	return 0;
}

