// Knapsack.cpp 
#include "Knapsack.h"
#include <exception>
#include <ctime>
#define NINF 0x80000000    // самое малое int-число  

int calcv(combi1::subset s, const int v[])  // объем в рюкзаке
{
    int rc = 0;
    for (int i = 0; i < s.sn; i++) rc += v[s.ntx(i)];
    return rc;
};
int calcc(combi1::subset s, const int v[], const int c[]) //стоимость в рюкзаке 
{
    int rc = 0;
    for (int i = 0; i < s.sn; i++) rc += (v[s.ntx(i)] * c[s.ntx(i)]);
    return rc;
};
void setm(combi1::subset s, short m[]) //отметить выбранные предметы 
{
    for (int i = 0; i < s.n; i++) m[i] = 0;
    for (int i = 0; i < s.sn; i++) m[s.ntx(i)] = 1;
};
int   knapsack_s(
    int V,         // [in] вместимость рюкзака 
    short n,       // [in] количество типов предметов 
    const int v[], // [in] размер предмета каждого типа  
    const int c[], // [in] стоимость предмета каждого типа
    short  m[]     // [out] количество предметов каждого типа {0,1} 
)
{
    combi1::subset s(n);
    int maxc = NINF, cc = 0;
    short  ns = s.getfirst();
    while (ns >= 0)
    {
        if (calcv(s, v) <= V)
            if ((cc = calcc(s, v, c)) > maxc)
            {
                maxc = cc;
                setm(s, m);
            }
        ns = s.getnext();
    };
    return maxc;
};

bool RandomFilling(int* arr, int size, int min, int max)
{
    try
    {
        srand((unsigned)time(NULL));
        for (int i = 0; i < size; i++)
            arr[i] = min + rand() % max;

        return true;
    }
    catch (const std::exception&)
    {
        return false;
    }
}