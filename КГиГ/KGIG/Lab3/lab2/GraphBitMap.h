#include <Windows.h>

	int ShowBitMap(HWND hWnd, HANDLE hBit, int x, int y);
	int ClientToBmp(HWND hWnd, char *Name);
	int ClientRectToBmp(HWND hwnd, char* name, RECT r);
	void MyLine(CDC &dc, int x1, int y1, int x2, int y2, COLORREF color);
	void CirclePoints(CDC &dc, int x, int y, CPoint &p, COLORREF color);
	void MyCircle(CDC &dc, CPoint p, int r, COLORREF color);
