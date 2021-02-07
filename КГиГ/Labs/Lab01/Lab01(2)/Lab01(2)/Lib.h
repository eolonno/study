#ifndef LIBGRAPH
#include "CMatrix.h"
#include "stdafx.h"
#include "resource.h"
#define LIBGRAPH 1
const double pi=3.14159;
//typedef double (*pfunc)(double);	// Указатель на функцию

struct CSizeD
{
  double cx;
  double cy;
};
//-------------------------------------------------------------------------------
struct CRectD 
 { 
  double left; 
  double top; 
  double right; 
  double bottom; 
  CRectD(){left=top=right=bottom=0;};
  CRectD(double l,double t,double r,double b);
  void SetRectD(double l,double t,double r,double b);
  CSizeD SizeD();	// Возвращает размеры(ширина, высота) прямоугольника 
 };

// класс для операций с CMatrix
class ControllerCMatrix
{
public:
	ControllerCMatrix() = default;
	~ControllerCMatrix() = default;

	#pragma region Methods
	// вывод матрицы
	void PrintMatrix(CDC& dc, int x, int y, CMatrix& M);
	// Инициализация матрицы случайными числами
	void InitMatrix(CMatrix& M);
	//Скалярное произведение векторов
	double ScalarMult(CMatrix& V1, CMatrix& V2);
	// преобразование double в CString (для вывода в окне)
	CString DoubleToString(double x);
	// модуль вектора
	double ModVec(CMatrix& V);
	// Векторное произведение
	CMatrix VectorMult(CMatrix& V1, CMatrix& V2);
	// Косинус угла между векторами
	double CosV1V2(CMatrix& V1, CMatrix& V2);
	// Преобразует сферические координаты PView  точки в декартовы
	CMatrix SphereToCart(CMatrix& PView);
	// PView(0) – r – расстояние до точки.
	// PView(1) - fi - азимут(отсчет от оси X), град.
	// PView(2) - q - угол(отсчетот оси Z), град.
	// Результат: R(0)- x, R(1)- y, R(2)- z	

	#pragma endregion
private:

};

class CDlg : public CDialog
{
public:
	CDlg(CWnd* pParrent = NULL) : CDialog(IDD_DIALOG1, pParrent) {}


	virtual ~CDlg() = default;
protected:

};


#endif

