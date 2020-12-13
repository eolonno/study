function draw(){
	event.preventDefault();

	//Удаление старого холста
	if($("canvas"))
		$("canvas").remove();
	if($("divY"))
		$("#divY").remove();
	if($("#divX"))
		$("#divX").remove();
	
	let canvas = document.createElement("canvas"),
		graph = event.target.graph.value,
		color = $("#select").value,
		y,
		ctx = canvas.getContext('2d');

	document.body.appendChild(canvas);
	canvas.width = 700;
	canvas.height = 400;
	$("canvas").css({"position" : "absolute", "top" : "40px"});
	$("canvas").attr("id", "canvas");

	//Нанесение описания системы координат
	$("body").append("<div>");
	$("body").append("<div>");

	$("div:first").attr("id", "divY");
	$("div:last").attr("id", "divX");

	$("#divY").text("Y");
	$("#divX").text("X");
	$("#divX").css({"position" : "absolute", "font-size" : "15px", "top" : $("canvas").height() / 2 + 50 + "px", "left" : $("canvas").width() - 10 + "px"});
	$("#divY").css({"position" : "absolute", "font-size" : "15px", "top": "40px", "left" : $("canvas").width() / 2 + 20 + "px"});

	//Нанесение системы координат
	ctx.lineWidth = 1;
	ctx.strokeStyle = "black";
	ctx.moveTo($("canvas").width() / 2 - 0.5, 0);
	ctx.lineTo($("canvas").width() / 2 - 0.5, $("canvas").height());
	ctx.moveTo(0, $("canvas").height() / 2 - 0.5);
	ctx.lineTo($("canvas").width(), $("canvas").height() / 2 - 0.5);

	ctx.moveTo($("canvas").width() / 2 - 0.5, 0);
	ctx.lineTo($("canvas").width() / 2 - 5.5, 10.5);
	ctx.moveTo($("canvas").width() / 2 - 0.5, 0);
	ctx.lineTo($("canvas").width() / 2 + 5.5, 10.5);

	ctx.moveTo($("canvas").width(), $("canvas").height() / 2 - 0.5);
	ctx.lineTo($("canvas").width() - 10.5, $("canvas").height() / 2 - 5.5);
	ctx.moveTo($("canvas").width(), $("canvas").height() / 2 - 0.5);
	ctx.lineTo($("canvas").width() - 10.5, $("canvas").height() / 2 + 5.5);

	ctx.stroke();

	ctx.fillStyle = color;//Выбор цвета

	//Черчение самого графика
	for(let x = -$("canvas").width() / 2; x < $("canvas").width() / 2; x += 0.01)
	{
		y = $("canvas").height() / 2 - 40 * eval(graph);
		ctx.fillRect(x + $("canvas").width() / 2 - 0.5, y - 0.5, 1, 1);
	}
}