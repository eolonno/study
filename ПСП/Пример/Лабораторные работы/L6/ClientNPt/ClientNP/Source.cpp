#include <iostream>
#include <Windows.h>
#include "Error.h"
#include <string>
void main()
{
	HANDLE _handle;
	char buf[128];
	char mes[128] = "Hello from Client";
	std::string mess;
	DWORD lBuf, bWrite = 128;
	DWORD dwMode = PIPE_READMODE_MESSAGE;
	int numMess;
	try
	{ 
		if ((_handle = CreateFile(L"\\\\.\\pipe\\channel", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("CreateFile: ", GetLastError());
		std::cout << "Enter number of message: " << std::endl;
		std::cin >> numMess;
		if (!SetNamedPipeHandleState(_handle, &dwMode, NULL, NULL))
			throw SetPipeError("Mode: ", GetLastError());
		for (int i = 0; i < numMess; i++)
		{
			mess = "Hello from Client " + std::to_string(i + 1);
			strcpy_s(mes, mess.c_str());
			if (!TransactNamedPipe(_handle, mes, sizeof(mes), buf, sizeof(buf), &lBuf, NULL))
				throw SetPipeError("Transact: ", GetLastError());
			std::cout << buf << std::endl;
		}
		if (!WriteFile(_handle, "stop", sizeof("stop"), &lBuf, NULL))
			throw SetPipeError("WriteFile: ", GetLastError());
		CloseHandle(_handle);
	}
	catch (std::string ErrorPipeText)
	{
		std::cout << ErrorPipeText << std::endl;
	}
	system("pause");
}	