#pragma once
#include "stdafx.h"
#include "GraphBitMap.h"
#include <fstream>

int counter = 0;

int ShowBitMap(HWND hWnd, HANDLE hBit, int x, int y)
{
	BITMAP BitMap;
	GetObjectW(hBit, sizeof(BITMAP), &BitMap);
	int Height = BitMap.bmHeight;
	int Width = BitMap.bmWidth;
	HDC hdc = GetDC(hWnd);
	HDC hdcMem = CreateCompatibleDC(hdc);
	HBITMAP OldBitmap = (HBITMAP)SelectObject(hdcMem, hBit);
	BitBlt(hdc, x, y, Width, Height, hdcMem, 0, 0, SRCCOPY);
	SelectObject(hdcMem, OldBitmap);
	ReleaseDC(hWnd, hdc);
	return 0;
}
int ClientToBmp(HWND hWnd, char *Name)
{
	RECT r;
	GetClientRect (hWnd, &r);
	return ClientRectToBmp (hWnd, Name, r);
}
int ClientRectToBmp(HWND hWnd, char* name, RECT r)
	{
		HANDLE fh = CreateFile (name, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN, NULL);
	if (fh == INVALID_HANDLE_VALUE) 
		return 2;
	BITMAPINFOHEADER bi;
		ZeroMemory (&bi, sizeof (BITMAPINFOHEADER));
	bi.biSize = sizeof (BITMAPINFOHEADER);
	bi.biWidth = r.right - r.left;
	bi.biHeight = r.bottom - r.top;
	bi.biPlanes = 1; 
	bi.biBitCount = 32;
	bi.biSizeImage = (bi.biWidth * bi.biBitCount + 31)/32*4*bi.biHeight;

	BITMAPFILEHEADER bmfHdr;
		ZeroMemory (&bmfHdr, sizeof (BITMAPFILEHEADER));
	bmfHdr.bfType = 0x4D42;
	bmfHdr.bfSize = bi.biSizeImage + sizeof (BITMAPFILEHEADER) + bi.biSize;
	bmfHdr.bfReserved1 = bmfHdr.bfReserved2 = 0;
	bmfHdr.bfOffBits = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)bi.biSize;

	HDC hDC = GetDC (hWnd);
	HDC hDCMem = CreateCompatibleDC (hDC);
	HBITMAP hBitmap = CreateCompatibleBitmap (hDC, bi.biWidth, bi.biHeight);
	HBITMAP oldBitmap = (HBITMAP)SelectObject (hDCMem, hBitmap);
	BitBlt (hDCMem, 0, 0, bi.biWidth, bi.biHeight, hDC, r.left, r.top, SRCCOPY);
	hBitmap = (HBITMAP)SelectObject (hDCMem, oldBitmap);

	HANDLE hDIB = GlobalAlloc (GHND /*GMEM_FIXED*/, bi.biSizeImage);
	char* lp = (char*)GlobalLock (hDIB);
	GetDIBits (hDC, hBitmap, 0, bi.biHeight, lp, (LPBITMAPINFO)&bi, DIB_RGB_COLORS);	// не используется?
	DWORD dwWritten = sizeof (BITMAPFILEHEADER);
		WriteFile(fh, (LPSTR)&bmfHdr, sizeof(BITMAPFILEHEADER), &dwWritten, NULL);
	dwWritten = sizeof (BITMAPINFOHEADER);
		WriteFile (fh, (LPSTR)&bi, sizeof (BITMAPINFOHEADER), &dwWritten, NULL);
	dwWritten = bi.biSizeImage;
		WriteFile (fh, lp, bi.biSizeImage, &dwWritten, NULL);

	GlobalUnlock(hDIB);    
	GlobalFree(hDIB);

	DeleteObject(hBitmap);
	lp = NULL;
	CloseHandle (fh);
	ReleaseDC (hWnd, hDCMem);
	ReleaseDC (hWnd, hDC);
	DeleteDC (hDCMem);
	DeleteDC (hDC);
	if (dwWritten == 2) return 2;
	counter++;
	return 0;
	}
void MyLine(CDC &dc, int x1, int y1, int x2, int y2, COLORREF color)
{
	int step = 1;

	if(y1 > y2)
	{
		int buf = x1;
		x1 = x2;
		x2 = buf;
		buf = y1;
		y1 = y2;
		y2 = buf;
	}
	
	if(x1 > x2)
		step = -1;

	int dx = abs(x2 - x1);
	int dy = y2 - y1;

	dc.SetPixel(x1,y1,color);
	if(dx > dy)
	{	
		int d = 2 * dy - dx;
		int d1 = 2 * dy;
		int d2 = 2 * (dy - dx);
		int y = y1;

		int x = x1;
		while( dx-- )
		{
			if(d<0)
				d+=d1;			
			else
			{
				y++;			
				d+=d2;			
			}
			dc.SetPixel(x,y, color);	
			
			x+=step;
		}
	}
	else
	{
		if(dx<0) dx*=-1;
		int d = 2 * dx - dy;
		int d1 = 2 * dx;
		int d2 = 2 * (dx - dy);		
		int x = x1;

		int y = y1;
		while( dy-- )		
		{
			if(d<0)
				d+=d1;			
			else
			{
				x+=step;
				d+=d2;			
			}
			dc.SetPixel(x,y, color);	
			y++;
		}
	}
}

void CirclePoints(CDC &dc, int x, int y, CPoint &p, COLORREF color)
{
	dc.SetPixel(p.x + x, p.y - y, color);
	dc.SetPixel(p.x + x, p.y + y, color);
	dc.SetPixel(p.x - x, p.y - y, color);
	dc.SetPixel(p.x - x, p.y + y, color);

	dc.SetPixel(p.x + y, p.y - x, color);
	dc.SetPixel(p.x + y, p.y + x, color);
	dc.SetPixel(p.x - y, p.y - x, color);
	dc.SetPixel(p.x - y, p.y + x, color);
}

void MyCircle(CDC &dc, CPoint p, int r, COLORREF color)
{
	double d = 5/4 - r;
	int p1 = 3, 
		q = p1 - 2 * r + 2;
	int x0 = 0, y0 = r;

	CirclePoints(dc, 0, r, p, color);
	while(x0 <= r/sqrt((double)2))
	{
		if(d < 0)
		{
			CirclePoints(dc, ++x0, y0, p, color);
			d = d + p1;
			p1 = p1 + 2;
			q = q + 2;			
		}
		else
		{
			CirclePoints(dc, ++x0, --y0, p, color);
			d = d + q;
			p1 = p1 + 2;
			q = q + 4;
		}
	}
}