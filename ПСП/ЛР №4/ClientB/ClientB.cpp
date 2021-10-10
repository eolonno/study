#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include "ErrorHandling.h"
#include <iostream>
#include <ctime>
#include "Winsock2.h"  
#pragma comment(lib, "WS2_32.lib")   // экспорт  WS2_32.dll

using namespace std;

bool GetServer(char* name, short port, sockaddr* from, int* flen);

void main()
{
	WSADATA wsaData;
	SOCKET sock;
	SOCKADDR_IN from;
	char name[] = "Hello";
	memset(&from, 0, sizeof(from));
	int lfrom = sizeof(from);
	int optval = 1;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		if ((sock = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket: ", WSAGetLastError());
		if(GetServer(name, sock, (sockaddr*)&from, &lfrom))
		{
			cout << "Connected server: " << endl;
			cout << "IP: " << inet_ntoa(from.sin_addr) << endl;
			cout << "Port: " << htons(from.sin_port) << endl;
		}
		
		if (closesocket(sock) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << "WSAGetLastError: " << errorMsgText << endl;
	}
}

bool GetServer(char* name, short port, sockaddr* from, int* flen)
{
	
	((SOCKADDR_IN*)from)->sin_family = AF_INET;
	((SOCKADDR_IN*)from)->sin_port = htons(2000);
	((SOCKADDR_IN*)from)->sin_addr.s_addr = INADDR_BROADCAST;
	int lbuf;
	char ibuf[50];
	int optval = 1;

	
	if (setsockopt(port, SOL_SOCKET, SO_BROADCAST, (char*)&optval, sizeof(optval)) == SOCKET_ERROR)
		throw SetErrorMsgText("opt: ", WSAGetLastError());

	if (lbuf = sendto(port, name, strlen(name) + 1, NULL, from, *flen) == SOCKET_ERROR)
		throw SetErrorMsgText("sendto: ", WSAGetLastError());

	if (lbuf = recvfrom(port, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
	{
		if (WSAGetLastError() == WSAETIMEDOUT)
			return false;
		else
			throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
	}
	//name[strlen(name)] = '0';
	if (strcmp(ibuf, name) == 0)
		return true;
	else
		return false;

}