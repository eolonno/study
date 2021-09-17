#include <iostream>
#include <Windows.h>
#include "Error.h"
#include <string>
void main()
{
	HANDLE _handle;
	char buf[128];
	char mes[128];
	std::string mess;
	DWORD lBuf;
	DWORD dwMode = PIPE_READMODE_MESSAGE;
	LPTSTR pipeName = TEXT("\\\\.\\pipe\\channel");
	int numMess;
	try
	{ 
		std::cout << "Enter number of message: " << std::endl;
		std::cin >> numMess;
		for (int i = 0; i < numMess; i++)
		{
			mess = "Call Client " + std::to_string(i + 1);
			strcpy_s(mes, mess.c_str());
			if (!CallNamedPipe(pipeName, mes, sizeof(mes), buf, sizeof(buf), &lBuf, 20000))
				throw SetPipeError("Call: ", GetLastError());
			std::cout << buf << std::endl;
		}
	}
	catch (std::string ErrorPipeText)
	{
		std::cout << ErrorPipeText << std::endl;
	}
	system("pause");
}	