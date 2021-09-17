#include <iostream>
#include <Windows.h>
#include "Error.h"

void main()
{
	HANDLE _handle;
	char buf[128];
	DWORD lBuf;
	DWORD bufSize = 128;
	try
	{	
		if ((_handle = CreateNamedPipe(L"\\\\.\\pipe\\channel",
			PIPE_ACCESS_DUPLEX,
			PIPE_TYPE_MESSAGE | PIPE_WAIT | PIPE_READMODE_MESSAGE,
			1, NULL, NULL,
			INFINITE, NULL)) == INVALID_HANDLE_VALUE)
		{
			throw SetPipeError("Create: ", GetLastError());
		}
		std::cout << "Wait..." << std::endl;
		if (!ConnectNamedPipe(_handle, NULL))
			std::cout << "Connected false" << std::endl;
		else
			std::cout << "Connected" << std::endl;
		while (true)
		{
			ConnectNamedPipe(_handle, NULL);
			if (!ReadFile(_handle, buf, sizeof(buf), &lBuf, NULL))
				throw SetPipeError("ReadFile: ", GetLastError());
			if (strcmp(buf, "stop") == 0)
				break;
			std::cout << buf << std::endl;
			if (!WriteFile(_handle, buf, sizeof(buf), &lBuf, NULL))
				throw SetPipeError("WriteFile: ", GetLastError());
			if(buf[0] == 'C')
				DisconnectNamedPipe(_handle);
		}
		DisconnectNamedPipe(_handle);
		CloseHandle(_handle);
	}
	catch (std::string ErrorPipeText)
	{
		std::cout << ErrorPipeText.c_str() << std::endl;
	}
	system("pause");
	
}