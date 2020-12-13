#include <windows.h>
#include <iostream>

#define COUNT 10

int random;

DWORD WINAPI Thread1(LPVOID lpParameter)
{
	for (int i = 0; i < COUNT; i++)
	{
		random = rand() % 2000 - 1000;
		Sleep(700);
	}

	return 0;
}

DWORD WINAPI Thread2(LPVOID lpParameter)
{
	for (int i = 0; i < COUNT; i++)
	{
		std::cout << "Random number #" << i + 1 << ": " << random << std::endl;
		Sleep(700);
	}

	return 0;
}

int main(int argc, TCHAR* argv[])
{
	HANDLE hwd[2];

	hwd[0] = CreateThread(NULL, 0, Thread1, NULL, 0, 0);
	hwd[1] = CreateThread(NULL, 0, Thread2, NULL, 0, 0);

	WaitForSingleObject(hwd[0], INFINITE);

	return 0;
}
