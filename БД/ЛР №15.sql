--1 задание
--Создать таблицу для логов, а также созадать триггер для ввода данных в таблицу, который будет логгировать данные

USE TMPAN_UNIVER;

CREATE TABLE TR_AUDIT(
	ID INT IDENTITY,
	STMT VARCHAR(20),	--DML-оператор
		CHECK (STMT IN ('INS', 'DEL', 'UPD', 'DEL1', 'DEL2', 'DEL3')),
	TRNAME VARCHAR(50),	--имя триггера
	CC VARCHAR(300)		--комментарий
);

--DROP TABLE TR_AUDIT;

CREATE TRIGGER TR_TRIGGER_INS
				ON TEACHER AFTER INSERT
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	SET @A1 = (SELECT TEACHER FROM inserted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM inserted);
	SET @A3 = (SELECT [GENDER] FROM inserted);
	SET @A4 = (SELECT [PULPIT] FROM inserted);
	SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('INS', 'TR_TRIGGER_INS', @COMMENT);
	RETURN;

INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'м', 'ИСиТ');
SELECT * FROM TR_AUDIT;

--2 задание
--Триггер для события delete

CREATE TRIGGER TR_TRIGGER_DEL
				ON TEACHER AFTER DELETE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	SET @A1 = (SELECT TEACHER FROM deleted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
	SET @A3 = (SELECT [GENDER] FROM deleted);
	SET @A4 = (SELECT [PULPIT] FROM deleted);
	SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL', 'TR_TRIGGER_DEL', @COMMENT);
	RETURN;

DELETE TEACHER WHERE TEACHER_NAME = 'Жуковский Роман Филлипович';
SELECT * FROM TR_AUDIT;

--3 звдвник
--Триггер для события update

CREATE TRIGGER TR_TRIGGER_UPD
				ON TEACHER AFTER UPDATE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(300),
		@A5 CHAR(10), @A6 VARCHAR(100), @A7 CHAR(1), @A8 CHAR(20)
	SET @A1 = (SELECT TEACHER FROM deleted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
	SET @A3 = (SELECT [GENDER] FROM deleted);
	SET @A4 = (SELECT [PULPIT] FROM deleted);
	SET @A5 = (SELECT TEACHER FROM inserted)
	SET @A6 = (SELECT [TEACHER_NAME] FROM inserted);
	SET @A7 = (SELECT [GENDER] FROM inserted);
	SET @A8 = (SELECT [PULPIT] FROM inserted);
	SET @COMMENT = 'DEL: ' + TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4) + 'INS:' + TRIM(@A5) + ' ' + TRIM(@A6) + ' ' + TRIM(@A7)  + ' ' + TRIM(@A8);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TRIGGER_UPD', @COMMENT);
	RETURN;

UPDATE TEACHER SET TEACHER = 'NEW' WHERE TEACHER = 'ЖРФ';
SELECT * FROM TR_AUDIT;

--4 задание
--Объединить все три события в один триггер

DROP TRIGGER TR_TRIGGER_INS;
DROP TRIGGER TR_TRIGGER_DEL;
DROP TRIGGER TR_TRIGGER_UPD;

CREATE TRIGGER TR_TRIGGER
				ON TEACHER AFTER INSERT, DELETE, UPDATE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	DECLARE @INS INT = (SELECT COUNT(*) FROM inserted),
			@DEL INT = (SELECT COUNT(*) FROM deleted);
	IF @INS > 0 AND @DEL = 0
	BEGIN
		SET @A1 = (SELECT TEACHER FROM inserted)
		SET @A2 = (SELECT [TEACHER_NAME] FROM inserted);
		SET @A3 = (SELECT [GENDER] FROM inserted);
		SET @A4 = (SELECT [PULPIT] FROM inserted);
		SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('INS', 'TR_TRIGGER_INS', @COMMENT);
	END;
	ELSE IF @INS = 0 AND @DEL > 0
	BEGIN
		SELECT * FROM deleted;
		SET @A1 = (SELECT TEACHER FROM deleted)
		SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
		SET @A3 = (SELECT [GENDER] FROM deleted);
		SET @A4 = (SELECT [PULPIT] FROM deleted);
		SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL', 'TR_TRIGGER_DEL', @COMMENT);
	END;
	ELSE IF @INS > 0 AND @DEL > 0
	BEGIN
		DECLARE @A5 CHAR(10), @A6 VARCHAR(100), @A7 CHAR(1), @A8 CHAR(20)
		SET @A1 = (SELECT TEACHER FROM deleted)
		SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
		SET @A3 = (SELECT [GENDER] FROM deleted);
		SET @A4 = (SELECT [PULPIT] FROM deleted);
		SET @A5 = (SELECT TEACHER FROM inserted)
		SET @A6 = (SELECT [TEACHER_NAME] FROM inserted);
		SET @A7 = (SELECT [GENDER] FROM inserted);
		SET @A8 = (SELECT [PULPIT] FROM inserted);
		SET @COMMENT = 'DEL: ' + TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4) + 'INS:' + TRIM(@A5) + ' ' + TRIM(@A6) + ' ' + TRIM(@A7)  + ' ' + TRIM(@A8);
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TRIGGER_UPD', @COMMENT);
	END;
	RETURN;

INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'м', 'ИСиТ');
UPDATE TEACHER SET TEACHER = 'NEW' WHERE TEACHER = 'ЖРФ';
DELETE TEACHER WHERE TEACHER = 'NEW';
DELETE TEACHER WHERE TEACHER_NAME = 'Жуковский Роман Филлипович';
SELECT * FROM TR_AUDIT;

--5 задание
--Проверка сработки целостности данных (свой пример)

DELETE TR_AUDIT WHERE ID > 0;
INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'мм', 'ИСиТ'); --пол должен состоять из одного символа => ошибка
SELECT * FROM TR_AUDIT;

--6 задание
--Использовать несколько триггеров для удаления строки и организовать их последовательный вызов

DROP TRIGGER TR_TRIGGER;

CREATE TRIGGER TR_TRIGGER_DEL1
				ON TEACHER AFTER DELETE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	SET @A1 = (SELECT TEACHER FROM deleted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
	SET @A3 = (SELECT [GENDER] FROM deleted);
	SET @A4 = (SELECT [PULPIT] FROM deleted);
	SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL1', 'TR_TRIGGER_DEL', @COMMENT);
	RETURN;

CREATE TRIGGER TR_TRIGGER_DEL2
				ON TEACHER AFTER DELETE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	SET @A1 = (SELECT TEACHER FROM deleted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
	SET @A3 = (SELECT [GENDER] FROM deleted);
	SET @A4 = (SELECT [PULPIT] FROM deleted);
	SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL2', 'TR_TRIGGER_DEL', @COMMENT);
	RETURN;

CREATE TRIGGER TR_TRIGGER_DEL3
				ON TEACHER AFTER DELETE
	AS DECLARE @A1  CHAR(10), @A2 VARCHAR(100), @A3 CHAR(1), @A4 CHAR(20), @COMMENT VARCHAR(200)
	SET @A1 = (SELECT TEACHER FROM deleted)
	SET @A2 = (SELECT [TEACHER_NAME] FROM deleted);
	SET @A3 = (SELECT [GENDER] FROM deleted);
	SET @A4 = (SELECT [PULPIT] FROM deleted);
	SET @COMMENT = TRIM(@A1) + ' ' + TRIM(@A2)  + ' ' + TRIM(@A3)  + ' ' + TRIM(@A4);
	INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL3', 'TR_TRIGGER_DEL', @COMMENT);
	RETURN;

select t.name, e.type_desc
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE' ;  

exec  SP_SETTRIGGERORDER @triggername = 'TR_TRIGGER_DEL1', 
	                        @order = 'Last', @stmttype = 'DELETE';
exec  SP_SETTRIGGERORDER @triggername = 'TR_TRIGGER_DEL3', 
	                        @order = 'First', @stmttype = 'DELETE';



INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'м', 'ИСиТ');
DELETE TEACHER WHERE TEACHER_NAME = 'Жуковский Роман Филлипович';
DELETE TEACHER WHERE TEACHER = 'ЖРФ';
SELECT * FROM TR_AUDIT;

DROP TRIGGER TR_TRIGGER_DEL1;
DROP TRIGGER TR_TRIGGER_DEL2;
DROP TRIGGER TR_TRIGGER_DEL3;

--7 задание
--Демонстрация того, что триггер является частью транзакции

CREATE TRIGGER TRAN_DEMO_TRIGGER
			ON TEACHER AFTER DELETE, INSERT, UPDATE
	AS DECLARE @A INT = (SELECT COUNT(*) FROM TEACHER)
	IF(@A > 5)
	BEGIN
		RAISERROR('Кол-во преподавателей больше 5!', 10, 1);
		ROLLBACK;
	END;
	RETURN;

INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'м', 'ИСиТ');

DROP TRIGGER TRAN_DEMO_TRIGGER;

--8 задание
--Для таблицы FACULTY создать INSEAD OF триггер, запрещающий удаление данных

CREATE TRIGGER FAC_INSTEAD_OF
			ON FACULTY INSTEAD OF DELETE 
	AS RAISERROR('Удаление запрещено!', 10, 1);
	RETURN;

DELETE FACULTY WHERE FACULTY = 'ИТ';

DROP TRIGGER FAC_INSTEAD_OF;

--Создать триггер insead of, который показывает, что проверка целостности выполнена
CREATE TRIGGER INTEGRITY_CHECK
			ON TEACHER INSTEAD OF INSERT, DELETE, UPDATE
	AS PRINT 'Проверка целостности прошла успешно!';
	RETURN;

INSERT INTO TEACHER VALUES ('ЖРФ', 'Жуковский Роман Филлипович', 'м', 'ИСиТ');

DROP TRIGGER FAC_INSTEAD_OF;

--9 задание
--Созадть триггер для всей БД, который будет запрещать удаление и создание таблиц

CREATE TRIGGER UNIVER_CONTROL ON DATABASE 
			FOR DDL_DATABASE_LEVEL_EVENTS AS
	declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
	declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
	declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
	begin
		print 'Тип события: '+@t;
		print 'Имя объекта: '+@t1;
		print 'Тип объекта: '+@t2;
		raiserror( N'Изменять кол-во таблиц базы данных запрещено!', 16, 1);  
		rollback;    
	end;

CREATE TABLE TTT
(ID INT);

--10 задание
--Триггеры для своей БД

USE An_MyBase;

CREATE TRIGGER MYBASE_CONTROL ON DATABASE 
			FOR DDL_DATABASE_LEVEL_EVENTS AS
	declare @t varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
	begin
		PRINT 'Таблица ' + @t + ' изменена!';
	end;

CREATE TABLE JUST_TABLE
(ID INT);

CREATE TRIGGER TABLE_EDITING
			ON JUST_TABLE AFTER INSERT, UPDATE, DELETE
	AS DECLARE @IDD INT = (SELECT TOP(1) * FROM deleted),
				@IDI INT = (SELECT TOP(1) * FROM inserted);
	BEGIN
		PRINT 'DELETED: ' + CAST(@IDD AS CHAR);
		PRINT 'INSERTED: ' + CAST(@IDI AS CHAR);
	END;

INSERT JUST_TABLE VALUES (1);
INSERT JUST_TABLE VALUES (2);
DELETE JUST_TABLE WHERE ID = 2;

DROP TABLE JUST_TABLE;

--11 задание
--Создать таблицу WEATHER (город, начальная дата, конечная дата, температура). Создать триггер, проверяющий корректность ввода и изменения данных. 
--Например, если в таблице есть строка (Минск, 01.01.2017 00:00, 01.01.2017 23:59, -6), то в нее не может быть вставлена строка (Минск, 01.01.2017 00:00, 01.01.2017 23:59, -2).
--Временные периоды могут быть различными.

USE DB;

CREATE TABLE WEATHER 
(
	CITY NVARCHAR(20) NOT NULL,
	SDATE SMALLDATETIME NOT NULL,
	EDATE SMALLDATETIME NOT NULL,
	TEMPERATURE INT NOT NULL
);

CREATE TRIGGER WEATHER_EDITING
			ON WEATHER INSTEAD OF UPDATE, INSERT
	AS DECLARE @C INT = (SELECT COUNT(*) FROM WEATHER WHERE EDATE BETWEEN (SELECT SDATE FROM inserted) AND (SELECT EDATE FROM inserted)
														OR SDATE BETWEEN (SELECT SDATE FROM inserted) AND (SELECT EDATE FROM inserted)
	BEGIN
		IF @C > 0
			RAISERROR('Некорретные данные!', 16, 1);
		ELSE
			RETURN;
	END;

