#include <windows.h>
#include <iostream>
#include "string.h"

int main(int argc, TCHAR* argv[])
{
    DWORD processID;
    STARTUPINFO cif;
    ZeroMemory(&cif, sizeof(STARTUPINFO));
    PROCESS_INFORMATION pi;
    TCHAR buf[] = TEXT("mspaint.exe");
    if (!(processID = CreateProcess(NULL, buf, NULL, NULL, FALSE, 0,
        NULL, NULL, &cif, &pi)))
        std::wcout << "Running " << '\n';

    HANDLE hProcess = GetCurrentProcess(); //получаем pID консольного приложен.

    if (NULL != hProcess)
    {
        Sleep(200);
        BOOL result = TerminateProcess(hProcess, 0);

        CloseHandle(hProcess);
    }
    else
    {
        std::wcout << "Error when terminating " << '\n';
    }
    getchar();
    return 0;
}
