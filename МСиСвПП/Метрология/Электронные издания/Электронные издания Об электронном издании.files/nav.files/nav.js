
var maxch = 10;
var currch = -1;
var htimer = null;

function widthclick(d)
{if (parent!=null && parent.frames['main']!=null && parent.frames['main'].sa!=null)
{ var tg = parent.frames['main'].sa;
 x = tg.style.width;
 y = parseInt( x.substring( 0, x.length-2 ) );
 y += d;
 tg.style.width = y;
 setCookie( "tabw", y );
}}

function setImgSrc(AImg, ASrc)
{ var l = AImg.src.length-ASrc.length;
  if (l<0 || AImg.src.substr(l)!=ASrc) {AImg.src=ASrc};
}

function updatenav()
{ var tg = parent.frames['main'];
  var imgs = ['files/nvfirst.gif','files/nvprev.gif','files/nvnext.gif','files/nvlast.gif'];

 if (tg==null || tg.chnum==null || tg.chnum==1){imgs[0]='files/nvfirst-.gif';imgs[1]='files/nvprev-.gif'}
 if (tg==null || tg.chnum==null || tg.chnum==maxch){imgs[3]='files/nvlast-.gif';imgs[2]='files/nvnext-.gif'}

 if (tg!=null && tg.chnum!=null){currch=tg.chnum} else {currch=-1};
 setImgSrc(nvfirst,imgs[0]);
 setImgSrc(nvprev ,imgs[1]);
 setImgSrc(nvnext ,imgs[2]);
 setImgSrc(nvlast ,imgs[3]);
}

function gonav(dest)
{ var tg = parent.frames['main'];
  var ndest = new String('000'+dest);
  var img = event.srcElement;
  if (img.src.lastIndexOf('-.gif')<0 && tg!=null) 	{ndest=ndest.substr(ndest.length-3);tg.location.href='part-'+ndest+'.htm';}
}

function doonclose()
{ if (htimer){clearInterval(htimer)}}
