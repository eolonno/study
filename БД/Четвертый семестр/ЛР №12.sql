--1 задание
--Режим неявной транзакции

set nocount on
if  exists (select * from  SYS.OBJECTS        -- таблица X есть?
	        where OBJECT_ID= object_id(N'DBO.X') )	            
drop table Y;           
declare @c int, @flag char = 'r', @i INT = 10;           -- commit или rollback?

SET IMPLICIT_TRANSACTIONS  ON   -- включ. режим неявной транзакции

CREATE table Y(X int);                         -- начало транзакции 
	WHILE @i != 0
	BEGIN
		INSERT INTO Y VALUES (CAST(RAND() * 1000 AS INT));
		SET @i = @i - 1;
	END;
	set @c = (select count(*) from Y);
	print 'количество строк в таблице Y: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;                   -- завершение транзакции: фиксация 
	        else   rollback;                  -- завершение транзакции: откат  
    SET IMPLICIT_TRANSACTIONS  OFF   -- выключ. режим неявной транзакции
	
if  exists (select * from  SYS.OBJECTS       -- таблица Y есть?
	        where OBJECT_ID= object_id(N'DBO.Y') )
print 'таблица Y есть';  
    else print 'таблицы Y нет'
GO;

--2 задание
--Атомарность транзакций
USE TMPAN_UNIVER;
SET NOCOUNT ON;

SELECT * FROM AUDITORIUM WHERE AUDITORIUM = '210';

BEGIN TRY
	BEGIN TRAN
		DELETE AUDITORIUM WHERE AUDITORIUM = '210';
		INSERT AUDITORIUM VALUES ('210', 'ЛК', 80, '210');
		THROW 5000, 'ERROR', 1; --Ошибка для перекидывания в блок catch и отката транзакции
	COMMIT TRAN
END TRY
BEGIN CATCH
	print(CAST(ERROR_NUMBER() AS NVARCHAR) + ': ' + ERROR_MESSAGE());
	IF @@TRANCOUNT > 0 ROLLBACK TRAN;
END CATCH;

SELECT * FROM AUDITORIUM WHERE AUDITORIUM = '210';

--Возвращаем в исходное состояние
DELETE AUDITORIUM WHERE AUDITORIUM = '210';
INSERT AUDITORIUM VALUES ('210', NULL, 1, '210');
GO;

--3 задание
--Демонстрация SAVE TRAN

SELECT * FROM AUDITORIUM;
DECLARE @POINT VARCHAR(2);
BEGIN TRY
	BEGIN TRAN
		DELETE AUDITORIUM WHERE AUDITORIUM = '210';
		SET @POINT = 'P1'; SAVE TRAN @POINT;
		INSERT AUDITORIUM VALUES ('210', 'ЛК', 80, '210');
		THROW 5000, 'ERROR', 1; --Ошибка для перекидывания в блок catch и отката транзакции
		SET @POINT = 'P2'; SAVE TRAN @POINT;
		INSERT AUDITORIUM VALUES ('220', 'ЛК', 100, '220');
		COMMIT TRAN;
	COMMIT TRAN
END TRY
BEGIN CATCH
	print(CAST(ERROR_NUMBER() AS NVARCHAR) + ': ' + ERROR_MESSAGE());
	IF @@TRANCOUNT > 0 
	BEGIN
		print('CHECKPOINT: ' + @POINT);
		ROLLBACK TRAN @POINT;
		COMMIT TRAN;
	END
END CATCH;
SELECT * FROM AUDITORIUM; --210 аудитории больше нет

--Возвращаем в исходное состояние
INSERT AUDITORIUM VALUES ('210', NULL, 1, '210');
GO;

--4 задание
--Неподтвержденное, неповторяющееся, фантомное чтение

USE TMPAN_UNIVER;
SET NOCOUNT ON;

BEGIN TRAN
	DECLARE @I INT = 10;
	WHILE @I != 0
	BEGIN
		DECLARE @NUM CHAR(20) = CAST(FLOOR(RAND() * 100) AS CHAR(20));
		INSERT AUDITORIUM VALUES (@NUM, NULL, 1, @NUM);
		SET @I = @I - 1;
	END;
ROLLBACK;

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRAN
	DECLARE @SELECT1 INT,
			@SELECT2 INT;
	SET @SELECT1 = (SELECT COUNT(*) FROM AUDITORIUM);
	SET @SELECT2 = (SELECT COUNT(*) FROM AUDITORIUM);
	IF(@SELECT1 = @SELECT2)
		PRINT('Запросы совпадают');
	ELSE
		PRINT('Запросы не совпадают');
COMMIT;

--5 задание
--READ COMMITTED

USE TMPAN_UNIVER;
SET NOCOUNT ON;

BEGIN TRAN
	DECLARE @I INT = 10;
	WHILE @I != 0
	BEGIN
		DECLARE @NUM CHAR(20) = CAST(FLOOR(RAND() * 100) AS CHAR(20));
		INSERT AUDITORIUM VALUES (@NUM, NULL, 1, @NUM);
		SET @I = @I - 1;
	END;
ROLLBACK;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRAN
	DECLARE @SELECT1 INT,
			@SELECT2 INT;
	SET @SELECT1 = (SELECT COUNT(*) FROM AUDITORIUM);
	SET @SELECT2 = (SELECT COUNT(*) FROM AUDITORIUM);
	IF(@SELECT1 = @SELECT2)
		PRINT('Запросы совпадают');
	ELSE
		PRINT('Запросы не совпадают');
COMMIT;

--6 задание
--REPEATABLE READ

USE TMPAN_UNIVER;
SET NOCOUNT ON;

BEGIN TRAN
	DECLARE @I INT = 10;
	WHILE @I != 0
	BEGIN
		DECLARE @NUM CHAR(20) = CAST(FLOOR(RAND() * 100) AS CHAR(20));
		INSERT AUDITORIUM VALUES (@NUM, NULL, 1, @NUM);
		SET @I = @I - 1;
	END;
	UPDATE AUDITORIUM SET AUDITORIUM_TYPE = 'ЛК' WHERE AUDITORIUM_TYPE IS NULL; --меняем строки, которые позже откатываются, они не должны быть
																				--видимы для режима REPEATABLE READ
ROLLBACK;

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRAN
	DECLARE @SELECT1 INT,
			@SELECT2 INT;
	SET @SELECT1 = (SELECT COUNT(*) FROM AUDITORIUM);
	SET @SELECT2 = (SELECT COUNT(*) FROM AUDITORIUM);
	IF(@SELECT1 = @SELECT2)
		PRINT('Запросы совпадают');
	ELSE
		PRINT('Запросы не совпадают'); --Запросы не должны совпадать, так как фантомное чтение возможно
	SELECT * FROM AUDITORIUM WHERE AUDITORIUM_TYPE IS NULL; --Таких аудиторий быть не должно
COMMIT;

--7 задание
--SERIALIZABLE

USE TMPAN_UNIVER;
SET NOCOUNT ON;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN
	DECLARE @I INT = 10;
	WHILE @I != 0
	BEGIN
		DECLARE @NUM CHAR(20) = CAST(FLOOR(RAND() * 100) AS CHAR(20));
		INSERT AUDITORIUM VALUES (@NUM, NULL, 1, @NUM);
		SET @I = @I - 1;
	END;
ROLLBACK;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRAN
	DECLARE @SELECT1 INT,
			@SELECT2 INT;
	SET @SELECT1 = (SELECT COUNT(*) FROM AUDITORIUM);
	SET @SELECT2 = (SELECT COUNT(*) FROM AUDITORIUM);
	IF(@SELECT1 = @SELECT2)
		PRINT('Запросы совпадают');
	ELSE
		PRINT('Запросы не совпадают');
COMMIT;

--8 задание
--Вложенные транзакции

USE TMPAN_UNIVER;
SET NOCOUNT ON;

BEGIN TRAN
	DECLARE @NUM CHAR(20) = CAST(FLOOR(RAND() * 100) AS CHAR(20));
	INSERT AUDITORIUM VALUES (@NUM, NULL, 2, @NUM);
	BEGIN TRAN
		UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = 3 WHERE AUDITORIUM_CAPACITY = 2;
	COMMIT;
	IF @@TRANCOUNT > 0 ROLLBACK;
SELECT * FROM AUDITORIUM;

--9 задание
--Скрипты для X_MyBase
USE An_MyBase;

SELECT * FROM Курсы;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN
	INSERT Курсы(Часы, Предмет, [Тип занятия], Оплата) VALUES (24, 'АВД', 'Лекция', 1200);
	UPDATE Курсы SET Часы = 56 WHERE Часы = 24;
	IF @@TRANCOUNT > 0 ROLLBACK;
	ELSE COMMIT;

SELECT * FROM Курсы;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN
	DELETE Курсы WHERE Часы = 56 OR Часы = 24;
	IF @@TRANCOUNT > 0 ROLLBACK;
	ELSE COMMIT;

SELECT * FROM Курсы;