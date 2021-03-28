#include "stdafx.h"
#include "CMatrix.h"
#include "Lib.h"
#include "Plot2D.h"

int setMode(CDC& dc, CRect& rectWindow, CRectD& rectWorld) //режим отображение
{
	int dsx = rectWorld._right - rectWorld._left;
	int dsy = rectWorld._top - rectWorld._bottom;
	int xsl = rectWorld._left;
	int ysl = rectWorld._bottom;
	int dwx = rectWindow.right - rectWindow.left;
	int dwy = rectWindow.bottom - rectWindow.top;
	int xwl = rectWindow.left;
	int ywh = rectWindow.bottom;

	int buffer = dc.SetMapMode(MM_ANISOTROPIC);//Логические единицы измерения отображаются произвольными единицами измерения с произвольно масштабируемыми осями
	dc.SetWindowExt(dsx, 1);//размеры окна
	dc.SetViewportExt(dwx, -dwy);//размеры области просмотра 
	dc.SetWindowOrg(xsl, 1); //Устанавливает начало окна контекста устройства.
	dc.SetViewportOrg(xwl, ywh);//Устанавливает начало области просмотра контекста устройства
	return buffer; // устанавливает режим отображения указанного контекста устройства
}

CMatrix getConverter(CRectD& rectWorld, CRect& rectWindow)//конвертируем отображение мировых и оконных
{
	CMatrix m(3, 3);
	double kx = (double)(((double)(rectWindow.right - rectWindow.left)) / ((double)(rectWorld._right - rectWorld._left)));//вычисляем отношение между  размером окна и мировых
	double ky = (double)(((double)(rectWindow.bottom - rectWindow.top)) / ((double)(rectWorld._bottom - rectWorld._top)));
	m(0, 1) = m(1, 0) = m(2, 0) = m(2, 1) = 0;
	m(2, 2) = 1;
	m(0, 0) = kx;
	m(0, 2) = rectWindow.left - kx * rectWorld._left;
	m(1, 1) = -ky;
	m(1, 2) = rectWindow.bottom + ky * rectWorld._top;
	return m;
}

CPlot2D::CPlot2D()
{
	_converter.resize(3, 3); // меняем на матрицу 3х3
}

//параметры графика
void CPlot2D::setParams(CMatrix& functionArgument, CMatrix& functionValue, CRect& rectWindow){
	int nRowsX = functionArgument.countRows(), nRowsY = functionValue.countRows();
	if (nRowsX != nRowsY)
	{
		MessageBox(NULL, L"Несоответствие размерностей матриц", L"Ошибка", MB_ICONERROR);
	}
	_functionArgument.resize(nRowsX); //меняем размер по х на переданные функции
	_functionValue.resize(nRowsY);//меняем размер по у на переданные функции
	_functionArgument = functionArgument;//меняем значение по х на переданные функции
	_functionValue = functionValue;//меняем значение по у на переданные функции

	_rectWorld._top = _functionValue.getMin();
	_rectWorld._bottom = _functionValue.getMax();
	_rectWorld._left = _functionArgument.getMin();
	_rectWorld._right = _functionArgument.getMax();

	_rectWindow.SetRect(rectWindow.left, rectWindow.top, rectWindow.right, rectWindow.bottom);//Устанавливает координаты прямоугольника
	_converter = getConverter(_rectWorld, _rectWindow);
}

void CPlot2D::setRectWindow(CRect& rectWindow)//Установка области для отображения графика
{
	_rectWindow.SetRect(rectWindow.left, rectWindow.top, rectWindow.right, rectWindow.bottom);
	_converter = getConverter(_rectWorld, _rectWindow);
}

void CPlot2D::setPenLine(CPlotPen& penLine)//Перо для рисования графика
{
	_penLine.set(penLine._style, penLine._width, penLine._color);
}

void CPlot2D::setPenAxis(CPlotPen& penAxis)//перо осей координат
{
	_penAxis.set(penAxis._style, penAxis._width, penAxis._color);
}

//пересчет из мировой сист координат в оконную сист коорд
void CPlot2D::getCoordsWindow(double xs, double ys, int &xw, int &yw)
{
	CMatrix V(3), W(3); //задаем вектор в мир сист коорд и в оконной сист
	V(2) = 1;
	V(0) = xs;
	V(1) = ys;
	W = _converter * V;//конвертируем в оконную сист
	xw = (int)W(0);
	yw = (int)W(1);
}

//возврат область графика в мировой сист коорд
void CPlot2D::getRectWorld(CRectD& rectWorld)
{
	rectWorld._bottom = _rectWorld._bottom;
	rectWorld._left = _rectWorld._left;
	rectWorld._right = _rectWorld._right;
	rectWorld._top = _rectWorld._top;
}

void CPlot2D::plot(CDC& dc, bool drawOuterRect, bool drawInnerGrid)//рисуем графики
{
	dc.SetMapMode(//устанавливает режим отображения контекста устройства. Определяет единицу измерения, для преобразования единиц измерения пространства страницы в пространства устройства
		MM_TEXT);//логическая единица измерения отображается как один пиксель устройства
	CMatrix V(3), W(3);
	V(2) = 1;
	if (drawOuterRect)
	{
		dc.Rectangle(_rectWindow);//Рисуем прямоугольник
	}
	if (drawInnerGrid)//русуем график
	{
		CPen pen(_penAxis._style, _penAxis._width, _penAxis._color);//передаем параметры пера
		CPen* pOldPen = dc.SelectObject(&pen); // Выбираем перо в контекст памяти
		if (_rectWorld._left * _rectWorld._right < 0)
		{
			V(0) = 0; //по х 0
			V(1) = _rectWorld._top; //по у передается значение верхушки прямоугольника
			W = _converter * V; //конверт в оконную сист коорд

			V(0) = 0;
			V(1) = _rectWorld._bottom;
			W = _converter * V;

			for (double i = 0; i < (_rectWindow.bottom - _rectWindow.top); i += 10)
			{
				dc.MoveTo(_rectWindow.left, _rectWindow.top + i);//ставим точку
				dc.LineTo(_rectWindow.right, _rectWindow.top + i);//рисуем линию
			}
			for (double i = 0; i < (_rectWindow.right - _rectWindow.left); i += 10)
			{
				dc.MoveTo(_rectWindow.left + i, _rectWindow.top);
				dc.LineTo(_rectWindow.left + i, _rectWindow.bottom);
			}
		}
		if (_rectWorld._top * _rectWorld._bottom < 0)
		{
			V(0) = _rectWorld._left;
			V(1) = 0;
			W = _converter * V;

			V(0) = _rectWorld._right;
			V(1) = 0;
			W = _converter * V;
		}
		dc.SelectObject(pOldPen);
	}

	V(0) = _functionArgument(0);
	V(1) = _functionValue(0);
	W = _converter * V;
	CPen MyPen(_penLine._style, _penLine._width, _penLine._color);//передаем параметры пера
	CPen * pOldPen = dc.SelectObject(&MyPen);//передаем в контекст для рисования перо

	dc.MoveTo((int)W(0), (int)W(1));//определяем начальную точку
	for (int i = 1; i < _functionArgument.countRows(); i++)
	{
		V(0) = _functionArgument(i);
		V(1) = _functionValue(i);
		W = _converter * V;
		dc.LineTo((int)W(0), (int)W(1));//ведем линию
	}
	dc.SelectObject(pOldPen);//возвращаем контекст рисования

}