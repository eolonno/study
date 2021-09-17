#pragma once
#include "Winsock2.h"
#include <string>
using namespace std;

string GetErrorSocketMsgByCode(int code)
{
	string msg = "";
	switch (code)
	{
	case WSAEINTR: msg = "Работа функции прервана"; break;
	case WSAEACCES: msg = "Разрешение отвергнуто"; break;
	case WSAEFAULT: msg = "Ошибочный адрес"; break;
	case WSAEINVAL: msg = "Ошибка в аргументе"; break;
	case WSAEMFILE: msg = "Слишком много файлов открыто"; break;
	case WSAEWOULDBLOCK: msg = "Ресурс временно недоступен"; break;
	case WSAEINPROGRESS: msg = "Операция в процессе развития"; break;
	case WSAEALREADY: msg = "Операция уже выполняется"; break;
	case WSAENOTSOCK: msg = "Сокет задан неправильно"; break;
	case WSAEDESTADDRREQ: msg = "Требуется адрес расположения"; break;
	case WSAEMSGSIZE: msg = "Сообщение слишком длинное"; break;
	case WSAEPROTOTYPE: msg = "Неправильный тип протокола для сокета"; break;
	case WSAENOPROTOOPT: msg = "Ошибка в опции протокола"; break;
	case WSAEPROTONOSUPPORT: msg = "Протокол не поддерживается"; break;
	case WSAESOCKTNOSUPPORT: msg = "Тип сокета не поддерживается"; break;
	case WSAEOPNOTSUPP: msg = "Операция не поддерживается"; break;
	case WSAEPFNOSUPPORT: msg = "Тип протоколов не поддерживается"; break;
	case WSAEAFNOSUPPORT: msg = "Тип адресов не поддерживается протоколом"; break;
	case WSAEADDRINUSE: msg = "Адрес уже используется"; break;
	case WSAEADDRNOTAVAIL: msg = "Запрошенный адрес не может быть использован"; break;
	case WSAENETDOWN: msg = "Сеть отключена"; break;
	case WSAENETUNREACH: msg = "Сеть не достижима"; break;
	case WSAENETRESET: msg = "Сеть разорвала соединение"; break;
	case WSAECONNABORTED: msg = "Программный отказ связи"; break;
	case WSAECONNRESET: msg = "Связь восстановлена"; break;
	case WSAENOBUFS: msg = "Не хватает памяти для буферов"; break;
	case WSAEISCONN: msg = "Сокет уже подключен"; break;
	case WSAENOTCONN: msg = "Сокет не подключен"; break;
	case WSAESHUTDOWN: msg = "Нельзя выполнить send : сокет завершил работу"; break;
	case WSAETIMEDOUT: msg = "Закончился отведенный интервал  времени"; break;
	case WSAECONNREFUSED: msg = "Соединение отклонено"; break;
	case WSAEHOSTDOWN: msg = "Хост в неработоспособном состоянии"; break;
	case WSAEHOSTUNREACH: msg = "Нет маршрута для хоста"; break;
	case WSAEPROCLIM: msg = "Слишком много процессов"; break;
	case WSASYSNOTREADY: msg = "Сеть не доступна"; break;
	case WSAVERNOTSUPPORTED: msg = "Данная версия недоступна"; break;
	case WSANOTINITIALISED: msg = "Не выполнена инициализация WS2_32.DLL"; break;
	case WSAEDISCON: msg = "Выполняется отключение"; break;
	case WSATYPE_NOT_FOUND: msg = "Класс не найден"; break;
	case WSAHOST_NOT_FOUND: msg = "Хост не найден"; break;
	case WSATRY_AGAIN: msg = "Неавторизированный хост не найден"; break;
	case WSANO_RECOVERY: msg = "Неопределенная  ошибка"; break;
	case WSANO_DATA: msg = "Нет записи запрошенного типа"; break;
	case WSA_INVALID_HANDLE: msg = "Указанный дескриптор события  с ошибкой"; break;
	case WSA_INVALID_PARAMETER: msg = "Один или более параметров с ошибкой"; break;
	case WSA_IO_INCOMPLETE: msg = "Объект ввода - вывода не в сигнальном состоянии"; break;
	case WSA_IO_PENDING: msg = "Операция завершится позже"; break;
	case WSA_NOT_ENOUGH_MEMORY: msg = "Не достаточно памяти"; break;
	case WSA_OPERATION_ABORTED: msg = "Операция отвергнута"; break;
	case WSASYSCALLFAILURE: msg = "Аварийное завершение системного вызова"; break;
	default:msg = "Неизвестная ошибка";
		break;
	}
	return msg;
}

string GetErrorMsg(string place, int code)
{
	return place + " " + GetErrorSocketMsgByCode(code);
}