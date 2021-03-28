// ChildView.cpp : реализация класса CChildView

#include "stdafx.h"
#include "Lab2.h"
#include "ChildView.h"
#include "CMatrix.h"
#include "Lib.h"
#include "Plot2D.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define PI 3.14159

// CChildView

CChildView::CChildView()
{
	graphType = 0;
}

CChildView::~CChildView()
{
}

BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(ID_PLOT_F1, &CChildView::OnPlotF1)
	ON_COMMAND(ID_PLOT_F2, &CChildView::OnPlotF2)
	ON_COMMAND(ID_PLOT_F3, &CChildView::OnPlotF3)
	ON_COMMAND(ID_PLOT_F4, &CChildView::OnPlotF4)
	ON_COMMAND(ID_PLOT_ALL, &CChildView::OnPlotAll)
	ON_COMMAND(ID_ALL, &CChildView::OnAll)
	ON_COMMAND(ID_F1, &CChildView::OnF1)
	ON_COMMAND(ID_F2, &CChildView::OnF2)
	ON_COMMAND(ID_F3, &CChildView::OnF3)
	ON_COMMAND(ID_F4, &CChildView::OnF4)
END_MESSAGE_MAP()

// обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs)
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS,
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW + 1), NULL);

	return TRUE;
}

void CChildView::OnPaint()//при рисовании будет использовать следующие параметры
{
	CPaintDC dc(this); // контекст устройства для рисования

	if (graphType == 1)
	{
		plot1.plot(dc, 1, 1);//начинаем рисовать
		int buffer = setMode(dc, CRect(1, 1, 2, 2), CRectD(1, 10, 5, 10));
		dc.SetMapMode(buffer);//Определяет новый режим отображение
	}
	if (graphType == 2)
	{
		plot2.plot(dc, 1, 1);
		int buffer = setMode(dc, CRect(1, 1, 2, 2), CRectD(1, 10, 5, 10));
		dc.SetMapMode(buffer);
	}
	if (graphType == 3)
	{
		plot3.plot(dc, 1, 1);
		int buffer = setMode(dc, CRect(1, 1, 2, 2), CRectD(1, 10, 5, 10));
		dc.SetMapMode(buffer);
	}
	if (graphType == 4)
	{
		plot4.plot(dc, 1, 1);
		int buffer = setMode(dc, CRect(1, 1, 2, 2), CRectD(1, 10, 5, 10));
		dc.SetMapMode(buffer);
	}

	if (graphType == 5)
	{
		plot1.plot(dc, 1, 1);
		plot2.plot(dc, 1, 1);
		plot3.plot(dc, 1, 1);
		plot4.plot(dc, 1, 1);
	}

	// TODO: Добавьте код обработки сообщений

	// Не вызывайте CWnd::OnPaint() для сообщений рисования
}

void CChildView::OnPlotF1()
{
	CPlotPen pen; //создаем перо для графика
	pen.set(//задаем его параметры
		PS_SOLID,//стиль - сплошное
		2, // размер - 2 px
		RGB(255, 0, 0)); //цвет - красный
	CPlotPen penLine; //линия пера для осей
	penLine.set(PS_SOLID, 1, RGB(0, 0, 255));//синий
	plot1.setPenLine(pen); // задает перо для графика
	plot1.setPenAxis(penLine); //задает перо для осей

	CRect Rect(400, 100, 800, 500);//параметры прямоугольника

	CMatrix arguments(217);//
	int i = 0;
	for (double x = -3 * PI; x <= 3 * PI; x += PI / 36.0)
	{
		arguments(i) = x;
		i++;
	}

	CMatrix values(217);
	i = 0;
	for (double x = -3 * PI; x <= 3 * PI; x += PI / 36.0)
	{
		values(i) = sin(x)/x;
		i++;
	}

	plot1.setParams(arguments, values, Rect);
	graphType = 1;
	Invalidate();
}


void CChildView::OnPlotF2()
{
	CPlotPen pen;
	pen.set(PS_SOLID, 3, RGB(0, 255, 0));//зеленый
	CPlotPen penLine;
	penLine.set(PS_SOLID, 2, RGB(0, 0, 255));//синий
	plot2.setPenLine(pen);
	plot2.setPenAxis(penLine);

	CRect Rect(400, 100, 800, 500);

	CMatrix arguments(41);
	int i = 0;
	for (double x = -5; x <= 5; x += 0.25)
	{
		arguments(i) = x;
		i++;
	}

	CMatrix values(41);
	i = 0;
	for (double x = -5; x <= 5; x += 0.25)
	{
		values(i) = x * x * x;
		i++;
	}

	plot2.setParams(arguments, values, Rect);
	graphType = 2;
	Invalidate();
}


void CChildView::OnPlotF3()
{
	CPlotPen pen;
	pen.set(PS_DASHDOT, 1, RGB(255, 0, 0));//штрихпунтирная линия, красная
	CPlotPen penLine;
	penLine.set(PS_SOLID, 1, RGB(0, 0, 0));
	plot3.setPenLine(pen);
	plot3.setPenAxis(penLine);

	CRect Rect(400, 100, 800, 500);

	CMatrix arguments(217);
	int i = 0;
	for (double x = 0; x <= 6 * PI; x += PI / 36)
	{
		arguments(i) = x;
		i++;
	}

	CMatrix values(217);
	i = 0;
	for (double x = 0; x <= 6 * PI; x += PI / 36)
	{
		values(i) = sqrt(x) * sin(x);
		i++;
	}

	plot3.setParams(arguments, values, Rect);
	graphType = 3;
	Invalidate();
}


void CChildView::OnPlotF4()
{
	CPlotPen pen;
	pen.set(PS_SOLID, 2, RGB(255, 0, 0));
	CPlotPen penLine;
	penLine.set(PS_SOLID, 2, RGB(0, 0, 255));
	plot4.setPenLine(pen);
	plot4.setPenAxis(penLine);

	CRect Rect(400, 100, 800, 500);

	CMatrix arguments(81); //выбираем аргумент
	int i = 0;
	for (double x = -10; x <= 10; x += 0.25)
	{
		arguments(i) = x;
		i++;
	}

	CMatrix values(81);//выбираем значение функции
	i = 0;
	for (double x = -10; x <= 10; x += 0.25)
	{
		values(i) = x * x;//y = x^2
		i++;
	}

	plot4.setParams(arguments, values, Rect);

	graphType = 4;
	Invalidate();
}


void CChildView::OnPlotAll()
{
	CPlotPen pen1;
	CPlotPen pen2;
	CPlotPen pen3;
	CPlotPen pen4;
	//параметры пера осей
	pen1.set(PS_SOLID, 1, RGB(0, 0, 255));//сплошной синий
	pen2.set(PS_SOLID, 1, RGB(0, 0, 255));
	pen2.set(PS_SOLID, 1, RGB(0, 0, 255));
	pen4.set(PS_SOLID, 2, RGB(0, 0, 255));//синий

	CPlotPen penLine1;
	CPlotPen penLine2;
	CPlotPen penLine3;
	CPlotPen penLine4;
	//параметры пера функции
	penLine1.set(PS_SOLID, 2, RGB(255, 0, 0));
	plot1.setPenLine(penLine1);
	penLine2.set(PS_SOLID, 3, RGB(0, 255, 0));
	plot2.setPenLine(penLine2);
	penLine3.set(PS_DASHDOT, 1, RGB(255, 0, 0));
	plot3.setPenLine(penLine3);
	penLine4.set(PS_SOLID, 3, RGB(255, 0, 0));
	plot4.setPenLine(penLine4);

	plot1.setPenAxis(pen1);
	plot2.setPenAxis(pen2);
	plot3.setPenAxis(pen3);
	plot4.setPenAxis(pen4);

	CMatrix arguments1(217);
	int i = 0;
	for (double x = -3 * PI; x <= 3 * PI; x += PI / 36)
	{
		arguments1(i) = x;
		i++;
	}

	CMatrix values1(217);
	i = 0;
	for (double x = -3 * PI; x <= 3 * PI; x += PI / 36)
	{
		values1(i) = sin(x)/x;
		i++;
	}

	CMatrix arguments2(41);
	i = 0;
	for (double x = -5; x <= 5; x += 0.25)
	{
		arguments2(i) = x;
		i++;
	}

	CMatrix values2(41);
	i = 0;
	for (double x = -5; x <= 5; x += 0.25)
	{
		values2(i) = x * x * x;
		i++;
	}

	CMatrix arguments3(217);
	i = 0;
	for (double x = 0; x <= 6 * PI; x += PI / 36)
	{
		arguments3(i) = x;
		i++;
	}

	CMatrix values3(217);
	i = 0;
	for (double x = 0; x <= 6 * PI; x += PI / 36)
	{
		values3(i) = sqrt(x) * sin(x);
		i++;
	}

	CMatrix arguments4(81);
	i = 0;
	for (double x = -10; x <= 10; x += 0.25)
	{
		arguments4(i) = x;
		i++;
	}

	CMatrix values4(81);
	i = 0;
	for (double x = -10; x <= 10; x += 0.25)
	{
		values4(i) = x * x;
		i++;
	}

	CRect Rect(250, 50, 550, 300);
	plot1.setParams(arguments1, values1, Rect);
	Rect.SetRect(250, 350, 550, 600);
	plot2.setParams(arguments2, values2, Rect);
	Rect.SetRect(650, 50, 960, 300);
	plot3.setParams(arguments3, values3, Rect);
	Rect.SetRect(650, 350, 960, 600);
	plot4.setParams(arguments4, values4, Rect);
	Rect.SetRect(50, 50, 960, 600);
	graphType = 5;
	Invalidate();
}

void CChildView::OnAll()
{
	OnPlotAll();
}

void CChildView::OnF1()
{
	OnPlotF1();
}

void CChildView::OnF2()
{
	OnPlotF2();
}

void CChildView::OnF3()
{
	OnPlotF3();
}

void CChildView::OnF4()
{
	OnPlotF4();
}