#include "windows.h"
#include <iostream>
#include <tlhelp32.h>
#include "string.h"

#define middle 40
#define UpSize 10
#define DownSize 10

void main()
{
	int down[3] = { 2, 2, 2 };
	HANDLE consoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD cursorPos;
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 0xDD);

	for(int i = 0; i < UpSize; i++)
	{
		cursorPos.X = (middle - i);
		cursorPos.Y = i + 2;
		SetConsoleCursorPosition(consoleOutput, cursorPos);
		int tmp = i*2;
		while (tmp--)
			printf(" ");
	}

	for (int i = 0; i < DownSize; i++) 
	{
		cursorPos.X = (middle - UpSize / 2);
		cursorPos.Y =  UpSize + i + 2;
		SetConsoleCursorPosition(consoleOutput, cursorPos);
		int tmp = UpSize;
		while (tmp--)
			printf(" ");
	}

	getchar();
}