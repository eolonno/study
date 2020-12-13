//К номеру своего варианта прибавить 1 и написать программу с использованием динамических массивов для условий из лабораторной работы № 12.
//Внести изменения в программу с тем, чтобы продемонстрировать использование указателей как формальных параметров функции и как результатов выполнения функции. 

//В строке есть два символа *. Получить все символы между первым и вторым символом *. 

#include <iostream>
using namespace std;

char* func(char*, char*);

int main()
{
	setlocale(LC_CTYPE, "rus");
	char str[] = "Lorem ipsum dolor *sit amet, consectetur* adipiscing.";
	char* ans = new char[strlen(str)];
	char* decision = func(str, ans);


	for (int i = 0; i < strlen(ans); i++)
	{
		cout << *(decision+i);
	}

	delete[] ans;
	return 0;
}

char* func(char* str, char* ans)
{
	int k = 0, index = 0;
	for (int i = 0; i < strlen(str); i++)
	{
		if (*(str + i) == '*')
		{
			k = i + 1;
			while (*(str + k) != '*')
			{
				*(ans + index) = *(str + k);
				k++;
				index++;
			}
			*(ans + index) = '\0';
			break;
		}
	}
	return ans;
}