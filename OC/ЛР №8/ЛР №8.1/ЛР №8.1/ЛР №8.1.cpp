#include <windows.h>
#include <iostream>

DWORD WINAPI Thread1(LPVOID lpParameter)
{
	unsigned int counter = 0;

	while (counter < 20)
	{
		Sleep(1000);
		counter++;
		printf("\n\n Thread_1 = %d\n", counter);
	}

	return 0;
}

DWORD WINAPI Thread2(LPVOID lpParameter)
{
	unsigned int counter = 0;

	while (counter < 20)
	{
		Sleep(400);
		counter++;
		printf("\n Thread_2 = %d", counter);
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
