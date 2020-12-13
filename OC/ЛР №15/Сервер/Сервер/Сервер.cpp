#include <iostream>
#include <Windows.h>
#include <string.h>

int main(int argc, TCHAR* argv[])
{
	HANDLE hPipe;
	char buffer[1024];
	DWORD dwRead;
	DWORD dwWritten;

	hPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\Pipe"),
		PIPE_ACCESS_DUPLEX | PIPE_TYPE_BYTE | PIPE_READMODE_BYTE,   // FILE_FLAG_FIRST_PIPE_INSTANCE is not needed but forces CreateNamedPipe(..) to fail if the pipe already exists...
		PIPE_WAIT,
		1,
		1024 * 16,
		1024 * 16,
		NMPWAIT_USE_DEFAULT_WAIT,
		NULL);
	while (hPipe != INVALID_HANDLE_VALUE)
	{
		if (ConnectNamedPipe(hPipe, NULL) != FALSE)   // wait for someone to connect to the pipe
		{
			while (1)
			{
				while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
				{
					/* add terminating zero */
					buffer[dwRead] = '\0';

					/* do something with data in buffer */
					char bufferReversed[128];
					int j = 0;
					int symbolCounter = 0;
					while (buffer[j] != '\0')
					{
						symbolCounter++;
						j++;
					}
					j = 0;
					symbolCounter--;
					for (; symbolCounter >= 0; symbolCounter--, j++)
						bufferReversed[j] = buffer[symbolCounter];
					bufferReversed[j] = '\0';

					printf("CLIENT: %s\n", buffer);
					printf("Reversed word: %s\n\n", bufferReversed);
					WriteFile(hPipe,
						bufferReversed,
						sizeof(bufferReversed) + 1,   // = length of string + terminating '\0' !!!
						&dwWritten,
						NULL);
				}
				
			}
		}

		DisconnectNamedPipe(hPipe);
	}

	return 0;
}
