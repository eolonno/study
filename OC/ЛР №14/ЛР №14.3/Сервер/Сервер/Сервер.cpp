#include <winsock2.h>
#include <iostream>
#include <stdio.h>
#pragma comment(lib, "Ws2_32.lib")
int main(void)
{
    WORD sockVer;
    WSADATA wsaData;
    int retVal;

    sockVer = MAKEWORD(2, 2);

    WSAStartup(sockVer, &wsaData);

    //Создаем сокет
    SOCKET servSock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

    if (servSock == INVALID_SOCKET)
    {
        printf("Unable to create socket\n");
        getchar();
        WSACleanup();
        return SOCKET_ERROR;
    }
    SOCKADDR_IN sin;
    sin.sin_family = PF_INET;
    sin.sin_port = htons(1111);
    sin.sin_addr.s_addr = INADDR_ANY;

    retVal = bind(servSock, (LPSOCKADDR)&sin, sizeof(sin));
    if (retVal == SOCKET_ERROR)
    {
        printf("Unable to bind\n");
        WSACleanup();
        return SOCKET_ERROR;
    }

    //Пытаемся начать слушать сокет
    retVal = listen(servSock, 10);
    if (retVal == SOCKET_ERROR)
    {
        printf("Unable to listen\n");
        WSACleanup();
        return SOCKET_ERROR;
    }
    //Ждем клиента
    SOCKET clientSock;

    clientSock = accept(servSock, NULL, NULL);

    if (clientSock == INVALID_SOCKET)
    {
        printf("Unable to accept\n");
        WSACleanup();
        return SOCKET_ERROR;
    }

    char info[12];
    if (recv(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)                         // Первое получение данных от клиента
    {
        std::cout << "Reception error";
        return SOCKET_ERROR;
    }
    std::cout << "The first reception was successful, the data received: " << info << std::endl;

    if (send(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)                         // Отправление данных назад к клиенту
    {
        std::cout << "Error sending string!" << std::endl;
        return SOCKET_ERROR;
    }
    std::cout << "String sent successfully!\n";

    if (recv(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)                         // Второе получение данных от клиента
    {
        std::cout << "Reception error";
        return SOCKET_ERROR;
    }
    std::cout << "The first reception was successful, the data received: " << info << std::endl;

    //Закрываем сокет
    closesocket(clientSock);
    closesocket(servSock);

    WSACleanup();
    return 0;
}