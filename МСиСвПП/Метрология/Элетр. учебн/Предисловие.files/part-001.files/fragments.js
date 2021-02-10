var currDest = null;
var currH = -1;
var vifr = null;
function currCheck()
	{ if (vifr==null) {vifr=window.frames['ifr']}
	  if (!vifr){alert('не найден irf')};
	  if (vifr && currDest) 
		{setTimeout('currCheck()',10);
		  if (currH<0) {vifr.location=currDest.src;currH=77777777;}
		   else { if (vifr.document && vifr.document.body)
				{vifr.scrollTo(10000,10000);
	                          H=vifr.document.body.scrollTop+vifr.document.body.offsetHeight;
				  if (H!=currH) {currH=H}
				        else{ if (H<20){H=300};
						ss='<iframe  id="'+currDest.id+'frm" width="100%" height="'+H+
						'" src="'+currDest.src+'" frameborder="0"> </iframe> ';
						currDest.innerHTML=ss;
						currDest=null;
						vifr.document.open();
					     }
				}}
	        }
        };


	function loadFragment(adest,ext)
	{if (ext)
		{window.open(adest.src, "FragWwin", "height=400,width=600,scrollbars=1,resizable=1").focus()}
 	        else {if (adest && !currDest){currDest=adest; currH=-1; setTimeout('currCheck()',10)}};
	return false;
	};


	function checkFragment()
	{
         if (currFrag<fragments.length)
              { setTimeout("checkFragment()",10);
                if (currDest==null)
                  { nm=fragments[currFrag];
                   currDest=document.all[nm];
                   currH=-1;
		   currFrag=currFrag+1;
		   setTimeout("currCheck()",10);}
              }
       };
