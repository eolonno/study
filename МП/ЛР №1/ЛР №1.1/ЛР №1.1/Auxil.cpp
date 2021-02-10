//-- Auxil.cpp   
#include "Auxil.h" 
#include <ctime>    
namespace auxil
{
    void start()                          // старт  генератора сл. чисел
    {
        srand((unsigned)time(NULL));
    };
    double dget(double rmin, double rmax) // получить случайное число
    {
        return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
    };
    int iget(int rmin, int rmax)         // получить случайное число

    {
        return (int)dget((double)rmin, (double)rmax);
    };
}
