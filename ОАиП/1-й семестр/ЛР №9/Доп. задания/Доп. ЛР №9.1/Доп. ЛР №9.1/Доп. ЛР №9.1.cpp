//Имеются результаты n ежедневных измерений количества выпавших осадков. За какую из недель (отрезок времени длиной 7 дней),
//считая с начала периода измерений, выпало наибольшее количество осадков?

#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "ru");
	int res[28], maxi = 1;
	double avg[4] = { 0,0,0,0 };
	for (int i = 0; i < 28; i++)
	{
		res[i] = rand() % 50;
	}

	for (int i = 0; i < 28; i++)
	{
		if (i < 7)
			avg[0] += res[i];
		if (i > 6 && i < 14)
			avg[1] += res[i];
		if (i > 13 && i < 21)
			avg[2] += res[i];
		if (i > 20 && i < 28)
			avg[3] += res[i];
	}
	
	for (int i = 0; i < 4; i++)
		avg[i] /= 7;
	int max = avg[0];
	for (int i = 0; i < 4; i++)
	{
		if (avg[i] >= max)
		{
			max = avg[i];
			maxi = i + 1;
		}
	}
	cout << "Максимальное количество осадков было на " << maxi << " неделе" << endl;

	return 0;
}