use TMPAN_UNIVER

create table TIMETABLE (
	BUNCH int,
	AUDITORIUM nvarchar(5),
	LESSONTYPE nvarchar(20),
	LESSON nvarchar(50),
	TEACHER nvarchar(50),
	DAYOFWK nvarchar(50) NOT NULL
)

insert into TIMETABLE values
	(1, '206-1', 'ЛБ-К', 'БД', 'Акунович Станислав Иванович', 'Четверг'),
	(2, '236-1', 'ЛК', 'ДМ', 'Бракович Андрей Игоревич', 'Понедельник'),
	(3, '301-1', 'ЛБ-К', 'ИГ', 'Барановский Станислав Иванович', 'Вторник'),
	(NULL, '206-1', 'ЛК-К', NULL, NULL, 'Понедельник'),
	(NULL, NULL, NULL, NULL, 'Безбородов Владимир Степанович', 'Понедельник'),
	(NULL, NULL, NULL, NULL, 'Бурганская Татьяна Минаевна', 'Понедельник'),
	(1, '206-1', 'ЛБ-К', 'ИНФ', 'Бурганская Татьяна Минаевна', 'Среда'),
	(2, '324-1', 'ЛК-К', 'КМС', 'Акунович Станислав Иванович', 'Понедельник'),
	(3, '301-1', 'ЛБ-К', 'ЛВ', 'Бракович Андрей Игоревич', 'Среда'),
	(NULL, NULL, NULL, NULL, 'Барановский Станислав Иванович', 'Суббота'),
	(NULL, NULL, NULL, NULL, 'Безбородов Владимир Степанович', 'Суббота'),
	(1, '206-1', 'ЛБ-К', 'ЛЭВМ', 'Акунович Станислав Иванович', 'Понедельник'),
	(2, '236-1', 'ЛК', 'БД', 'Безбородов Владимир Степанович', 'Пятница'),
	(3, '301-1', 'ЛБ-К', 'ДМ', 'Бурганская Татьяна Минаевна', 'Четверг'),
	(NULL, NULL, NULL, NULL, 'Барановский Станислав Иванович', 'Вторник'),
	(NULL, NULL, NULL, NULL, 'Бракович Андрей Игоревич', 'Пятница')

select * from TIMETABLE where LESSONTYPE = 'ЛК-К' and BUNCH IS NULL
select * from TIMETABLE where BUNCH IS NULL and AUDITORIUM = '206-1' and DAYOFWK = 'Понедельник'
select * from TIMETABLE where TEACHER = 'Безбородов Владимир Степанович' and BUNCH IS NULL
select * from TIMETABLE



