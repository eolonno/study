//Global ConcurrentServer
#pragma once
#include <iostream>
#include <string>
#include <list>
#include <time.h>
#include "locale.h"
#include "Winsock2.h"              
#pragma comment(lib,"WS2_32.lib")
#include "Windows.h"
#include "Error.h"
#include <vector>

using std::string;
using std::list;
using namespace std;

int port = 2000; //используемый порт (значение по умолчанию 2000)
int uport = 2000; //udp-порт, используемый ResponseServer
char* dllname = "ServiceLibrary"; //название загружаемой библиотеки 
char* npname = "smc"; //имя именованного канала, используемое ConsolePipe
char* ucall = "ABC"; //позывной сервера, используемый ResponseServer
int AS_SQUIRT = 10; //максимальное количество клиентов одновременно
//int squirt = AS_SQUIRT; //текущее максимальное количество клиентов одновременно
HANDLE (*ts1)(char*, LPVOID); //дескриптор, используемый для импорта функции из dll
HANDLE hAcceptServer; //дескриптор AcceptServer
HMODULE st1; //дескриптор dll
HANDLE Event=CreateEvent(NULL, FALSE, FALSE, NULL); //дескриптор события

enum TalkersCmd {Start, Stop, Exit, Statistics, Wait, Shutdown, Getcommand}; //допустимые команды RConsole

//статистика подключений
volatile LONG Accept=0;  //количество подключений
volatile LONG Fail=0;    //неудачные подключения
volatile LONG Finished=0;//завершенные удачно
volatile LONG Work=0;    //подключены в текущий момент

CRITICAL_SECTION scListContact; //критическая секция

vector<HMODULE> vList;
vector<HANDLE> vArray;

struct Contact         // элемент списка подключений       
{
	                   // состояние сервера подключения
	enum TE{                
		EMPTY,              // пустой элемент списка подключений 
		ACCEPT,             // подключен (ACCEPT), но не обслуживается
		CONTACT             // передан обслуживающему серверу  
	}    type;              // тип элемента списка подключний

	                        // состояние обслуживающего сервера
	enum ST{                 
		WORK,               // идет обмен данными с клиентом
		ABORT,              // обслуживающий сервер завершился ненормально 
		TIMEOUT,            // обслуживающий сервер завершился по таймеру (вркмени)
		FINISH              // обслуживающий сервер завершился  нормально 
	}      sthread;         // состояние обслуживающего сревера (потока)

	SOCKET      s;         // сокет для обмена данными с клиентом
	SOCKADDR_IN prms;      // параметры  сокета 
	int         lprms;     // длина prms 
	HANDLE      hthread;   // дескриптор потока или (процесса)
	HANDLE      htimer;    // дескриптор таймера

	bool        TimerOff;   // метка срабатывания таймера
	bool        CloseConn;  // метка завершения обслуживания

	char msg[50];           // сообщение 
	char srvname[15];       // имя обслуживающего потока (сервера)

	HANDLE hAcceptServer;// Handle обслуживающего потока

	Contact( TE t = EMPTY, char* namesrv = "") // конструктор 
	{
		memset(&prms,0,sizeof(SOCKADDR_IN));  
		lprms = sizeof(SOCKADDR_IN); // размер сокета
		type = t;             
		strcpy(srvname, namesrv);  
		msg[0] = 0;
		CloseConn=false;
		TimerOff=false;
	};            

	void SetST(ST sth, char* m = "" ) 
	{
		sthread = sth;     
		strcpy(msg,m);
	}           
};

typedef list<Contact> ListContact;  
ListContact Contacts; // список подключений  

//асинхронная функция при срабатывании таймера
void CALLBACK ASWTimer(LPVOID Lprm,DWORD,DWORD) 
{   
	char obuf[50]="Close: timeout;";
	Contact *client = (Contact*) Lprm; //преобразуем переданный параметр
	EnterCriticalSection(&scListContact); //входим в критическую секцию
	client->TimerOff=true; 	//ставим метку срабатывания таймера
	client->sthread=Contact::TIMEOUT;
	LeaveCriticalSection(&scListContact); 	//выходим из критической секции
	if((send(client->s,obuf,sizeof(obuf)+1,NULL))==SOCKET_ERROR)
		throw  SetErrorMsgText("Send:",WSAGetLastError());
	SYSTEMTIME stt;
	// Получаем текущее время и дату
	GetLocalTime(&stt);
	// Выводим сообщение
	printf("%d.%d.%d %d:%02d Timeout ",stt.wDay,stt.wMonth,stt.wYear,stt.wHour, stt.wMinute);
	cout<<client->srvname<<";"<<endl;
}

// Асинхронная функция запуска обслуживающего потока
void CALLBACK ASStartMessage(DWORD Lprm)
{   
	Contact *client = (Contact*) Lprm;
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
	printf("%d.%d.%d %d:%02d ",stt.wDay,stt.wMonth,stt.wYear,stt.wHour, stt.wMinute);
	std::cout<<sn<<" started;"<<std::endl;
}
// Асинхронная функция завершения обслуживающего потока
void CALLBACK ASFinishMessage(DWORD Lprm)
{   
	Contact *client = (Contact*) Lprm;
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
	printf("%d.%d.%d %d:%02d ",stt.wDay,stt.wMonth,stt.wYear,stt.wHour, stt.wMinute);
	std::cout<<sn<<" stoped;"<<std::endl;
}
