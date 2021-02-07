#include "stdafx.h"
#include "cube.h"

#include "cubedoc.h"
#include "cubeview.h"

#include "gl/gl.h"
#include "gl/glu.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

unsigned char threeto8[8] =
{
	0, 0111>>1, 0222>>1, 0333>>1, 0444>>1, 0555>>1, 0666>>1, 0377
};

unsigned char twoto8[4] =
{
	0, 0x55, 0xaa, 0xff
};

unsigned char oneto8[2] =
{
	0, 255
};

/////////////////////////////////////////////////////////////////////////////
// CCubeView

IMPLEMENT_DYNCREATE(CCubeView, CView)

BEGIN_MESSAGE_MAP(CCubeView, CView)
	//{{AFX_MSG_MAP(CCubeView)
	ON_COMMAND(ID_FILE_PLAY, OnFilePlay)
	ON_UPDATE_COMMAND_UI(ID_FILE_PLAY, OnUpdateFilePlay)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_SIZE()
	ON_WM_TIMER()
	ON_WM_ERASEBKGND()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// construction/destruction

CCubeView::CCubeView()
{
	m_pDC = NULL;
	m_pOldPalette = NULL;
	m_play = FALSE;
}

CCubeView::~CCubeView()
{
}


void CCubeView::OnDraw(CDC* /*pDC*/)
{
	CCubeDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	DrawScene();
}

#ifdef _DEBUG
void CCubeView::AssertValid() const
{
	CView::AssertValid();
}

void CCubeView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CCubeDoc* CCubeView::GetDocument() // non-debug version is inline
{
	return STATIC_DOWNCAST(CCubeDoc, m_pDocument);
}
#endif

void CCubeView::OnFilePlay()
{
	m_play = m_play ? FALSE : TRUE;
	if (m_play)
		SetTimer(1, 15, NULL);
	else
		KillTimer(1);
}

void CCubeView::OnUpdateFilePlay(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_play);
}

BOOL CCubeView::PreCreateWindow(CREATESTRUCT& cs)
{
	// An OpenGL window must be created with the following flags and must not
	// include CS_PARENTDC for the class style. Refer to SetPixelFormat
	// documentation in the "Comments" section for further information.
	cs.style |= WS_CLIPSIBLINGS | WS_CLIPCHILDREN;

	return CView::PreCreateWindow(cs);
}

int CCubeView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CView::OnCreate(lpCreateStruct) == -1)
		return -1;

	Init(); // initialize OpenGL

	return 0;
}

void CCubeView::OnDestroy()
{
	HGLRC   hrc;

	KillTimer(1);

	hrc = ::wglGetCurrentContext();

	::wglMakeCurrent(NULL,  NULL);

	if (hrc)
		::wglDeleteContext(hrc);

	if (m_pOldPalette)
		m_pDC->SelectPalette(m_pOldPalette, FALSE);

	if (m_pDC)
		delete m_pDC;

	CView::OnDestroy();
}

void CCubeView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);

	if(cy > 0)
	{
		glViewport(0, 0, cx, cy);

		if((m_oldRect.right > cx) || (m_oldRect.bottom > cy))
			RedrawWindow();

		m_oldRect.right = cx;
		m_oldRect.bottom = cy;

		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		gluPerspective(45.0f, (GLdouble)cx/cy, 3.0f, 7.0f);
		glMatrixMode(GL_MODELVIEW);
	}
}

void CCubeView::OnTimer(UINT_PTR nIDEvent)
{
	DrawScene();

	CView::OnTimer(nIDEvent);

	// Eat spurious WM_TIMER messages
	MSG msg;
	while(::PeekMessage(&msg, m_hWnd, WM_TIMER, WM_TIMER, PM_REMOVE));
}

/////////////////////////////////////////////////////////////////////////////
// GL helper functions

void CCubeView::Init()
{
	PIXELFORMATDESCRIPTOR pfd;
	int         n;
	HGLRC       hrc;
	GLfloat     fMaxObjSize, fAspect;
	GLfloat     fNearPlane, fFarPlane;

	m_pDC = new CClientDC(this);

	ASSERT(m_pDC != NULL);

	if (!bSetupPixelFormat())
		return;

	n = ::GetPixelFormat(m_pDC->GetSafeHdc());
	::DescribePixelFormat(m_pDC->GetSafeHdc(), n, sizeof(pfd), &pfd);

	hrc = wglCreateContext(m_pDC->GetSafeHdc());
	wglMakeCurrent(m_pDC->GetSafeHdc(), hrc);

	GetClientRect(&m_oldRect);
	glClearDepth(1.0f);
	glEnable(GL_DEPTH_TEST);

	if (m_oldRect.bottom)
		fAspect = (GLfloat)m_oldRect.right/m_oldRect.bottom;
	else    // don't divide by zero, not that we should ever run into that...
		fAspect = 1.0f;
	fNearPlane = 3.0f;
	fFarPlane = 7.0f;
	fMaxObjSize = 3.0f;
	m_fRadius = fNearPlane + fMaxObjSize / 2.0f;

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45.0f, fAspect, fNearPlane, fFarPlane);
	glMatrixMode(GL_MODELVIEW);
}

BOOL CCubeView::bSetupPixelFormat()
{
	static PIXELFORMATDESCRIPTOR pfd =
	{
		sizeof(PIXELFORMATDESCRIPTOR),  // size of this pfd
		1,                              // version number
		PFD_DRAW_TO_WINDOW |            // support window
		  PFD_SUPPORT_OPENGL |          // support OpenGL
		  PFD_DOUBLEBUFFER,             // double buffered
		PFD_TYPE_RGBA,                  // RGBA type
		24,                             // 24-bit color depth
		0, 0, 0, 0, 0, 0,               // color bits ignored
		0,                              // no alpha buffer
		0,                              // shift bit ignored
		0,                              // no accumulation buffer
		0, 0, 0, 0,                     // accum bits ignored
		32,                             // 32-bit z-buffer
		0,                              // no stencil buffer
		0,                              // no auxiliary buffer
		PFD_MAIN_PLANE,                 // main layer
		0,                              // reserved
		0, 0, 0                         // layer masks ignored
	};
	int pixelformat;

	if ( (pixelformat = ChoosePixelFormat(m_pDC->GetSafeHdc(), &pfd)) == 0 )
	{
		MessageBox("ChoosePixelFormat failed");
		return FALSE;
	}

	if (SetPixelFormat(m_pDC->GetSafeHdc(), pixelformat, &pfd) == FALSE)
	{
		MessageBox("SetPixelFormat failed");
		return FALSE;
	}

	return TRUE;
}

unsigned char CCubeView::ComponentFromIndex(int i, UINT nbits, UINT shift)
{
	unsigned char val;

	val = (unsigned char) (i >> shift);
	switch (nbits)
	{

	case 1:
		val &= 0x1;
		return oneto8[val];
	case 2:
		val &= 0x3;
		return twoto8[val];
	case 3:
		val &= 0x7;
		return threeto8[val];

	default:
		return 0;
	}
}

void CCubeView::DrawScene(void)
{
	static BOOL     bBusy = FALSE;
	static GLfloat  wAngleY = 10.0f;
	static GLfloat  wAngleX = 1.0f;
	static GLfloat  wAngleZ = 5.0f;

	if(bBusy)
		return;
	bBusy = TRUE;

	glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glPushMatrix();

		glTranslatef(0.0f, 0.0f, -m_fRadius);
		glRotatef(wAngleX, 1.0f, 0.0f, 0.0f);
		glRotatef(wAngleY, 0.0f, 1.0f, 0.0f);
		glRotatef(wAngleZ, 0.0f, 0.0f, 1.0f);

		wAngleX += 1.0f;
		wAngleY += 10.0f;
		wAngleZ += 5.0f;

		GLfloat // Размерности пирамиды (внутри орто-проекции)
			x0 = -1., x1 = 1., y0 = -1., y1 = 1., z0 = 0., z1 = 1.5;

		glColor3f(0.5f, 0.0f, 1.0f);

		glBegin(GL_POLYGON);    // ABCD
		glVertex3f(x1, y0, z0);	// D
		glVertex3f(x0, y0, z0);	// A
		glVertex3f(x0, y1, z0);	// B
		glVertex3f(x1, y1, z0);	// C
		glEnd();

		glColor3f(0.5f, 0.0f, 1.0f);

		glBegin(GL_POLYGON);    // EDC
		glVertex3f(0., 0., z1);	// E
		glVertex3f(x1, y0, z0);	// D
		glVertex3f(x1, y1, z0);	// C
		glEnd();

		glColor3f(0.0f, 0.5f, 1.0f);

		glBegin(GL_POLYGON);    // ECB
		glVertex3f(0., 0., z1);	// E
		glVertex3f(x1, y1, z0);	// C
		glVertex3f(x0, y1, z0);	// B
		glEnd();

		glColor3f(0.0f, 0.0f, 0.5f);

		glBegin(GL_POLYGON);    // EBA
		glVertex3f(0., 0., z1);	// E
		glVertex3f(x0, y1, z0);	// B
		glVertex3f(x0, y0, z0);	// A
		glEnd();

		glColor3f(0.0f, 0.5f, 1.0f);

		glBegin(GL_POLYGON);    // EAD
		glVertex3f(0., 0., z1);	// E
		glVertex3f(x0, y0, z0);	// A
		glVertex3f(x1, y0, z0);	// D
		glEnd();

	glPopMatrix();

	glFinish();
	SwapBuffers(wglGetCurrentDC());

	bBusy = FALSE;
}

BOOL CCubeView::OnEraseBkgnd(CDC*)
{
	return TRUE;
}
