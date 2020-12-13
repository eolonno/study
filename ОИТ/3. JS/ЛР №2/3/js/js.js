let table = document.createElement("table");
let a = 1;
let b = 5;
let tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = "Радиус";
tr.appendChild(document.createElement('td')).innerHTML = "Площадь круга";
tr.appendChild(document.createElement('td')).innerHTML = "Длина окружности";

do {
	tr = table.appendChild(document.createElement('tr'));
	tr.appendChild(document.createElement('td')).innerHTML = a.toFixed(1);
	tr.appendChild(document.createElement('td')).innerHTML = Math.round(Math.PI * Math.pow(a, 2));
	tr.appendChild(document.createElement('td')).innerHTML = Math.round(Math.PI * 2 * a)
	a += 0.3;
} while(a <= b)

document.body.append(table);