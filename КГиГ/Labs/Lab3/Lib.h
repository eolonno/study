#pragma once

struct CRectD
{
	double _left; //левая часть экрана
	double _top; // Верхняя часть экрана
	double _right; // правая часть экрана
	double _bottom; //Нижняя часть экрана
	CRectD(); //установка в нулевой позиции
	CRectD(double, double, double, double); //установка в заданной позиции
	void SetRectD(double, double, double, double);
};