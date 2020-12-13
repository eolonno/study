#include <stdio.h>
#include <iostream>
#include <string>
#include <winsock2.h>
#pragma comment(lib, "Ws2_32.lib")
#pragma warning(disable : 4996)

int main()
{
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

    char info[] = "INFORMATION";                                                // Первая отправка на сервер
    if (send(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)
    {
        std::cout << "Error sending string!" << std::endl;
        return SOCKET_ERROR;
    }
    std::cout << "String sent successfully!\n";

    if (recv(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)             // Получение данных с сервера
    {
        std::cout << "Reception error";
        return SOCKET_ERROR;
    }
    std::cout << "The first reception was successful, the data received: " << info << std::endl;

    if (send(clientSock, info, sizeof(info), NULL) == SOCKET_ERROR)             // Вторая отправка данных на сервер
    {
        std::cout << "Error sending string!" << std::endl;
        return SOCKET_ERROR;
    }
    std::cout << "String sent successfully!\n";

    closesocket(clientSock);
    WSACleanup();

    return 0;
}