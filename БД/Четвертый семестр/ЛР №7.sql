use An_MyBase;

--1 задание
select min(Курсы.Оплата)[Минимальная цена курса],
		max(Курсы.Оплата)[Максимальная цена курса],
		count(Курсы.Оплата)[Кол-во курсов],
		sum(Курсы.Оплата)[Сумма стомостей всех курсов]
	from Курсы;

--2 задание
--Статистика по студентам в группах, которые ходят в лекционные и практические аудитории
select Курсы.[Тип занятия],
		min(Группы.[Количество студентов])[Минимальное кол-во студентов],
		max(Группы.[Количество студентов])[Максимальное кол-во студентов],
		avg(Группы.[Количество студентов])[Среднее кол-во студентов]
	from Группы join Курсы
	on Группы.[Код курса] = Курсы.[Код курса]
	group by Курсы.[Тип занятия];

--3 задание
--Поделить курсы по ценовой категории и вывести кол-во курсов в каждой категории
select * from (select case when Оплата > 700 then 'High price'
				when Оплата between 600 and 700 then 'Middle price'
				else 'Low price'
				end [Ценовые категории], count(*)[Количество]
				from Курсы group by case
				when Оплата > 700 then 'High price'
				when Оплата between 600 and 700 then 'Middle price'
				else 'Low price'
				end) as T
	order by case [Ценовые категории]
	when 'High price' then 1
	when 'Middle price' then 2
	else 3
	end;

--4 задание
--Средний стаж по группе
select Группы.[Номер группы], Группы.Специальность, avg(Стаж)[Средний стаж]
	from Группы inner join Преподаватели on Группы.[Номер группы] = Преподаватели.[Номер группы]
	group by Группы.[Номер группы], Группы.Специальность;

--То же самое, но только для ИСиТ и ЦАИ
select Группы.[Номер группы], Группы.Специальность, avg(Стаж)[Средний стаж]
	from Группы inner join Преподаватели on Группы.[Номер группы] = Преподаватели.[Номер группы]
	where Специальность in ('ЦАИ', 'ИСиТ')
	group by Группы.[Номер группы], Группы.Специальность;

--5 задание
--ROLLUP
select Группы.[Номер группы], Группы.Специальность, avg(Стаж)[Средний стаж]
	from Группы inner join Преподаватели on Группы.[Номер группы] = Преподаватели.[Номер группы]
	group by rollup (Группы.[Номер группы], Группы.Специальность);

--CUBE
select Группы.[Номер группы], Группы.Специальность, avg(Стаж)[Средний стаж]
	from Группы inner join Преподаватели on Группы.[Номер группы] = Преподаватели.[Номер группы]
	group by cube (Группы.[Номер группы], Группы.Специальность);

--7 задание
--Сумма стажей первой и второй группы
select Преподаватели.[Номер группы], avg(Преподаватели.Стаж)[Средний стаж]
	from Преподаватели
	where [Номер группы] = 1
	group by [Номер группы]
UNION
select Преподаватели.[Номер группы], avg(Преподаватели.Стаж)[Средний стаж]
	from Преподаватели
	where [Номер группы] = 2
	group by [Номер группы]

--8 задание
--INTERSECT
select Группы.Специальность from Группы
intersect select Курсы.Предмет from Курсы

--9 задание
--EXCEPT
select Группы.Специальность from Группы
except select Курсы.Предмет from Курсы

--10 задание
--HAVING
select * from (select Курсы.[Код курса], COUNT(Фамилия)Количество from Преподаватели join Группы 
							on Преподаватели.[Номер группы] = Группы.[Номер группы] join Курсы
							on Курсы.[Код курса] = Группы.[Код курса]
							group by Курсы.[Код курса]
							having Курсы.[Код курса] >= 3) as T;

--12 задание
use TMPAN_UNIVER;

--Подсчитать кол-во студентов в каждой группе, на каждом факультете и всего в университете
select * from (select GROUPS.IDGROUP, COUNT(*)[COUNT GROUP] from STUDENT join GROUPS
	on STUDENT.IDGROUP = GROUPS.IDGROUP
	group by GROUPS.IDGROUP) as T,
(select GROUPS.FACULTY, COUNT(*)[COUNT FACULTY] from STUDENT join GROUPS
	on STUDENT.IDGROUP = GROUPS.IDGROUP
	group by GROUPS.FACULTY) as T1,
(select COUNT(*)[COUNT UNIVER] from STUDENT) as T2;

--Подсчитать кол-во аудиторий по типам и суммарной вместимости в корпусах
select * from
	(select AUDITORIUM_TYPE, COUNT(*)[COUNT] from AUDITORIUM 
		group by AUDITORIUM_TYPE) as S