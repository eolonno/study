// ClientNP
#define _CRT_SECURE_NO_WARNING
#include <iostream>
#include <Windows.h>
#include "ErrorHandling.h"
#include <tchar.h>

#define BUFSIZE 512

using namespace std;

int main()
{
	LPCWSTR lpvMessage = TEXT("Hello from Client");
	DWORD  cbRead, cbToWrite, cbWritten;
	TCHAR  chBuf[BUFSIZE];
	BOOL   fSuccess = FALSE;

	HANDLE hPipe; // дескриптор канала
	try
	{
		if ((hPipe = CreateFile(
			TEXT("\\\\tiery\\pipe\\Tube"),
			GENERIC_READ | GENERIC_WRITE,
			FILE_SHARE_READ | FILE_SHARE_WRITE,
			NULL, OPEN_EXISTING, NULL,
			NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("createfile:", GetLastError());

		cout << "Connected!" << endl;

		//..................................................................
		int num = 0;
		cout << "Enter number: ";
		cin >> num;

		clock_t start, stop;
		start = clock();

		for (int i = num; i > 0; i--)
		{
			char hello[] = "Hello from Client ";
			char numberstring[(((sizeof i) * CHAR_BIT) + 2) / 3 + 2];
			sprintf_s(numberstring, "%d", i);

			char result[BUFSIZE];   // array to hold the result.
			strcpy_s(result, hello); // copy string one into the result.
			strcat_s(result, numberstring);
			
			wchar_t* wtext = new wchar_t[BUFSIZE];

			size_t outSize;
			mbstowcs_s(&outSize, wtext, BUFSIZE, result, BUFSIZE - 1);
			lpvMessage = wtext;

			cbToWrite = (lstrlen(lpvMessage) + 1) * sizeof(TCHAR);

			fSuccess = WriteFile(
				hPipe, // pipe handle
				lpvMessage, // message
				cbToWrite, // message length
				&cbWritten, // bytes written
				NULL); // not overlapped

			if (!fSuccess)
			{
				throw SetPipeError("writefile:", GetLastError());
			}

			//..................................................................

			do
			{
				fSuccess = ReadFile(
					hPipe, // pipe handle
					chBuf, // buffer to receive reply
					BUFSIZE * sizeof(TCHAR), // size of buffer
					&cbRead, // number of bytes read
					NULL); // not overlapped

				_tprintf(TEXT("%s\n"), chBuf);
			} while (!fSuccess);

			if (!fSuccess)
			{
				throw SetPipeError("readfile:", GetLastError());
			}
		}


		stop = clock();
		cout << (stop - start) << " ticks passed" << endl;

		lpvMessage = TEXT("");

		cbToWrite = (lstrlen(lpvMessage) + 1) * sizeof(TCHAR);

		fSuccess = WriteFile(
			hPipe, // pipe handle
			lpvMessage, // message
			cbToWrite, // message length
			&cbWritten, // bytes written
			NULL); // not overlapped

		if (!fSuccess)
		{
			throw SetPipeError("writefile:", GetLastError());
		}

		cout << "Disconnected" << endl;
		CloseHandle(hPipe);
	}
	catch (string ErrorPipeText)
	{
		cout << endl << ErrorPipeText;
	}

}