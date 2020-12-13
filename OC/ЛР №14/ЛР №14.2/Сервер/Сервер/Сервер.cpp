#include <winsock2.h>
#include <iostream>
#include <string>
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
    setlocale(LC_CTYPE, "rus");
    std::string str;
    std::cout << "Введите строку, которую хотите передать на сервер (на английском): ";
    std::getline(std::cin, str);
    char* forSend = new char[str.size()];
    for (int i = 0; i < str.size(); i++)
        forSend[i] = str[i];
    if (send(clientSock, forSend, sizeof(char) * str.size(), NULL) == SOCKET_ERROR)
    {
        std::cout << "Ошибка отправки строки" << std::endl;
        return SOCKET_ERROR;
    }
    std::cout << "Строка успешно отправлена!";

    delete[] forSend;

    //Закрываем сокет
    closesocket(clientSock);
    closesocket(servSock);

    WSACleanup();
    return 0;
}
