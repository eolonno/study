//В заданном предложении указать слово, в котором доля гласных (A, E, I, O, U — строчных или прописных) максимальна.
#include <iostream>
using namespace std;

int main()
{
	char given[] = "aAeEiIoOuU";
	string str[] = { "Lorem ", "ipsum ", "dolor ", "sit ", "amet,", "consectetur ", "adipiscing ", "elit." }; 
	int counter[] = { 0,0,0,0,0,0,0,0 };

	for (int i = 0; i < 8; i++)
	{
		for (int k = 0; k  < str[i].size(); k ++)
		{
			for (int givencounter = 0; givencounter < 10; givencounter++)
			{
				if (str[i][k] == given[givencounter])
					counter[i]++;
			}
			
		}
	}

	int max = 0;
	for (int i = 0; i < 8; i++)
	{
		if (max <= counter[i])
			max = i;
	}

	for (int i = 0; i < str[max].size(); i++)
	{
		cout << str[max][i];
	}


	return 0;
}