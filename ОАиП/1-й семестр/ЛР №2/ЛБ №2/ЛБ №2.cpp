#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	bool start = true;
	int times = 0;
	while (start)
	{
		cout << "Введите номер задачи: ";
		int num;
		cin >> num;
		cout << endl;

		if (num == 1)
		{
			float b = -0.12, x = 1.3 * pow(10, -4), z, y;
			int n = 2;
			z = 1 / (x - 1) + sin(x) - sqrt(n);
			y = (exp(-b) + 1) / 2 * z;
			cout << " z = " << z << endl << " y = " << y << endl;
			if (times == 1)
				break;
			cout << "Запустить вторую задачу? \t (1. Да \t 2. Нет)" << endl;
			int choice;
			cin >> choice;
			if (choice == 1)
				num = 2;
			else
				start = false;
			times++;
		}

		if (num == 2)
		{
			int b = 40;
			float x = 1.1, a = pow(5, -6), y, w;
			w = (a + b) * tan(x) / (x + 1);
			y = 1 / 2 * b - sqrt(w - a * b);
			cout << " w = " << w << endl << " y = " << y << endl;
			if (times == 1)
				break;
			cout << "Запустить первую задачу? \t (1. Да \t 2. Нет)" << endl;
			int choice;
			cin >> choice;
			if (choice == 1)
				num = 2;
			else
				start = false;
			times++;
		}
		if (times == 2)
			start = false;
	}
	return 0;
}