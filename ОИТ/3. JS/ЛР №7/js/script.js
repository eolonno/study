let form = document.querySelector("form");
let button = document.querySelector("#print");

button.onclick = function print(event){
	event.preventDefault();
	let faculty = form.querySelector("textarea").value;
	let lastName = form.querySelector("#lastName").value;
	let name = form.querySelector("#name").value;
	let specialty = form.specialty.value;
	let course = form.course.value;
	let subjects = {};
	let counter = 0;
	for (let i = 0; i < form.subjects.length; i++) {
		if(form.subjects[i].checked){
			subjects[counter] = form.subjects[i].value;
			counter++;
		}
	}

	document.write("<h4>" + faculty + "</h4>" + "Студент " + lastName + " специальность " + specialty + " курс " + course + " должен сдавать следующие предметы:<br>");
	let ul = document.createElement("ul");
	for (var i = 0; i < counter; i++){
		ul.appendChild(document.createElement("li")).innerHTML = subjects[i];
	}

	document.body.appendChild(ul);


	//Четвертое задание
	let secondForm = document.createElement("form");
	let select =  secondForm.appendChild(document.createElement("select"));
	for (let i = 0; i < counter; i++) {
		select.appendChild(document.createElement("option")).innerHTML = subjects[i];
	}
	document.body.appendChild(secondForm);
}
