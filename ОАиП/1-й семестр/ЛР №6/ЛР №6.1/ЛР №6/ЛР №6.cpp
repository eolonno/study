#include <iostream>
#include <cmath>

using namespace std;

int main() {
	float b = -0.05, a = 1.72, i = -5, d, z;
	for (i; i <= 5; i += 2)
	{
		if (i > 3 * b)
			d = b * i;
		else if (i < 3 * b)
			d = tan(b) - a * i;
	}

	z = (d * a / 4) / (3 * a * b - exp(a + d) / 100);

	return 0;
}