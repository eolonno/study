#include <cstdio>
#include <cmath>
#include <gl/glut.h>

typedef float (*pFunc)(float);

//////////////////////////////////////////////////////////////////////////
struct DRAW_TASK      // "Задача" для прорисовки
{
	DRAW_TASK(pFunc func, float begin, float end)
		: func(func), begin(begin), end(end) {}

	float begin, end; // Область определения функции [begin, end]
	pFunc func;       // Сама функция
};
enum DRAW_STATE
{
	DRAW_STATE_CLEAN, DRAW_STATE_FUNC
};
//////////////////////////////////////////////////////////////////////////

void OnDraw();
void OnSize(GLint w, GLint h);
void StandartKeyPress(unsigned char key, int x, int y);
void SpecialKeyPress(int key, int x, int y);
void DrawNet();
void DrawFunctionGraph();

void ClearXYTable();
void FillXYTable(pFunc func, float begin, unsigned int numberPoints);

float MyFunc0(float x) { return sin(x);                           }
float MyFunc1(float x) { return log(x);                           }
float MyFunc2(float x) { return sqrt(x);                          }
float MyFunc3(float x) { return x;                                }
float MyFunc4(float x) { return x * x;                            }
float MyFunc5(float x) { return x * x * x;                        }
float MyFunc6(float x) { return exp(sqrt(x)) * sin(x);            }
float MyFunc7(float x) { return x < 0 ? x * x : floor(x);         }
float MyFunc8(float x) { return x < 0 ? sin(x) : x * x;           }
float MyFunc9(float x) { return 2 * sin(cos(x)) * sin(4 * x * x); }

DRAW_TASK g_Tasks[] =
{
	//        function  begin  end
	DRAW_TASK(MyFunc0,   -10,  10), // F1
	DRAW_TASK(MyFunc1,  0.01,  20), // F2
	DRAW_TASK(MyFunc2,     0,  20), // F3
	DRAW_TASK(MyFunc3,   -10,  10), // F4
	DRAW_TASK(MyFunc4,   -10,  10), // F5
	DRAW_TASK(MyFunc5,   -10,  10), // F6
	DRAW_TASK(MyFunc6,   0.1,  50), // F7
	DRAW_TASK(MyFunc7,    -3,   5), // F8
	DRAW_TASK(MyFunc8,   -10,   3), // F9
	DRAW_TASK(MyFunc9,    -5,   5)  // F10
};

float g_Dx = 0.01;      // Шаг "дискретизации"
float g_NetStep = 1;    // Шаг сетки

GLint 
	g_InitWidth  = 800, // Стартовая ширина окна
	g_InitHeight = 600; // Стартовая высота окна

float **g_XYTable = NULL;
unsigned int g_NumberPoints;
GLdouble g_Left, g_Right, g_Top, g_Bottom;
DRAW_STATE g_DrawState = DRAW_STATE_CLEAN;

void main(int argc, char *argv[])
{
	::glutInit(&argc, argv);
	::glutInitDisplayMode(GLUT_RGB | GLUT_SINGLE);
	::glutInitWindowSize(g_InitWidth, g_InitHeight);
	::glutCreateWindow("Графопостроитель на OpenGL");
	::glutDisplayFunc(OnDraw);
	::glutReshapeFunc(OnSize);
	::glutKeyboardFunc(StandartKeyPress);
	::glutSpecialFunc(SpecialKeyPress);
	::glutMainLoop();
}

void OnDraw(void) 
{
	glClearColor(1., 1., 1., 0.); // Цвет фона в окне
	glClear(GL_COLOR_BUFFER_BIT); // Очистить буфер цвета, залив цветом фона

	switch(g_DrawState)
	{
	case DRAW_STATE_CLEAN:
		break;
	case DRAW_STATE_FUNC:	
		::glMatrixMode(GL_MODELVIEW);    // Видовая матрица
		::glLoadIdentity(); 

		::glMatrixMode(GL_PROJECTION);   // Ортографическая проекция
		::glLoadIdentity();
		::gluOrtho2D(g_Left, g_Right, g_Bottom, g_Top); // (left, bottom) - (right, top)

		::DrawNet();
		::DrawFunctionGraph();
		
		break;
	}

    ::glFinish(); 
} 
 
void OnSize(GLint newWidth, GLint newHeight)
{   
    ::glViewport(0, 0, newWidth, newHeight);
} 

void StandartKeyPress(unsigned char key, int x, int y)
{
	if(key == '\033') // Esc
		::exit(0);
}

void SpecialKeyPress(int key, int x, int y) // Обработка нажатия на клавишу без ASCII-кода
{
	if(key >= 1 && key <= sizeof(g_Tasks)/sizeof(DRAW_TASK)) // F1, F2, F3, ...
	{
		DRAW_TASK task = g_Tasks[key - 1];

		::FillXYTable(task.func, task.begin, (unsigned int)((task.end - task.begin) / g_Dx) + 1);

		float maxY = g_XYTable[0][1], minY = g_XYTable[0][1], tmp;

		for(unsigned int i = 0; i < g_NumberPoints; ++i)
		{
			tmp = g_XYTable[i][1];
			if (maxY < tmp) maxY = tmp;
			if (minY > tmp) minY = tmp;
		}

		g_Left   = task.begin;
		g_Right  = task.end;
		g_Bottom = minY;
		g_Top    = maxY;

		g_DrawState = DRAW_STATE_FUNC;
	}
	
	::glutPostRedisplay();
}

void DrawNet()
{
	::glColor3ub(220, 220, 220);
	::glLineWidth(1.);

	float 
		stepForX = (g_Right - g_Left) * g_Dx,
		stepForY = (g_Top  - g_Bottom) * g_Dx;
	
	for (GLfloat x = 0; x < g_Right; x += stepForX)
	{
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(x, g_Top);
		::glVertex2f(x, g_Bottom);

		::glEnd();
	}
	for (GLfloat x = 0; x > g_Left; x -= stepForX)
	{
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(x, g_Top);
		::glVertex2f(x, g_Bottom);

		::glEnd();
	}
	for (GLfloat y = 0; y < g_Top; y += stepForY)
	{
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(g_Left, y);
		::glVertex2f(g_Right, y);

		::glEnd();
	}
	for (GLfloat y = 0; y > g_Bottom; y -= stepForY)
	{
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(g_Left, y);
		::glVertex2f(g_Right, y);

		::glEnd();
	}
}

void DrawFunctionGraph()
{
	if(g_Top * g_Bottom < 0)  // Нужна ли ось X ?
	{
		::glColor3ub(0, 0, 0);
		::glLineWidth(1.);
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(g_Left, 0);
		::glVertex2f(g_Right, 0);

		::glEnd(); 
	}
	if(g_Left * g_Right < 0)  // Нужна ли ось Y ?
	{	
		::glColor3ub(0, 0, 0);
		::glLineWidth(1.);
		::glBegin(GL_LINE_STRIP);

		::glVertex2f(0, g_Bottom);
		::glVertex2f(0, g_Top);    

		::glEnd(); 
	}

    ::glColor3ub(0,255,0);	  // Цвет линии 
	::glLineWidth(2.0) ;	  // Толщина линии
	::glBegin(GL_LINE_STRIP); // Линия графика

    for(unsigned int i = 0; i < g_NumberPoints; ++i)
		::glVertex2fv(g_XYTable[i]);

    ::glEnd();
}

void FillXYTable(pFunc func, float begin, unsigned int numberPoints)
{
	if(g_XYTable != NULL)
		::ClearXYTable();

	g_XYTable = new float*[numberPoints];

	float x;

	for(unsigned int i = 0; i < numberPoints; ++i)
	{
		g_XYTable[i] = new float[2];

		x = begin + i * g_Dx;
		g_XYTable[i][0] = x;
		g_XYTable[i][1] = func(x);
	}

	g_NumberPoints = numberPoints;
}

void ClearXYTable()
{
	for(unsigned int i = 0; i < g_NumberPoints; ++i)
		delete [] g_XYTable[i];
	delete g_XYTable;
	g_XYTable = NULL;
}