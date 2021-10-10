#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <ctime>
#include "ErrorHandling.h"
#include "Winsock2.h"  
#pragma comment(lib, "WS2_32.lib")   // экспорт  WS2_32.dll

using namespace std;

bool GetRequestFromClient(char*, short, struct sockaddr*, int*);
bool PutAnswerToClient(char*, short, struct sockaddr*, int*);
void SearchServer(char*);


int main()
{
	WSADATA wsaData;
	SOCKET sS;
	SOCKADDR_IN serv;
	SOCKADDR_IN from;

	char name[50] = "Hello";
	serv.sin_family = AF_INET;           // используется IP-адресация  
	serv.sin_port = htons(2000);          // порт 2000
	serv.sin_addr.s_addr = INADDR_ANY;   // любой собственный IP-адрес 

	memset(&from, 0, sizeof(from));   // обнулить память
	int lfrom = sizeof(from);

	char hostname[25];
	hostent* clntInfo;
	memset(&clntInfo, 0, sizeof(clntInfo));

	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		cout << "Search servers..." << endl;
		SearchServer(name);

		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());

		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());
		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("Socket:", WSAGetLastError());
		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw  SetErrorMsgText("Bind:", WSAGetLastError());
		if (gethostname(hostname, sizeof(hostname)) == SOCKET_ERROR)
			throw SetErrorMsgText("gethostname: ", WSAGetLastError());
		cout << "Server hostname: " << hostname << endl;
		do
		{
			if (GetRequestFromClient(name, sS, (sockaddr*)&from, &lfrom))
			{
				clntInfo = gethostbyaddr((const char*)&from.sin_addr, 4, AF_INET);

				cout << endl;
				cout << "Client socket:" << endl;
				cout << "Hostname: " << clntInfo->h_name << endl;
				cout << "IP: " << inet_ntoa(from.sin_addr) << endl;
				cout << "Port: " << htons(from.sin_port) << endl;
				cout << endl;
				if (PutAnswerToClient(name, sS, (sockaddr*)&from, &lfrom))
				{
					cout << "Success" << endl;
				}
			}
			else
				cout << "Wrong call name" << endl;
		} while (true);

		if (closesocket(sS) == SOCKET_ERROR)
			throw  SetErrorMsgText("CloseSocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << "\n" << errorMsgText << endl;
	}
}

bool GetRequestFromClient(char* name, short port, struct sockaddr* from, int* flen)
{
	int lbuf;
	char ibuf[50] = "";
	cout << "Wait message..." << endl;
	while (true)
	{
		if (lbuf = recvfrom(port, ibuf, sizeof(ibuf), NULL, from, flen) == SOCKET_ERROR)
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
	}
}

bool PutAnswerToClient(char* name, short port, struct sockaddr* to, int* lto)
{
	int lbuf;
	if (lbuf = sendto(port, name, strlen(name) + 1, NULL, to, *lto) == SOCKET_ERROR)
		throw SetErrorMsgText("sendto: ", WSAGetLastError());

	return true;
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
		cout << "Server socket: " << endl;
		cout << "IP: " << inet_ntoa(from.sin_addr) << endl;
		cout << "Port: " << htons(from.sin_port) << endl;
	}
	if (closesocket(sock) == SOCKET_ERROR)
	{
		throw SetErrorMsgText("closesocket: ", WSAGetLastError());
	}
}