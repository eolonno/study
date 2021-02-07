#include <cmath>
#include <cstring>
#include <gl/glut.h>

struct POINT
{
	double X;
	double Y;
	double Z;
	POINT(double x, double y, double z) : X(x), Y(y), Z(z) {}
};

GLint g_InitWidth  = 800;	  // Начальная ширина окна 
GLint g_InitHeight = 600;     // Начальная высота окна

GLdouble // Размерности ортографической проекции
	g_Left = -10., g_Right = 10., g_Bottom = -10., g_Top = 10., g_Znear = -10., g_Zfar = 10.;

GLfloat // Размерности пирамиды (внутри орто-проекции)
	g_X0 = -5., g_X1 = 5., g_Y0 = -5., g_Y1 = 5., g_Z0 = 0., g_Z1 = 9.;

GLint left, right, top, bottom, znear, zfar; // Для определения области видимости графических 
                                             // данных после проектирования в СКН
float g_AngleX = 0;      // Угол для поворота вокруг оси X, град
float g_AngleY = 0;      // Угол для поворота вокруг оси Y, град
float d_angle = 10;      // Шаг изменеия угла, град

// Параметры материала пирамиды 
float mat3_dif[]  = {0.1f, 0.5f, 0.0f};
float mat3_amb[]  = {0.2f, 0.2f, 0.2f};
float mat3_spec[] = {0.6f, 0.6f, 0.6f};
float mat3_shininess = 0.1f * 128;

void GetNormal(const POINT &P1, const POINT &P2, const POINT &P3, GLfloat *VN)
	// Вычисляет единичный вектор нормали к плоскости,определяемой
	// точками P1,P2,P3(P=(P.x,P.y,P.z)
	// Вектора P1P2, P1P3 и VN образуют правую тройку 
	// Результат записывается в вектор VN[3]
{
	double V1[3] = { P2.X - P1.X, P2.Y - P1.Y, P2.Z - P1.Z };
	double V2[3] = { P3.X - P1.X, P3.Y - P1.Y, P3.Z - P1.Z };
	double x = V1[1] * V2[2] - V1[2] * V2[1];
	double y = -(V1[0] * V2[2] - V1[2] * V2[0]);
	double z = V1[0] * V2[1] - V1[1] * V2[0];
	double r = sqrt(x*x + y*y + z*z);
	VN[0] = x/r;
	VN[1] = y/r;
	VN[2] = z/r;
}

void Pyramid(GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1, GLfloat z2)
{		
	// Основание ABCD: A(x1,y1,z1), B(x1,y2,z1), C(x2,y2,z1), D(x2,y1,z1). Вершина E(0,0,z2)
	GLfloat VN[3]; // Вектор нормали
	POINT A(x1, y1, z1), B(x1, y2, z1), C(x2, y2, z1), D(x2, y1, z1), E(0, 0, z2);

	GetNormal(A,B,D,VN); // Внешняяя нормаль к основанию
	glBegin(GL_POLYGON); // Основание 
	glNormal3fv(VN);
	glVertex3f(x2, y1, z1);	// D
	glVertex3f(x1, y1, z1);	// A
	glVertex3f(x1, y2, z1);	// B
	glVertex3f(x2, y2, z1);	// C
	glEnd();

	GetNormal(E, D, C,VN); // Внешняяя нормаль к EDC
	glBegin(GL_POLYGON);   // EDC
	glNormal3fv(VN);
	glVertex3f(0., 0., z2);	// E
	glVertex3f(x2, y1, z1);	// D
	glVertex3f(x2, y2, z1);	// C         
	glEnd ();

	GetNormal(E, C, B, VN); // Внешняяя нормаль к ECB
	glBegin(GL_POLYGON);    // ECB
	glNormal3fv(VN);
	glVertex3f(0., 0., z2);	// E
	glVertex3f(x2, y2, z1);	// C
	glVertex3f(x1, y2, z1);	// B					       
	glEnd();

	GetNormal(E, B, A, VN); // Внешняяя нормаль к EBA
	glBegin(GL_POLYGON);    // EBA
	glNormal3fv(VN);
	glVertex3f(0., 0., z2);	// E
	glVertex3f(x1, y2, z1);	// B	
	glVertex3f(x1, y1, z1);	// A
	glEnd();

	GetNormal(E, A, D, VN); // Внешняяя нормаль к EAD
	glBegin(GL_POLYGON);    // EAD
	glNormal3fv(VN);
	glVertex3f(0., 0., z2);	// E
	glVertex3f(x1, y1, z1);	// A
	glVertex3f(x2, y1, z1);	// D
	glEnd();	
}

void OnDraw(void) 
{   
	glClearColor(1.0, 1.0, 1.0, 0.0);                    // Фон
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT ); // Заливка		
	
	glMatrixMode(GL_MODELVIEW); // Видовая матрица
	glLoadIdentity(); 
	glRotatef(g_AngleY, 0.0, 1.0, 0.0); // Вокруг оси Y, M = Ry(angleY) 
	glRotatef(g_AngleX, 1.0, 0.0, 0.0); // Вокруг оси X, M = Ry(angleY) * Rx(angleX) 
	                                    // Результат V2 = Ry*Rx*V1
	
	glMatrixMode(GL_PROJECTION); // Ортографическая проекция
	glLoadIdentity();
	glOrtho(g_Left, g_Right, g_Bottom, g_Top, g_Znear, g_Zfar); 
	
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);
	
	glMaterialfv(GL_FRONT,GL_AMBIENT,mat3_amb); 
	glMaterialfv(GL_FRONT,GL_DIFFUSE,mat3_dif); 
	glMaterialfv(GL_FRONT,GL_SPECULAR,mat3_spec); 
	glMaterialf(GL_FRONT,GL_SHININESS,mat3_shininess);
	
	Pyramid(g_X0, g_X1, g_Y0, g_Y1, g_Z0, g_Z1);
	
	glutSwapBuffers(); // Переключение буферов (обязательно при использовании двойной буферизации GLUT_DOUBLE)
	glFinish(); 
}

void OnWindowsResize(GLint newWidth, GLint newHeight) 
{   
	glViewport(0, 0, newWidth, newHeight);
} 

void OnKeyPress(unsigned char key, int x, int y)
{
	static const unsigned char esc_key = '\033';

	if (key == esc_key)
		exit(0);
}

void OnSpecialKeyPress(int key, int x, int y)
{
	switch(key)
	{
	case GLUT_KEY_RIGHT:
		g_AngleY += d_angle;		
		break;
	case GLUT_KEY_LEFT:
		g_AngleY -= d_angle;	
		break;
	case GLUT_KEY_UP:
		g_AngleX -= d_angle;		
		break;
	case GLUT_KEY_DOWN:
		g_AngleX += d_angle;
		break;
	}

	glutPostRedisplay();
}

void Init() // Инициализация параметров материалов и источника света
{ 
	GLfloat light_ambient[]  = { 0., 0., 0., 1. }; 
	GLfloat light_diffuse[]  = { 1., 1., 1., 1. }; 
	GLfloat light_specular[] = { 1., 1., 1., 1. }; 
	GLfloat light_position[] = { 0., 0., 1., 0. }; 

	glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient); 
	glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT0, GL_POSITION, light_position);

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
}

void main() // Entry point
{ 
	glutInitDisplayMode(GLUT_RGB | GLUT_SINGLE | GLUT_DEPTH);
	glutInitWindowSize(g_InitWidth, g_InitHeight);
	glutCreateWindow("Пирамида с освещением");
	Init();
	glutDisplayFunc(OnDraw);
	glutReshapeFunc(OnWindowsResize);
	glutKeyboardFunc(OnKeyPress);
	glutSpecialFunc(OnSpecialKeyPress);
	glutMainLoop();
}