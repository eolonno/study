#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>


int main(int argc, TCHAR* argv[])
{

    HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);

    SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_GREEN |

        FOREGROUND_INTENSITY | BACKGROUND_BLUE);

    HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (hSnapshot) {
        PROCESSENTRY32 pe32;
        pe32.dwSize = sizeof(PROCESSENTRY32);
        if (Process32First(hSnapshot, &pe32)) {
            do {

                std::wcout << "Running  ProcName: " << pe32.szExeFile << '\n';
            } while (Process32Next(hSnapshot, &pe32));
        }
        CloseHandle(hSnapshot);
    }

    getchar();

    return 0;
}
