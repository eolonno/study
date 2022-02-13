#pragma once
#include "Global.h"


DWORD WINAPI TimeServer(LPVOID lParam)
{
	// Код возврата
	DWORD rc = 0;
	Contact* client = (Contact*)lParam;
	// Ставим в очередь сообщение о старте обслуживания
	QueueUserAPC(ASStartMessage, client->hAcceptServer, (DWORD)client);
	try
	{
		client->sthread = Contact::WORK;
		int  bytes = 1;
		char ibuf[50], obuf[50] = "Close: finish;", Time[50] = "Time";
		// Принимаем данные из сокета
		while (client->TimerOff == false)
		{
			// Принимаем данные
			if ((bytes = recv(client->s, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR)
			{
				switch (WSAGetLastError())
				{
				case WSAEWOULDBLOCK: Sleep(100); break;
				default: throw  SetErrorMsgText("Recv:", WSAGetLastError());
				}
			}
			else
			{
				if (ibuf[0] != '0')
				{
					// Проверяем метку срабатывания таймера
					if (client->TimerOff != false)
					{
						break;
					}
					SYSTEMTIME stt;
					GetLocalTime(&stt);
					sprintf(ibuf, "%s %d.%d.%d/%d:%02d:%d", Time, stt.wDay, stt.wMonth, stt.wYear, stt.wHour, stt.wMinute, stt.wSecond);
					// Отправляем обратно
					if ((send(client->s, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR)
						throw  SetErrorMsgText("Send:", WSAGetLastError());
				}
				else break;
			}
		}


		if (client->TimerOff == false)
		{
			// Отключаем таймер
			CancelWaitableTimer(client->htimer);
			if ((send(client->s, obuf, sizeof(obuf) + 1, NULL)) == SOCKET_ERROR)
				throw  SetErrorMsgText("Send:", WSAGetLastError());
			// Ставим метку удачного завершения
			client->sthread = Contact::FINISH;
			QueueUserAPC(ASFinishMessage, client->hAcceptServer, (DWORD)client);
		}
	}
	catch (string errorMsgText)
	{
		std::cout << errorMsgText << std::endl;
		CancelWaitableTimer(client->htimer);
		client->sthread = Contact::ABORT;
	}
	// Завершаем поток
	ExitThread(rc);
}