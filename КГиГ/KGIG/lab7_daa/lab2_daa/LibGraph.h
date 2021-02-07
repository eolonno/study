#ifndef LIBGRAPH
#define LIBGRAPH 1
const double pi=3.14159;

struct CSizeD
{
  double cx;
  double cy;
};

struct CRectD 
 { 
  double left; 
  double top; 
  double right; 
  double bottom; 
  CRectD(){left=top=right=bottom=0;};
  CRectD(double l,double t,double r,double b);
  void SetRectD(double l,double t,double r,double b);
  CSizeD SizeD();
 }; 

CMatrix SpaceToWindow(CRectD& rs,CRect& rw);

CMatrix CreateViewCoord(double r,double fi,double q);
// Создает матрицу пересчета точки из мировой системы координат в видовую
// (r,fi,q)- координата ТОЧКИ НАБЛЮДЕНИЯ(начало видовой системы координат)
// в мировой сферической системе координат( углы fi и q в градусах)

CMatrix VectorMult(CMatrix& V1,CMatrix& V2);
// Вычисляет векторное произведение векторов V1 и V2

double ScalarMult(CMatrix& V1,CMatrix& V2);
// Вычисляет скалярное произведение векторов V1 и V2

CMatrix SphereToCart(CMatrix& PView);
// Преобразует сферические координаты PView  точки в декартовы
// PView(0) - r
// PView(1) - fi - азимут(отсчет от оси X), град.
// PView(2) - q - угол(отсчетот оси Z), град.
// Результат: R(0)- x, R(1)- y, R(2)- z	

#endif