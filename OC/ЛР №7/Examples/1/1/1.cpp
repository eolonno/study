#include <windows.h>
#include <iostream>
#include <string>
#include <tlhelp32.h>

bool IsProcessRun(TCHAR*);

int main(int argc, TCHAR* argv[])
{
    WIN32_FIND_DATA FindFileData;
    HANDLE hFind = INVALID_HANDLE_VALUE;

    TCHAR filesearch[] = TEXT("C:\\Windows\\System32\\note*.exe");
    // Find the first file in the directory.
    hFind = FindFirstFile(filesearch, &FindFileData);

    if (hFind == INVALID_HANDLE_VALUE)
        printf("Invalid file handle. Error is %u.\n", GetLastError());
    else
    {
        std::wcout << "Found: " << FindFileData.cFileName << '\n';

        STARTUPINFO cif;
        ZeroMemory(&cif, sizeof(STARTUPINFO));
        PROCESS_INFORMATION pi = { 0 };

        if (!(CreateProcess(NULL, FindFileData.cFileName, NULL, NULL, FALSE, 0, NULL, NULL, &cif, &pi)))
            std::wcout << "Error " << GetLastError() << '\n';
    }

    return 0;
}