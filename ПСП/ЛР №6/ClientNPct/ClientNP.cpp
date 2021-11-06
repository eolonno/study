// ClientNPct
#define _CRT_SECURE_NO_WARNING
#include <iostream>
#include <Windows.h>
#include "ErrorHandling.h"
#include <tchar.h>

#define BUFSIZE 512

using namespace std;

int main()
{
	DWORD  cbRead, cbToWrite, cbWritten;
	TCHAR  chBuf[BUFSIZE] = TEXT("Hello from Client");
	TCHAR  zeroBuf[BUFSIZE] = TEXT("");
	LPTSTR lpvMessage = chBuf;
	BOOL   fSuccess = FALSE;

	HANDLE hPipe; // дескриптор канала
	try
	{
		cout << "Connected!" << endl;

		clock_t start, stop;
		start = clock();

		cbToWrite = (lstrlen(lpvMessage) + 1) * sizeof(TCHAR);

		fSuccess = CallNamedPipe(
			TEXT("\\\\tiery\\pipe\\Tube"),        // pipe name 
			lpvMessage,           // message to server 
			(lstrlen(lpvMessage) + 1) * sizeof(TCHAR), // message length 
			chBuf,              // buffer to receive reply 
			BUFSIZE * sizeof(TCHAR),  // size of read buffer 
			&cbRead,                // number of bytes read 
			20000);                 // waits for 20 seconds

		_tprintf(TEXT("%s\n"), chBuf);

		if (!fSuccess)
		{
			throw SetPipeError("transact:", GetLastError());
		}

		stop = clock();
		cout << (stop - start) << " ticks passed" << endl;

		cout << "Disconnected" << endl;
	}
	catch (string ErrorPipeText)
	{
		cout << endl << ErrorPipeText;
	}
}