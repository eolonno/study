
// ChildView.cpp : реализация класса CChildView
//

#include "stdafx.h"
#include "Lab01(2).h"
#include "ChildView.h"


#ifdef _DEBUG
//#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{
	CMatrix A(3, 3), B(3,3), V1(3), V2(3);
	controller.InitMatrix(A); controller.InitMatrix(B);
	controller.InitMatrix(V1); controller.InitMatrix(V2);
	arr.push_back(A); arr.push_back(B); arr.push_back(V1); 
	arr.push_back(V2);

	
	controller.InitMatrix(V);
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(ID_TEST_MATRIX, &CChildView::OnTestMatrix)
	ON_COMMAND(ID_TEST_FUNCTIONS, &CChildView::OnTestFunctions)
END_MESSAGE_MAP()



// обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // контекст устройства для рисования
	
	// TODO: Добавьте код обработки сообщений

	// Не вызывайте CWnd::OnPaint() для сообщений рисования
}



void CChildView::OnTestMatrix()
{
	// TODO: добавьте свой код обработчика команд
	CClientDC dc(this);
	CPen MyPen(PS_DASHDOT, 1, RGB(133, 255, 100));
	dc.TextOut(10,5,_T("Исходные матрицы"));
	controller.PrintMatrix(dc, 10, 20, arr[0]);
	controller.PrintMatrix(dc, 10, 200, arr[1]);
	dc.TextOut(250, 5, _T("Исходные вектора"));
	controller.PrintMatrix(dc, 250, 20, arr[2]);
	controller.PrintMatrix(dc, 300, 20, arr[3]);

	dc.TextOut(500, 5, _T("Результаты"));
	CMatrix C1 = arr[0] + arr[1];
	dc.TextOut(500, 20, _T("C1 = A + B"));
	controller.PrintMatrix(dc,500,40,C1);

	CMatrix C2 = arr[0] * arr[1];
	dc.TextOut(700, 20, _T("C2 = A * B"));
	controller.PrintMatrix(dc, 700, 40, C2);

	CMatrix D = arr[0] * arr[2];
	dc.TextOut(900, 20, _T("D = A * V1"));
	controller.PrintMatrix(dc, 900, 40, D);

	CMatrix q = arr[2].Transp() * arr[3];
	dc.TextOut(500, 200, _T("q = V1^T * V2"));
	controller.PrintMatrix(dc, 500, 250, q);

	CMatrix p = arr[2].Transp() * arr[0] * arr[3];
	dc.TextOut(700, 200, _T("p = V1^T * A * V2"));
	controller.PrintMatrix(dc, 700, 250, p);

	CMatrix I(3), K(3);
	CMatrix F = I * K;
	dc.TextOut(700, 200, _T("I * K"));
	controller.PrintMatrix(dc, 700, 400, F);
}


void CChildView::OnTestFunctions()
{
	// TODO: добавьте свой код обработчика команд
	CClientDC dc(this);
	InvalidateRect(0);
	UpdateWindow();
	dc.TextOut(10, 10, _T("Исходные вектора"));
	controller.PrintMatrix(dc, 10, 30, arr[2]);
	controller.PrintMatrix(dc, 50, 30, arr[3]);

	dc.TextOut(150, 10, _T("Векторное произведение:"));
	auto vec = controller.VectorMult(arr[2], arr[3]);
	controller.PrintMatrix(dc, 150, 30,vec);

	dc.TextOut(350, 10, _T("Скалярное произведение:"));
	auto stringScal = controller.DoubleToString(controller.ScalarMult(arr[2], arr[3]));
	dc.TextOut(350, 30, stringScal);

	dc.TextOut(550, 10, _T("Модуль вектора V1:"));
	auto stringMod = controller.DoubleToString(controller.ModVec(arr[2]));
	dc.TextOut(550, 30, stringMod);

	dc.TextOut(700, 10, _T("Косинус между V1 и V2:"));
	auto stringCos = controller.DoubleToString(controller.CosV1V2(arr[2], arr[3]));
	dc.TextOut(700, 30, stringCos);

	dc.TextOut(350, 50, _T("Преобразует сферические координаты PView  точки в декартовы"));
	
	controller.PrintMatrix(dc, 350, 80, V);
	controller.PrintMatrix(dc, 550, 80, controller.SphereToCart(V));


}
