#include <windows.h>
#include <iostream>
#include <string>

#define TIMES 5

HANDLE hslot = CreateFile(L"\\\\.\\mailslot\\demoslot", GENERIC_WRITE, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL);
CRITICAL_SECTION section;

DWORD WINAPI CLIENT_1(LPVOID param);
DWORD WINAPI CLIENT_2(LPVOID param);

int main(int argc, TCHAR* argv[])
{
	HANDLE threads[2];

	InitializeCriticalSection(&section);

	threads[0] = CreateThread(NULL, NULL, CLIENT_1, NULL, 0, NULL);
	threads[1] = CreateThread(NULL, NULL, CLIENT_2, NULL, 0, NULL);

	WaitForMultipleObjects(1, threads, TRUE, INFINITE);

	DeleteCriticalSection(&section);
	CloseHandle(hslot);
	return 0;
}

DWORD WINAPI CLIENT_2(LPVOID param) {
	EnterCriticalSection(&section);
	if (hslot == INVALID_HANDLE_VALUE)
	{

		std::cout << "CLIENT_2 WRITING ERROR" << std::endl;
		LeaveCriticalSection(&section);
		return 0;
	}
	LeaveCriticalSection(&section);

	for (int i = 0; i < TIMES; i++) {
		EnterCriticalSection(&section);

		std::string number = std::to_string(rand() % 200 - 100);
		DWORD dwBytesWrite;
		if (!WriteFile(hslot, &number, sizeof(number), &dwBytesWrite, NULL))
		{
			std::cout << "CLIENT_2 WRITING ERROR" << std::endl;
			LeaveCriticalSection(&section);
			return 0;
		}

		std::cout << "Data WRITTEN TO BOX: " << number << std::endl;
		LeaveCriticalSection(&section);
		Sleep(5);
	}
	CloseHandle(hslot);
	return 0;
}
DWORD WINAPI CLIENT_1(LPVOID param) {
	EnterCriticalSection(&section);
	if (hslot == INVALID_HANDLE_VALUE)
	{
		std::cout << "CLIENT_1 WRITING ERROR" << std::endl;
		LeaveCriticalSection(&section);
		return 0;
	}
	LeaveCriticalSection(&section);

	for (int i = 0; i < TIMES; i++) {
		EnterCriticalSection(&section);

		std::string str = "Entry #";
		str.append(std::to_string(i + 1));
		DWORD dwBytesWrite;
		if (!WriteFile(hslot, &str, sizeof(str), &dwBytesWrite, NULL))
		{
			std::cout << "CLIENT_1 WRITING ERROR" << GetLastError() << std::endl;
			LeaveCriticalSection(&section);
			return 0;
		}

		std::cout << "Data WRITTEN TO BOX: " << str << std::endl;

		LeaveCriticalSection(&section);
		Sleep(5);
	}
	CloseHandle(hslot);
	return 0;
}