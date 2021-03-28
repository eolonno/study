// Knapsack.h      
#pragma once 
#include "Combi1.h"
int   knapsack_s(
    int V,         // [in]  вместимость рюкзака 
    short n,       // [in]  количество типов предметов 
    const int v[], // [in]  размер предмета каждого типа  
    const int c[], // [in]  стоимость предмета каждого типа     
    short m[]      // [out] количество предметов каждого типа  
);

bool RandomFilling(
    int* arr,       // [out] пустой массив для заполнения
    int size,       // [in] размер массива
    int min,        // [in] минимальное значение для заполнения
    int max         // [in] максимальное значение для заполнения
);