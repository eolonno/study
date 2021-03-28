use An_MyBase

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
	from Преподаватели join Группы 
	on Преподаватели.[Номер группы] = Группы.[Номер группы]

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
	from Преподаватели join Группы 
	on Преподаватели.[Номер группы] = Группы.[Номер группы] and Группы.Специальность like '%и%'

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
	from Преподаватели, Группы 
	where Преподаватели.[Номер группы] = Группы.[Номер группы]

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
	from Преподаватели, Группы 
	where Преподаватели.[Номер группы] = Группы.[Номер группы] and Группы.Специальность like '%и%'

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Преподаватели.Стаж, Курсы.Предмет, 
	case
	when (Курсы.Оплата < 600) then 'Low price'
	when (Курсы.Оплата between 600 and 700) then 'Middle price'
	when (Курсы.Оплата > 700) then 'High price'
	end [Ценовая категория]
	from Группы join Преподаватели  on Группы.[Номер группы] = Преподаватели.[Номер группы]
	join Курсы on Группы.[Код курса] = Курсы.[Код курса]
	order by Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество

select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Преподаватели.Стаж, Курсы.Предмет, 
	case
	when (Курсы.Оплата < 600) then 'Low price'
	when (Курсы.Оплата between 600 and 700) then 'Middle price'
	when (Курсы.Оплата > 700) then 'High price'
	end [Ценовая категория]
	from Группы join Преподаватели  on Группы.[Номер группы] = Преподаватели.[Номер группы]
	join Курсы on Группы.[Код курса] = Курсы.[Код курса]
	order by 
	(case 
		when(Курсы.Оплата < 600) then 3
		when (Курсы.Оплата between 600 and 700) then 1
		else 2
		end
	)

--Удаление фамилии для демонстрации
alter table Преподаватели alter column Фамилия nvarchar(20) NULL;
update Преподаватели set Фамилия = NULL where Фамилия = 'Жжёнова'

select Группы.[Номер группы], isnull(Преподаватели.Фамилия, '***')[Фамилия]
	from Группы left outer join Преподаватели
	on Группы.[Номер группы] = Преподаватели.[Номер группы]

select Группы.[Номер группы], isnull(Преподаватели.Фамилия, '***')[Фамилия]
	from Преподаватели right outer join Группы
	on Группы.[Номер группы] = Преподаватели.[Номер группы]

--8 задание
create table AUTHORS(
	ID int NOT NULL,
	AUTHOR nvarchar(40)
)

create table BOOKS(
	AUTHORID int NOT NULL,
	BOOK nvarchar(40)
)

insert into BOOKS(BOOK, AUTHORID) values
	('book1', 1),
	('book2', 2),
	('book3', 5),
	('book4', 7)

insert into AUTHORS(AUTHOR, ID) values
	('author1', 1),
	('author2', 8),
	('author3', 2),
	('author4', 12)

select BOOKS.AUTHORID, BOOKS.BOOK
	from BOOKS full outer join AUTHORS
	on AUTHORS.ID = BOOKS.AUTHORID
	where BOOKS.AUTHORID is NOT NULL

select AUTHORS.ID, AUTHORS.AUTHOR
	from BOOKS full outer join AUTHORS
	on AUTHORS.ID = BOOKS.AUTHORID
	where AUTHORS.ID is NOT NULL

select *
	from BOOKS full outer join AUTHORS
	on AUTHORS.ID = BOOKS.AUTHORID

drop table BOOKS
drop table AUTHORS

--9 задание
select Группы.[Номер группы], Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Группы.Специальность 
	from Преподаватели cross join Группы 
	where Преподаватели.[Номер группы] = Группы.[Номер группы]