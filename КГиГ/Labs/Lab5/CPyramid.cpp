#include "stdafx.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "CPyramid.h"

CPyramid::CPyramid()//Пирамида по умолчанию
{
	_vertices.resize(4, 8);

	_vertices(0, 0) = 6;
	_vertices(0, 3) = 2;
	_vertices(2, 3) = 6;

	_vertices(1, 1) = -6;
	_vertices(1, 4) = -2;
	_vertices(2, 4) = 6;

	_vertices(0, 2) = -6;
	_vertices(0, 5) = -2;
	_vertices(2, 5) = 6;
}

void CPyramid::draw(CDC& dc, CMatrix& viewport, CRect& rectWindow)//нарисовать пирамиду без невидимых граней
{
	CMatrix viewportCoords = sphericalToCartesian(viewport);//переводим из сферической в декартову
	CMatrix converterWorldToView = getConverterWorldToView(viewport(0), viewport(1), viewport(2));//конвертация мировых в видовые
	CMatrix verticesView = converterWorldToView * _vertices;
	CRectD rectView;
	getRect(verticesView, rectView);//задаёт прямоугольник для рисования (область для рисования)
	CMatrix converterWorldToWindow = getConverterWorldToWindow(rectView, rectWindow);//конвертация мировых координат в оконные

	CPoint vertices[6];
	CMatrix verticesCoords(3);
	verticesCoords(2) = 1;

	for (int i = 0; i < 6; i++)//задание точек
	{
		verticesCoords(0) = verticesView(0, i);
		verticesCoords(1) = verticesView(1, i);

		verticesCoords = converterWorldToWindow * verticesCoords;
		vertices[i].x = (int)verticesCoords(0);
		vertices[i].y = (int)verticesCoords(1);
	}

	CPen brushEdge(PS_SOLID, 2, RGB(0, 0, 255)); //задаем в перо синего цвета для краев(линий)
	CPen* pOldPen = dc.SelectObject(&brushEdge);//передаем в контекст рисования
	CBrush brushBottom(RGB(255, 0, 0));//задаем в перо синего цвета для основания
	CBrush* pOldBrush = dc.SelectObject(&brushBottom); //передаем в контекст рисования
	CMatrix R1(3), R2(3), normalOuter(3);
	double sm;
	for (int i = 0; i < 3; i++) // закрашивание граней
	{
		CMatrix VE = _vertices.getCol(i + 3, 0, 2);//Получение подстроки по номеру и диапазону
		int k = i == 2 ? 0 : i + 1;
		R1 = _vertices.getCol(i, 0, 2);
		R2 = _vertices.getCol(k, 0, 2);
		CMatrix edgeBase = R2 - R1;
		CMatrix edgeVertex = VE - R1;
		normalOuter = vectorProduct(edgeVertex, edgeBase);
		sm = scalarProduct(normalOuter, viewportCoords);// скалярное произведение видовых и граневых координат
														//то есть, если произведение = или более 0, то есть площадь и можно рисовать грани

		if (sm >= 0)
		{
			dc.MoveTo(vertices[i]);
			dc.LineTo(vertices[k]);
			dc.LineTo(vertices[k + 3]);
			dc.LineTo(vertices[i + 3]);
			dc.LineTo(vertices[i]);
		}
	}

	normalOuter = vectorProduct(R1, R2);
	sm = scalarProduct(normalOuter, viewportCoords);// скалярное произведение видовых и граневых координат
	if (viewportCoords(2) < 0) //если меньше, то это основание
	{
		dc.Polygon(vertices, 3);
	}
	else//иначе, верхнее основание усеченной пирамиды
	{
		CBrush brushTop(RGB(0, 255, 0));//задаем в перо зеленого цвета для основания
		dc.SelectObject(brushTop);//передаем перо в контекс рисования
		dc.Polygon(vertices + 3, 3);
	}

	dc.SelectObject(pOldPen);
	dc.SelectObject(pOldBrush);
}

void CPyramid::drawXray(CDC& dc, CMatrix& viewport, CRect& rectWindow)
{
	CMatrix converterWorldToView = getConverterWorldToView(viewport(0), viewport(1), viewport(2));//конвертация мировых в видовые
	CMatrix verticesView = converterWorldToView * _vertices;
	CRectD rectView;
	getRect(verticesView, rectView);//задаёт прямоугольник для рисования (область для рисования)
	CMatrix converterWorldToWindow = getConverterWorldToWindow(rectView, rectWindow);//конвертация мировых координат в оконные

	CPoint vertices[6];
	CMatrix verticesCoords(3);
	verticesCoords(2) = 1;

	for (int i = 0; i < 6; i++)//задание точек
	{
		verticesCoords(0) = verticesView(0, i);
		verticesCoords(1) = verticesView(1, i);
		verticesCoords = converterWorldToWindow * verticesCoords;
		vertices[i].x = (int)verticesCoords(0);
		vertices[i].y = (int)verticesCoords(1);
	}

	CPen brushEdge(PS_SOLID, 2, RGB(0, 0, 255)); //задаем в перо синего цвета для краев(линий)
	CPen* pOldPen = dc.SelectObject(&brushEdge);//передаем в контекст рисования

	dc.MoveTo(vertices[2]); //рисуем грани
	for (int i = 0; i < 3; i++)
	{
		dc.LineTo(vertices[i]);
	}
	dc.MoveTo(vertices[5]);
	for (int i = 3; i < 6; i++)
	{
		dc.LineTo(vertices[i]);
	}
	for (int i = 0; i < 3; i++)
	{
		dc.MoveTo(vertices[i]);
		dc.LineTo(vertices[i + 3]);
	}

	dc.SelectObject(pOldPen);
}

void CPyramid::getRect(CMatrix& Vert, CRectD& RectView)//прямоугольник
{
	CMatrix V = Vert.getRow(0);

	double xMin = V.getMin();
	double xMax = V.getMax();

	V = Vert.getRow(1);

	double yMin = V.getMin();
	double yMax = V.getMax();

	RectView.setRectD(xMin, yMax, xMax, yMin);
}
// Вычисляет координаты прямоугольника, охватывающего проекцию 
// пирамиды на плоскость XY в ВИДОВОЙ системе координат
// Vert - координаты вершин (в столбцах)
// RectView - проекция - охватывающий прямоугольник