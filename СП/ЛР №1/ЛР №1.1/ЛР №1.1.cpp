/**
 * Application OS09_01
 * Created by Anikeyenka Yahor
 */
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>

BOOL printFileInfo(LPWSTR FileName);

int main(int argc, char** argv)
{
	setlocale(LC_ALL, "rus");
	char text[] = "D:\\Учеба\\СП\\ЛР №1\\lab1.txt";
	wchar_t wtext[40];
	mbstowcs(wtext, text, strlen(text) + 1);
	LPWSTR ptr = wtext;
	printFileInfo(ptr);
}

BOOL printFileInfo(LPWSTR FileName)
{
	struct stat fileInfo;


	if (stat((char*)FileName, &fileInfo) != 0) {  // Use stat() to get the info
		return(EXIT_FAILURE);
	}

	std::cout << "Type:         : ";
	if ((fileInfo.st_mode & S_IFMT) == S_IFDIR) { // From sys/types.h
		std::cout << "Directory\n";
	}
	else {
		std::cout << "File\n";
	}
	std::wstring ws(FileName);
	std::string s(ws.begin(), ws.end());

	size_t i = s.rfind("\\", s.length());

	std::cout << "Name			: ";
	if (i != std::string::npos) {
		std::cout << (s.substr(i + 1, s.length() - i));
	}

	std::cout << '\n';
	std::cout << "Size          : " <<
		fileInfo.st_size << " bytes\n";               // Size in bytes
	std::cout << "Created       : " <<
		std::ctime(&fileInfo.st_ctime);         // Creation time
	std::cout << "Modified      : " <<
		std::ctime(&fileInfo.st_mtime);         // Last mod time

	return 0;
}
