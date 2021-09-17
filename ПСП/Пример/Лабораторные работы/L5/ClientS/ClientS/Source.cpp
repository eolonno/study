#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <time.h>
#include "Error.h"
#include <Windows.h>
#pragma comment(lib, "WS2_32.lib")

bool GetServerByName(char *name, char *call, sockaddr *from, int *flen)
{
	hostent *servInfo;
	memset(&servInfo, 0, sizeof(servInfo));
	SOCKET sock;
	int lbuf;
	int optval = 1;
	if ((sock = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
	{
		throw SetErrorMsgText("socket: ", WSAGetLastError());
	}
	servInfo = gethostbyname(name);
	in_addr *addr_list;
	addr_list = (in_addr*)*(servInfo->h_addr_list);
	SOCKADDR_IN serv;
	serv.sin_family = AF_INET;
	serv.sin_port = htons(2000);
	serv.sin_addr = *addr_list;
	if (lbuf = sendto(sock, call, strlen(call) + 1, NULL, (sockaddr*)&serv, sizeof(serv)) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("sendto: ", WSAGetLastError());
	}
	char ibuf[50];
	if (lbuf = recvfrom(sock, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
	{
		if (WSAGetLastError() == WSAETIMEDOUT)
			return false;
		else
			throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
	}
	cout << ibuf << endl;
	if (closesocket(sock) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("closesocket: ", WSAGetLastError());
	}
	return true;
}

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	WSADATA wsaData;
	char call[] = "hello";
	SOCKADDR_IN from;
	memset(&from, 0, sizeof(from));
	int lfrom = sizeof(from);
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		}
		GetServerByName("Kaiser-X542U", call, (sockaddr*)&from, &lfrom);
		if (WSACleanup() == SOCKET_ERROR)
		{
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
		}
	}
	catch (string errorMsgText)
	{
		cout << "WSAGetLastError: " << errorMsgText << endl;
	}
	cout << "End" << endl;
	system("pause");
}