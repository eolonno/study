#include <iostream>
#include <bitset>
#include <locale>
#include <locale.h>
#include <clocale>
#include <string>

using namespace std;

string InBinary(unsigned long);
bool CheckAddress(char*);
unsigned long CharToLong(char*);
bool CheckMask(int);

int main()
{
	setlocale(LC_ALL, "rus");

	unsigned long IP, Mask, HOST, Subnet, Broadcast;
	char* IP_ = new char[16],
		* Mask_ = new char[16];
	bool Flag = true;

	do
	{
		if (!Flag) cout << "Неверно введён адрес!" << endl;
		cout << "IP: ";
		cin >> IP_;
	} while (!(Flag = CheckAddress(IP_)));
	IP = CharToLong(IP_);
	Flag = true;
	do
	{
		if (!Flag) cout << "Неправильная маска!" << endl;
		Flag = true;
		do
		{
			if (!Flag) cout << "Неверно введена маска!" << endl;
			cout << "Маска: ";
			cin >> Mask_;
		} while (!(Flag = CheckAddress(Mask_)));
		Mask = CharToLong(Mask_);
	} while (!(Flag = CheckMask(Mask)));

	Subnet = IP & Mask;
	HOST = IP & ~Mask;
	Broadcast = Subnet | ~Mask;

	cout << "ID подсети: " << InBinary(Subnet);
	cout << "ID хоста: " << InBinary(HOST);
	cout << "Броадкаст: " << InBinary(Broadcast);
}

string InBinary(unsigned long Number)
{
	{
		int bin, mod;
		int Arr[40];
		int Arr2[40];
		int Index = 0;
		string out = "";

		while (Number != 1)
		{
			if (Number % 2 == 0)
			{
				Number /= 2;
				Arr[Index] = 0;
				Index++;
			}
			else
			{
				Number -= 1;
				Number /= 2;
				Arr[Index] = 1;
				Index++;
			}
		}
		Arr[Index] = 1;
		Index++;
		if (Index != 32)
		{
			while (Index != 32)
			{
				Arr[Index] = 0;
				Index++;
			}
		}
		for (int i = Index - 1, j = 0; i >= 0; i--, j++)
		{
			Arr2[j] = Arr[i];
		}
		int dir = 7;
		int num = 0;
		int point = 0;
		for (int i = 0; i < Index; i++)
		{
			num += Arr2[i] * pow(2, dir);
			dir--;
			if (dir == -1)
			{
				point++;
				if (point == 4)
					out += to_string(num);
				else
					out += to_string(num) + '.';
				dir = 7;
				num = 0;
			}
		}
		out += '\n';
		return out;
	}
}

bool CheckAddress(char* IP_)
{
	int points = 0,		// Количество точек
		numbers = 0;	// Значение октета
	char* Buffer;		// Буфер для одного октета
	Buffer = new char[3];
	for (int i = 0; IP_[i] != '\0'; i++)
	{ 
		if (IP_[i] <= '9' && IP_[i] >= '0')
		{
			if (numbers > 3) return false;	// Если больше трех чисел в октете – ошибка
			Buffer[numbers++] = IP_[i];		// Скопировать в буфер
		}
		else
			if (IP_[i] == '.') // если точка
			{
				if (atoi(Buffer) > 255)		// Проверить диапазон октета
					return false;
				if (numbers == 0)			// Если числа нет - ошибка
					return false;
				numbers = 0;
				points++;
				delete[] Buffer;
				Buffer = new char[3];
			}
			else return false;
	}
	if (points != 3) // Если количество точек в IP-адресе не 3 - ошибка
		return false;
	if (numbers == 0 || numbers > 3)
		return false;
	return true;
}

unsigned long CharToLong(char* IP_)
{
	unsigned long out = 0;	// Число для IP-адреса
	char* Buffer;			// Буфер
	Buffer = new char[3];	// Буфер для хранения одного октета
	for (int i = 0, j = 0, k = 0; IP_[i] != '\0'; i++, j++)
	{
		if (IP_[i] != '.')
			Buffer[j] = IP_[i];
		if (IP_[i] == '.' || IP_[i + 1] == '\0')
		{
			out <<= 8;					// Если следующий октет или последнийсдвинуть число на 8 бит
			if (atoi(Buffer) > 255)		// Еcли октет больше 255 – ошибка
				return NULL;


			out += (unsigned long)atoi(Buffer);	//Преобразовать и добавить к числу IP-адреса
			k++;
			j = -1;
			delete[] Buffer;
			Buffer = new char[3];
		}
	}
	return out;
}

bool CheckMask(int Mask)
{

	std::string Binary = std::bitset<32>(Mask).to_string(); // Перевод к бинарному виду

	if (Binary[0] == '0')
	{
		return false;
	}
	if (Binary[0] == '1')
	{
		for (int i = 1; i <= Binary.length() - 2; i++)
		{
			if (Binary[i] == '0')
			{
				for (int k = i + 1; k <= Binary.length(); k++)
				{
					if (Binary[k] == '1')
					{
						return false;
					}
				}
			}
		}
	}
	return true;
}