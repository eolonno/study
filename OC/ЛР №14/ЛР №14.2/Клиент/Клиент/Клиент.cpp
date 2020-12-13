#include <stdio.h>
#include <iostream>
#include <string>
#include <winsock2.h>
#pragma comment(lib, "Ws2_32.lib")
#pragma warning(disable : 4996)

int main()
{
    setlocale(LC_CTYPE, "rus");
    WORD ver = MAKEWORD(2, 2);
    WSADATA wsaData;
    int retVal = 0;

    WSAStartup(ver, (LPWSADATA)&wsaData);

    LPHOSTENT hostEnt;

    hostEnt = gethostbyname("localhost");

    if (!hostEnt)
    {
        printf("Unable to collect gethostbyname\n");
        WSACleanup();
        return 1;
    }

    //Создаем сокет
    SOCKET clientSock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

    if (clientSock == SOCKET_ERROR)
    {
        printf("Unable to create socket\n");
        WSACleanup();
        return 1;
    }

    SOCKADDR_IN serverInfo;

    serverInfo.sin_family = PF_INET;
    serverInfo.sin_addr = *((LPIN_ADDR)*hostEnt->h_addr_list);
    serverInfo.sin_port = htons(1111);

    retVal = connect(clientSock, (LPSOCKADDR)&serverInfo, sizeof(serverInfo));
    if (retVal == SOCKET_ERROR)
    {
        printf("Unable to connect\n");
        WSACleanup();
        return 1;
    }

    printf("Connection made sucessfully\n");

    char str[128];
    if (recv(clientSock, str, sizeof(str), NULL) == SOCKET_ERROR)
    {
        std::cout << "Ошибка приема строки!";
        return SOCKET_ERROR;
    }
    std::cout << "Отправленная строка: ";
    int i = 0;
    while (str[i] >= 32 && str[i] <= 126)
    {
        std::cout << str[i];
        i++;
    }
    closesocket(clientSock);
    WSACleanup();

    return 0;
}
