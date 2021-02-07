#include "LibGraph.h"
#include <string>
#include <iostream>
void PrintMatrix(CDC& dc, int x, int y, CMatrix& M)
{
	int x0 = x;
	for (int i = 0; i < M.rows(); i++)
	{
		for (int j = 0; j < M.cols(); j++)
		{
			char buff[32]; // буфер
			sprintf_s(buff, " %3.2f ", M(i, j)); //преобразование дробного числа в строку
			dc.TextOut(x, y, buff); //вывод числа по указанным координатам
			x += 45; // смещение вправо на 45 едениц
		}
		y += 30; // смещение вниз на 30 едениц
		x = x0; // аннулирование горизонтальной координаты
	}
}

CMatrix VectorMult(CMatrix& V1, CMatrix& V2) // Векторное произведение
{
	CMatrix temp(3);
	temp(0) = V1(1)*V2(2) - V1(2)*V2(1);
	temp(1) = V1(2)*V2(0) - V1(0)*V2(2);
	temp(2) = V1(0)*V2(1) - V1(1)*V2(0);
	return temp;
}

double ScalarMult(CMatrix& V1, CMatrix& V2) // Скалярное произведение
{
	
	return (V1(0)*V2(0) + V1(1)*V2(1) + V1(2)*V2(2));
}

double ModVec(CMatrix& V) // Модуль вектора
{
	return sqrt(V(0)*V(0) + V(1)*V(1) + V(2)*V(2));
}

double CosV1V2(CMatrix& V1, CMatrix& V2) // Косинус угла двух векторов
{
	return (ScalarMult(V1, V2) / (ModVec(V1)*ModVec(V2)));
}

CMatrix SphereToCart(CMatrix& PView) // Преобразует сферические координаты в декартовы
{
	CMatrix R(3);
	R(0) = PView(0)*cos(PView(1))*sin(PView(2));
	R(1) = PView(0)*sin(PView(1))*sin(PView(2));
	R(2) = PView(0)*cos(PView(2));
	return R;
}