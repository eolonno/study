//Первое задание
let span1 = document.getElementById("span1");
span1.onmouseover = function(){
	span1.style.color = "red";
}

//Второе задание
let span2 = document.getElementById("span2");
span2.onclick = function(){
	span2.style.fontSize = "20px";
}

//Третье, четвертое и пятое задание
let span3 = document.getElementById("span3");
span3.onclick = function(){
	span3.parentNode.innerHTML = '<img id="third" style="left: 50px; position: relative;" src="images/1.jpg" alt="" onmouseover="this.classList.toggle(\'big\')" onmouseout="this.classList.toggle(\'big\')">';

	let img = document.getElementById("third");

	img.onclick = function (){
		if (img.src == "file:///D:/%D0%A3%D1%87%D0%B5%D0%B1%D0%B0/%D0%9E%D0%98%D0%A2/3.%20JS/%D0%9B%D0%A0%20%E2%84%968/images/1.jpg")
			img.src = "images/2.jpg";
		else 
			img.src = "images/1.jpg";
}
}

//Пятое задание
let p = document.querySelector("#secondPar");
secondPar.ondblclick =  function (event){
	p.style.border = "solid black 3px";
	p.style.borderLeft = "solid 3px red";
	p.style.borderRight = "solid 3px red";
}