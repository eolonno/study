
#include "afxwin.h"						// MFC Основные и стандартные компоненты
#include "afxext.h"						// MFC Расширения
#include "resource.h"					// Идентификаторы ресурсов
#define IDR_MENU1		101
#define IDC_MYEDIT		102	
#define IDC_MYEDIT1		103
#define IDC_MYEDIT2		104
#define IDC_MYEDIT3		105
#define IDC_MYLINE		106
#define IDC_MYRECTANGLE	107
#define IDC_MYCIRCLE	108
#define IDC_MYCLEAR		109

class CMyButton: public CButton 
{ 
public:
   afx_msg void OnLButtonDown(UINT, CPoint);
private:
   DECLARE_MESSAGE_MAP(); 
};

class CMyButton1: public CButton
{
	public:
		afx_msg void OnLButtonDown(UINT, CPoint);

	private:
		DECLARE_MESSAGE_MAP();
};

class CMyButton2: public CButton
{
	public:
		afx_msg void OnLButtonDown(UINT, CPoint);

	private:
		DECLARE_MESSAGE_MAP();
};

class CMyButton3: public CButton
{
	public:
		afx_msg void OnLButtonDown(UINT, CPoint);

	private:
		DECLARE_MESSAGE_MAP();
};

void MyLine(CDC &dc, int x1, int y1, int x2, int y2, COLORREF color)
{
	int dx=abs(x2-x1);
	int dy=abs(y2-y1);
	int incX=x2>=x1?1:-1;
	int incY=y2>=y1?1:-1;
	if(dy<=dx)
	{
		int d=2*dy-dx;
		int d1=2*dy;
		int d2=2*(dy-dx);
		dc.SetPixel(x1,y1,color);
		int x=x1;
		int y=y1;
		for(int i=1;i<=dx;i++)
		{
			x+=incX;	
			if(d<0)d+=d1;
			else
			{
				y+=incY;
				d+=d2;
			}
			dc.SetPixel(x,y,color);		
		}	
	}
else
	{
		int d=2*dx-dy;
		int d1=2*dx;
		int d2=2*(dx-dy);
		dc.SetPixel(x1,y1,color);
		int x=x1;
		int y=y1;
		for(int i=1;i<=dy;i++)
		{
			y+=incY;	
			if(d<0)d+=d1;
			else
			{
				x+=incX;
				d+=d2;
			}
			dc.SetPixel(x,y,color);		
		}	
	}
}

//void drawCircle(CDC &dc, int x0, int y0, int radius, COLORREF color)
//{
//        int x = 0;
//        int y = radius;
//        int delta = 2 - 2 * radius;
//        int error = 0;
//        while(y >= 0) {
//                dc.SetPixel(x0 + x, y0 + y, color);
//                dc.SetPixel(x0 + x, y0 - y, color);
//                dc.SetPixel(x0 - x, y0 + y, color);
//                dc.SetPixel(x0 - x, y0 - y, color);
//                error = 2 * (delta + y) - 1;
//                if(delta < 0 && error <= 0) {
//                        ++x;
//                        delta += 2 * x + 1;
//                        continue;
//                }
//                error = 2 * (delta - x) - 1;
//                if(delta > 0 && error > 0) {
//                        --y;
//                        delta += 1 - 2 * y;
//                        continue;
//                }
//                ++x;
//                delta += 2 * (x - y);
//                --y;
//        }
//}

void plot_circle(CDC &dc, int x, int y, int x_center, int  y_center, int color_code)
{
    dc.SetPixel(x_center+x,y_center+y,color_code);
    dc.SetPixel(x_center+x,y_center-y,color_code);
    dc.SetPixel(x_center-x,y_center+y,color_code);
    dc.SetPixel(x_center-x,y_center-y,color_code);
}
 
/* Вычерчивание окружности с использованием алгоритма Брезенхэма */
void drawCircle(CDC &dc, int x_center, int y_center, int radius, int color_code)
{
    int x,y,delta;
    x = 0;
    y = radius;
    delta=3-2*radius;
    while(x<y) {
        plot_circle(dc, x,y,x_center,y_center,color_code);
        plot_circle(dc, y,x,x_center,y_center,color_code);
        if (delta<0)
            delta+=4*x+6;
        else {
            delta+=4*(x-y)+10;
            y--;
        }
        x++;
    }
 
    if(x==y) plot_circle(dc, x,y,x_center,y_center,color_code);
}

BEGIN_MESSAGE_MAP(CMyButton, CButton)
	ON_WM_LBUTTONDOWN()
END_MESSAGE_MAP()

BEGIN_MESSAGE_MAP(CMyButton1, CButton)   
	ON_WM_LBUTTONDOWN()
END_MESSAGE_MAP()

BEGIN_MESSAGE_MAP(CMyButton2, CButton)   
	ON_WM_LBUTTONDOWN()
END_MESSAGE_MAP()

BEGIN_MESSAGE_MAP(CMyButton3, CButton)   
	ON_WM_LBUTTONDOWN()
END_MESSAGE_MAP()

class CMainWnd : public CFrameWnd
{
public:
	CMainWnd();						
	int OnCreate(LPCREATESTRUCT lpCreateStruct);        
	void MenuOpen();
	void MenuSave();
	void MenuExit();
	CEdit* MyEdit, *MyEdit1, *MyEdit2, *MyEdit3;
	~CMainWnd();		
	afx_msg void OnPaint();
	void setPath(CString s);
	CString getPath();
	BOOL ppaint;
private:    
	CMyButton* MyButton;
	CMyButton1* MyButton1;
	CMyButton2* MyButton2;
	CMyButton3* MyButton3;
	CMenu m_wndMenu;
	CString path;

	DECLARE_MESSAGE_MAP();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd) 
 ON_WM_PAINT()
 ON_WM_CREATE()					
 ON_COMMAND(ID_FILE_OPEN,MenuOpen)
 ON_COMMAND(ID_FILE_SAVE,MenuSave)
 ON_COMMAND(ID_FILE_EXIT,MenuExit)
END_MESSAGE_MAP()

void CMainWnd::setPath(CString s)
{
	path = s;
}

CString CMainWnd::getPath()
{
	return path;
}

void CMyButton::OnLButtonDown( UINT, CPoint )
{	
	CMainWnd* mw = (CMainWnd*)this->GetParent();
	
	CString buf, buf1, buf2, buf3;
	mw->MyEdit->GetWindowTextA(buf);
	mw->MyEdit1->GetWindowTextA(buf1);
	mw->MyEdit2->GetWindowTextA(buf2);
	mw->MyEdit3->GetWindowTextA(buf3);

	CClientDC dc(this);
	MyLine(dc, (90+atoi(buf)), (-130+atoi(buf1)), (90+atoi(buf2)), (-130+atoi(buf3)), (COLORREF)0);//d1
	Invalidate();
}

void CMyButton1::OnLButtonDown( UINT, CPoint )
{	
	CMainWnd* mw = (CMainWnd*)this->GetParent();
	
	CString buf, buf1, buf2, buf3;
	mw->MyEdit->GetWindowTextA(buf);
	mw->MyEdit1->GetWindowTextA(buf1);
	mw->MyEdit2->GetWindowTextA(buf2);
	mw->MyEdit3->GetWindowTextA(buf3);

	CClientDC dc(this);
	MyLine(dc, (90+atoi(buf)), (-160+atoi(buf1)), (90+atoi(buf2)), (-160+atoi(buf3)), (COLORREF)0);//d1
	MyLine(dc, (90+atoi(buf)), (-160+atoi(buf3)), (90+atoi(buf2)), (-160+atoi(buf1)), (COLORREF)0);//d2
	MyLine(dc, (90+atoi(buf)), (-160+atoi(buf1)), (90+atoi(buf2)), (-160+atoi(buf1)), (COLORREF)0);//a
	MyLine(dc, (90+atoi(buf2)), (-160+atoi(buf1)), (90+atoi(buf2)), (-160+atoi(buf3)), (COLORREF)0);//b
	MyLine(dc, (90+atoi(buf)), (-160+atoi(buf3)), (90+atoi(buf2)), (-160+atoi(buf3)), (COLORREF)0);//c
	MyLine(dc, (90+atoi(buf)), (-160+atoi(buf1)), (90+atoi(buf)), (-160+atoi(buf3)), (COLORREF)0);//d
	Invalidate();
}

void CMyButton2::OnLButtonDown( UINT, CPoint )
{	
	CMainWnd* mw = (CMainWnd*)this->GetParent();
	
	CString buf, buf1, buf2, buf3;
	mw->MyEdit->GetWindowTextA(buf);
	mw->MyEdit1->GetWindowTextA(buf1);
	mw->MyEdit2->GetWindowTextA(buf2);

	CClientDC dc(this);
	drawCircle(dc,90+atoi(buf), -190+atoi(buf1),atoi(buf2),RGB(0,0,0));
	Invalidate();
}

void CMyButton3::OnLButtonDown( UINT, CPoint )
{	
	CMainWnd* mw = (CMainWnd*)this->GetParent();
	mw->Invalidate();
}

void CMainWnd::OnPaint()
{
	CPaintDC dc(this);   // Получить контекст устройства
	dc.TextOut(0,10,"x:");
	dc.TextOut(0,40,"y:");
	dc.TextOut(0,70,"x1/r:");
	dc.TextOut(0,100,"y1:");
	HBITMAP hBmp = (HBITMAP)LoadImage(NULL, path, IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE), oldBmp;
	BITMAP bmp;

	GetObject(hBmp, sizeof(BITMAP), &bmp);
	
	int w = bmp.bmWidth, h = bmp.bmHeight;

 	HDC hdcMem = CreateCompatibleDC(dc);

	oldBmp = (HBITMAP)SelectObject(hdcMem, hBmp);

 	BitBlt(dc, 120, 0, w, h, hdcMem, 0, 0, SRCCOPY);

 	SelectObject(hdcMem, oldBmp);

	DeleteDC(hdcMem);
}

void CMainWnd::MenuOpen()  
{	
	CFileDialog fileDialog(TRUE, NULL, "*.bmp");

	int result = fileDialog.DoModal();
	if (result == IDOK)	
	{
		this->path = fileDialog.GetPathName();
		this->RedrawWindow(0, 0, 1);
	}
}

void CMainWnd::MenuSave()  
{
	CString buf, buf1, buf2, buf3;
	MyEdit->GetWindowTextA(buf);
	MyEdit1->GetWindowTextA(buf1);
	MyEdit2->GetWindowTextA(buf2);
	MyEdit3->GetWindowTextA(buf3);

	int w = atoi(buf2) - atoi(buf), h = atoi(buf3) - atoi(buf1), x = atoi(buf) + 120, y = atoi(buf1);

	CFileDialog FileDlg(FALSE, NULL, "*.bmp", 0, "All Files (*.*)|*.*||");

	if( FileDlg.DoModal() == IDOK )
	{
   BITMAPFILEHEADER    bmfHdr;
   BITMAPINFOHEADER bi;
   RECT r;
   int BitToPixel=16;		//Устанавливаем цветовую глубину 16 бит 
   GetClientRect(&r);	//Узнаем размер рабочей области
   CPaintDC hdc(this);
   //HDC hdc = GetDC(this);
   HDC hdcMem=CreateCompatibleDC(hdc); 
//Создалем битовую карту BitMap по размеру рабочей области окна
//Битовая карта создается на основе контекста устройства hdc, поэтому 
//она хранит изображение DDB-формата (а не DIB). Именно поэтому нельзя 
//использовать функцию WriteDIBC() 
   HBITMAP BitMap = CreateCompatibleBitmap(hdc, r.right,r.bottom);
   HBITMAP OldBitmap = (HBITMAP)SelectObject(hdcMem, BitMap);
   BitBlt(hdcMem, 0, 0, w, h, hdc, x, y, SRCCOPY);
   BitMap = (HBITMAP)SelectObject(hdcMem,OldBitmap);
   ZeroMemory(&bi,sizeof(BITMAPINFOHEADER));	//Это аналог функции 
// memset(), 	который заполняет заголовок нулями. 
    bi.biSize = sizeof(BITMAPINFOHEADER);
    bi.biWidth = w;
	bi.biHeight = h;
    bi.biPlanes = 1;
    bi.biBitCount = BitToPixel;    //в примерах  режим 16 бит тоже сохраняется,
 //как 24- это DIB, но 8 бит на пиксел работать не будут – не записаны после 
// заголовка элементы палитры
//Для вычисления размера изображения в байтах мы увеличиваем значение 
//г.right * BitToPixel/8 байт на строку до значения, кратного четырем. Это 
//вычисление может выполнить и функция GetDIBits() (см. MSDN). 
	bi.biSizeImage = (w * BitToPixel + 31)/32*4*h;
    DWORD dwWritten;     //Количество записанных файлов
//Открываем файл
	HANDLE fh = CreateFile(FileDlg.GetPathName(), GENERIC_WRITE, 0, NULL,
                                   CREATE_ALWAYS,  FILE_ATTRIBUTE_NORMAL |    
                                   FILE_FLAG_SEQUENTIAL_SCAN, NULL);
      bmfHdr.bfType = ('M'<<8)|'B';  //Заполняем дисковый заголовок
      bmfHdr.bfSize = bi.biSizeImage + sizeof(bmfHdr)+bi.biSize;  //Размер файла
      bmfHdr.bfReserved1 = bmfHdr.bfReserved2 = 0;
      bmfHdr.bfOffBits = sizeof(bmfHdr) + bi.biSize; // Смещение до начала данных
//Запись заголовка в файл
    WriteFile(fh, (LPSTR)&bmfHdr, sizeof(bmfHdr), &dwWritten, NULL);
// Запись в файл загружаемого заголовка  
	WriteFile(fh, (LPSTR)&bi, sizeof(BITMAPINFOHEADER), &dwWritten, NULL);
//Выделяем место в памяти для того,чтобы функция GetDIBits()перенесла 
//туда коды цвета в DIB-формате.
    char *lp=(char *) GlobalAlloc(GMEM_FIXED, bi.biSizeImage);
// Из карты BitMap строки с нулевой по bi.biHeight функция пересылает
// в массив lp по формату bi ( беспалитровый формат)	 
	int err=GetDIBits(hdc, BitMap,0,(UINT)h, lp,(LPBITMAPINFO)&bi, DIB_RGB_COLORS); 
//Запись изображения на диск				          
    WriteFile(fh, lp, bi.biSizeImage, &dwWritten, NULL);
//Освобождение памяти и закрытие файла
    GlobalFree(GlobalHandle(lp));
	CloseHandle(fh);
     DeleteDC(hdcMem);		

	}
}

void CMainWnd::MenuExit()  
{	
	DestroyWindow(); // Уничтожить окно   
}

int CMainWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
 {
  if (CFrameWnd::OnCreate(lpCreateStruct) == -1)  return -1;
  MyEdit = new CEdit();
 if (MyEdit!=NULL) MyEdit->Create(WS_CHILD|WS_VISIBLE|WS_BORDER,
     CRect(30,10,110,30),this,IDC_MYEDIT);
 MyEdit->SetWindowTextA("100");
   MyEdit1 = new CEdit();
 if (MyEdit1!=NULL) MyEdit1->Create(WS_CHILD|WS_VISIBLE|WS_BORDER,
     CRect(30,40,110,60),this,IDC_MYEDIT1);
  MyEdit1->SetWindowTextA("200");
    MyEdit2 = new CEdit();
 if (MyEdit2!=NULL) MyEdit2->Create(WS_CHILD|WS_VISIBLE|WS_BORDER,
     CRect(30,70,110,90),this,IDC_MYEDIT2);
  MyEdit2->SetWindowTextA("300");
     MyEdit3 = new CEdit();
 if (MyEdit3!=NULL) MyEdit3->Create(WS_CHILD|WS_VISIBLE|WS_BORDER,
     CRect(30,100,110,120),this,IDC_MYEDIT3);
  MyEdit3->SetWindowTextA("300");
   MyButton = new CMyButton();
 if (MyButton!=NULL) MyButton->Create("LINE",WS_CHILD|WS_VISIBLE|SS_CENTER,
      CRect(30,130,110,150),this,IDC_MYLINE); 
 MyButton1 = new CMyButton1();
 if (MyButton1!=NULL) MyButton1->Create("RECTANGLE",WS_CHILD|WS_VISIBLE|SS_CENTER,
      CRect(30,160,110,180),this,IDC_MYRECTANGLE); 
  MyButton2 = new CMyButton2(); 
 if (MyButton2!=NULL) MyButton2->Create("CIRCLE",WS_CHILD|WS_VISIBLE|SS_CENTER,
      CRect(30,190,110,210),this,IDC_MYCIRCLE); 
   MyButton3 = new CMyButton3(); 
 if (MyButton3!=NULL) MyButton3->Create("CLEAR",WS_CHILD|WS_VISIBLE|SS_CENTER,
      CRect(30,220,110,240),this,IDC_MYCLEAR); 
  m_wndMenu.LoadMenu(IDR_MENU1);
  SetMenu(&m_wndMenu);
  ppaint = false;
  return 0;
}

CMainWnd::CMainWnd()
{
 Create(NULL,"lab4",WS_OVERLAPPEDWINDOW,rectDefault,NULL,NULL);	
}

CMainWnd::~CMainWnd()
{
if (MyButton!=NULL)delete MyButton;	
if (MyButton1!=NULL)delete MyButton1;
if (MyButton2!=NULL)delete MyButton2;	
if (MyEdit!=NULL)delete MyEdit;
if (MyEdit1!=NULL)delete MyEdit1;
if (MyEdit2!=NULL)delete MyEdit2;
if (MyEdit3!=NULL)delete MyEdit3;
}


class CMyApp : public CWinApp
{

public:
	CMyApp();				
	virtual BOOL InitInstance();	

};

CMyApp::CMyApp()
{}

BOOL CMyApp::InitInstance()		
{ 
	m_pMainWnd=new CMainWnd();	
	ASSERT(m_pMainWnd);		
	m_pMainWnd->ShowWindow(SW_SHOW);
	m_pMainWnd->UpdateWindow();	
	return TRUE;				
};

CMyApp theApp;	

