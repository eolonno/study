#include "windows.h"
#include <iostream>
#include <tlhelp32.h>
#include "string.h"
#include <locale.h>
#include <stdio.h>

using namespace std;

int main()
{
	int index = 1, LastNameRow = 0, LastNameColumn = 0, GroupColumn = 0, GroupRow = 0;
	char lastName[][10] = { "Last name", "Frolov", "Leonov", "Alekseev" };
	char group[][6] = { "Group", "3", "12", "10" };

	printf("%c", 201);
	for (int i = 0; i < 24; i++)
	{
		if (i == 15) printf("%c", 203);
		else printf("%c", 205);
	}
	printf("%c", 187);

	HANDLE consoleOutput;
	COORD cursorPos;
	consoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);

	while (index < 9)
	{
		cursorPos.X = 0;
		cursorPos.Y = index;
		SetConsoleCursorPosition(consoleOutput, cursorPos);
		printf("%c", 186);
		printf("  ");
		while (LastNameRow < 10)
		{
			printf("%c", lastName[LastNameColumn][LastNameRow]);
			LastNameRow++;
		}
		LastNameColumn++;
		LastNameRow = 0;

		cursorPos.X = 16;
		SetConsoleCursorPosition(consoleOutput, cursorPos);
		printf("%c", 186);
		cursorPos.X = 19;
		SetConsoleCursorPosition(consoleOutput, cursorPos);

		while (GroupColumn < 6)
		{
			printf("%c", group[GroupRow][GroupColumn]);
			GroupColumn++;
		}
		GroupRow++;
		GroupColumn = 0;
		printf("%c", 186);

		++index;

		if (index < 7)
		{
			cursorPos.Y = index;
			cursorPos.X = 0;
			SetConsoleCursorPosition(consoleOutput, cursorPos);
			printf("%c", 204);
			for (int i = 0; i < 24; i++)
			{
				if (i == 15) printf("%c", 206);
				else printf("%c", 205);
			}
			printf("%c", 185);
		}
		++index;
	}

	cursorPos.Y = index - 1;
	cursorPos.X = 0;
	SetConsoleCursorPosition(consoleOutput, cursorPos);
	printf("%c", 200);
	for (int i = 0; i < 24; i++)
	{
		if (i == 15) printf("%c", 202);
		else printf("%c", 205);
	}
	printf("%c", 188);

	getchar();
	return 0;
}