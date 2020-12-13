#include<iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char res[120];
	char RES[10000], k;
	int  n, i = 0;
	cout << "Введите строку символов res (латиницей)" << endl;
	cin >> res;
	cout << "Введите строку символов RES (латиницей)" << endl;
	cin >> RES;
	cout << "Введите длину подстроки RES: " << endl;
	cin >> k;
	cout << "Введите номер позиции для вставки: " << endl;
	cin >> n;
	while (res[i + k + n] != '\0')
	{
		res[i + k + n] = res[n + i];
		i++;
	}
	for (i = 0; i < k; i++)
	{
		res[n + i] = RES[i];
	}
	cout << "Итог: " << res;



}



