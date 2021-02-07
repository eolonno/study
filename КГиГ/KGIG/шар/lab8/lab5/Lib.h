#ifndef LIBGRAPH
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




#endif

