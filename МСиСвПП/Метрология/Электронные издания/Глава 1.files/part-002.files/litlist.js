function showlitlist(qq){
var ImgWin;
if (ImgWin ==null || ImgWin.Closed)
{ImgWin=window.open("", "litlistWwin", "height=200,width=500,resizable=1,scrollbars=1")};
 ImgWin.document.open(); 
 ImgWin.document.clear('');
 ImgWin.document.write("<HTML><HEAD>");
 ImgWin.document.write('<META http-equiv="Content-Type" content="text/html; charset=windows-1251">');
 ImgWin.document.write('<link rel="stylesheet" type="text/css" href="files/main.css">');
 ImgWin.document.write('<meta http-equiv="Content-Language" content="ru">')
 ImgWin.document.write("<TITLE>");
 ImgWin.document.write("список источников литературы");
 ImgWin.document.write("</TITLE></HEAD>");
 ImgWin.document.write('<BODY CLASS="источники">');
 ImgWin.document.write("<center>");
 ImgWin.document.write("<table cellspacing=2 cellpadding=2 width=100% border=0>");
for (i=0; i<(qq.length/2); i++){
 if (i>0) {ImgWin.document.write("<tr><td colspan=2 bgcolor=gray height=1/></tr>");}; 
 ImgWin.document.write("<tr><td>"+qq[i*2]+"</td><td>"+qq[i*2+1]+"</td></tr>");};
 ImgWin.document.write("</table>");
 ImgWin.document.write("</center>");
 ImgWin.document.write("</BODY></HTML>");
 ImgWin.focus();
 window.status=('готово');
}