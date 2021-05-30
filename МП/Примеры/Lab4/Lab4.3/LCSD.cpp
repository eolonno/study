#include <cstring>
#include "LCSD.h"
#define LCS_C(x1,x2)  (C[(x1)*(leny+1)+(x2)])
#define LCS_B(x1,x2)  (B[(x1)*(leny+1)+(x2)])
#define LCS_X(i)      (x[(i)-1])
#define LCS_Y(i)      (y[(i)-1])
#define LCS_Z(i)      (z[(i)-1])
enum Dart { TOP, LEFT, LEFTTOP };
void getLCScontent(int lenx, int leny, const char x[],
	const Dart* B,
	int n, int i, int j, char z[])
{
	if ((i > 0 && j > 0 && n > 0))
	{
		if (LCS_B(i, j) == LEFTTOP)
		{
			getLCScontent(lenx, leny, x, B, n - 1, i - 1, j - 1, z);
			LCS_Z(n) = LCS_X(i);
			LCS_Z(n + 1) = 0;
		}
		else if (LCS_B(i, j) == TOP)
			getLCScontent(lenx, leny, x, B, n, i - 1, j, z);
		else getLCScontent(lenx, leny, x, B, n, i, j - 1, z);
	}
};
int lcsd(const char x[], const char y[], char z[])
{
	int n;
	int lenx = strlen(x), leny = strlen(x),
		* C = new int[(lenx + 1) * (leny + 1)];
	Dart* B = new Dart[(lenx + 1) * (leny + 1)];
	memset(C, 0, sizeof(int) * (lenx + 1) * (leny + 1));
	for (int i = 1; i <= lenx; i++)
		for (int j = 1; j <= leny; j++)
			if (LCS_X(i) == LCS_Y(j))
			{
				LCS_C(i, j) = LCS_C(i - 1, j - 1) + 1;
				LCS_B(i, j) = LEFTTOP;
			}
			else if (LCS_C(i - 1, j) >= LCS_C(i, j - 1))
			{
				LCS_C(i, j) = LCS_C(i - 1, j);
				LCS_B(i, j) = TOP;
			}
			else
			{
				LCS_C(i, j) = LCS_C(i, j - 1);
				LCS_B(i, j) = LEFT;
			}
	getLCScontent(lenx, leny, x, B, LCS_C(lenx, leny), lenx, leny, z);
	return LCS_C(lenx, leny);
}
#undef LCS_Z
#undef LCS_C
#undef LCS_B
#undef LCS_X
#undef LCS_Y
