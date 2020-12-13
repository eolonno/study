//Первое задание
alert("Вас приветсвует учебный центр");
let name = prompt("Введите, пожалуйства, Ваше имя");
let choice = confirm("Хотите стать Web-дизайнером?");
if (choice)
    alert(name + ", учите CSS и JS")
else
    alert("Упускаете время")

//Второе задание
document.write(10+5, "<br>");
document.write("10"+"5", "<br>");
document.write("10"+5, "<br>");
document.write(5+"10", "<br>");
alert("Результатом сложения строки и числа всегда будет строка");
document.write("<br><br>");

//Третье задание
let x = 2, y = 34553;
let num1 = (35*y-25*x)/5+232;
let num2 = (8*y/x+5*x/y-43)*6;
document.write(num2 % num1, "<br>");
alert(num2 % num1);
document.write("Первое выражеие равно: " + num1 + "<br>" + "Второе выражение равно: " + num2 + "<br>");
alert(num1);
alert(num2);

//Четвертое задание
let num = prompt("Введите число");
if (num == 15 || (num > 44 && num <= 4958 && num % 3 == 0))
	alert("Правильное значение");
else
	alert("Неправильное значение");

//Пятое задание
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

//Шестое задание
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

//Седьмое задание
try {
	num1 = 17;
	num2 = 0;
	if (num2 == 0)
		throw "DivisionByZero";
	else 
		document.write(num1 / num2);
}
catch (e){
	console.log("ERROR: " + e);
}
