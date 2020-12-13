
#include <iostream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");

	int m, m1, m2;
	cout << "¬ведите число m: ";
	cin >> m;

	for (int i = 0; i < m; i++)
	{
		for (int k = 0; k < m; k++)
		{
			if (i+k==m)
			{
				if (k-i == 5)
				{
					m1 = k;
					m2 = i;
					break;
				}
			}
		}
		if (m2 == i)
			break;
	}

		cout << m1 << " - " << m2 << " = 5" << endl;


	return 0;
}