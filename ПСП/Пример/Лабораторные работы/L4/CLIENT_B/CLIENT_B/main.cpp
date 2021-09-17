#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include "Validation.h"
#include <string>
#include <Windows.h>
#include <WinSock2.h>
#pragma comment(lib,"WS2_32.lib")
using namespace std;

WSAData wsa;
SOCKET clientSocket;
SOCKADDR_IN serverConfig;
SOCKADDR_IN serverConfigP;
int send_optval = 1;
int recv_optval = 5000;
char ibuf[50];

bool GetServer(char* call, short port, sockaddr* from, int lfrom) {
	try {
		char buf[50];
	
	((SOCKADDR_IN*)from)->sin_family = AF_INET;                // используется IP-адресация  
	((SOCKADDR_IN*)from)->sin_port = htons(port);             // порт 2000
	((SOCKADDR_IN*)from)->sin_addr.s_addr = inet_addr("192.168.56.255"); // всем 

	
	if ((sendto(clientSocket, call, sizeof(call)+1, NULL,from, lfrom)) == SOCKET_ERROR)
		throw  GetErrorMsg("sendto:", WSAGetLastError());

	if (setsockopt(clientSocket, SOL_SOCKET, SO_RCVTIMEO, (char*)&recv_optval, sizeof(int)) == SOCKET_ERROR)
		throw  GetErrorMsg("opt:", WSAGetLastError());

	if ((recvfrom(clientSocket, buf, 100, NULL, (LPSOCKADDR)&serverConfigP, &lfrom)) == SOCKET_ERROR)
		throw WSAGetLastError();

	if (strcmp(buf, call) == 0)
		return true;
	else
		return false;
	}
	catch (int err_code)
	{
		if (err_code != WSAETIMEDOUT)
		{
			throw GetErrorMsg("GS:", WSAGetLastError());
		}
		else {
			if (setsockopt(clientSocket, SOL_SOCKET, SO_BROADCAST, (char*)&send_optval, sizeof(int)) == SOCKET_ERROR)
				throw  GetErrorMsg("opt:", WSAGetLastError());
			return false;
		}
	}
}


void main()
{

	setlocale(LC_CTYPE, "Russian");
	cout << "CLIENT" << endl;
	try {


		if (WSAStartup(MAKEWORD(2, 0), &wsa) != 0)
			throw GetErrorMsg("WSA:", WSAGetLastError());

		if ((clientSocket = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  GetErrorMsg("socket:", WSAGetLastError());


		if (setsockopt(clientSocket, SOL_SOCKET, SO_BROADCAST, (char*)&send_optval, sizeof(int)) == SOCKET_ERROR)
			throw  GetErrorMsg("opt:", WSAGetLastError());




		if (GetServer("Hello", 2000, (LPSOCKADDR)&serverConfig, sizeof(serverConfig)))
		{
			cout << "Connect -->" << inet_ntoa(serverConfigP.sin_addr) << ":" << htons(serverConfigP.sin_port) << endl;
		}
		else
		{
			cout << "Not connected" << endl;
		}
		closesocket(clientSocket);
		WSACleanup();
	}
	catch (string errorMsg)
	{
		cout << errorMsg << endl;
	}
	system("pause");
}