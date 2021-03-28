// Combi3.h      
#pragma once 
namespace combi3
{
    struct  permutation    // генератор   перестановок     
    {
        const static bool L = true;  // левая стрелка 
        const static bool R = false; // правая стрелка   
        short  n,          // количество элементов исходного множества 
            * sset;        // массив индексов текущей перестановки
        bool* dart;        // массив  стрелок (левых-L и правых-R) 
        permutation(short n = 1); // конструктор (кол-во эл-ов исх. мн-ва) 
        void reset();             // сбросить генератор, начать сначала 
        __int64 getfirst();       // сформировать первый массив индексов    
        __int64 getnext();        // сформировать случайный массив индексов  
        short ntx(short i);       // получить i-й элемент масива индексов 
        unsigned __int64 np;      // номер перествновки 0,... count()-1 
        unsigned __int64 count() const; // вычислить общее кол. перестановок    
    };
};
