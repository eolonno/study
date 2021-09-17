#include <string>
#include "Winsock2.h" //заголовок WS2_32.dll
#pragma comment(lib, "WS2_32.lib") //экспорт WS2_32.dll
#pragma once
using namespace std;

//функция для формирования текста ошибки
string GetErrorMsgText(int code);

//фунция для обработки стандартных ошибок библиотеки WS2_32.dll
string SetErrorMsgText(string msgText, int code);