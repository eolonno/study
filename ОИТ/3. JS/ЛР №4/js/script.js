//Первое задание
function Gruppa(num, speciality, amount) {
	//Свойства(номер, специальность, количество)
	this.num = num;
	this.speciality = speciality;
	this.amount = amount;

	//Метод (добавить в группу k студентов)
	this.add_stud = function add_stud(k) {
		this.amount += k;
		document.write('В группу №' + this.num + ' добавили ' + k + ' студента(ов).<br>');
	}
	//Отчисление студентов
	this.sub_stud = function sub_stud(k){
		this.amount -= k;
		document.write('Из группы №' + this.num + ' отчислили ' + k + ' студента(ов).<br>')
	}
 }

let isit2 = new Gruppa(2, 'ИСиТ', 30);
isit2.add_stud(3);
isit2.sub_stud(4);
let poit5 = new Gruppa(5, 'ПОИТ', 30);
poit5.add_stud(1);
poit5.sub_stud(3);
console.log(isit2);
console.log(poit5);
document.write('<br><br>');

//Второе задание
function Student(name, second_name, physics, math, informatics, biology){
	this.name = name;
	this.second_name = second_name;
	this.physics = physics;
	this.math = math;
	this.informatics = informatics;
	this.biology = biology;

	this.avg_rating = function avg_rating(){
		document.write('Средний балл студента по имени ' + this.name + ' равен ' + ((this.physics + this.math + this.informatics + this.biology) / 4).toFixed(2) + '<br>');
	}

	this.introduce = function introduce(){
		alert('Фамилия и имя студента ' + this.name + ' ' + this.second_name);
	}

	this.info = function info(){
		document.write('Иформация о студенте:<br>' + 'Фамилия: ' + this.second_name + '<br>Имя: ' + this.name + '<br>Оценка по физике: ' + this.physics + '<br>Оценка по математике: ' + this.math + '<br>Оценка по информатике: ' + this.informatics + '<br>Оценка по биологии: ' + this.biology + '<br>');
	}
}

let stud1 = new Student('Егор', 'Аникеенко', 8, 9, 10, 8);
let stud2 = new Student('Даниил', 'Вощук', 10, 10, 10, 9);
let stud3 = new Student('Иван', 'Барановский', 9, 10, 10, 9);

stud1.info();
stud1.avg_rating();
document.write('<br>');
stud2.info();
stud2.avg_rating();
document.write('<br>');
stud3.info();
stud3.avg_rating();
document.write('<br>');

//Третье задание
let arr = [1, 2, 3, 4, 5, 6];
console.log(arr);
delete arr[2];
console.log(arr);

console.log(1 in arr);
console.log('add_stud' in Gruppa);
console.log('chemistry' in Student);

console.log(arr instanceof Array);
console.log(stud1 instanceof Object);
console.log(isit2 instanceof String);

function return5(){
	return 5;
}

console.log(typeof Gruppa);
console.log(typeof Gruppa.prototype.name);
console.log(typeof Gruppa.prototype.add_stud);
console.log(typeof Gruppa.prototype.sub_stud);
console.log(typeof isit2.add_stud);
console.log(typeof isit2.sub_stud);
console.log(typeof isit2);
console.log(typeof Student);
console.log(typeof Student.prototype.avg_rating);
console.log(typeof Student.prototype.introduce);
console.log(typeof Student.prototype.info);
console.log(typeof stud1);
console.log(typeof stud1.name);
console.log(typeof stud1.second_name);
console.log(typeof stud1.physics);
console.log(typeof stud1.math);
console.log(typeof stud1.informatics);
console.log(typeof stud1.biology);
console.log(typeof arr);
console.log(typeof return5);
