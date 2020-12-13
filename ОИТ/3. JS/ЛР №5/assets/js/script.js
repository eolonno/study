//Первое задание
for (let i = 0; i < document.all.length; i++){
    console.log("Тэг номер " + (i + 1) + ": " + document.all[i].tagName);    
}

//Второе задание
for(let i = 0; i < document.body.childNodes.length; i++){
	console.log(document.body.childNodes[i]);
}

//Третье задание
//Первый подпункт
for(let i = 0; i < document.all.length; i++){
	if(document.all(i).tagName == "SPAN")
		{
			console.log(document.all(i));
			break;
		}
}

//Второй подпункт
console.log(document.querySelectorAll("span")[0]);

//Третий подпункт
console.log(document.getElementById("first"));

//Четвертое задание
let table = document.getElementById("table");
let avg = 0;
for(let i = 3; i < 8; i ++){
	avg += Number(table.rows[i].cells[2].innerHTML);
}

document.getElementById("second").innerHTML += ", средний балл: " + (avg / 5);