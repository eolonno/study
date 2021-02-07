#include "CMatrix.h"
#include "LibGraph.h"
class CPyramid
{
		CMatrix Vertices;
		void GetRect(CMatrix& Vert,CRectD& RectView);
	public:
		CPyramid();
		void Draw(CDC& dc,CMatrix& P,CRect& RW);
		void Draw1(CDC& dc,CMatrix& P,CRect& RW);		
};