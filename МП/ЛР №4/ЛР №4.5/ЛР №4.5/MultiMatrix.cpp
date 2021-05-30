// --- MultiMatrix.cpp 
//    расстановка скобок (рекурсия) 
#include <memory.h>
#include "MultiMatrix.h"
#define INFINITY  0x7fffffff
#define NINFINITY 0x80000000
int OptimalM(int i, int j, int n, const int c[], int* s)
{
#define OPTIMALM_S(x1,x2)  (s[(x1-1)*n+x2-1])  
	int o = INFINITY, bo = INFINITY;
	if (i < j)
	{
		for (int k = i; k < j; k++)
		{
			bo = OptimalM(i, k, n, c, s) +
				OptimalM(k + 1, j, n, c, s) + c[i - 1] * c[k] * c[j];
			if (bo < o)
			{
				o = bo;
				OPTIMALM_S(i, j) = k;
			}
		}
	}
	else  o = 0;
	return o;
#undef OPTIMALM_S             
};
// --- MultyMatrix.cpp (продолжение) 
//    расстановка скобок (динамическое программирование)  
int OptimalMD(int n, const int c[], int* s)
{
#define OPTIMALM_S(x1,x2)  (s[(x1-1)*n+x2-1]) 
#define OPTIMALM_M(x1,x2)  (M[(x1-1)*n+x2-1])
	int* M = new int[n * n], j = 0, q = 0;
	for (int i = 1; i <= n; i++) OPTIMALM_M(i, i) = 0;
	for (int l = 2; l <= n; l++)
	{
		for (int i = 1; i <= n - l + 1; i++)
		{
			j = i + l - 1;
			OPTIMALM_M(i, j) = INFINITY;
			for (int k = i; k <= j - 1; k++)
			{
				q = OPTIMALM_M(i, k) + OPTIMALM_M(k + 1, j) + c[i - 1] * c[k] * c[j];
				if (q < OPTIMALM_M(i, j))
				{
					OPTIMALM_M(i, j) = q;  OPTIMALM_S(i, j) = k;
				}
			}
		}
	}
	return OPTIMALM_M(1, n);
#undef OPTIMALM_M
#undef OPTIMALM_S 
};
