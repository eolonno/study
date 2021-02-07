#include <windows.h>
#include "CMatrix.h"
#include <time.h>
CMatrix::CMatrix()
{
 n_rows=1;
 n_cols=1;
 array=new double*[n_rows];
 for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
 for(int i=0;i<n_rows;i++)
   for(int j=0;j<n_cols;j++) array[i][j]=0;
 }

//-------------------------------------------------------------------------------
CMatrix::CMatrix(int Nrow,int Ncol)
// Nrow - строки
// Ncol - коллонки
{
 n_rows=Nrow;
 n_cols=Ncol;
 array=new double*[n_rows];
 for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
 for(int i=0;i<n_rows;i++)
 for (int j = 0; j < n_cols; j++)
 {
	 array[i][j] = rand() % 6; // целая часть
	 //array[i][j] += (rand() %99)*0.01; // дробная часть
 }
 }

//---------------------------------------------------------------------------------
CMatrix::CMatrix(int Nrow)  //Âåêòîð
// Nrow - ÷èñëî ñòðîê
{
 n_rows=Nrow;
 n_cols=1;
 array=new double*[n_rows];
 for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
 for(int i=0;i<n_rows;i++)
 for (int j = 0; j<n_cols; j++) 
 {
	 array[i][j] = rand() % 6;
	 //array[i][j] += (rand() % 99)*0.01;
 }
 }
//---------------------------------------------------------------------------------
CMatrix::~CMatrix()
{
 for(int i=0;i<n_rows;i++) delete array[i];
 delete array;
}

//---------------------------------------------------------------------------------
double &CMatrix::operator()(int i,int j)
// i - íîìåð ñòðîêè
// j - íîìåð ñòîëáöà
{
if ((i>n_rows-1)||(j>n_cols-1))     //  ïðîâåðêà âûõîäà çà äèàïàçîí
   {
		 TCHAR* error=(L"CMatrix::operator(int,int): error ");
		 MessageBox(NULL,error,(L"Îøèáêà"),MB_ICONSTOP);
     exit(1);
   }
return array[i][j];
}

//---------------------------------------------------------------------------------
double &CMatrix::operator()(int i)
// i - íîìåð ñòðîêè äëÿ âåêòîðà
{
if (n_cols>1)     //  ×èñëî ñòîëáöîâ áîëüøå îäíîãî
   {
    char* error="CMatrix::operator(int): îáúåêò íå âåêòîð - ÷èñëî ñòîëáöîâ áîëüøå 1 ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
   }
if (i>n_rows-1)     //  ïðîâåðêà âûõîäà çà äèàïàçîí
   {
    TCHAR* error=TEXT("CMatrix::operator(int): âûõîä èíäåêñà çà ãðàíèöó äèàïàçîíà ");
		MessageBox(NULL,error,TEXT("Error"),MB_ICONSTOP);
    exit(1);
   }
return array[i][0];
}
//---------------------------------------------------------------------------------
CMatrix CMatrix::operator-()
// Îïåðàòîð -M
{
	CMatrix Temp(n_rows,n_cols);
  for(int i=0;i<n_rows;i++)
	for(int j=0;j<n_cols;j++) Temp(i,j)=-array[i][j];
  return Temp;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::operator+(CMatrix& M)
// Îïåðàòîð M1+M2
{	
	int bb=(n_rows==M.rows())&&(n_cols==M.cols());
	if(!bb)
	{ 
		char* error="CMatrix::operator(+): íåñîîòâåòñòâèå ðàçìåðíîñòåé ìàòðèö ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	CMatrix Temp(*this);
  for(int i=0;i<n_rows;i++)
	for(int j=0;j<n_cols;j++) Temp(i,j)+=M(i,j);
  return Temp;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::operator-(CMatrix& M)
// Îïåðàòîð M1-M2
{	
	int bb=(n_rows==M.rows())&&(n_cols==M.cols());
	if(!bb)
	{ 
		char* error="CMatrix::operator(-): íåñîîòâåòñòâèå ðàçìåðíîñòåé ìàòðèö ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	CMatrix Temp(*this);
	for(int i=0;i<n_rows;i++)
	for(int j=0;j<n_cols;j++) Temp(i,j)-=M(i,j);
  return Temp;
}
//---------------------------------------------------------------------------------
CMatrix CMatrix::operator*(CMatrix& M)
// Óìíîæåíèå íà ìàòðèöó M
{
double sum;
int nn=M.rows();
int mm=M.cols();
CMatrix Temp(n_rows,mm);
if (n_cols==nn)
  {
   for (int i=0;i<n_rows;i++)
        for (int j=0;j<mm;j++)
          {
          sum=0;
          for (int k=0;k<n_cols;k++) sum+=(*this)(i,k)*M(k,j);
          Temp(i,j)=sum;
          }
  }
else
 {
   TCHAR* error=TEXT("CMatrix::operator*: íåñîîòâåòñòâèå ðàçìåðíîñòåé ìàòðèö ");
   MessageBox(NULL,error,TEXT("Îøèáêà"),MB_ICONSTOP);
   exit(1);
  }
return Temp;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::operator=(const CMatrix& M)
// Îïåðàòîð ïðèñâàèâàíèÿ M1=M
{
if (this==&M) return *this;
int nn=M.rows();
int mm=M.cols();
if ((n_rows==nn)&&(n_cols==mm))
 {
for (int i=0;i<n_rows;i++)
     for (int j=0;j<n_cols;j++) array[i][j]=M.array[i][j];
 }
else   // äëÿ îøèáêè ðàçìåðíîñòåé
  {
   TCHAR* error=TEXT("CMatrix::operator=: íåñîîòâåòñòâèå ðàçìåðíîñòåé ìàòðèö");
   MessageBox(NULL,error,TEXT("Îøèáêà"),MB_ICONSTOP);
   exit(1);
  }
return *this;
}

//---------------------------------------------------------------------------------
CMatrix::CMatrix(const CMatrix &M) // Êîíñòðóêòîð êîïèðîâàíèÿ
{
	n_rows=M.n_rows;
	n_cols=M.n_cols;
	array=new double*[n_rows];
	for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
	for(int i=0;i<n_rows;i++)
    for(int j=0;j<n_cols;j++) array[i][j]=M.array[i][j];
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::operator+(double x)
// Îïåðàòîð M+x, ãäå M - ìàòðèöà, x - ÷èñëî
{
  CMatrix Temp(*this);
  for(int i=0;i<n_rows;i++)
	for(int j=0;j<n_cols;j++) Temp(i,j)+=x;
  return Temp;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::operator-(double x)
// Îïåðàòîð M+x, ãäå M - ìàòðèöà, x - ÷èñëî
{
  CMatrix Temp(*this);
  for(int i=0;i<n_rows;i++)
	for(int j=0;j<n_cols;j++) Temp(i,j)-=x;
  return Temp;
}



//---------------------------------------------------------------------------------
CMatrix CMatrix::Transp()
// Âîçâðàùàåò ìàòðèöó,òðàíñïîíèðîâàííóþ ê (*this)
{
  CMatrix Temp(n_cols,n_rows);
  for (int i=0;i<n_cols;i++)
     for (int j=0;j<n_rows;j++) Temp(i,j)=array[j][i];
  return Temp;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::GetRow/*строка*/(int k)	
// Âîçâðàùàåò ñòðîêó ìàòðèöû ïî íîìåðó k
{
	if(k>n_rows-1)
	{
		char* error="CMatrix::GetRow(int k): ïàðàìåòð k ïðåâûøàåò ÷èñëî ñòðîê ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	CMatrix M(1,n_cols);
	for(int i=0;i<n_cols;i++)M(0,i)=(*this)(k,i);
	return M;
}
//---------------------------------------------------------------------------------
CMatrix CMatrix::GetRow(int k,int n,int m)	
// Âîçâðàùàåò ïîäñòðîêó èç ñòðîêè ìàòðèöû ñ íîìåðîì k
// n - íîìåð ïåðâîãî ýëåìåíòà â ñòðîêå
// m - íîìåð ïîñëåäíåãî ýëåìåíòà â ñòðîêå
{
	int b1=(k>=0)&&(k<n_rows);
	int b2=(n>=0)&&(n<=m);
	int b3=(m>=0)&&(m<n_cols);
	int b4=b1&&b2&&b3;
	if(!b4)
	{
		char* error="CMatrix::GetRow(int k,int n, int m):îøèáêà â ïàðàìåòðàõ ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	int nCols=m-n+1;
	CMatrix M(1,nCols);
	for(int i=n;i<=m;i++)M(0,i-n)=(*this)(k,i);
	return M;
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::GetCol(int k)	
// Âîçâðàùàåò ñòîëáåö ìàòðèöû ïî íîìåðó k
{
	if(k>n_cols-1)
	{
		char* error="CMatrix::GetCol(int k): ïàðàìåòð k ïðåâûøàåò ÷èñëî ñòîëáöîâ ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	CMatrix M(n_rows,1);
	for(int i=0;i<n_rows;i++)M(i,0)=(*this)(i,k);
	return M;
}
//---------------------------------------------------------------------------------
CMatrix CMatrix::GetCol(int k,int n, int m)
// Âîçâðàùàåò ïîäñòîëáåö èç ñòîëáöà ìàòðèöû ñ íîìåðîì k
// n - íîìåð ïåðâîãî ýëåìåíòà â ñòîëáöå
// m - íîìåð ïîñëåäíåãî ýëåìåíòà â ñòîëáöå
{
	int b1=(k>=0)&&(k<n_cols);
	int b2=(n>=0)&&(n<=m);
	int b3=(m>=0)&&(m<n_rows);
	int b4=b1&&b2&&b3;
	if(!b4)
	{
		char* error="CMatrix::GetCol(int k,int n, int m):îøèáêà â ïàðàìåòðàõ ";
		MessageBoxA(NULL,error,"Îøèáêà",MB_ICONSTOP);
    exit(1);
	}
	int nRows=m-n+1;
	CMatrix M(nRows,1);
	for(int i=n;i<=m;i++)M(i-n,0)=(*this)(i,k);
	return M;
}
//---------------------------------------------------------------------------------
CMatrix CMatrix::RedimMatrix(int NewRow,int NewCol)
// Èçìåíÿåò ðàçìåð ìàòðèöû ñ óíè÷òîæåíèåì äàííûõ
// NewRow - íîâîå ÷èñëî ñòðîê
// NewCol - íîâîå ÷èñëî ñòîëáöîâ 
{
	for(int i=0;i<n_rows;i++) delete array[i];
	delete array;
	n_rows=NewRow;
	n_cols=NewCol;
	array=new double*[n_rows];
	for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
	for(int i=0;i<n_rows;i++)
		for(int j=0;j<n_cols;j++) array[i][j]=0;
	return (*this);
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::RedimData(int NewRow,int NewCol)
// Èçìåíÿåò ðàçìåð ìàòðèöû ñ ñîõðàíåíèåì äàííûõ, êîòîðûå ìîæíî ñîõðàíèòü
// NewRow - íîâîå ÷èñëî ñòðîê
// NewCol - íîâîå ÷èñëî ñòîëáöîâ 
{
	CMatrix Temp=(*this);
	this->RedimMatrix(NewRow,NewCol);
	int min_rows=Temp.rows()<(*this).rows()?Temp.rows():(*this).rows();
	int min_cols=Temp.cols()<(*this).cols()?Temp.cols():(*this).cols();
	for(int i=0;i<min_rows;i++)
		for(int j=0;j<min_cols;j++) (*this)(i,j)=Temp(i,j);
	return (*this);
}


//---------------------------------------------------------------------------------
CMatrix CMatrix::RedimMatrix(int NewRow)
// Èçìåíÿåò ðàçìåð ìàòðèöû ñ óíè÷òîæåíèåì äàííûõ
// NewRow - íîâîå ÷èñëî ñòðîê
// NewCol=1
{
	for(int i=0;i<n_rows;i++) delete array[i];
	delete array;
	n_rows=NewRow;
	n_cols=1;
	array=new double*[n_rows];
	for(int i=0;i<n_rows;i++) array[i]=new double[n_cols];
	for(int i=0;i<n_rows;i++)
		for(int j=0;j<n_cols;j++) array[i][j]=0;
	return (*this);
}

//---------------------------------------------------------------------------------
CMatrix CMatrix::RedimData(int NewRow)
// Èçìåíÿåò ðàçìåð ìàòðèöû ñ ñîõðàíåíèåì äàííûõ, êîòîðûå ìîæíî ñîõðàíèòü
// NewRow - íîâîå ÷èñëî ñòðîê
// NewCol=1
{
	CMatrix Temp=(*this);
	this->RedimMatrix(NewRow);
	int min_rows=Temp.rows()<(*this).rows()?Temp.rows():(*this).rows();	
	for(int i=0;i<min_rows;i++)(*this)(i)=Temp(i);	
	return (*this);
}
//----------------------------------------------------------------------------------
double CMatrix::MaxElement()
// Ìàêñèìàëüíîå çíà÷åíèå ýëåìåíòîâ ìàòðèöû
{
	double max=(*this)(0,0);
	for(int i=0;i<(this->rows());i++)
	  for(int j=0;j<(this->cols());j++) if ((*this)(i,j)>max) max=(*this)(i,j);
	return max;
}

//----------------------------------------------------------------------------------
double CMatrix::MinElement()
// Ìèíèìàëüíîå çíà÷åíèå ýëåìåíòîâ ìàòðèöû
{
	double min=(*this)(0,0);
	for(int i=0;i<(this->rows());i++)
	  for(int j=0;j<(this->cols());j++) if ((*this)(i,j)<min) min=(*this)(i,j);
	return min;
}
