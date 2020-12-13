#include <iostream>
using namespace std;

int main()
{
	double m = 4, c = -0.045, b[] = { -2,6,1.1,2.7,4 }, pr = 1;

	for (int i = 0; i < m; i++)
	{
		pr *= pow(b[i] + 1, 2);
	}
	cout << "Answer num 2: " << pr * c << endl;

	double k = 5, x[] = { -2,6,1.1,2.7,4 }, z, sum = 0;
	for (int i = 0; i < k; i++)
	{
		sum += pow(x[i] - 2, 2);
	}
	cout << "Answer num 3:" << 8 * x[2] + sum << endl;

	double n = 6, f[] = { 3,-2,0.7,-1,-2.7 }, y[] = { 2.1,7.7,-4,5,9 }, q = 0;
	for (int i = 0; i < n; i++)
		q += f[i] * y[i];
	cout << "Answer num 10: " << q << endl;

	return 0;
}
