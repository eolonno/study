#include <windows.h>
#include <iostream>


int main(int argc, TCHAR* argv[])
{
	HANDLE hslot;
	hslot = CreateMailslot(L"\\\\.\\mailslot\\demoslot", 0, MAILSLOT_WAIT_FOREVER, NULL);
	if (hslot == INVALID_HANDLE_VALUE)
	{

		std::cout << "SLOT FAILED" << std::endl;
		std::cout << "PRESS KEY TO FINICH" << std::endl;
		std::cin.get();
		return 0;

	}

	std::cout << "SLOT IS WAITING" << std::endl;
	std::string Data = "";

	DWORD BytesRead;
	while (true) {
		if (!ReadFile(hslot, &Data, sizeof(Data), &BytesRead, (LPOVERLAPPED)NULL))
		{
			std::cout << "READING SLOT FAILED" << std::endl;
			CloseHandle(hslot);
			return 0;
		}
			std::cout << "Data Read: " << Data << std::endl;
			Data = "";
	}

	return 0;
}
