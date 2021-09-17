#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include "stdafx.h"
#include <string>
#include <iostream>
#include "Winsock2.h" //заголовок WS2_32.dll
#pragma comment(lib, "WS2_32.lib") //экспорт WS2_32.dll
#include "Error.h"
#include <ctime>

using namespace std;

int main()
{
	setlocale(LC_ALL, "rus");
	WSADATA wsaData;
	SOCKET sS; //дескриптор сокета

	SOCKADDR_IN serv; //параметры сокета sS
	serv.sin_family = AF_INET; //используется IP-адресация
	serv.sin_port = htons(80); //порт 2000
	serv.sin_addr.s_addr = INADDR_ANY; //любой собственный IP-адрес

	SOCKET cS; //сокет для обмена данными с клиентом
	SOCKADDR_IN clnt; //параметры сокета клиента
	memset(&clnt, 0, sizeof(clnt)); //обнулить память
	int lclnt = sizeof(clnt); //размер SOCKADDR_IN

	char ibuf[50] = "server: get "; //буфер вывода
	int libuf = 0; //количество отправленных байт
	int lobuf = 0; //количество принятых байт

	clock_t start, stop;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup: ", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket: ", WSAGetLastError());

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw SetErrorMsgText("bind: ", WSAGetLastError());

		if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
			throw SetErrorMsgText("listen: ", WSAGetLastError());
		do
		{
			if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
				throw SetErrorMsgText("accept: ", WSAGetLastError());
			cout << "Soket: " << inet_ntoa(clnt.sin_addr);
			cout << ":" << clnt.sin_port << endl;

			

			start = clock();
			while (true)
			{
				if ((libuf = recv(cS, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR)
					throw SetErrorMsgText("recv: ", WSAGetLastError());
				string obuf = ibuf;
				if ((lobuf = send(cS, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR)
					throw SetErrorMsgText("send: ", WSAGetLastError());
				if (strcmp(ibuf, "") == 0)
					break;
				cout << ibuf << endl;
			}
			stop = clock();
			cout << "Time for send and recv: " << (double)((stop - start) / CLK_TCK) << endl;
		} while (true);
		if (closesocket(sS) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket: ", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText << endl;
	}

	system("pause");
	return 0;
}