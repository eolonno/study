#include "stdafx.h"
#include "cube.h"

#include "cubedoc.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CCubeDoc

IMPLEMENT_DYNCREATE(CCubeDoc, CDocument)

BEGIN_MESSAGE_MAP(CCubeDoc, CDocument)
	//{{AFX_MSG_MAP(CCubeDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CCubeDoc construction/destruction

CCubeDoc::CCubeDoc()
{
	// TODO: add one-time construction code here

}

CCubeDoc::~CCubeDoc()
{
}

BOOL CCubeDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CCubeDoc serialization

void CCubeDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CCubeDoc diagnostics

#ifdef _DEBUG
void CCubeDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CCubeDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CCubeDoc commands
