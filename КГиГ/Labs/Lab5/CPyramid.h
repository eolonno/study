#pragma once

class CPyramid
{
private:
	CMatrix _vertices;

public:
	CPyramid();
	void getRect(CMatrix&, CRectD&);
	void drawXray(CDC&, CMatrix&, CRect&);
	void draw(CDC&, CMatrix&, CRect&);
};