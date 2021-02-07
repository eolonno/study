#pragma once

class CChildView : public CWnd
{
	enum DrawStates : short
	{
		NULL_STATE, DRAW_BMP_STATE
	};

private:
	short m_Index;
	HBITMAP m_Bitmap;

public:
	CChildView();
	virtual ~CChildView();

private:
	void ShowBitMap(HWND hWnd, HBITMAP hBit, int x, int y);
	void ClientToBmp(HWND hWnd, CString name);

public:
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnFileOpen();
	afx_msg void OnFileSaveAs();
};

