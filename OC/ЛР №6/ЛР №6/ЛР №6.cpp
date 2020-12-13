#include <Windows.h>
#include <iostream>

TCHAR Buffer[] = TEXT("Glad to hear from You"); // Строка для записи в файл

void Continue();
void CreateDir();
void CreateAndWrite();
void Copy();
void Delete();
void RenameAndRead();

int main(int argc, TCHAR* argv[])
{
    CreateDir();            // Первое задание
    CreateAndWrite();       // Второе задание
    Copy();                 // Третье задание
    Delete();               // Четвертое задание
    RenameAndRead();        // Пятое задание

    return 0;
}

void Continue() {
    printf("Press enter to continue...");
    getchar();
    printf("\n");
}

void CreateDir() {
    TCHAR Buffer[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Первый каталог");
    TCHAR Buffer1[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Второй каталог");

    if (CreateDirectory(Buffer, NULL) && CreateDirectory(Buffer1, NULL))
        std::wcout << "Directory was created" << '\n';
    else
        std::wcout << "Error creating directory" << '\n';
    Continue();
}

void CreateAndWrite() {
    DWORD nLenCurDir;
    HANDLE hOut;
    DWORD dwNumberOfBytes;

    TCHAR stdPath[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Первый каталог\\Второе задание.txt");

    hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL,
        CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

    if (hOut == INVALID_HANDLE_VALUE) {
        printf("ERROR %x \n", GetLastError());
    }

    else
    {
        nLenCurDir = GetCurrentDirectory(256, stdPath);
        WriteFile(hOut, Buffer, sizeof(Buffer), NULL, NULL);
        printf("File successfully created\n");
        CloseHandle(hOut);
    }
    Continue();
}

void Copy() {

    TCHAR stdPathA[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Первый каталог\\Второе задание.txt");
    TCHAR stdPathB[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Второй каталог\\Второе задание.txt");

    if (CopyFile(stdPathA, stdPathB, FALSE))
        printf("File was copied\n");
    else
        printf("Copy Error\n");
    Continue();
}

void Delete() {
    TCHAR stdPathA[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Первый каталог\\Второе задание.txt");

    if (DeleteFile(stdPathA))
        printf("File successfully deleted\n");
    else
        printf("Error deleting file\n");
    Continue();
}

void RenameAndRead() {
    TCHAR stdPathA[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Второй каталог\\Второе задание.txt");
    TCHAR stdPathB[] = TEXT("D:\\Учеба\\OC\\ЛР №6\\Второй каталог\\Пятое задание.txt");

    if (MoveFile(stdPathA, stdPathB))
        printf("File was copied\n");
    else
        printf("Copy Error\n");


    TCHAR BufferToRead[256];
    DWORD dwNumberOfBytes;

    HANDLE hIn = CreateFile(stdPathB, GENERIC_READ, 0, NULL,
        OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

    if (hIn == INVALID_HANDLE_VALUE) {
        printf("ERROR %x \n", GetLastError());
        getchar();
    }

    else
    {
        ReadFile(hIn, BufferToRead, sizeof(Buffer), &dwNumberOfBytes, NULL);
        printf("Data read\n");
        CloseHandle(hIn);
        WriteFile(GetStdHandle(STD_OUTPUT_HANDLE), Buffer, sizeof(Buffer), NULL, NULL);
        printf("\n");
    }
}