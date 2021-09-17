#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <time.h>
#include "Error.h"
#include <Windows.h>
#pragma comment(lib, "WS2_32.lib")

bool PutAnswerToClient(char* name, SOCKET sock, sockaddr* to, int* lto)
{
	int lbuf;
	if (lbuf = sendto(sock, name, strlen(name) + 1, NULL, to, *lto) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("sendto: ", WSAGetLastError());
	}
	return true;
}

bool GetRequestFromClient(char* name, SOCKET sock, sockaddr* from, int* flen)
{
	int lbuf;
	char ibuf[50];
	cout << "Wait message..." << endl;
	while (true)
	{
		if (lbuf = recvfrom(sock, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
		{
			if (WSAGetLastError() == WSAETIMEDOUT)
				return false;
			else
				throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
		}
		if (strcmp(ibuf, name) == 0)
		{
			return true;
		}
	}
}

void SearchServer(char* name)
{
	SOCKADDR_IN from;
	memset(&from, 0, sizeof(from));
	int lfrom = sizeof(from);
	SOCKET sock;
	int lbuf;
	int optval = 3000;
	if ((sock = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
	{
		throw SetErrorMsgText("socket: ", WSAGetLastError());
	}
	if (setsockopt(sock, SOL_SOCKET, SO_BROADCAST, (char*)&optval, sizeof(optval)) == SOCKET_ERROR)
		throw SetErrorMsgText("opt: ", WSAGetLastError());
	SOCKADDR_IN all;
	all.sin_family = AF_INET;
	all.sin_port = htons(2000);
	all.sin_addr.s_addr = INADDR_BROADCAST;
	char ibuf[50];
	if (lbuf = sendto(sock, name, strlen(name) + 1, NULL, (sockaddr*)&all, sizeof(all)) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("sendto: ", WSAGetLastError());
	}
	if (setsockopt(sock, SOL_SOCKET, SO_RCVTIMEO, (char*)&optval, sizeof(optval)) == SOCKET_ERROR)
		throw SetErrorMsgText("opt: ", WSAGetLastError());
	if (lbuf = recvfrom(sock, ibuf, sizeof(ibuf), NULL, (sockaddr*)&from, &lfrom) == SOCKET_ERROR)
	{
		if (WSAGetLastError() != WSAETIMEDOUT)
			throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
	}
	if (lbuf == 0)
	{
		cout << "Server socket -> ";
		cout << inet_ntoa(from.sin_addr) << ": " << htons(from.sin_port) << endl;
	}
	if (closesocket(sock) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("closesocket: ", WSAGetLastError());
	}
}

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	WSADATA wsaData;
	SOCKET sockServer;
	char name[] = "hello";
	char ans[] = "Access";
	char hostname[25];
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		}
		cout << "Search server..." << endl;
		SearchServer(name);
		if (WSACleanup() == SOCKET_ERROR)
		{
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
		}
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
		{
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		}
		if ((sockServer = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
		{
			throw SetErrorMsgText("Socket: ", WSAGetLastError());
		}
		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.s_addr = INADDR_ANY;
		if (bind(sockServer, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("bind: ", WSAGetLastError());
		}
		SOCKADDR_IN from;
		memset(&from, 0, sizeof(from));
		int lfrom = sizeof(from);
		hostent *clntInfo;
		memset(&clntInfo, 0, sizeof(clntInfo));
		cout << "Server start" << endl;
		if (gethostname(hostname, sizeof(hostname)) == SOCKET_ERROR)
			throw SetErrorMsgText("gethostname: ", WSAGetLastError());
		cout << "Server name: " << hostname << endl;
		while (true)
		{
			if (GetRequestFromClient(name, sockServer, (sockaddr*)&from, &lfrom))
			{
				cout << "Client socket -> ";
				cout << inet_ntoa(from.sin_addr) << ": " << htons(from.sin_port) << endl;
				clntInfo = gethostbyaddr((const char*)&from.sin_addr, 4, AF_INET);
				cout << "Client name: " << clntInfo->h_name << endl;
				cout << "Succes" << endl;
				PutAnswerToClient(ans, sockServer, (sockaddr*)&from, &lfrom);
			}
			else
				cout << "Error" << endl;
		}
		if (closesocket(sockServer) == SOCKET_ERROR)
		{
			throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		}

		if (WSACleanup() == SOCKET_ERROR)
		{
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
		}
	}
	catch (string errorMsgText)
	{
		cout << "WSAGetLastError: " << errorMsgText << endl;
	}
	system("pause");
}