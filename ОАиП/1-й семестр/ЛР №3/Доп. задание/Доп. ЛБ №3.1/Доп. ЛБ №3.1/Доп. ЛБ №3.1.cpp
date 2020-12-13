
#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");

	float ps, milk, milksum, milkwin, years;
	cout << "Введите стоимость молока: ";
	cin >> milk;
	cout << endl << "На сколько процентов должна подняться стоимость молока? ";
	cin >> ps;
	cout << endl << "Через какое число лет вы хотите узнать результат? \t";
	cin >> years;

	ps *= 0.01;

	for (int i = 0; i < years; i++)
	{
		milkwin = ps * milk + milk;
		cout << "Стоимость молока зимой №" << i + 1 << " равна: " << milkwin <<endl;
		milksum = milkwin - ps * milkwin;
		cout << "Стоимость молока летом №" << i + 1 << " равна: " << milksum << endl;
	}


	if (milkwin > milksum)
		cout << "Стоимость молока зимой №" << years <<" была выше на " << milkwin - milksum;
	else if (milksum > milkwin)
		cout << "Стоимость молока летом №" << years << " была выше на " << milksum - milkwin;
	else
		cout << "Стоимость молока летом №" << years << " равна стоимости молока зимой №" << years;

	return 0;
}

