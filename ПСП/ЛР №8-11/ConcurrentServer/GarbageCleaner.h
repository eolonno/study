#pragma once
#include "Global.h"
using std::iterator;

DWORD WINAPI GarbageCleaner(LPVOID pPrm)
{
	cout << "GarbageCleaner started;\n" << endl;
	DWORD rc = 0;
	try
	{
		while (*((TalkersCmd*)pPrm) != Exit && &Work > 0)
		{
			EnterCriticalSection(&scListContact);

			for (std::list<Contact>::iterator first = Contacts.begin(); first != Contacts.end();)
			{
				if (first->sthread == Contact::FINISH || first->sthread == Contact::TIMEOUT || first->sthread == Contact::ABORT || first->type == Contact::EMPTY)
				{
					printf("IP of deleted client:-%s", inet_ntoa(first->prms.sin_addr));
					cout << " with code " << first->sthread << ";" << endl;
					if (first->type == Contact::EMPTY) InterlockedIncrement(&Fail);
					else
					{
						HANDLE nulX;
						if (first->sthread == Contact::FINISH) InterlockedIncrement(&Finished);
						if (first->sthread == Contact::TIMEOUT) InterlockedIncrement(&Fail);
						if (first->sthread == Contact::ABORT) InterlockedIncrement(&Fail);
						//if (first->hthread != nulX)
						//CloseHandle(first->hthread);
						//if(first->htimer != nulX)
							//CloseHandle(first->htimer);
					}
					closesocket(first->s);
					first = Contacts.erase(first);
					InterlockedDecrement(&Work);
				}

				else first++;
			}
			LeaveCriticalSection(&scListContact);
			Sleep(1000);
		}
	}
	catch (string errorMsgText)
	{
		std::cout << errorMsgText << endl;
	}
	cout << "GarbageCleaner stoped;\n" << endl;
	ExitThread(rc);
}