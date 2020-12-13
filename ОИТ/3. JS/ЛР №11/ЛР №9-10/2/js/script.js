$(function(){
	setInterval(road, 1500);
	function road(){$("img").animate({"left" : "100vw"}, 0).animate({"left" : "-100vw"}, 1500);}
});