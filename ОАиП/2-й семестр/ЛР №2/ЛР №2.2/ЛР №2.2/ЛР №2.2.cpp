//Компоненты файла f –  целые двухзначные(отличные от нуля) числа, причем 10 положительных чи - сел, 10 отрицательных, и т.д.
//Получить файл g, в котором записаны сначала 5 положительных чисел, затем 5 отрицательных и т.д.
#include <stdio.h>
#include <iostream>
#include <string>
#include <fstream>


int main() {
	setlocale(LC_CTYPE, "rus");
	FILE* f, *g;
	fopen_s(&f, "f.txt", "r");
	fopen_s(&g, "g.txt", "w");

	if (f != 0 && g != 0)
		printf("Файл успешно открыт\n");
	else return 1;

	char fa[70];
	fgets(fa, 70, f);

	char strnums[3];
	int intnums[20];
	int i = -1;
	int strnumsindex = 0;
	int intnumsindex = 0;
	while(fa[i] != '\0')
	{
		i++;
		for (; fa[i] != ' ' && fa[i] != '\0'; i++) {
			strnums[strnumsindex] = fa[i];
			strnumsindex++;
		}
		intnums[intnumsindex] = atof(strnums);
		intnumsindex++;
		for (int j = 2; j > 0; j--)
			strnums[j] = '\0';
		strnumsindex = 0;
	}

	int OutputCounter = 1;
	while (OutputCounter <= 20) {
		for (int i = 0; i < 20; i++)
		{
			if ((OutputCounter <= 5 || (OutputCounter > 10 && OutputCounter <= 15)) && intnums[i] > 0 && intnums[i] != 100)
			{
				fprintf(g, "%d ", intnums[i]);
				intnums[i] = 100;
				break;
			}
			else if (((OutputCounter > 5 && OutputCounter <= 10 ) || (OutputCounter > 15)) && intnums[i] < 0 && intnums[i] != 100)
			{
				fprintf(g, "%d ", intnums[i]);
				intnums[i] = 100;
				break;
			}
		}
		OutputCounter++;
	}


	
	fclose(f);
	return 0;
}
