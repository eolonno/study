//Исключить из строки группы символов, расположенные между скобками вместе со скобками. Предполагается, что нет вложенных скобок.

#include <iostream>
using namespace std;

int main()
{
	char str[] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit (donec ut pharetra nulla). Duis ac convallis.";
	bool in = false;
	int counter = 0, istart;

	for (int i = 0; i <= strlen(str); i++)
	{
		if (str[i] == '(')
		{
			in = true;
			counter++;
			istart = i;
		}
		if (str[i] == ')' && in)
		{
			in = false;
			counter ++; 
		}
		if (in)
			counter++;
	}

	for (int i = 0; i < counter; i++)
	{
		int f = i + istart;
		str[f] = str[istart + counter+i-1];
	}

	for (int i = 0; i <= strlen(str); i++)
	{
		cout << str[i];
	}

	return 0;
}