
// ChildView.h : интерфейс класса CChildView
//


#pragma once
struct ExtPoint
{
public:
	float X;
	float Y;
	float Z;
	ExtPoint ExtPoint::operator-(ExtPoint& second)
	{
		ExtPoint result;
		result.X=X-second.X;
		result.Y=Y-second.Y;
		result.Z=Z-second.Z;
		return result;
	}
	void Set(float x,float y,float z)
	{
		X=x;
		Y=y;
		Z=z;
	}
	POINT ToPOINT()
	{
		POINT res;
		res.x=X;
		res.y=Y;
		return res;
	}
};
struct LightParams
{
	double intensivity, KoefDifuz, KoefStandart, KoefZerkal, p;
};

class Sphere
{
	double radius;
public:
	CMatrix transform;
	CMatrix cord;
	CMatrix rescord;
	Sphere(double R)
	{
		radius=R;
	}
	void Draw(CDC& dc, bool light_mode);
	void CalculateMatrix(CRect ramka,CRectD ramka_figura)
	{
		transform.RedimMatrix(3,3);
		transform=SpaceToWindow(ramka_figura,ramka);
		cord.RedimMatrix(3);
		rescord.RedimMatrix(3);
		cord(2)=1;
		rescord(2)=1;
	}	
private:
	CMatrix SpaceToWindow(CRectD &RS,CRect &RW)
{
	CMatrix M(3,3);
	double kx=(double)RW.Width()/(RS.right-RS.left);
	double ky=(double)RW.Height()/(RS.top-RS.bottom);
	M(0,0)=kx;	M(0,1)=0;
	M(0,2)=(double)RW.left-kx*RS.left;
	M(1,0)=0;M(1,1)=-ky;
	M(1,2)=(double)RW.bottom+ky*RS.bottom;
	M(2,0)=0;	M(2,1)=0;	M(2,2)=1;
	return M;
}
	ExtPoint SphereToCart(double r,double Fi,double Teta)
	{
		ExtPoint result;
		result.X=r*sin(Teta)*cos(Fi);
		result.Y=r*sin(Teta)*sin(Fi);
		result.Z=r*cos(Teta);
		return result;
	}
	double GetDarkness(ExtPoint LightVector,ExtPoint CamVector,ExtPoint NormalVector,LightParams param )
	{
		ExtPoint centr;
		centr.Set(0,0,0);
		double temp=(ScalarMultiply(NormalVector,LightVector)*2)/pow(ModulVector(NormalVector),2);
		ExtPoint VectorOtrazenia;
		VectorOtrazenia.X=NormalVector.X*temp-LightVector.X;
		VectorOtrazenia.Y=NormalVector.Y*temp-LightVector.Y;
		VectorOtrazenia.Z=NormalVector.Z*temp-LightVector.Z;
		double UgolAlpha=Ugol(CamVector,VectorOtrazenia);
		double power=GetLightPower(param,Ugol(NormalVector,LightVector),UgolAlpha)/param.intensivity;
		return power;
	}
	double GetLightPower(LightParams param,double Fi, double alpha)
	{
		double first=0;
		double second=0;
		first=param.KoefDifuz*cos(Fi)*cos(Fi+alpha);
		second=param.KoefZerkal*pow(cos(alpha),Fi);
		double result=param.intensivity*param.KoefStandart+param.intensivity*(first+second);
		if(result<0) return 0;
		return result;
	}
	double ModulVector(ExtPoint v)
	{
		return sqrt(v.X*v.X+v.Y*v.Y+v.Z*v.Z);
	}
	double ScalarMultiply(ExtPoint v1,ExtPoint v2)
	{
		return v1.X*v2.X+v1.Y*v2.Y+v1.Z*v2.Z;
	}
	double Ugol(ExtPoint v1,ExtPoint v2)
	{
		double ugol=ScalarMultiply(v1,v2)/(ModulVector(v1)*ModulVector(v2));
		ugol=acos(ugol);
		return ugol;
	}
	ExtPoint VectorMyltiply(ExtPoint v1,ExtPoint v2)
	{
		ExtPoint res;
		res.X=v1.Y*v2.Z-v1.Z*v2.Y;
		res.Y=v1.Z*v2.X-v1.X*v2.Z;
		res.Z=v1.X*v2.Y-v1.Y*v2.X;
		return res;
	}
	ExtPoint PointsOnVector(ExtPoint begin,ExtPoint end)
	{
		ExtPoint res;
		res.X=end.X-begin.X;
		res.Y=end.Y-begin.Y;
		res.Z=end.Z-begin.Z;
		return res;
	}
};

class CChildView : public CWnd
{
	Sphere *figura;
// Создание
public:
	CChildView();

// Атрибуты
public:

// Операции
public:

// Переопределение
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Реализация
public:
	virtual ~CChildView();

	// Созданные функции схемы сообщений
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	afx_msg void Svitch_to_diffusian();
	afx_msg void svitch_to_zerkal();
};