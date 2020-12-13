#include <windows.h>
#include <iostream>
#include <string>

CRITICAL_SECTION cs = { 0 };

int size = 0;

DWORD WINAPI Write(void* lpPar) {
    for (int i = 0; i < 10; i++) {
        EnterCriticalSection(&cs);
        DWORD nLenCurDir;
        HANDLE hOut;
        DWORD dwNumberOfBytes;

        TCHAR stdPath[] = TEXT("D:\\Учеба\\OC\\ЛР №9\\Задание.txt");

        hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL,
            CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

        if (hOut == INVALID_HANDLE_VALUE) {
            printf("ERROR %x \n", GetLastError());
            return 1;
        }

        else
        {
            std::wstring buf = std::to_wstring((int)(rand() % 100 - 50));

            size = sizeof(buf.c_str());

            WriteFile(hOut, buf.c_str(), size, NULL, NULL);
            CloseHandle(hOut);
        }
        //std::cout << "write " << i << std::endl;
        LeaveCriticalSection(&cs);
        Sleep(5);
    }
    return 0;
}

DWORD WINAPI Read(void* lpPar) {
    for (int i = 0; i < 10; i++) {
        EnterCriticalSection(&cs);
        TCHAR stdPath[] = TEXT("D:\\Учеба\\OC\\ЛР №9\\Задание.txt");


        TCHAR BufferToRead[256];
        DWORD dwNumberOfBytes;

        HANDLE hIn = CreateFile(stdPath, GENERIC_READ, 0, NULL,
            OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

        if (hIn == INVALID_HANDLE_VALUE) {
            printf("ERROR %x \n", GetLastError());
            return 0;
        }

        else
        {
            ReadFile(hIn, BufferToRead, sizeof(BufferToRead), &dwNumberOfBytes, NULL);
            CloseHandle(hIn);
            WriteFile(GetStdHandle(STD_OUTPUT_HANDLE), BufferToRead, size, NULL, NULL);
            printf("\n");  
        }

        //std::cout << "read " << i << std::endl;
        LeaveCriticalSection(&cs);
        Sleep(5);
    }
    return 0;
}


int main(int argc, TCHAR* argv[])
{
    HANDLE threads[2];

    InitializeCriticalSection(&cs);

    threads[0] = CreateThread(NULL, 0, Write, NULL, 0, 0);
    threads[1] = CreateThread(NULL, 0, Read, NULL, 0, 0);

    WaitForMultipleObjects(2, threads, TRUE, INFINITE);

    DeleteCriticalSection(&cs);

    return 0;
}