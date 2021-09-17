#pragma once
#include "Global.h"

DWORD WINAPI EchoServer (LPVOID lParam)
{	
	// Код возврата
	DWORD rc=0;
	Contact *client=(Contact*)lParam;
	// Ставим в очередь асинхронную процедуру сообщение о старте обслуживания
	QueueUserAPC(ASStartMessage,client->hAcceptServer, (DWORD)client);
	try
	{
		client->sthread=Contact::WORK;
		int  bytes=1;
		char ibuf[50], obuf[50]="Close: finish;";
		// Принимаем данные из сокета
		while(client->TimerOff==false)
		{
			// Принимаем данные
			if((bytes=recv(client->s,ibuf,sizeof(ibuf),NULL))==SOCKET_ERROR)
			{
				switch(WSAGetLastError())
				{
				case WSAEWOULDBLOCK: Sleep(100);break;
				default: throw  SetErrorMsgText("Recv:",WSAGetLastError());
				}
			}
			else
			{
				if(strcmp(ibuf, "exit")!=0)
				{
					// Проверяем метку срабатывания таймера
					if (client->TimerOff!=false)
					{
						break;
					}
					// Отправляем обратно
					if((send(client->s,ibuf,sizeof(ibuf),NULL))==SOCKET_ERROR)
						throw  SetErrorMsgText("Send:",WSAGetLastError());

				}
				else break;
			}
		}


		if(client->TimerOff==false) 
		{
			// Отключаем таймер
			CancelWaitableTimer(client->htimer);
			if((send(client->s,obuf,sizeof(obuf)+1,NULL))==SOCKET_ERROR)
				throw  SetErrorMsgText("Send:",WSAGetLastError());
			// Ставим метку удачного завершения
			client->sthread=Contact::FINISH;
			// Ставим в очередь асинхронную процедуру сообщение о завершении обслуживания
			QueueUserAPC(ASFinishMessage,client->hAcceptServer, (DWORD)client);
		}
	}
	catch(string errorMsgText)
	{
		std::cout<<errorMsgText<<std::endl;
		CancelWaitableTimer(client->htimer);
		client->sthread=Contact::ABORT;
	}
	// Завершаем поток
	ExitThread(rc);
}