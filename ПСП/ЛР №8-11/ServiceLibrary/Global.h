//Global DLL
#pragma once
#include "locale.h"
#include <iostream>
#include "Winsock2.h"              
#pragma comment(lib,"WS2_32.lib")
#include "Windows.h"
#include <string>
#include <list>
#include <time.h>
using std::string;
using std::list;

// Команды получаемые от RConsole
enum TalkersCmd {Start,Stop,Exit,Statistics,Wait,Shutdown,Getcommand};

// Статистика подключений
volatile LONG Accept=0;  // Количество подключений
volatile LONG Fail=0;    // Неудачные подключения
volatile LONG Finished=0;// Завершенные удачно
volatile LONG Work=0;    // Подключения в текущий момент

HANDLE (*ts2)(char*, LPVOID);
HANDLE (*ts3)(char*, LPVOID);

HMODULE st2;
HMODULE st3;

CRITICAL_SECTION scListContact;// Критическая секция

struct Param
{
	TalkersCmd cmd;
	int port;
};

struct Contact         // элемент списка подключений       
{
	enum TE {               // состояние  сервера подключения  
		EMPTY,              // пустой элемент списка подключений 
		ACCEPT,             // подключен (accept), но не обслуживается
		CONTACT             // передан обслуживающему серверу  
	}    type;     // тип элемента списка подключений 

	enum ST {               // состояние обслуживающего сервера  
		WORK,               // идет обмен данными с клиентом
		ABORT,              // обслуживающий сервер завершился ненормально 
		TIMEOUT,            // обслуживающий сервер завершился по времени 
		FINISH              // обслуживающий сервер завершился  нормально 
	}      sthread; // состояние  обслуживающего сервера (потока)

	SOCKET      s;         // сокет для обмена данными с клиентом
	SOCKADDR_IN prms;      // параметры  сокета 
	int         lprms;     // длина prms 
	HANDLE      hthread;   // handle потока (или процесса) 
	HANDLE      htimer;    // handle таймера
	bool        TimerOff;  // Метка срабатывания таймера
	bool        CloseConn;      // Метка завершения обслуживания

	char msg[50];           // сообщение 
	char srvname[15];       //  наименование обслуживающего сервера 

	HANDLE hAcceptServer;// Handle обслуживающего потока

	Contact(TE t = EMPTY, const char* namesrv = "") // конструктор 
	{
		memset(&prms, 0, sizeof(SOCKADDR_IN));
		lprms = sizeof(SOCKADDR_IN);// Размер сокета
		type = t;
		strcpy(srvname, namesrv);
		msg[0] = 0;
		CloseConn = false;
		TimerOff = false;
	};

	void SetST(ST sth, const char* m = "")
	{
		sthread = sth;
		strcpy(msg, m);
	}
};
typedef list<Contact> ListContact;  
// список подключений  

ListContact Contacts;
// Асинхронная функция срабатывания таймера
void CALLBACK ASWTimer(LPVOID Lprm, DWORD, DWORD)
{
	Contact *client = (Contact*)Lprm; //преобразуем переданный параметр
	//EnterCriticalSection(&scListContact); //входим в критическую секцию
	client->TimerOff = true; 	//ставим метку срабатывания таймера
	client->sthread = Contact::TIMEOUT;
	//LeaveCriticalSection(&scListContact); 	//выходим из критической секции
	SYSTEMTIME stt;
	// Получаем текущее время и дату
	GetLocalTime(&stt);
	// Выводим сообщение
	printf("%d.%d.%d %d:%02d Timeout ", stt.wDay, stt.wMonth, stt.wYear, stt.wHour, stt.wMinute);
	std::cout << client->srvname << ";" << std::endl;
}
// Асинхронная функция запуска обслуживающего потока
void CALLBACK ASStartMessage(DWORD Lprm)
{
	Contact *client = (Contact*)Lprm;
	/*EnterCriticalSection(&scListContact);*/
	// Ставим метку срабатывания таймера
	char* sn = client->srvname;
	// Покидаем критическую секцию
	//LeaveCriticalSection(&scListContact);
	// Структура времени
	SYSTEMTIME stt;
	// Получаем текущее время и дату
	GetLocalTime(&stt);
	// Выводим сообщение
	printf("%d.%d.%d %d:%02d ", stt.wDay, stt.wMonth, stt.wYear, stt.wHour, stt.wMinute);
	std::cout << sn << " started;" << std::endl;
}
// Асинхронная функция завершения обслуживающего потока
void CALLBACK ASFinishMessage(DWORD Lprm)
{
	Contact *client = (Contact*)Lprm;
	/*EnterCriticalSection(&scListContact);*/
	// Ставим метку срабатывания таймера
	char* sn = client->srvname;
	// Покидаем критическую секцию
	/*LeaveCriticalSection(&scListContact);*/
	// Структура времени
	SYSTEMTIME stt;
	// Получаем текущее время и дату
	GetLocalTime(&stt);
	// Выводим сообщение
	printf("%d.%d.%d %d:%02d ", stt.wDay, stt.wMonth, stt.wYear, stt.wHour, stt.wMinute);
	std::cout << sn << " stoped;" << std::endl;
}

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
	return  msgText + GetErrorMsgText(code);
};