use University

insert into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE, FOTO) 
	select 'Амбразевич Владимир Сергеевич', 'Программное обеспечение информационных технологий', 23, '04-06-2000', 2, 'м', 8.0, BulkColumn
	from OpenRowSet(bulk N'C:\D\БГТУ\2курс\Zrla\2_2 Mark\ООП\Labs\OOP-labs-4-sem-master\8\Lab7\Foto\Vova.jpg', single_blob) as Файл;
insert into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE, FOTO) 
	select 'Чистякова Юлия Алекандровна', 'Программное обеспечение информационных технологий', 20, '10-07-1998', 2, 'ж', 8.0, BulkColumn
	from OpenRowSet(bulk N'C:\D\БГТУ\2курс\Zrla\2_2 Mark\ООП\Labs\OOP-labs-4-sem-master\8\Lab7\Foto\Julia.jpg', single_blob) as Файл;
insert into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE, FOTO) 
	select 'Докурно Вадим Сергеевич', 'Информационные системы и технологии', 19, '12-07-1997', 3, 'м', 7.0, BulkColumn
	from OpenRowSet(bulk N'C:\D\БГТУ\2курс\Zrla\2_2 Mark\ООП\Labs\OOP-labs-4-sem-master\8\Lab7\Foto\Dokurno.jpg', single_blob) as Файл;
insert into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE, FOTO) 
	select 'Каспер Наталья Викторовна', 'Дизайн электронных и веб-изданий', 18, '12-02-2000', 2, 'ж', 7.5, BulkColumn
	from OpenRowSet(bulk N'C:\D\БГТУ\2курс\Zrla\2_2 Mark\ООП\Labs\OOP-labs-4-sem-master\8\Lab7\Foto\Kasper.jpg', single_blob) as Файл;

insert into [Address](StudentID, Town, [Index], Street, House, Flat) values
(100, 'Минск', 220006, 'Бобруйская', 21, 404),
(101, 'Минск', 220006, 'Белорусская', 21, 404),
(102, 'Минск', 220052, 'Гурского', 21, 312),
(103, 'Минск', 220006, 'Белорусская', 21, 710)


select * from Student
select * from [Address]


--drop table [Address]
--drop table Student