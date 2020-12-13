#include <windows.h>
#include <iostream>
#include <ctime>

int size = 5;

void New(HANDLE*, int*);
void Del(HANDLE*, int*);
void insert(HANDLE*, int*);
void remove(HANDLE*, int*);

void print(int*);

int main(int argc, TCHAR* argv[])
{
	setlocale(LC_CTYPE, "rus");

	HANDLE hHeap = HeapCreate(HEAP_NO_SERIALIZE, 0, 0);
	if (!hHeap)
	{
		std::cout << "Heap Creation Failed" << std::endl;
		return GetLastError();
	}
	int *arr = new int[size];

	arr = (int*)HeapAlloc(hHeap, NULL, size * sizeof(int));
	for (int i = 0; i < size; i++)
		arr[i] = rand() % 20 - 10;
	
	int ans;
	do {
		std::cout << "1) Добавить новый элемент в кучу\n2) Удалить последний элемент из кучи\n3) Добавить новый элемент в рандомное место\n4) Удалить рандомный элемент в куче\n0) Выход\n$ ";
		std::cin >> ans;
		switch (ans)
		{
		case 1:
			New(&hHeap, arr);
			break;
		case 2:
			Del(&hHeap, arr);
			break;
		case 3:
			insert(&hHeap, arr);
			break;
		case 4:
			remove(&hHeap, arr);
			break;
		case 0: 
			break;
		default:
			std::cout << "Введены некорректные данные\n";
			break;
		}
		std::cout << std::endl;
	} while (ans);

	return 0;
}

void New(HANDLE* hHeap, int* arr) {
	size++;
	arr = (int*)HeapReAlloc(*hHeap, NULL, arr, size * sizeof(int));
	std::cout << "Введите новый целочисленный элемент: ";
	std::cin >> arr[size - 1];
	print(arr);
}

void Del(HANDLE* hHeap, int* arr) {
	if (size == 0)
	{
		print(arr);
		return;
	}
	size--;
	arr = (int*)HeapReAlloc(*hHeap, NULL, arr, size * sizeof(int));
	print(arr);
}

void insert(HANDLE* hHeap, int* arr)
{
	size++;
	arr = (int*)HeapReAlloc(*hHeap, NULL, arr, size * sizeof(int));
	std::cout << "Введите новый целочисленный элемент: ";
	int number;
	std::cin >> number;
	std::srand(std::time(nullptr));
	int random = rand() % (size - 1);
	for (int i = 0; i < size; i++)
	{
		arr[size - 1 - i] = arr[size - i - 2];
		if (random == i)
		{
			arr[size - i - 1] = number;
			break;
		}
	}
	print(arr);
}

void remove(HANDLE* hHeap, int* arr)
{
	if (size == 0)
	{
		print(arr);
		return;
	}
	
	if (size > 2) {
		std::srand(std::time(nullptr));
		int random = size > 2 ? rand() % (size - 2) : 0;
		bool isStart = true;
		for (int i = 0; i < size; i++)
		{
			if (random == i)
				isStart = false;
			if (isStart)
				arr[i] = arr[i + 1];
			if (!isStart && size - i - 2 > 0)
				arr[i] = arr[i + 2];
		}
	}
	size--;
	arr = (int*)HeapReAlloc(*hHeap, NULL, arr, size * sizeof(int));
	print(arr);
}

void print(int* arr)
{
	if (size == 0)
	{
		std::cout << "Куча пуста!\n";
		return;
	}
	std::cout << "Куча: ";
	for (int i = 0; i < size; i++)
		std::cout << arr[i] << ' ';
	std::cout << '\n';
}