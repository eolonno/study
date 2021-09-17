--1 задание
--Список дисциплин на кафедре ИСиТ

USE TMPAN_UNIVER;

DECLARE @subject char(10),
		@subjects char(300) = '';
DECLARE cur CURSOR 
	FOR SELECT SUBJECT FROM SUBJECT WHERE PULPIT like 'ИСиТ'
	ORDER BY SUBJECT;

OPEN cur;
FETCH cur into @subject;
SET @subjects = rtrim(@subject);
FETCH cur into @subject;

WHILE @@FETCH_STATUS = 0
BEGIN 
	SET @subjects = rtrim(@subject) + ', ' + @subjects;
	FETCH cur into @subject;
END;

CLOSE cur;
print('Список дисциплин кафедры ИСиТ: ' + @subjects);
GO;

DEALLOCATE cur;
GO;

--2 задание
USE YEGOR_UNIVER;

DECLARE @BirthDate date,
		@FullName nvarchar(100);

--Локальный курсор (действует только внутри пакета)
DECLARE STUDENTS_L CURSOR LOCAL
	FOR SELECT BirthDate, FullName FROM STUDENT;
OPEN STUDENTS_L;
FETCH STUDENTS_L INTO @BirthDate, @FullName;

print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
FETCH STUDENTS_L INTO @BirthDate, @FullName;
print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
GO
DECLARE @BirthDate date,
		@FullName nvarchar(100);
FETCH STUDENTS_L INTO @BirthDate, @FullName; -- ошибка
print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
GO


DECLARE @BirthDate date,
		@FullName nvarchar(100);

--Глобальный курсор (действует внутри всех выполняемых пакетов)
DECLARE STUDENTS_G CURSOR GLOBAL
	FOR SELECT BirthDate, FullName FROM STUDENT;
OPEN STUDENTS_G;
FETCH STUDENTS_G INTO @BirthDate, @FullName;

print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
FETCH STUDENTS_G INTO @BirthDate, @FullName;
print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
GO
DECLARE @BirthDate date,
		@FullName nvarchar(100);
FETCH STUDENTS_G INTO @BirthDate, @FullName; -- ошибка
print(cast(@BirthDate as nvarchar) + ' ' +  @FullName);
GO
CLOSE STUDENTS_G;
DEALLOCATE STUDENTS_G;

--3 задание
--Статический курсор (работает с временной таблицей)
USE YEGOR_UNIVER;
DECLARE @BirthDate date,
		@FullName nvarchar(100),
		@DateOfAdmission date;

DECLARE STATIC_CUR CURSOR LOCAL STATIC
	FOR SELECT BirthDate, FullName, DateOfAdmission FROM STUDENT;

OPEN STATIC_CUR;
FETCH STATIC_CUR INTO @BirthDate, @FullName, @DateOfAdmission;

INSERT STUDENT VALUES
		(23843828, 'STUDENT4', 'M', '2002-08-12', '2019-07-12');
UPDATE STUDENT SET DateOfAdmission = '2019-07-13' WHERE FullName = 'STUDENT2';

WHILE @@FETCH_STATUS = 0
BEGIN
	print(cast(@BirthDate as nvarchar) + ' ' + @FullName + ' ' + cast(@DateOfAdmission as nvarchar));
	FETCH STATIC_CUR INTO @BirthDate, @FullName, @DateOfAdmission;
END;

DELETE STUDENT WHERE FullName = 'STUDENT4';
UPDATE STUDENT SET DateOfAdmission = '2019-07-12' WHERE FullName = 'STUDENT2';
GO

--Динамический курсор (работает с основной таблицей)
DECLARE @BirthDate date,
		@FullName nvarchar(100),
		@DateOfAdmission date;

DECLARE DYNAMIC_CUR CURSOR LOCAL DYNAMIC
	FOR SELECT BirthDate, FullName, DateOfAdmission FROM STUDENT;

OPEN DYNAMIC_CUR;
FETCH DYNAMIC_CUR INTO @BirthDate, @FullName, @DateOfAdmission;

INSERT STUDENT VALUES
		(23843828, 'STUDENT4', 'M', '2002-08-12', '2019-07-12');
UPDATE STUDENT SET DateOfAdmission = '2019-07-13' WHERE FullName = 'STUDENT2';

WHILE @@FETCH_STATUS = 0
BEGIN
	print(cast(@BirthDate as nvarchar) + ' ' + @FullName + ' ' + cast(@DateOfAdmission as nvarchar));
	FETCH DYNAMIC_CUR INTO @BirthDate, @FullName, @DateOfAdmission;
END;

DELETE STUDENT WHERE FullName = 'STUDENT4';
UPDATE STUDENT SET DateOfAdmission = '2019-07-12' WHERE FullName = 'STUDENT2';
GO

--4 задание
--Аттрибут SCROLL
USE YEGOR_UNIVER;
DECLARE @BirthDate date,
		@FullName nvarchar(100);

DECLARE CUR CURSOR LOCAL SCROLL
	FOR SELECT BirthDate, FullName FROM STUDENT;

OPEN CUR;
FETCH CUR INTO @BirthDate, @FullName;

print('Все строки таблицы: ');
WHILE @@FETCH_STATUS = 0
BEGIN
	print(cast(@BirthDate as nvarchar) + ' ' + @FullName);
	FETCH CUR INTO @BirthDate, @FullName;
END;
print('');

FETCH FIRST FROM CUR INTO @BirthDate, @FullName;
print('Первая строка: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH LAST FROM CUR INTO @BirthDate, @FullName;
print('Последняя строка: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH PRIOR FROM CUR INTO @BirthDate, @FullName;
print('Предыдущая строка: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH NEXT FROM CUR INTO @BirthDate, @FullName;
print('Следующая строка: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH ABSOLUTE 2 FROM CUR INTO @BirthDate, @FullName;
print('Вторая строка: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH ABSOLUTE -2 FROM CUR INTO @BirthDate, @FullName;
print('Вторая строка с конца: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH RELATIVE -1 FROM CUR INTO @BirthDate, @FullName;
print('Предыдушая строка, но через relative: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

FETCH RELATIVE 1 FROM CUR INTO @BirthDate, @FullName;
print('Следующая строка, но через relative: ' + cast(@BirthDate as nvarchar) + ' ' + @FullName);

CLOSE CUR;
DEALLOCATE CUR;

--5 задание
--Конструкция CURRENT OF
SET nocount on;
CREATE TABLE #TMP51
(
	ID INT IDENTITY(1,1) NOT NULL,
	IsEven BIT NULL
);

DECLARE @i int = 10;

WHILE @i != 0
BEGIN
	INSERT #TMP51(IsEven) VALUES (NULL);
	SET @i = @i - 1;
END;

DECLARE @ID int;
DECLARE CUR CURSOR LOCAL DYNAMIC
	FOR SELECT ID FROM #TMP51;
OPEN CUR;
FETCH CUR INTO @ID;

print('Начальное состояние таблицы: ');
WHILE @@FETCH_STATUS = 0
BEGIN
	print(@ID);
	FETCH CUR INTO @ID;
END;
print('');

FETCH FIRST FROM CUR INTO @ID;

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @ID % 2 = 0
		UPDATE #TMP51 SET IsEven = 1 WHERE CURRENT OF CUR;
	ELSE
		DELETE #TMP51 WHERE CURRENT OF CUR;
	FETCH CUR INTO @ID;
END;

print('Конечное состояние таблицы: ');
FETCH FIRST FROM CUR INTO @ID;
WHILE @@FETCH_STATUS = 0
BEGIN
	print(@ID);
	FETCH CUR INTO @ID;
END;

CLOSE CUR;
DEALLOCATE CUR;

SELECT * FROM #TMP51;

DROP TABLE #TMP51;

--6 задание
--Удаление студентов из бд, оценки которых ниже 4
--ДЛЯ НАЧАЛА НУЖНО СОЗДАТЬ БД TMPAN_UNIVER_FORDELETE

USE TMPAN_UNIVER_FORDELETE;

DECLARE @NOTE int;
DECLARE CUR CURSOR
	FOR SELECT NOTE FROM PROGRESS 
	JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP
	FOR UPDATE;
OPEN CUR;
FETCH CUR INTO @NOTE;

SELECT * FROM PROGRESS 
	JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP;

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @NOTE <= 4
	BEGIN
		DELETE PROGRESS WHERE CURRENT OF CUR;
		DELETE STUDENT WHERE CURRENT OF CUR;
	END
	FETCH CUR INTO @NOTE;
END;

CLOSE CUR;
DEALLOCATE CUR;

SELECT * FROM PROGRESS 
	JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP;
GO

--Увеличение оценки на единицу, зная IDSTUDENT
DECLARE @NOTE int,
		@IDSTUDENT int = 1000;
DECLARE CUR CURSOR
	FOR SELECT NOTE FROM PROGRESS WHERE IDSTUDENT = @IDSTUDENT
	FOR UPDATE;

SELECT NOTE FROM PROGRESS WHERE IDSTUDENT = @IDSTUDENT;

OPEN CUR;
FETCH CUR INTO @NOTE;
BEGIN TRY
	UPDATE PROGRESS SET NOTE = @NOTE + 1 WHERE CURRENT OF CUR;
END TRY
BEGIN CATCH
	print(ERROR_MESSAGE());
END CATCH;
CLOSE CUR;
DEALLOCATE CUR;

SELECT NOTE FROM PROGRESS WHERE IDSTUDENT = @IDSTUDENT;

DROP DATABASE TMPAN_UNIVER_FORDELETE;

--7 задание
USE An_MyBase;

--Вывод списков групп
DECLARE @LAST_NAME nvarchar(20),
		@GROUP_NUMBER INT,
		@LAST_GROUP_NUMBER INT;
DECLARE CUR CURSOR 
	FOR SELECT [Номер группы], Фамилия FROM Преподаватели
	ORDER BY [Номер группы];

OPEN CUR;
FETCH CUR INTO @GROUP_NUMBER, @LAST_NAME;
SET @LAST_GROUP_NUMBER = @GROUP_NUMBER;
print('Group #' + CAST(@LAST_GROUP_NUMBER AS nvarchar));

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @LAST_GROUP_NUMBER != @GROUP_NUMBER
	BEGIN
		print('');
		SET @LAST_GROUP_NUMBER = @GROUP_NUMBER;
		print('Group #' + CAST(@LAST_GROUP_NUMBER AS nvarchar));
	END
	print(@LAST_NAME);
	FETCH CUR INTO @GROUP_NUMBER, @LAST_NAME;
END;

CLOSE CUR;
DEALLOCATE CUR;
GO

--ФИ всех преподавателей
DECLARE @NAME NVARCHAR(20),
		@LAST_NAME NVARCHAR(20);
DECLARE CUR CURSOR
	FOR SELECT Имя, Фамилия FROM Преподаватели;

OPEN CUR;
FETCH CUR INTO @NAME, @LAST_NAME;

WHILE @@FETCH_STATUS = 0
BEGIN
	print(@NAME + ' ' + @LAST_NAME);
	FETCH CUR INTO @NAME, @LAST_NAME;
END;
GO

--8 задание
USE TMPAN_UNIVER;
DECLARE @FACULTY NVARCHAR(10),
		@PULPIT NVARCHAR(10),
		@TEACHER NVARCHAR(10),
		@TEACHERS NVARCHAR (100),
		@SUBJECT NVARCHAR(10),
		@TEACHER_COUNT INT = 0,
		@SUBJECTS NVARCHAR(100) = '',
		@LAST_FACULTY NVARCHAR(10),
		@LAST_PULPIT NVARCHAR(10);
DECLARE CUR CURSOR LOCAL STATIC
	FOR SELECT FACULTY.FACULTY, PULPIT.PULPIT, TEACHER.TEACHER, SUBJECT.SUBJECT FROM FACULTY 
		JOIN PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
		JOIN TEACHER ON TEACHER.PULPIT = PULPIT.PULPIT
		JOIN SUBJECT ON SUBJECT.PULPIT = PULPIT.PULPIT
		ORDER BY FACULTY.FACULTY, PULPIT.PULPIT;

OPEN CUR;
FETCH CUR INTO @FACULTY, @PULPIT, @TEACHER, @SUBJECT;
SELECT @LAST_FACULTY = @FACULTY, @LAST_PULPIT = @PULPIT;

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @LAST_FACULTY = @FACULTY
	print('Факультет: ' + @FACULTY);
	BEGIN
		WHILE @LAST_FACULTY = @FACULTY AND @@FETCH_STATUS = 0
		BEGIN
			print('  Кафедра: ' + @PULPIT);
			WHILE @LAST_PULPIT = @PULPIT AND @@FETCH_STATUS = 0
			BEGIN
				IF @SUBJECTS NOT LIKE '%' + RTRIM(@SUBJECT) + '%'
					SET @SUBJECTS = @SUBJECTS + ', ' + RTRIM(@SUBJECT);
				IF @TEACHERS NOT LIKE '%' + RTRIM(@TEACHER) + '%'
					BEGIN
						SET @TEACHERS = @TEACHERS + RTRIM(@TEACHER);
						SET @TEACHER_COUNT = @TEACHER_COUNT + 1;
					END
				FETCH CUR INTO @FACULTY, @PULPIT, @TEACHER, @SUBJECT;
			END;
			SET @LAST_PULPIT = @PULPIT;
			print('    Количество преподавателей: ' + CAST(@TEACHER_COUNT AS NVARCHAR(3)));
			IF LEN(@SUBJECTS) = 0
				SET @SUBJECTS = 'нет';
			ELSE
				SET @SUBJECTS = SUBSTRING(@SUBJECTS, 3, LEN(@SUBJECTS)) + '.';
			print('    Дисциплины: ' + @SUBJECTS);
			SELECT @TEACHER_COUNT = 0, @SUBJECTS = '', @TEACHERS = '';
		END;
		SET @LAST_FACULTY = @FACULTY;
	END
END;
