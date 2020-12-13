//Из заданного предложения удалить те слова, которые уже встречались в предложении раньше.
#include <iostream>
#include <string>
using namespace std;

int main()
{
	string str[] = { "Lorem", " ipsum", " dolor", " adipiscing", " amet,", " ipsum", " adipiscing", " sit." };
	for (int i = 7; i >= 0; i--)
	{
		for (int k = 0; k < i; k++)
		{
			if (str[i] == str[k])
				str[k].erase();
		}
	}

	
	for (int i = 0; i < 9; i++)
	{
		for (int k = 0; k < str[i].size(); k++)
		{
			cout << str[i][k];
		}
	}


	return 0;
}