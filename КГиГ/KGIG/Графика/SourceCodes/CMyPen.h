#pragma once

class CMyPen
{
private:
	int m_Style;      // Стиль пера
	int m_Width;      // Толщина пера
	COLORREF m_Color; // Цвет пера

public:
	CMyPen();
	CMyPen(CMyPen & pen);
	CMyPen(int style, int width, COLORREF color);

	void SetStyle(int style) { m_Style = style; }
	void SetWidth(int width) { m_Width = width; }
	void SetColor(COLORREF color) { m_Color = color; }
	void SetParams(int style, int width, COLORREF color);

	int GetStyle() const { return m_Style; }
	int GetWidth() const { return m_Width; }
	COLORREF GetColor() const { return m_Color; }
};