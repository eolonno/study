struct __TableEntry 
{
	char __Id[9];  
	DWORD  ((WINAPI* __Fn)) (LPVOID ClientList);
};
#define BEGIN_TABLESERVICE  __TableEntry  __TableService[] = {
#define ENTRYSERVICE(s,t)  {s,t}  
#define END_TABLESERVICE    };
#define TABLESERVICE_ID(i)  __TableService[i].__Id
#define TABLESERVICE_FN(i)  __TableService[i].__Fn
#define SIZETS sizeof(__TableService)/sizeof(__TableEntry)  