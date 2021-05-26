#include "stdafx.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "CPyramid.h"
#include "Lab2.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CChildView

CChildView::CChildView()
{
	Mode = 0;
	Viewport.resize(3);
}

CChildView::~CChildView()
{
}

BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(ID_PYRAMID_DRAW, &CChildView::OnPyramidDrawxray)
	ON_COMMAND(ID_PYRAMID_DRAWXRAY, &CChildView::OnPyramidDraw)
	ON_WM_KEYDOWN()
	ON_WM_SIZE()
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

void CChildView::OnPaint()
{
	CPaintDC dc(this);

	if (Mode == 1)//Позрачная
	{
		Pyramid.draw(dc, Viewport, RectWindow);
	}
	if (Mode == 2)//Непрозрачная
	{
		Pyramid.drawXray(dc, Viewport, RectWindow);
	}
}

void CChildView::OnPyramidDraw()
{
	Viewport(0) = 10;//расстояние до камеры
	Viewport(1) = 315;// угл до линии обзора камеры по Х
	Viewport(2) = 45;// угл до линии обзора до камеры по У

	Mode = 1;//режим рисунка
	Invalidate();
}

void CChildView::OnPyramidDrawxray()
{
	Viewport(0) = 10;//расстояние до камеры
	Viewport(1) = 315;// угл до линии обзора камеры по Х
	Viewport(2) = 45;// угл до линии обзора до камеры по У

	Mode = 2;//режим рисунка
	Invalidate();
}

void CChildView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)//Движение фигуры в пространстве через стрелочки
{
	if ((Mode == 1) || (Mode == 2))
	{
		switch (nChar)
		{
			double d;

		case VK_UP://стрелка вверх
			d = Viewport(2) - 5;
			if (d >= 0)
			{
				Viewport(2) = d;
			}
			break;

		case VK_DOWN://стрелка вниз
			d = Viewport(2) + 5;
			if (d <= 180)
			{
				Viewport(2) = d;
			}
			break;

		case VK_LEFT://стрелка влево
			d = Viewport(1) - 5;
			if (d >= -180)
			{
				Viewport(1) = d;
			}
			else
			{
				Viewport(1) = d + 360;
			}
			break;

		case VK_RIGHT://стрелка вправо
			d = Viewport(1) + 5;
			if (d <= 180)
			{
				Viewport(1) = d;
			}
			else
			{
				Viewport(1) = d - 360;
			}
			break;
		}
		Invalidate();
	}
	CWnd::OnKeyDown(nChar, nRepCnt, nFlags);
}

void CChildView::OnSize(UINT nType, int cx, int cy)// изменяет фигуру при изменении размеров окна
{
	CWnd::OnSize(nType, cx, cy);
	RectWindow.SetRect(100, 100, cx - 100, cy - 50);
}