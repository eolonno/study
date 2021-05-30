#include <algorithm>
#include "LCSR.h"
int lcs(int lenx, const char x[],
	int leny, const char y[])
{
	int rc = 0;
	if (lenx > 0 && leny > 0)
	{
		if (x[lenx - 1] == y[leny - 1]) rc = 1 + lcs(lenx - 1, x, leny - 1, y);
		else rc = std::max(lcs(lenx, x, leny - 1, y), lcs(lenx - 1, x, leny, y));
	}
	return rc;        //длина LCS
}