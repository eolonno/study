function openimgindex(imgname,imgtitle,foncolor,altimgname){
var ImgWin = null;
if (ImgWin ==null || ImgWin.Closed)
{ImgWin=window.open("", "ImgWwin", "height=200,width=180,scrollbars=1,resizable=1")};
 ImgWin.document.open();
 ImgWin.document.writeln("<HTML>");
 ImgWin.document.writeln("<head>");
 ImgWin.document.writeln("<TITLE>");
 ImgWin.document.writeln("иллюстрация: "+imgtitle);
 ImgWin.document.writeln("</TITLE>");

 ImgWin.document.writeln("<script>");


 ImgWin.document.writeln("function upd()");
 ImgWin.document.writeln("{var wH;");
 ImgWin.document.writeln(" var wW;");
 ImgWin.document.writeln(' var atit = "'+imgtitle+'"');
 ImgWin.document.writeln(" var wimg = ill;");

 ImgWin.document.writeln("if (wimg.complete) { wW=wimg.width+50;");
 ImgWin.document.writeln("           if (wW<200) {wW=200};");
 ImgWin.document.writeln("           wH=(atit.length / (wW/16)+2)*30+wimg.height+20;");
 ImgWin.document.writeln("           if (wH>screen.height*0.7) {wH=screen.height*0.7};");
 ImgWin.document.writeln("           if (wW>screen.width*0.7) {wW=screen.width*0.7};");
 ImgWin.document.writeln("           window.resizeTo(wW,wH);");
 ImgWin.document.writeln("           vtit.innerHTML=atit;"); 
 ImgWin.document.writeln("           focus();");
 ImgWin.document.writeln("          }");
 ImgWin.document.writeln("else {setTimeout('upd()',100);}");
 ImgWin.document.writeln("}");
 ImgWin.document.writeln("window.status='загружается изображение "+imgname+"';");
 ImgWin.document.writeln("</script>");

 ImgWin.document.writeln("</head>");
 ImgWin.document.writeln('<body bgcolor="'+foncolor+'" onload="upd()">');
 ImgWin.document.writeln("<center>");
 ImgWin.document.writeln("<table id=tit cellspacing=0 cellpadding=0 width='100%'>");
 ImgWin.document.writeln("<caption><font face='verdana' size='2'><span id=vtit>загружается изображение <br/><i>"+imgtitle+"</i></span></font></caption>");
 ImgWin.document.writeln("</table><br/>");
 ImgWin.document.writeln('<table id="img" cellspacing="0" cellpadding="0" width="100%"" >');
 ImgWin.document.writeln('<tr><td  align=center>');
 ImgWin.document.write('<img id="ill" src="'+imgname+' " border="0"  onload="upd()" ' );
 if (altimgname!=null && altimgname!='') 
    { 
       ImgWin.document.write(' onerror="this.src='); 
       ImgWin.document.write("'"+altimgname+"'"); 
       ImgWin.document.write(' " ');
    } 
 ImgWin.document.write(' /> </td> </tr>');
 ImgWin.document.write('</table>');
 ImgWin.document.write('</center>');
 ImgWin.document.write('<div id=dv />');
 ImgWin.document.write('</body>');
 ImgWin.document.write('</HTML>');
 window.status=('готово');
return false;
}