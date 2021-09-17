// dllmain.cpp: определяет точку входа для приложения DLL.
#include "stdafx.h"
#include "Windows.h"
#include "DefineTableService.h" // макро для TableService
#include "EchoServer.h"
#include "RandServer.h"
#include "TimeServer.h"

BEGIN_TABLESERVICE              // таблица 
	ENTRYSERVICE("Echo", EchoServer),
	ENTRYSERVICE("Time",TimeServer),
	ENTRYSERVICE("Rand", RandServer)
	END_TABLESERVICE;    

extern "C" __declspec(dllexport) HANDLE  SSS (char* id, LPVOID prm)
{
	HANDLE rc = NULL;
	int  i = 0;
	while(i < SIZETS && strcmp(TABLESERVICE_ID(i), id) != 0)i++;
	if (i < SIZETS) 
		rc =  CreateThread(NULL,NULL,TABLESERVICE_FN(i), prm ,NULL,NULL);	 
	return rc;
};

BOOL APIENTRY DllMain( HANDLE hinst, DWORD  rcall, LPVOID wres)
{
	return TRUE;
}
