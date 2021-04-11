--1 задание 

DECLARE @ch char(10) = 'Hello',
		@varch varchar(10) = 'World!',
		@date datetime,
		@time time,
		@int int,
		@smallint smallint,
		@tinyint tinyint,
		@numeric numeric(12,5);

SET @date = '12-12-2001';
SELECT @time = CONVERT(varchar(10), GETDATE(), 108);
SELECT @int = 13, @smallint = 3, @tinyint = 2;

SELECT @ch 'ch', @varch 'varch', @date 'date', @time 'time';
print(@int);
print(@smallint);
print(@tinyint);
print(@numeric);
GO

--2 задание
USE TMPAN_UNIVER;
DECLARE @capacity int;
SELECT @capacity =  SUM(AUDITORIUM_CAPACITY) FROM dbo.AUDITORIUM;
IF @capacity > 200
	begin
		DECLARE @count int,
				@lowerAvgCount int;
		SELECT @count = COUNT(*) FROM AUDITORIUM;
		SELECT @lowerAvgCount = COUNT(*) FROM AUDITORIUM WHERE AUDITORIUM_CAPACITY < @capacity / @count;
		SELECT @count 'Кол-во аудиторий', @capacity 'Общая вместимость', @capacity / @count 'Средняя вместимость', 
			@lowerAvgCount 'Аудитории, которые вмещают < среднего', CAST(@lowerAvgCount as real) / CAST(@count as real) * 100 'Процент таких аудиторий';
	end
ELSE 
	SELECT COUNT(*) [Общая вместимость аудиторий] FROM AUDITORIUM;
GO

--3 задание
print('Число обработанных строк: ' + cast(@@ROWCOUNT as varchar));
print('Версия SQL Server: ' + cast(@@VERSION as varchar));
print('Системный идентификатор процесса, назначенный сервером текущему подключению: ' + cast(@@SPID as varchar));
print('Код последней ошибки: ' + cast(@@ERROR as varchar));
print('Имя сервера: ' + cast(@@SERVERNAME as varchar));
print('Уровень вложенности программы: ' + cast(@@TRANCOUNT as varchar));
print('Проверка результата считывания строк результирующего набора: ' + cast(@@FETCH_STATUS as varchar));
print('Уровень вложенности текущей процедуры: ' + cast(@@NESTLEVEL as varchar));
GO

--4 задание

--1 подзадание: решить систему с разными входными данными
DECLARE @z real,
@t real,
@x real;

SELECT @t = 12, @x = 12;

IF @t > @x
BEGIN
    SET @z = power(sin(@t), 2);
    PRINT 'sin^2(t) = ' + cast(@z as nvarchar(50));
END
ELSE IF @t < @x
BEGIN
    SET @z = 4*(@t+@x);
    PRINT '4*(t+x) = ' + cast(@z AS nvarchar(50));
END
ELSE IF @t = @x
BEGIN
    SET @z = 1-exp(@x-2);
    PRINT '1-e^(x-2) = ' + cast(@z AS nvarchar(50));
END
GO

--2 подзадание
-- преобразование полного ФИО студента в сокращенное 
DECLARE @fullname nvarchar(50) = '', @shortName nvarchar(50) = '';
DECLARE c_name CURSOR LOCAL FOR SELECT STUDENT.NAME FROM STUDENT;
DECLARE @part1 nvarchar(20) = '', @part2 char = '', @part3 char = '';
DECLARE @tmp TABLE (
	FullName nvarchar(50),
	ShortName nvarchar(20)
);
OPEN c_name;
FETCH  c_name INTO @fullname;

WHILE @@FETCH_STATUS = 0 -- проверяем состояние курсора
BEGIN
    SET @part1 = substring(@fullname, 1, charindex(' ', @fullname));
    SET @part2 = substring(@fullname, charindex(' ', @fullname) + 1 , 1);
    SET @part3 = substring(@fullname, charindex(' ', @fullname, charindex(' ', @fullname) + 1) + 1, 1);    

    SET @shortName = CAST((@part1 + @part2 + '. ' + @part3 + '.') as nvarchar);
	INSERT INTO @tmp VALUES (CAST(@fullname as nvarchar(50)), CAST(@shortName as nvarchar(20)));
    FETCH  c_name INTO @fullname;
END;
CLOSE c_name;

SELECT FullName [Полное ФИО], ShortName [Сокращенное ФИО] FROM @tmp;

--3 подзадание
--Поиск студентов, у которых день рождения в следующем месяце, и определение их возраста
SELECT NAME ФИО, BDAY [Дата рождения], datediff(year, BDAY, cast(getdate() as date))[Возраст] FROM STUDENT WHERE month(BDAY) + 1 = month(getdate());

--4 подзадание
--Поиск дня недели, в который студенты некоторой группы сдавали экзамен по СУБД
DECLARE @examDay nvarchar(15), @examDate date;

SET @examDate =
(SELECT TOP(1) PROGRESS.PDATE
FROM PROGRESS
WHERE PROGRESS.SUBJECT = 'СУБД');

SET @examDay = CONVERT(nvarchar(15), datepart(DW,@examDate));
SET @examDay = CASE @examDay
WHEN '1' THEN 'Вс'
WHEN '2' THEN 'Пн'
WHEN '3' THEN 'Вт'
WHEN '4' THEN 'Ср'
WHEN '5' THEN 'Чт'
WHEN '6' THEN 'Пт'
WHEN '7' THEN 'Сб'
END

PRINT 'День недели, когда был экзамент по СУБД: '+ @examDay;

--5 задание (копия второго задания)
--Продемонстрировать конструкцию IF… ELSE на примере анализа данных таблиц базы данных Х_UNIVER
DECLARE @capacity int;
SELECT @capacity =  SUM(AUDITORIUM_CAPACITY) - 0 FROM dbo.AUDITORIUM;
IF @capacity > 200
	begin
		DECLARE @count int,
				@lowerAvgCount int;
		SELECT @count = COUNT(*) FROM AUDITORIUM;
		SELECT @lowerAvgCount = COUNT(*) FROM AUDITORIUM WHERE AUDITORIUM_CAPACITY < @capacity / @count;
		SELECT @count 'Кол-во аудиторий', @capacity 'Общая вместимость', @capacity / @count 'Средняя вместимость', 
			@lowerAvgCount 'Аудитории, которые вмещают < среднего', CAST(@lowerAvgCount as real) / CAST(@count as real) * 100 'Процент таких аудиторий';
	end
ELSE 
	SELECT COUNT(*) [Общая вместимость аудиторий] FROM AUDITORIUM;
GO

--6 задание
--Разработать сценарий, в котором с помощью CASE анализируются оцен-ки, полученные студентами некоторого факультета при сдаче экзаменов
SELECT 
CASE
	WHEN PROGRESS.NOTE > 7 THEN 'Хорошо'
	WHEN PROGRESS.NOTE < 7 AND PROGRESS.NOTE >= 5 THEN 'Удовлетворительно'
	WHEN PROGRESS.NOTE <= 4 THEN 'Плохо'
	ELSE 'Очень плохо'
END [Статус оценки], COUNT(*) [Кол-во], GROUPS.FACULTY [Факультет]
FROM PROGRESS INNER JOIN STUDENT
ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
INNER JOIN GROUPS
ON STUDENT.IDGROUP = GROUPS.IDGROUP
WHERE GROUPS.FACULTY = 'ИДиП'
GROUP BY
CASE
WHEN PROGRESS.NOTE > 7 THEN 'Хорошо'
WHEN PROGRESS.NOTE < 7 AND PROGRESS.NOTE >= 5 THEN 'Удовлетворительно'
WHEN PROGRESS.NOTE <= 4 THEN 'Плохо'
ELSE 'Очень плохо'
END, GROUPS.FACULTY

--7 задание
--Создать временную локальную таблицу из трех столбцов и 10 строк, заполнить ее и вывести содержимое. Использовать оператор WHILE.
CREATE TABLE #TAB
(
	ID int,
	charI nvarchar(20),
	someDate date
);
GO

DECLARE @i smallint = 10;

WHILE @i > 0
begin
	INSERT INTO #TAB VALUES (@i, cast(rand() as nvarchar(20)), DATEADD(day, (ABS(CHECKSUM(NEWID())) % 65530), 0));
	SET @i = @i - 1;
end
GO

SELECT * FROM #TAB;

--8 задание
print('1');
print('2');
RETURN;
print('3');
GO

--9 задание
BEGIN TRY
INSERT INTO FACULTY(FACULTY, FACULTY_NAME) 
VALUES('12345678910','идип'); --Итого 11 симовлов, а можно только 10
END TRY
BEGIN CATCH
	PRINT 'ERROR_NUMBER=' + CAST(ERROR_NUMBER() AS NVARCHAR(50))
	PRINT 'ERROR_MESSAGE=' + ERROR_MESSAGE()
	PRINT 'ERROR_LINE=' + CAST(ERROR_LINE() AS NVARCHAR(50))
	PRINT 'ERROR_PROCEDURE=' + CAST(ERROR_PROCEDURE() AS NVARCHAR(50))
	PRINT 'ERROR_SEVERITY=' + CAST(ERROR_SEVERITY() AS NVARCHAR(50))
	PRINT 'ERROR_STATE=' + CAST(ERROR_STATE() AS NVARCHAR(50))
END CATCH