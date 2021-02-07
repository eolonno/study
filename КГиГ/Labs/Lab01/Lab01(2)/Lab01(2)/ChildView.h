
// ChildView.h : интерфейс класса CChildView
//


#pragma once


// окно CChildView

class CChildView : public CWnd
{
// Создание
public:
	CChildView();

	vector<CMatrix> arr;
	CMatrix V = CMatrix(3);;
	ControllerCMatrix controller;
// Атрибуты
public:

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
	afx_msg void OnTestMatrix();
	afx_msg void OnTestFunctions();
};

