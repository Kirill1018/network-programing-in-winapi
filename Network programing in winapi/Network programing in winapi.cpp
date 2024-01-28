#define _WIN32_WINNT 0x600
#include <iostream>
#include <iomanip>
#include <WinSock2.h>
#include <ws2tcpip.h>
#pragma comment(lib, "Ws2_32.lib")
#include <windows.h>
using namespace std;
int main()
{
    WSADATA wsadata;
    if (WSAStartup(MAKEWORD(2, 2), &wsadata) != 0) throw runtime_error("WSAStartup failed");
    SOCKET listening = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (listening == INVALID_SOCKET) throw runtime_error("socket() failed");
    sockaddr_in sock_in;
    sock_in.sin_family = AF_INET;
    inet_pton(AF_INET, "192.168.1.130", &sock_in.sin_addr);
    sock_in.sin_port = htons(2024);
    if (bind(listening, (sockaddr*)&sock_in, sizeof(sock_in)) != 0) throw runtime_error("bind server");
    const int queue = 5;
    if (listen(listening, queue) == SOCKET_ERROR) throw runtime_error("listen failed");
    cout << "listening on port" << 2024 << endl;
    while (true)
    {
        SOCKET socket_ = accept(listening, NULL, NULL);
        if (socket_ == INVALID_SOCKET) throw runtime_error("accept failed");
    }
    SOCKET socket;
    if (connect(socket, (sockaddr*)&sock_in, sizeof(sock_in)) == SOCKET_ERROR) throw runtime_error("connect failed");
    char buffer[4];
    recv(socket, buffer, 4,
        0);
    byte length = *(reinterpret_cast<byte*>(buffer));
    if (length % 1024 == 0) cout << "#";
}