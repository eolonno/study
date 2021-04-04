use TMPAN_UNIVER

--1 задание
create view Преподаватель
	as select TEACHER [Код], TEACHER_NAME [Имя преподавателя], GENDER [Пол], PULPIT [Код кафедры] 
	from TEACHER;

select * from Преподаватель

--2 задание
--Невозможно использовать операторы dml потому что в запросе, на котором основывается представление, есть секция group by, а также используется несколько
--таблиц в секции from
create view [Количество кафедр] 
	as select FACULTY.FACULTY_NAME [Факультет], count(PULPIT.PULPIT_NAME) [Количество кафедр]
	from FACULTY join PULPIT 
	on FACULTY.FACULTY = PULPIT.FACULTY
	group by FACULTY.FACULTY_NAME;

select * from [Количество кафедр]

--3 задание
create view Аудитории 
	as select AUDITORIUM [Код], AUDITORIUM_NAME [Наименование аудитории]
	from AUDITORIUM
	where AUDITORIUM_TYPE like 'ЛК%'

select * from Аудитории

--Не будет виден в представлении Аудитории, так как они не обозначены как лекционные, однако эти значения добавляются в таблицу AUDITORIUM
insert Аудитории values ('214-2', '214-2')

--4 задание
create view Лекционные_аудитории
	as select AUDITORIUM [Код], AUDITORIUM_NAME [Наименование аудитории]
	from AUDITORIUM
	where AUDITORIUM_TYPE like 'ЛК%' with check option

--Невозможно выполнить, так как мы не контролируем столбец AUDITORIUM_TYPE, который должен начинаться с ЛК для вставки строки в данное представление.
--Чтобы выполнять вставку нужно добавить столбец AUDITORIUM_TYPE в представление
insert Лекционные_аудитории (Код, [Наименование аудитории]) values ('123-4', '123-4')

--5 задание
create view Дисциплины
	as select TOP 10 SUBJECT [Код], SUBJECT_NAME [Наименование дисциплины], PULPIT [Код кафедры]
	from SUBJECT
	order by SUBJECT_NAME

select * from Дисциплины

--6 задание
alter view [Количество кафедр] with SCHEMABINDING
	as select FACULTY.FACULTY_NAME [Факультет], count(PULPIT.PULPIT_NAME) [Количество кафедр]
	from dbo.FACULTY join dbo.PULPIT 
	on FACULTY.FACULTY = PULPIT.FACULTY
	group by FACULTY.FACULTY_NAME;

select * from [Количество кафедр]

--7 задание
use An_MyBase

create view Категории
	as select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Преподаватели.Стаж, Курсы.Предмет, 
		case
		when (Курсы.Оплата < 600) then 'Low price'
		when (Курсы.Оплата between 600 and 700) then 'Middle price'
		when (Курсы.Оплата > 700) then 'High price'
		end [Ценовая категория]
		from Группы join Преподаватели  on Группы.[Номер группы] = Преподаватели.[Номер группы]
		join Курсы on Группы.[Код курса] = Курсы.[Код курса]

select * from Категории

create view ПредставлениеxD
	as select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
		from Преподаватели, Группы 
		where Преподаватели.[Номер группы] = Группы.[Номер группы] and Группы.Специальность like '%и%'

select * from ПредставлениеxD

--8 задание
use TMPAN_UNIVER

create view [Кол-во занятий в день недели]
	as select [День недели], [Понедельник], [Вторник], [Среда], [Чертверг], [Пятница], [Суббота]   
		from (select 'Кол-во занятий' as 'День недели', DAYOFWK, LESSON from TIMETABLE) x
		pivot 
		(
			COUNT(LESSON) for DAYOFWK IN ([Понедельник], [Вторник], [Среда], [Чертверг], [Пятница], [Суббота])
		) pvt

select * from [Кол-во занятий в день недели]
