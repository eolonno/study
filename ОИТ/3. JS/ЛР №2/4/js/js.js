let table = document.createElement("table");
let a = new Number('14');
let b = new Number(Math.PI);

let tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = "Число";
tr.appendChild(document.createElement('td')).innerHTML = "Метод";
tr.appendChild(document.createElement('td')).innerHTML = "Результат";
tr.appendChild(document.createElement('td')).innerHTML = "Описание метода";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = a;
tr.appendChild(document.createElement('td')).innerHTML = "toExponential(3)";
tr.appendChild(document.createElement('td')).innerHTML = a.toExponential(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число в экспоненциальной форме";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = b;
tr.appendChild(document.createElement('td')).innerHTML = "toExponential(3)";
tr.appendChild(document.createElement('td')).innerHTML = b.toExponential(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число в экспоненциальной форме";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = a;
tr.appendChild(document.createElement('td')).innerHTML = "toFixed(3)";
tr.appendChild(document.createElement('td')).innerHTML = a.toFixed(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число в форме с фиксированным количеством цифр после точки";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = b;
tr.appendChild(document.createElement('td')).innerHTML = "toFixed(3)";
tr.appendChild(document.createElement('td')).innerHTML = b.toFixed(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число в форме с фиксированным количеством цифр после точки";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = a;
tr.appendChild(document.createElement('td')).innerHTML = "toPrecision(3)";
tr.appendChild(document.createElement('td')).innerHTML = a.toPrecision(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число с заданным общим количеством значащих цифр";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = b;
tr.appendChild(document.createElement('td')).innerHTML = "toPrecision(3)";
tr.appendChild(document.createElement('td')).innerHTML = b.toPrecision(3);
tr.appendChild(document.createElement('td')).innerHTML = "Представляет число с заданным общим количеством значащих цифр";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = a;
tr.appendChild(document.createElement('td')).innerHTML = "toString(3)";
tr.appendChild(document.createElement('td')).innerHTML = a.toString(3);
tr.appendChild(document.createElement('td')).innerHTML = " Возвращает строковое представление числа в системе счисления с указанным основанием";

tr = table.appendChild(document.createElement('tr'));
tr.appendChild(document.createElement('td')).innerHTML = b;
tr.appendChild(document.createElement('td')).innerHTML = "toString(3)";
tr.appendChild(document.createElement('td')).innerHTML = b.toString(3);
tr.appendChild(document.createElement('td')).innerHTML = " Возвращает строковое представление числа в системе счисления с указанным основанием";

document.body.append(table);