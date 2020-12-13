$(function(){

//Первое задание
$("#span1").mouseover(function(){
	$("#span1").css("color", "red");
});

//Второе задание
$("#span2").click(function(){
	$("#span2").css("font-size", "20px");
});

//Третье, четвертое и пятое задание
$("#span3").click(function(){
	$("#span3").parent().html('<img id="third" style="left: 50px; position: relative;" src="images/1.jpg" alt="" onmouseover="this.classList.toggle(\'big\')" onmouseout="this.classList.toggle(\'big\')">');

	$("#third").click(function (){
		if($(this).attr("src") == "images/1.jpg")
			$(this).attr("src", "images/2.jpg");
		else
			$(this).attr("src", "images/1.jpg");
			
});
});

//Пятое задание
let p = document.querySelector("#secondPar");
$("#secondPar").dblclick(function (){
	$(this).css("border", "solid black 3px");
	$(this).css("borderLeft", "solid 3px red");
	$(this).css("borderRight", "solid 3px red");
});
});