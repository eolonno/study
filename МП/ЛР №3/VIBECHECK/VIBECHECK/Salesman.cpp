// Salesman.cpp
#include "Salesman.h"
int sum(int x1, int x2) // суммирование с учетом бесконечности 
{
    return (x1 == INF || x2 == INF) ? INF : (x1 + x2);
};
int* firstpath(int n)   // формирование 1го маршрута 0,1,2,..., n-1, 0
{
    int* rc = new int[n + 1]; rc[n] = 0;
    for (int i = 0; i < n; i++) rc[i] = i;
    return rc;
};
int* source(int n)      // формирование исходного массива 1,2,..., n-1
{
    int* rc = new int[n - 1];
    for (int i = 1; i < n; i++) rc[i - 1] = i;
    return rc;
};
void  copypath(int n, int* r1, const int* r2)   // копировать маршрут
{
    for (int i = 0; i < n; i++)  r1[i] = r2[i];
};
int distance(int n, int* r, const int* d)       // длина маршрута 
{
    int rc = 0;
    for (int i = 0; i < n - 1; i++) rc = sum(rc, d[r[i] * n + r[i + 1]]);
    return  sum(rc, d[r[n - 1] * n + 0]);    //+ последн€€ дуга (n-1,0) 
};
void indx(int n, int* r, const int* s, const short* ntx) {
    for (int i = 1; i < n; i++)  r[i] = s[ntx[i - 1]];
}
int salesman(
    int n,         // [in]  количество городов 
    const int* d,  // [in]  массив [n*n] рассто€ний 
    int* r         // [out] массив [n] маршрут 0 x x x x 
) {
    int* s = source(n), * b = firstpath(n), rc = INF, dist = 0;
    combi3::permutation p(n - 1);
    int k = p.getfirst();
    while (k >= 0)  // цикл генерации перестановок
    {
        indx(n, b, s, p.sset);        // новый маршрут 
        if ((dist = distance(n, b, d)) < rc) { rc = dist; copypath(n, r, b); }
        k = p.getnext();
    };
    return rc;
}
