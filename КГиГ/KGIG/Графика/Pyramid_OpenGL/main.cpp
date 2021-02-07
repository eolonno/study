#include <windows.h>
#include <gl/glut.h>
#pragma comment(linker, "/ENTRY:main /SUBSYSTEM:WINDOWS")

struct COLOR
{
	GLclampf Red, Green, Blue, Alpha;

	COLOR(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha = 0)
		: Red(red), Green(green), Blue(blue), Alpha(alpha) {}
};

enum DRAW_STATE { DRAW_STATE_PYRAMID, DRAW_STATE_PYRAMID_PLUS };

DRAW_STATE g_DrawState = DRAW_STATE_PYRAMID;

GLint
	g_InitWidth  = 800, // Стартовая ширина окна
	g_InitHeight = 600; // Стартовая высота окна

GLdouble // Размерности ортографической проекции
	g_Left = -10., g_Right = 10., g_Bottom = -10., g_Top = 10., g_Znear = -10., g_Zfar = 10.;

GLfloat // Размерности пирамиды (внутри орто-проекции)
	g_X0 = -5., g_X1 = 5., g_Y0 = -5., g_Y1 = 5., g_Z0 = 0., g_Z1 = 9.;

GLfloat
	g_AngleX =  -10.,  // Угол для поворота вокруг оси X, град
	g_AngleY =   30.,  // Угол для поворота вокруг оси Y, град
	g_AngelStep = 5.,  // Шаг изменеия угла, град
	g_LineWidth = 1.;  // Толщина линий

bool g_IsPress = false;

GLfloat
	g_RotateAnimationStep = 0.2;

void OnDisplay();
void OnWindowsResize(GLint newWidth, GLint newHeight); 
void OnKeyPress(unsigned char key, int x, int y);
void OnSpecialKeyPress(int key, int x, int y);
void OnMouse(int button, int state, int x, int y);
void OnIdle();

// Рисовать пирамиду (E)ABCD, где A(x0, y0, z0),
//                                B(x1, y0, z0),
//                                C(x1, y1, z0),
//                                D(x0, y1, z0),
//                                E( 0,  0, z1)
void DrawPyramid(GLfloat x0, GLfloat x1, GLfloat y0, GLfloat y1, GLfloat z0, GLfloat z1);


void main() // Entry point
{
	glutInitDisplayMode(GLUT_RGB | GLUT_SINGLE | GLUT_DEPTH);
	glutInitWindowSize(g_InitWidth, g_InitHeight);
	glutInitWindowPosition(
		(GetSystemMetrics(SM_CXSCREEN) - g_InitWidth ) / 2,
		(GetSystemMetrics(SM_CYSCREEN) - g_InitHeight) / 2);
	glutCreateWindow("Удаление нелицевых граней (F2), анимация (LeftMouseButton) на OpenGL");
	glutDisplayFunc(OnDisplay);
	glutReshapeFunc(OnWindowsResize);
	glutKeyboardFunc(OnKeyPress);
	glutSpecialFunc(OnSpecialKeyPress);
	glutMouseFunc(OnMouse);
	glutIdleFunc(OnIdle);
	glutMainLoop();
}

void OnIdle()
{
	if (g_IsPress)
	{
		g_AngleY += g_RotateAnimationStep;
		if (g_AngleY > 359.99)
			g_AngleY = g_RotateAnimationStep;
	}

	glutPostRedisplay();
}

void OnMouse(int button, int state, int x, int y)
{
	switch (button)
	{
	case 0:
		g_IsPress = true;
		break;
	case 2:
		g_IsPress = false;
		break;
	}

	glutPostRedisplay();
}

void OnDisplay() 
{
	COLOR
		backColor(1., 1., 1.), // Цвет фона RGB
		lineColor(0., 0., 0.); // Цвет линий RGB

	glClearColor(backColor.Red, backColor.Green, backColor.Blue, backColor.Alpha);
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3ub(lineColor.Red, lineColor.Green, lineColor.Blue);
	glLineWidth(g_LineWidth);

	glMatrixMode(GL_MODELVIEW);  // Видовая матрица
	glLoadIdentity(); 	         // Видовая матрица  M = I
	glRotatef(g_AngleY, 0.0, 1.0, 0.0); // Вокруг оси Y
	glRotatef(g_AngleX, 1.0, 0.0, 0.0); // Вокруг оси X

	glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
	glLoadIdentity(); 
	
	glOrtho(g_Left, g_Right, g_Bottom, g_Top, g_Znear, g_Zfar);

	switch(g_DrawState)
	{
	case DRAW_STATE_PYRAMID:
		glDisable(GL_CULL_FACE);
		break;
	case DRAW_STATE_PYRAMID_PLUS:
		glEnable(GL_CULL_FACE);
		glCullFace(GL_BACK);
		break;
	}

	glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
	DrawPyramid(g_X0, g_X1, g_Y0, g_Y1, g_Z0, g_Z1);
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
	case GLUT_KEY_F1:
		g_DrawState = DRAW_STATE_PYRAMID;
		break;
	case GLUT_KEY_F2:
		g_DrawState = DRAW_STATE_PYRAMID_PLUS;
		break;
	case GLUT_KEY_UP:
		g_AngleX -= g_AngelStep;
		break;
	case GLUT_KEY_DOWN:
		g_AngleX += g_AngelStep;
		break;
	case GLUT_KEY_LEFT:
		g_AngleY -= g_AngelStep;
		break;
	case GLUT_KEY_RIGHT:
		g_AngleY += g_AngelStep;
		break;
	}

	glutPostRedisplay();
}

void DrawPyramid(GLfloat x0, GLfloat x1, GLfloat y0, GLfloat y1, GLfloat z0, GLfloat z1)
{
	glBegin(GL_POLYGON);    // ABCD
	 glVertex3f(x1, y0, z0);	// D
	 glVertex3f(x0, y0, z0);	// A
	 glVertex3f(x0, y1, z0);	// B
	 glVertex3f(x1, y1, z0);	// C
	glEnd();

	glBegin(GL_POLYGON);    // EDC
	 glVertex3f(0., 0., z1);	// E
	 glVertex3f(x1, y0, z0);	// D
	 glVertex3f(x1, y1, z0);	// C
	glEnd();

	glBegin(GL_POLYGON);    // ECB
	 glVertex3f(0., 0., z1);	// E
	 glVertex3f(x1, y1, z0);	// C
	 glVertex3f(x0, y1, z0);	// B
	glEnd();

	glBegin(GL_POLYGON);    // EBA
	 glVertex3f(0., 0., z1);	// E
	 glVertex3f(x0, y1, z0);	// B
	 glVertex3f(x0, y0, z0);	// A
	glEnd();

	glBegin(GL_POLYGON);    // EAD
	 glVertex3f(0., 0., z1);	// E
	 glVertex3f(x0, y0, z0);	// A
	 glVertex3f(x1, y0, z0);	// D
	glEnd();
}