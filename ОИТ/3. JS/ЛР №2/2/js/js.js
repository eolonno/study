let table = document.createElement('table');
let a = prompt("Введите первое число");
let b = prompt("Введите второе число");

for(let i = 0; i <= a; i++){
	tr = table.appendChild(document.createElement('tr'));
	for (j = 0; j <= b; j++) {
	    td = tr.appendChild(document.createElement('td'));
	    if(i==0)
	    	td.append(j);
	    else if (j==0)
	    	td.append(i);
	    else
	    	td.append(i*j);
	}
}
document.body.append(table);
