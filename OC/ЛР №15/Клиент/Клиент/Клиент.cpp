#include <iostream>
#include <string>
#include <Windows.h>


int main(int argc, TCHAR* argv[])
{
	HANDLE hPipe;
	DWORD dwWritten;
	char buffer[1024];
	DWORD dwRead;

	hPipe = CreateFile(TEXT("\\\\.\\pipe\\Pipe"),
		GENERIC_READ | GENERIC_WRITE,
		0,
		NULL,
		OPEN_EXISTING,
		0,
		NULL);
	if (hPipe != INVALID_HANDLE_VALUE)
	{
		while (1)
		{
			std::cout << "Enter the word: ";
			char str[128];
			std::cin >> str;
			WriteFile(hPipe,
				str,
				sizeof(str) + 1,   // = length of string + terminating '\0' !!!
				&dwWritten,
				NULL);

			if (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
			{
				/* add terminating zero */
				buffer[dwRead] = '\0';

				printf("SERVER: %s\n\n", buffer);
			}
		}
		CloseHandle(hPipe);
	}

	return (0);
}
