//Первое задание
function func1() {
	alert("Вас приветсвует учебный центр");
	let name = prompt("Введите, пожалуйства, Ваше имя");
	let choice = confirm("Хотите стать Web-дизайнером?");
	if (choice)
	    alert(name + ", учите CSS и JS")
	else
	    alert("Упускаете время")
}
//Второе задание
function func2() {
	let temp = 10 + 5;
	document.getElementById('output').innerHTML = 10 + 5 + " <br>";
	document.getElementById('output').innerHTML += "10" + "5" + "<br>";
	document.getElementById('output').innerHTML += "10" + 5 + "<br>";
	document.getElementById('output').innerHTML += 5 + "10" + '<br>';
	alert("Результатом сложения строки и числа всегда будет строка");
}

//Третье задание
function func3() {
	let x = 2, y = 34553;
	let num1 = (35*y-25*x)/5+232;
	let num2 = (8*y/x+5*x/y-43)*6;
	alert(num2 % num1);
	document.getElementById('output').innerHTML = "Первое выражеие равно: " + num1 + "<br>" + "Второе выражение равно: " + num2 + "<br>";
	document.getElementById('output').append("Остаток от деления: " + num2 % num1);
	alert(num1);
	alert(num2);
}

//Четвертое задание
function func4(){
let num = prompt("Введите число");
if (num == 15 || (num > 44 && num <= 4958 && num % 3 == 0))
	alert("Правильное значение");
else
	alert("Неправильное значение");
}

//Пятое задание
function func5(){
	num1 = prompt("Введите первое число");
	num2 = prompt("Введите второе число");

	if (num1 > num2)
		alert("Первое чило больше второго");
	else if (num2 > num1)
		alert("Второе число больше первого");
	else
		alert("Числа равны");

	let years = prompt("Сколько Вам лет?");
	years >= 18 ? alert("Добро пожаловать!") : alert("До свидания!");
}
//Шестое задание
function func6(){
let now = new Date();
let day = now.getDay();
switch (day){
		case 1: 
			alert("Сегодня понедельник");
			break;
		case 2: 
			alert("Сегодня вторник");
			break;
		case 3: 
			alert("Сегодня среда");
			break;
		case 4: 
			alert("Сегодня четверг");
			break;
		case 5: 
			alert("Сегодня пятница");
			break;
		case 6: 
			alert("Сегодня суббота");
			break;
		case 0: 
			alert("Сегодня воскресенье");
			break;	
	}
}
//Седьмое задание
function func7() {
	try {
		num1 = prompt("Введите первое число");
		num2 = prompt("Введите второе число");
		if (num2 == 0)
			throw "DivisionByZero";
		else 
			document.getElementById('output').innerHTML = num1 / num2;
	}
	catch (e) {
		console.log("ERROR: " + e);
	}
}