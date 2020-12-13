let img = document.querySelector("img"),
	left = 100;


setInterval(road, 10);
function road(){
	img.style.left = left + "vw";
	left--;
	if(left == -100)
		left = 100;
}

