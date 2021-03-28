// ChildView.h : интерфейс класса CChildView

#pragma once

#include "CMatrix.h"
#include "Lib.h"
#include "Plot2D.h"

// окно CChildView

class CChildView : public CWnd
{
	// Создание
public:
	CChildView();

	// Атрибуты
public:
	CPlot2D plot1;
	CPlot2D plot2;
	CPlot2D plot3;
	CPlot2D plot4;
	int graphType;

	// Операции
public:

	// Переопределение
protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

	// Реализация
public:
	virtual ~CChildView();

	// Созданные функции схемы сообщений
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnPlotF1();
	afx_msg void OnPlotF2();
	afx_msg void OnPlotF3();
	afx_msg void OnPlotF4();
	afx_msg void OnPlotAll();
	afx_msg void OnAll();
	afx_msg void OnF1();
	afx_msg void OnF2();
	afx_msg void OnF3();
	afx_msg void OnF4();
};