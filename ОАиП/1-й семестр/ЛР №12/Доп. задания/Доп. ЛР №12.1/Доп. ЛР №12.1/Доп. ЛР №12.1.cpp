#include <iostream>
//В заданной последовательности слов найти все слова, имеющие заданное окончание
using namespace std;

int main()
{
	char str[] = "Lorem ipsum dolor adipiscing amet, ipsum adipiscing sit.", res[1000];
	int counter = 0, ind = 0;

	for (int i = 0; i < strlen(str); i++)
	{
		if (str[i] == ' ' || str[i] == '.')
			if (str[i - 1] == 'm' && str[i - 2] == 'u')
			{
				{
					for (int k = counter; k > 0; k--)
					{
						res[ind] = str[i - k];
						ind++;
					}
					res[ind] = ' ';
					ind++;
				}
			}
		
		if (str[i] == ' ')
			counter = 0;
		counter++;
	}

	res[ind] = '\0';

	for (int i = 0; i < strlen(res); i++)
	{
		cout << res[i];
	}

	return 0;
}