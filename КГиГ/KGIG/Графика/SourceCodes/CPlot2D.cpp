#include "stdafx.h"
#include "CPlot2D.h"

void CPlot2D::SetParams(CMatrix & xMatr, CMatrix & yMatr, CRect & rw)
{
	int nRowsX = xMatr.rows();
	int nRowsY = yMatr.rows();

	if (nRowsX != nRowsY) 
	{
		throw _T("CPlot2D::SetParams(CMatrix&, CMatrix&, CRect&): xMatr.rows() != yMatr.rows()");
	}

	m_X.RedimMatrix(nRowsX); m_X = xMatr;
	m_Y.RedimMatrix(nRowsY); m_Y = yMatr;

	m_Rs.SetRect(xMatr.MinElement(), yMatr.MaxElement(), xMatr.MaxElement(), yMatr.MinElement());
	m_Rw.SetRect(rw.left, rw.top, rw.right, rw.bottom); 

	m_K = ::SpaceToWindow(m_Rs, m_Rw);
}

void CPlot2D::SetWindowRect(CRect & rw)
{
	m_Rw.SetRect(rw.left, rw.top, rw.right, rw.bottom);
	m_K = ::SpaceToWindow(m_Rs, m_Rw);
}

void CPlot2D::SetPenLine(CMyPen & pLine)
{
	m_PenLine.SetParams(pLine.GetStyle(), pLine.GetWidth(), pLine.GetColor()); 
}

void CPlot2D::SetPenAxis(CMyPen & pAxis)
{
	m_PenAxis.SetParams(pAxis.GetStyle(), pAxis.GetWidth(), pAxis.GetColor());
}

void CPlot2D::Draw(CDC & dc, bool isDrawRect, bool isDrawGraph)
{
	CMatrix v(3); 
	CMatrix w(3); 
	v(2) = 1;

	if (isDrawRect)
	{
		dc.MoveTo(m_Rw.left, m_Rw.top);
		dc.LineTo(m_Rw.right, m_Rw.top);
		dc.LineTo(m_Rw.right, m_Rw.bottom);
		dc.LineTo(m_Rw.left, m_Rw.bottom);
		dc.LineTo(m_Rw.left, m_Rw.top);
	} 
	if (isDrawGraph)
	{	
		CPen AxisPen(m_PenAxis.GetStyle(), m_PenAxis.GetWidth(), m_PenAxis.GetColor());
		CPen LinePen(m_PenLine.GetStyle(), m_PenLine.GetWidth(), m_PenLine.GetColor());

		CPen *oldPen =                 // Сохраняем старую кисть
			dc.SelectObject(&AxisPen); // Устанавливаем кисть для рисования осей

		if (m_Rs.GetLeft() * m_Rs.GetRight() < 0)
		{
			v(0) = 0;
			v(1) = m_Rs.GetTop();
			w = m_K * v;

			dc.MoveTo((int)w(0), (int)w(1));

			v(0) = 0;
			v(1) = m_Rs.GetBottom();
			w = m_K * v;

			dc.LineTo((int)w(0), (int)w(1));
		}
		if (m_Rs.GetBottom() * m_Rs.GetTop() < 0)
		{
			v(0) = m_Rs.GetLeft();
			v(1) = 0;
			w = m_K * v;

			dc.MoveTo((int)w(0), (int)w(1));

			v(0) = m_Rs.GetRight();
			v(1) = 0;
			w = m_K * v;

			dc.LineTo((int)w(0), (int)w(1));
		}

		dc.SelectObject(&LinePen);

		v(0) = m_X(0); 
		v(1) = m_Y(0); 
		w = m_K * v;

		dc.MoveTo((int)w(0), (int)w(1));

		for (int i = 1; i < m_X.rows(); ++i)
		{
			v(0) = m_X(i);
			v(1) = m_Y(i);
			w = m_K * v;

			dc.LineTo((int)w(0), (int)w(1));
		}

		dc.SelectObject(oldPen); // Восстанавливаем старую кисть
	}
}

void CPlot2D::Draw1(CDC & dc, bool isDrawRect, bool isDrawGraph)
{
	if (isDrawRect)
	{
		//dc.Rectangle(m_Rw);
	} 
	if (isDrawGraph)
	{	
		//SetMyMode(dc, m_Rs, m_Rw);

		CPen AxisPen(m_PenAxis.GetStyle(), m_PenAxis.GetWidth(), m_PenAxis.GetColor());
		CPen LinePen(m_PenLine.GetStyle(), m_PenLine.GetWidth(), m_PenLine.GetColor());

		CPen *oldPen =                 // Сохраняем старую кисть
			dc.SelectObject(&AxisPen); // Устанавливаем кисть для рисования осей

		if (m_Rs.GetLeft() * m_Rs.GetRight() < 0)
		{
			dc.MoveTo(0, (int)m_Rs.GetTop());
			dc.LineTo(0, (int)m_Rs.GetBottom());
		}
		if (m_Rs.GetTop() * m_Rs.GetBottom() < 0)
		{
			dc.MoveTo(0, (int)m_Rs.GetLeft());
			dc.LineTo(0, (int)m_Rs.GetRight());
		}

		dc.SelectObject(&LinePen);

		dc.MoveTo((int)m_X(0), (int)m_Y(0));

		for (int i = 1; i < m_X.rows(); ++i)
		{
			dc.LineTo((int)m_X(i), (int)m_Y(i));
		}

		dc.SelectObject(oldPen); // Восстанавливаем старую кисть
	}
}

void CPlot2D::SetMyMode(CDC & dc, CRectD & rSpace, CRect & rWindow)
{
	int dsx = (int)rSpace.GetWidth(),
		dsy = (int)rSpace.GetHeight(),
		xsl = (int)rSpace.GetLeft(),
		ysl = (int)rSpace.GetBottom(),
		dwx = (int)rWindow.Width(),
		dwy = (int)rWindow.Height(),
		xwl = (int)rWindow.left,
		ywl = (int)rWindow.bottom;
	 
	dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt(dsx, dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg(xsl, ysl);
	dc.SetViewportOrg(xwl, ywl);
}