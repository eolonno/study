#pragma once
#include "Global.h"

template <typename typed, size_t n> int lenght(typed(&a)[n])
{
	int counter = 0;
	for (size_t q = 0; q < n; ++q)
		counter++;
	return counter;
}

DWORD WINAPI RandServer(LPVOID lParam)
{
	// Код возврата
	DWORD rc = 0;
	Contact* client = (Contact*)lParam;
	// Ставим в очередь сообщение о старте обслуживания
	QueueUserAPC(ASStartMessage, client->hAcceptServer, (DWORD)client);
	try
	{
		char* numbers = "1234567890";
		// Метка старта обслуживания клиента	
		client->sthread = Contact::WORK;
		int  bytes = 1;
		char ibuf[50], obuf[50] = "Close: finish;", Rand[50] = "Rand";
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
				//if (strcmp(ibuf, "Rand") == 0)
				if (ibuf[0] != '0')
				{
					// Проверяем метку срабатывания таймера
					if (client->TimerOff != false)
					{
						break;
					}
					/*int i = 0,
						j = 0,
						count = 0;
					while (numbers[i] != '\0')
					{
						while (ibuf[j] != '\0')
						{
							if (numbers[i] != ibuf[j++])
								count++;
						}
						i++;
					}

					if (count != lenght(ibuf))
						break;*/

					srand(time(NULL));
					int RandNumber = rand();
					sprintf(ibuf, "%s: %d", Rand, RandNumber);

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