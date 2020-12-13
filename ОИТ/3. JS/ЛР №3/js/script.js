//Первое задание
let arr = [6*Math.pow(Math.PI, 2)+3*Math.exp(8), 2*Math.cos(4)+Math.cos(12)+8*Math.exp(3), 3*Math.sin(9)+Math.log(5)+Math.sqrt(3), 2*Math.tan(5)+6*Math.PI+Math.sqrt(12)];

console.log("Максимальный элемент массива: " + Math.max(...arr) + "\nИндекс максимального элемента массива: " + arr.indexOf(Math.max(...arr)));
console.log("Минимальный элемент массива: " + Math.min(...arr) + "\nИндекс миинмального элемента массива: " + arr.indexOf(Math.min(...arr)));

//Второе задание
arr = ['pow', 'pop', 'push', 'shift', 'round', 'floor', 'sline', 'sort'];
let arrOfMathMethods = [];
let arrOfArrayMethods = [];
for (let i = 0; i < arr.length; i++) {
	if (Math.hasOwnProperty(arr[i])) 
		arrOfMathMethods.push(arr[i]);
	else if (Array.prototype.hasOwnProperty(arr[i]))
		arrOfArrayMethods.push(arr[i]);
}

arrOfArrayMethods.push('reverse');
arrOfMathMethods.push('PI');

console.log("Исходный массив: " + arr);
console.log("Массив с методами массива: " + arrOfArrayMethods);
console.log("Длина массива с методами массива: " + arrOfArrayMethods.length);
console.log("Массив с методами объекта Math: " + arrOfMathMethods);
console.log("Длина массива с методами объекта Math: " + arrOfArrayMethods.length);

//Третье задание
let str = "Аникеенко Егор Вячеславович";
console.log("Длина моего ФИО: " + str.length);
let strInUpperCase = str.toUpperCase();
let strInLowerCase = str.toLowerCase();
let strConcatUpperAndLowerCase = strInUpperCase + strInLowerCase;
let words = str.split(' ');
let FIO = words[0][0] + '. ' + words[1][0] + ". " + words[2][0] + '.';
document.write(str + '<br>' + strInLowerCase + '<br>' + strInUpperCase + '<br>' + strConcatUpperAndLowerCase + '<br>' + FIO);

//Четвертое задание
let date = new Date()
let table = document.createElement('table');
let tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'Год';
tr.appendChild(document.createElement('td')).innerHTML = date.getFullYear();

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'Месяц';
tr.appendChild(document.createElement('td')).innerHTML = date.getMonth()+1;
tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'День';
tr.appendChild(document.createElement('td')).innerHTML = date.getDate();

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'Час';
tr.appendChild(document.createElement('td')).innerHTML = date.getHours();

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'Минуты';
tr.appendChild(document.createElement('td')).innerHTML = date.getMinutes();

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = 'Секунды';
tr.appendChild(document.createElement('td')).innerHTML = date.getSeconds();

document.body.appendChild(table);