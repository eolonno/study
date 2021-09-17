#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include <iostream>
#include "Validation.h"
#include <string>
#include <Windows.h>
#include <WinSock2.h>
#pragma comment(lib,"WS2_32.lib")
using namespace std;

WSAData wsa;

SOCKET serverSocket;

SOCKADDR_IN serverConfig;
SOCKADDR_IN clientConfig;

int send_optval = 1;
int recv_optval = 3000;
int numOfServers = 0;
char ibuf[50];
char myName[50] = "Hello";

bool GetRequestFromClient(char* name, short port, sockaddr* from, int* sizefrom)
{
	try {
		serverConfig.sin_family = AF_INET;
		serverConfig.sin_port = htons(port);
		serverConfig.sin_addr.s_addr = INADDR_ANY;

		if ((bind(serverSocket, (LPSOCKADDR)&serverConfig, sizeof(serverConfig))) == SOCKET_ERROR)
			throw GetErrorMsg("Bind:", WSAGetLastError());
		while (true)
		{
			if ((recvfrom(serverSocket, ibuf, 2000, NULL, from, sizefrom)) == SOCKET_ERROR)
				throw GetErrorMsg("Recv:", WSAGetLastError());

			if (strcmp(ibuf, name) == 0)
				return true;
		}

	}
	catch (int err_code)
	{
		if (err_code != WSAETIMEDOUT)
		{
			throw GetErrorMsg("GRFC:", WSAGetLastError());
		}
		else return false;
	}
}

bool  PutAnswerToClient(char* name, sockaddr* to, int lto)
{
	if ((sendto(serverSocket, name, strlen(name) + 1, NULL, to, sizeof(clientConfig))) == SOCKET_ERROR)
		throw GetErrorMsg("Send:", WSAGetLastError());
	return true;
}

bool GetServer(char* call, short port, sockaddr* from, int lfrom) {
	try {
		bool notErr = true;
		char buf[50];
		int numberOfServers = 0;
		SOCKET GS;
		if ((GS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw GetErrorMsg("Socket:", WSAGetLastError());
		((SOCKADDR_IN*)from)->sin_family = AF_INET;                // используется IP-адресация  
		((SOCKADDR_IN*)from)->sin_port = htons(port);             // порт 2000
		((SOCKADDR_IN*)from)->sin_addr.s_addr = inet_addr("192.168.56.255"); // всем 

		if (setsockopt(GS, SOL_SOCKET, SO_BROADCAST, (char*)&send_optval, sizeof(int)) == SOCKET_ERROR)
			throw  GetErrorMsg("opt:", WSAGetLastError());

		if ((sendto(GS, call, strlen(call) + 1, NULL, from, lfrom)) == SOCKET_ERROR)
			throw  GetErrorMsg("sendto:", WSAGetLastError());
	
		if (setsockopt(GS, SOL_SOCKET, SO_RCVTIMEO, (char*)&recv_optval, sizeof(int)) == SOCKET_ERROR)
			throw  GetErrorMsg("opt:", WSAGetLastError());
		while (notErr)
		{
			if ((recvfrom(GS, buf, 100, NULL, (LPSOCKADDR)&clientConfig, &lfrom)) == SOCKET_ERROR)
				throw WSAGetLastError();

			if (strcmp(buf, call) == 0)
				numOfServers++;
			else
				return false;
		}
		
	}
	catch (int err_code)
	{
		if (err_code != WSAETIMEDOUT)
		{
			throw GetErrorMsg("GS:", WSAGetLastError());
		}
		else if(numOfServers==0){
			return false;
		}
		else {
			return true;
		}
	}
}

void main()
{
	cout << "SERVER" << endl;
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);


	try {

		if (WSAStartup(MAKEWORD(2, 0), &wsa) != 0)
			throw GetErrorMsg("WSA:", WSAGetLastError());

		bool resServ = GetServer("Hello", 100, (LPSOCKADDR)&clientConfig, sizeof(clientConfig));
		if (resServ)
		{
			cout << "Servers exist"<<endl <<"Number of servers: "<<numOfServers<< endl;
		}
		else
		{
			cout << "Servers not exist" << endl;
		}

		while (true)
		{
			if ((serverSocket = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
				throw GetErrorMsg("Socket:", WSAGetLastError());
			memset(&clientConfig, 0, sizeof(clientConfig));
			int szClientConfig = sizeof(clientConfig);





			bool res = GetRequestFromClient(myName, 2000, (LPSOCKADDR)&clientConfig, &szClientConfig);


			szClientConfig = sizeof(clientConfig);
			if (res) {
				cout << "Connect -->" << inet_ntoa(clientConfig.sin_addr) << ":" << htons(clientConfig.sin_port) << endl;
				PutAnswerToClient(myName, (LPSOCKADDR)&clientConfig, szClientConfig);
			}

			closesocket(serverSocket);
		}


		WSACleanup();

	}
	catch (string errorMsg)
	{
		cout << errorMsg << endl;
	}


	system("pause");
}