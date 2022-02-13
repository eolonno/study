#pragma once
#include "Global.h"


static void WaitClients()
{
	bool ListEmpty = false;
	while (!ListEmpty)
	{
		// проверяем наличие клиентов
		EnterCriticalSection(&scListContact);
		ListEmpty = Contacts.empty();
		LeaveCriticalSection(&scListContact);
		// ждём (выполняя асинхронные процедуры)
		SleepEx(0, TRUE);
	}
}

bool AcceptCycle(int squirt, SOCKET* s)
{
	bool rc = false;
	// Создаем новый Contact
	Contact c(Contact::ACCEPT, "AcceptServer");
	// Передаем HANDLE обслуживающего потока
	c.hAcceptServer = hAcceptServer;


	if ((c.s = accept(*s, (sockaddr*)&c.prms, &c.lprms)) == INVALID_SOCKET)
	{
		if (WSAGetLastError() != WSAEWOULDBLOCK)
			throw  SetErrorMsgText("Accept:", WSAGetLastError());
	}
	else //если подключился
	{
		rc = true;
		InterlockedIncrement(&Accept);// Увеличиваем кол-во общих подключений
		InterlockedIncrement(&Work);  // Увеличиваем кол-во текущих подключений
		EnterCriticalSection(&scListContact);
		Contacts.push_front(c);
		LeaveCriticalSection(&scListContact);
		SetEvent(Event); // Переводим событие в сигнальное состояние

	}
	return rc;
};

void CommandsCycle(TalkersCmd& cmd, SOCKET* s)      // цикл обработки команд
{
	int squirt = 0;
	while (cmd != Exit)     // цикл обработки команд консоли и подключений
	{
		switch (cmd)
		{
		case Start:  //возобновить подключение клиентов
			cmd = Getcommand;
			squirt = AS_SQUIRT;
			break;
		case Stop:  //остановить подключение клиентов 
			cmd = Getcommand;
			squirt = 0;
			break;
		case Wait:  //обработать текущих, а после разрешить подключение новых клиентов
			WaitClients();
			cmd = Getcommand;
			squirt = AS_SQUIRT;
			break;
		case Shutdown:  //обработать текущих, а после завершить сервер
			WaitClients();
			cmd = Exit;
			break;
		};

		if (cmd != Exit && squirt > Work)
		{
			if (AcceptCycle(squirt, s))   //цикл  запрос/подключение (accept) 
			{
				cmd = Getcommand;
			}


			SleepEx(0, TRUE);
		}

	}
};

// Потоковая функция обработки запросов на подключение клиентов
DWORD WINAPI AcceptServer(LPVOID pPrm)
{
	cout << "AcceptServer started\n" << endl;
	DWORD rc = 0; //код возврата  
	SOCKET  ServerSocket;
	WSADATA wsaData;

	try
	{
		// Инициализируем Winsocket 
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		// Создаем сокет сервера для приема подключений клиентов
		if ((ServerSocket = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("Socket:", WSAGetLastError());

		// Параметры сокета сервера
		SOCKADDR_IN Server_IN;
		Server_IN.sin_family = AF_INET;
		Server_IN.sin_port = htons(port);
		Server_IN.sin_addr.s_addr = ADDR_ANY;
		// Применить параметры к сокету
		if (bind(ServerSocket, (LPSOCKADDR)&Server_IN, sizeof(Server_IN)) == SOCKET_ERROR)
			throw  SetErrorMsgText("Bind:", WSAGetLastError());

		// Переводим сокет в режим прослушивания
		if (listen(ServerSocket, SOMAXCONN) == SOCKET_ERROR)
			throw  SetErrorMsgText("Listen:", WSAGetLastError());

		// Переводим сокет в неблокирующий режим
		u_long nonblk;
		if (ioctlsocket(ServerSocket, FIONBIO, &(nonblk = 1)) == SOCKET_ERROR)
			throw SetErrorMsgText("Ioctlsocket:", WSAGetLastError());

		TalkersCmd* command = (TalkersCmd*)pPrm;
		// Функция обрабатывает сообщения от консоли
		CommandsCycle(*((TalkersCmd*)command), &ServerSocket);

		// Закрываем сокет
		if (closesocket(ServerSocket) == SOCKET_ERROR)
			throw  SetErrorMsgText("Сlosesocket:", WSAGetLastError());
		// Очищаем ресурсы
		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		std::cout << errorMsgText << endl;
	}
	cout << "AcceptServer stoped;\n" << endl;
	// Выходим из потока
	ExitThread(rc);
}

