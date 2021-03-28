#pragma once

int setMode(CDC&, CRect&, CRectD&);

CMatrix getConverter(CRectD&, CRect&);

struct CPlotPen
{
	int _style, _width;
	COLORREF _color;

	CPlotPen()
	{
		_style = PS_SOLID; //сплошное перо
		_width = 1;
		_color = RGB(0, 0, 0);
	}
	void set(int style, int width, COLORREF color)
	{
		_style = style;
		_width = width;
		_color = color;
	}
};

class CPlot2D
{
private:
	CMatrix _functionArgument, _functionValue, _converter;// аргумент, функция, матрица пересчета координат
	CRect _rectWindow; //прямоугольник в окне
	CRectD _rectWorld; //прямоугольник в мировой сист коорд
	CPlotPen _penLine, _penAxis;// перья для линии и осей

public:
	CPlot2D();// конструктор по умолчанию
	void setParams(CMatrix&, CMatrix&, CRect&); //Параметры графика
	void setRectWindow(CRect&); //Установка области для отображения графика
	void setPenLine(CPlotPen&); //Перо для рисования графика
	void setPenAxis(CPlotPen&); //перо осей координат
	void getCoordsWindow(double, double, int&, int&); //пересчет из мировой сист координат в оконную сист коорд
	void getRectWorld(CRectD&);  //возврат область графика в мировой сист коорд
	void plot(CDC&, bool, bool); //рисование
};