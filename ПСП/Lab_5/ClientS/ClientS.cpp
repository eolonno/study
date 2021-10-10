#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include "ErrorHandling.h"
#include <iostream>
#include <ctime>
#include "Winsock2.h"  
#pragma comment(lib, "WS2_32.lib")   // экспорт  WS2_32.dll

using namespace std;

bool GetServerByHostName(char* name, char* hostName, sockaddr* from, int* flen);

void main()
{
	WSADATA wsaData;
	
	SOCKADDR_IN from;
	memset(&from, 0, sizeof(from));
	char name[] = "Hello";
	int lfrom = sizeof(from);
	char hostName[] = "tiery";
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup: ", WSAGetLastError());
		
		if (GetServerByHostName(name, hostName, (sockaddr*)&from, &lfrom))
		{
			cout << "Connection successful" << endl << endl;

			cout << "Connected server: " << endl;
			cout << "Hostname: " << hostName<< endl;
			cout << "IP: " << inet_ntoa(from.sin_addr) << endl;
			cout << "Port: " << htons(from.sin_port) << endl;
			
		}
		else 
		{
			cout << "Wrong call name" << endl;
		}

		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << "WSAGetLastError: " << errorMsgText << endl;
	}
}

bool GetServerByHostName(char* name, char* hostName, sockaddr* from, int* flen)
{
	SOCKET sock;
	
	hostent* servInfo;
	memset(&servInfo, 0, sizeof(servInfo));
	servInfo = gethostbyname(hostName);
	in_addr* addr_list;
	addr_list = (in_addr*)*(servInfo->h_addr_list);

	((SOCKADDR_IN*)from)->sin_family = AF_INET;
	((SOCKADDR_IN*)from)->sin_port = htons(2000);
	((SOCKADDR_IN*)from)->sin_addr = *addr_list;
	int lbuf;
	char ibuf[50];
	int optval = 1;

	if ((sock = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
		throw SetErrorMsgText("socket: ", WSAGetLastError());

	if (lbuf = sendto(sock, name, strlen(name) + 1, NULL, from, *flen) == SOCKET_ERROR)
		throw SetErrorMsgText("sendto: ", WSAGetLastError());

	if (lbuf = recvfrom(sock, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
	{
		if (WSAGetLastError() == WSAETIMEDOUT)
			return false;
		else
			throw SetErrorMsgText("recvfrom: ", WSAGetLastError());
	}

	if (strcmp(ibuf, name) == 0)
		return true;
	else
		return false;

	if (closesocket(sock) == SOCKET_ERROR)
		throw SetErrorMsgText("closesocket: ", WSAGetLastError());
}