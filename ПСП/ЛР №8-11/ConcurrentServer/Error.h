#pragma once
#include <iostream>
#include <string>
#include "Winsock2.h"              
#pragma comment(lib,"WS2_32.lib")
#include "Windows.h"


using std::string;
using namespace std;

string  GetErrorMsgText(int code)    
{
	string msgText;   
	switch (code)                      // проверка кода возврата  
	{
	case WSAEINTR:                  msgText = "WSAEINTR";               break;    //Работа функции прервана
	case WSAEACCES:                 msgText = "WSAEACCES";              break;    //Разрешение отвергнуто
	case WSAEFAULT:                 msgText = "WSAEFAULT";              break;    //Ошибочный адрес
	case WSAEINVAL:                 msgText = "WSAEINVAL";              break;    //Ошибка в аргументе
	case WSAEMFILE:                 msgText = "WSAEMFILE";              break;    //Слишком много файлов открыто
	case WSAEWOULDBLOCK:            msgText = "WSAEWOULDBLOCK";         break;    //Ресурс временно недоступен
	case WSAEINPROGRESS:            msgText = "WSAEINPROGRESS";         break;    //Операция в процессе развития
	case WSAEALREADY:               msgText = "WSAEALREADY";            break;    //Операция уже выполняется
	case WSAENOTSOCK:               msgText = "WSAENOTSOCK";            break;    //Сокет задан неправильно
	case WSAEDESTADDRREQ:           msgText = "WSAEDESTADDRREQ";        break;    //Требуется адрес расположения
	case WSAEMSGSIZE:               msgText = "WSAEMSGSIZE";            break;    //Сообщение слишком длинное
	case WSAEPROTOTYPE:             msgText = "WSAEPROTOTYPE";          break;    //Неправильный тип протокола для сокета
	case WSAENOPROTOOPT:            msgText = "WSAENOPROTOOPT";         break;    //Ошибка в опции протокола
	case WSAEPROTONOSUPPORT:        msgText = "WSAEPROTONOSUPPORT";     break;    //Протокол не поддерживается
	case WSAESOCKTNOSUPPORT:        msgText = "WSAESOCKTNOSUPPORT";     break;    //Тип сокета не поддерживается
	case WSAEOPNOTSUPP:             msgText = "WSAEOPNOTSUPP";          break;    //Операция не поддерживается
	case WSAEPFNOSUPPORT:           msgText = "WSAEPFNOSUPPORT";        break;    //Тип протоколов не поддерживается
	case WSAEAFNOSUPPORT:           msgText = "WSAEAFNOSUPPORT";        break;    //Тип адресов не поддерживается протоколом
	case WSAEADDRINUSE:             msgText = "WSAEADDRINUSE";          break;    //Адрес уже используется
	case WSAEADDRNOTAVAIL:          msgText = "WSAEADDRNOTAVAIL";       break;    //Запрошенный адрес не может быть использован
	case WSAENETDOWN:               msgText = "WSAENETDOWN";            break;    //Сеть отключена
	case WSAENETUNREACH:            msgText = "WSAENETUNREACH";         break;    //Сеть не достижима
	case WSAENETRESET:              msgText = "WSAENETRESET";           break;    //Сеть разорвала соединение
	case WSAECONNABORTED:           msgText = "WSAECONNABORTED";        break;    //Программный отказ связи
	case WSAECONNRESET:             msgText = "WSAECONNRESET";          break;    //Связь восстановлена
	case WSAENOBUFS:                msgText = "WSAENOBUFS";             break;    //Не хватает памяти для буферов
	case WSAEISCONN:                msgText = "WSAEISCONN";             break;    //Сокет уже подключен
	case WSAENOTCONN:               msgText = "WSAENOTCONN";            break;    //Сокет не подключен
	case WSAESHUTDOWN:              msgText = "WSAESHUTDOWN";           break;    //Нельзя выполнить send: сокет завершил работу
	case WSAETIMEDOUT:              msgText = "WSAETIMEDOUT";           break;    //Закончился отведенный интервал  времени
	case WSAECONNREFUSED:           msgText = "WSAECONNREFUSED";        break;    //Соединение отклонено
	case WSAEHOSTDOWN:              msgText = "WSAEHOSTDOWN";           break;    //Хост в неработоспособном состоянии
	case WSAEHOSTUNREACH:           msgText = "WSAEHOSTUNREACH";        break;    //Нет маршрута для хоста
	case WSAEPROCLIM:               msgText = "WSAEPROCLIM";            break;    //Слишком много процессов
	case WSASYSNOTREADY:            msgText = "WSASYSNOTREADY";         break;    //Сеть не доступна
	case WSAVERNOTSUPPORTED:        msgText = "WSAVERNOTSUPPORTED";     break;    //Данная версия недоступна
	case WSANOTINITIALISED:         msgText = "WSANOTINITIALISED";      break;    //Не выполнена инициализация WS2_32.DLL
	case WSAEDISCON:                msgText = "WSAEDISCON";             break;    //Выполняется отключение
	case WSATYPE_NOT_FOUND:         msgText = "WSATYPE_NOT_FOUND";      break;    //Класс не найден
	case WSAHOST_NOT_FOUND:         msgText = "WSAHOST_NOT_FOUND";      break;    //Хост не найден
	case WSATRY_AGAIN:              msgText = "WSATRY_AGAIN";           break;    //Неавторизированный хост не найден
	case WSANO_RECOVERY:            msgText = "WSANO_RECOVERY";         break;    //Неопределенная  ошибка
	case WSANO_DATA:                msgText = "WSANO_DATA";             break;    //Нет записи запрошенного типа
	case WSA_INVALID_HANDLE:		msgText = "WSA_INVALID_HANDLE";     break;    //Указанный дескриптор события  с ошибкой
	case WSA_INVALID_PARAMETER:		msgText = "WSA_INVALID_PARAMETER";  break;    //Один или более параметров с ошибкой
	case WSA_IO_INCOMPLETE:			msgText = "WSA_IO_INCOMPLETE";      break;    //Объект ввода-вывода не в сигнальном состоянии
	case WSA_IO_PENDING:			msgText = "WSA_IO_PENDING";         break;    //Операция завершится позже
	case WSA_NOT_ENOUGH_MEMORY:		msgText = "WSA_NOT_ENOUGH_MEMORY";  break;    //Не достаточно памяти
	case WSA_OPERATION_ABORTED:		msgText = "WSA_OPERATION_ABORTED";  break;    //Операция отвергнута
	case WSASYSCALLFAILURE:         msgText = "WSASYSCALLFAILURE";      break; 
	default:						msgText = "***ERROR***";			break;  
	};
	return msgText;
}
string  SetErrorMsgText(string msgText, int code)
{
	return  msgText+GetErrorMsgText(code);
};