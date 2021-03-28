#include "stdafx.h"
#include "Lib.h"


//установка в нулевую позицию
CRectD::CRectD()
{
	_left = _top = _right = _bottom = 0;
}

//Задаем позицию
CRectD::CRectD(double left, double top, double right, double bottom)
{
	_left = left;
	_top = top;
	_right = right;
	_bottom = bottom;
}

//Задаем позицию
void CRectD::SetRectD(double left, double top, double right, double bottom)
{
	_left = left;
	_top = top;
	_right = right;
	_bottom = bottom;
}