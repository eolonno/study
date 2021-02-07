
#include "LibGraph.h"
#include <string>
#define ID_M 2002
#define ID_F 2004

class CMyMainWnd : public CFrameWnd
{
public:
	CMyMainWnd()
	{
		Create(NULL, L"Laba 1 \"CMatrix\"");
		
	}
	CMenu *menu;
	afx_msg int OnCreate(LPCREATESTRUCT);
	void Matrix();
	void Functions();
	DECLARE_MESSAGE_MAP(); //”казать классу, что он реагирует на событи€
};
class CMyApp : public CWinApp
{
public:
	CMyApp(){};
	virtual BOOL InitInstance()
	{
		m_pMainWnd = new CMyMainWnd();
		m_pMainWnd->ShowWindow(SW_SHOW);
		
		return TRUE;
	}
};
BEGIN_MESSAGE_MAP(CMyMainWnd, CFrameWnd)//таблица откликов на событи€
	ON_WM_CREATE()
	ON_COMMAND(ID_M, Matrix)
	ON_COMMAND(ID_F, Functions)
END_MESSAGE_MAP()

afx_msg int CMyMainWnd::OnCreate(LPCREATESTRUCT)//процедуры, соответствующие таблице, в классе, реагирующем на событи€
{
	menu = new CMenu();
	menu->CreateMenu();
	CMenu *subMenu = new CMenu();
	subMenu->CreatePopupMenu();
	subMenu->AppendMenu(MF_STRING, ID_M, _T("Matrix"));
	subMenu->AppendMenu(MF_STRING, ID_F, _T("Functions"));
	this->menu->AppendMenu(MF_POPUP | MF_STRING, (UINT)subMenu->m_hMenu, _T("Tests"));
	SetMenu(menu);
	return 0;
}

void CMyMainWnd::Matrix()
{
	InvalidateRect(0);
	UpdateWindow();
	CClientDC dc(this);
	CChildView M;
	int y_out = 20;
	int x_out = 700;
	dc.TextOut(x_out, y_out + 32, "A = ");
	PrintMatrix(dc, x_out+40, y_out, *M.A);
	dc.TextOut(x_out, (y_out+=120) + 32, "B = ");
	PrintMatrix(dc, x_out + 40, y_out, *M.B);
	dc.TextOut(x_out, (y_out += 120) + 32, "V1 = ");
	PrintMatrix(dc, x_out + 40, y_out, *M.V1);
	dc.TextOut(x_out, (y_out += 120) + 32, "V2 = ");
	PrintMatrix(dc, x_out + 40, y_out, *M.V2);
	/* C1=A+B */
	y_out = 20;
	x_out = 10;
	dc.TextOut(x_out , y_out -15, "C1=A+B");
	PrintMatrix(dc, x_out, y_out, *M.A);
	dc.TextOut(x_out += 185, y_out + 32, "+");
	PrintMatrix(dc, x_out += 35, y_out, *M.B);
	dc.TextOut(x_out += 185, y_out + 32, "=");
	CMatrix C1 = *M.A + *M.B;
	PrintMatrix(dc, x_out += 35, y_out, C1);
	/* C2=A*B */
	x_out = 10;
	y_out += 120;
	dc.TextOut(x_out, y_out - 15, "C2=A*B");
	PrintMatrix(dc, x_out, y_out, *M.A);
	dc.TextOut(x_out += 185, y_out + 32, "x");
	PrintMatrix(dc, x_out += 35, y_out, *M.B);
	dc.TextOut(x_out += 185, y_out + 32, "=");
	CMatrix C2 = *M.A * *M.B;
	PrintMatrix(dc, x_out += 35, y_out, C2);
	/* D=A*V1 */
	x_out = 10;
	y_out += 120;
	dc.TextOut(x_out, y_out - 15, "D=A*V1");
	PrintMatrix(dc, x_out, y_out, *M.A);
	dc.TextOut(x_out += 185, y_out + 32, "x");
	PrintMatrix(dc, x_out += 35, y_out, *M.V1);
	dc.TextOut(x_out += 70, y_out + 32, "=");
	CMatrix D = (*M.A)*(*M.V1);
	PrintMatrix(dc, x_out += 35, y_out, D);
	CMatrix q, p;
	/* q=v1t*v2 */
	x_out = 10;

	y_out += 120;
	dc.TextOut(x_out, y_out - 15, "q=V1(T) *V2");
	PrintMatrix(dc, x_out, y_out+32, (*M.V1).Transp());
	dc.TextOut(x_out += 185, y_out+32, "x");
	PrintMatrix(dc, x_out += 35, y_out, *M.V2);
	dc.TextOut(x_out += 70, y_out+32, "=");
	q = (*M.V1).Transp()*(*M.V2);
	PrintMatrix(dc, x_out += 35, y_out+32, q);
	/* p=v1t*A*v2 */
	x_out = 10;
	y_out += 120;
	dc.TextOut(x_out, y_out - 15, "p=V1(T) *A*V2");
	PrintMatrix(dc, x_out, y_out + 32, (*M.V1).Transp());
	dc.TextOut(x_out += 185, y_out + 32, "x");
	PrintMatrix(dc, x_out+=35, y_out, *M.A);
	dc.TextOut(x_out += 185, y_out + 32, "x");
	PrintMatrix(dc, x_out += 35, y_out, *M.V2);
	dc.TextOut(x_out += 70, y_out + 32, "=");
	p = (*M.V1).Transp()*(*M.A)*(*M.V2);
	PrintMatrix(dc, x_out += 35, y_out + 32, p);

}
void CMyMainWnd::Functions()
{
	char t[10];
	InvalidateRect(0);
	UpdateWindow();
	CClientDC dc(this);
	CChildView M;
	int y_out = 20;
	int x_out = 700;
	dc.TextOut(x_out, (y_out += 120) + 32, "V1 = ");
	PrintMatrix(dc, x_out + 40, y_out, *M.V1);
	dc.TextOut(x_out, (y_out += 120) + 32, "V2 = ");
	PrintMatrix(dc, x_out + 40, y_out, *M.V2);
	y_out = 20;
	x_out = 10;
	dc.TextOut(x_out, y_out - 15, "VectorMult");
	CMatrix Mult = VectorMult(*M.V1, *M.V2);
	PrintMatrix(dc, x_out, y_out, Mult);
	dc.TextOut(x_out, (y_out+=120) - 15, "ScalarMult");
	sprintf_s(t,"%3.2f",ScalarMult(*M.V1, *M.V2));
	dc.TextOut(x_out, y_out, t);
	dc.TextOut(x_out, (y_out +=65) - 15, "ModVec V1");
	dc.TextOut(x_out+100, (y_out) - 15, "ModVec V2");
	sprintf_s(t, "%f", ModVec(*M.V1));
	dc.TextOut(x_out, y_out, t);
	sprintf_s(t, "%f", ModVec(*M.V2));
	dc.TextOut(x_out+100, y_out, t);
	dc.TextOut(x_out, (y_out += 65) - 15, "CosV1V2");
	sprintf_s(t, "%f", CosV1V2(*M.V1,*M.V2));
	dc.TextOut(x_out, y_out, t);
	dc.TextOut(x_out, (y_out += 65) - 15, "Sphere");
	dc.TextOut(x_out+185, y_out - 15, "Cart");
	dc.TextOut(x_out + 100, y_out - 15, "->");
	CMatrix s(3);
	PrintMatrix(dc, x_out, y_out, s);
	PrintMatrix(dc, x_out+185, y_out, SphereToCart(s));
	dc.TextOut(x_out + 100, y_out+32, "->");
}
CMyApp theApp;