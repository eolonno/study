#pragma once
#include "CRectD.h"
#include "CMyPen.h"
#include "CMatrix.h"

class CPlot2D
{
public:
	CMatrix m_X;       // Массив для хранения x координат
	CMatrix m_Y;       // Массив для хранения y координат
	CMatrix m_K;       // Матрица для пересчета координат из мировых в оконные
	CRect  m_Rw;       // Описание области в окне
	CRectD m_Rs;       // Описание области в пространстве
	CMyPen m_PenLine;  // Перо для рисования линий
	CMyPen m_PenAxis;  // Перо для рисования осей координат
public:
	CPlot2D() { m_K.RedimMatrix(3,3); }
	void SetParams(CMatrix & x, CMatrix & y, CRect & rw);
	void SetWindowRect(CRect & rw);
	void SetPenLine(CMyPen & pLine);
	void SetPenAxis(CMyPen & pAxis);
	void Draw(CDC & dc, bool isDrawRect = true, bool isDrawGraph = true);
	void Draw1(CDC & dc, bool isDrawRect = true, bool isDrawGraph = true);
	static void SetMyMode(CDC & dc, CRectD & rs, CRect & rw);
};