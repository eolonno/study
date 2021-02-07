#pragma once

void DrawLine(CPaintDC &dc, int x1, int y1, int x2, int y2, COLORREF color);
void DrawRectangle(CPaintDC &dc, CRect rectangle, COLORREF color, bool drawDiagonals = false);
void DrawCircle(CPaintDC &dc, int xc, int yc, int radius, COLORREF color);
void FillCircle(CPaintDC &dc, int xc, int yc, int radius, COLORREF color);