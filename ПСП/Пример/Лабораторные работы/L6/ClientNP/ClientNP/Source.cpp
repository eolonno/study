#include <iostream>
#include <Windows.h>
#include "Error.h"
#include <string>
void main()
{
	HANDLE _handle;
	char buf[128];
	std::string mess;
	DWORD lBuf, bWrite = 128;
	int numMess;
	
	try
	{ 
		if ((_handle = CreateFile(TEXT("\\\\.\\pipe\\channel"), GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("CreateFile: ", GetLastError());
		std::cout << "Enter number of message: " << std::endl;
		std::cin >> numMess;
		for (int i = 0; i < numMess; i++)
		{
			mess = "Hello from Client " + std::to_string(i + 1);
			if (!WriteFile(_handle, mess.c_str(), sizeof(mess), &lBuf, NULL))
				throw SetPipeError("WriteFile: ", GetLastError());
			if (!ReadFile(_handle, buf, sizeof(buf), &lBuf, NULL))
				throw SetPipeError("ReadFile: ", GetLastError());
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