#include <iostream>
#include <Windows.h>
#include <string>

void main()
{
	HANDLE hM;
	//HANDLE hMm;
	DWORD lBuf;
	int num;
	try
	{
		//if ((hM = CreateFile(L"\\\\butterfly\\mailslot\\box", GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
			//throw "CreateFileError";
		if ((hM = CreateFile(L"\\\\.\\mailslot\\box", GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
			throw "CreateFileError";
		std::cout << "Enter number of message: ";
		std::cin >> num;
		for (int i = 0; i < num; i++)
		{
			char buf[128] = "Hello from Mail-slot Client ";
			char buf1[128] = "Hello to Honey ";
			strcat_s(buf, std::to_string(i + 1).c_str());
			strcat_s(buf1, std::to_string(i + 1).c_str());
			//if (!WriteFile(hM, buf, sizeof(buf), &lBuf, NULL))
				//throw "WriteFileError";
			if (!WriteFile(hM, buf, sizeof(buf), &lBuf, NULL))
				throw "WriteFileError";
		}
		if (!WriteFile(hM, "stop", sizeof("stop"), &lBuf, NULL))
			throw "WriteFileError";
		//if (!WriteFile(hMm, "stop", sizeof("stop"), &lBuf, NULL))
		//	throw "WriteFileError";
		CloseHandle(hM);
		//CloseHandle(hMm);
	}
	catch (char *Error)
	{
		std::cout << Error << std::endl;
	}
	system("pause");
}