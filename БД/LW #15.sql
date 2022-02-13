--1. Создайте таблицу, имеющую несколько атрибутов, один из которых первичный ключ.
CREATE TABLE LW15TABLE
(
    PK numeric(10,0) GENERATED ALWAYS AS IDENTITY,
    someText varchar(20) NOT NULL,
    TextBeginsWithB varchar(20) NULL,
    PRIMARY KEY (PK),
    CONSTRAINT CHECK_TextBeginsWithB CHECK (TextBeginsWithB LIKE 'B%')
);

--2.Заполните таблицу строками (10 шт.)
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText1', 'BText1');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText2', 'BText2');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText3', 'BText3');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText4', 'BText4');
INSERT INTO LW15TABLE(SOMETEXT)  VALUES ('someText5');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText6', 'BText6');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText7', 'BText7');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText8', 'BText8');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText9', 'BText9');
INSERT INTO LW15TABLE(SOMETEXT)  VALUES ('someText10');

SELECT * FROM LW15TABLE;

--3.Создайте BEFORE – триггер уровня оператора на события INSERT, DELETE и UPDATE.
--4.Этот и все последующие триггеры должны выдавать сообщение на серверную консоль (DMS_OUTPUT) со своим собственным именем.
CREATE OR REPLACE TRIGGER LW15TABLE_BEFORE
    BEFORE INSERT OR DELETE OR UPDATE ON LW15TABLE
    BEGIN
        DBMS_OUTPUT.PUT_LINE(' LW15TABLE: before insert or update or delete ');
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11';

--5.Создайте BEFORE-триггер уровня строки на события INSERT, DELETE и UPDATE.
CREATE OR REPLACE TRIGGER LW15TABLE_BEFORE_FOREACHROW
    BEFORE INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        DBMS_OUTPUT.PUT_LINE(' LW15TABLE: before insert or update or delete (for each row)');
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText12');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11' OR TEXTBEGINSWITHB = 'BText12';

--6.Примените предикаты INSERTING, UPDATING и DELETING.
CREATE OR REPLACE TRIGGER LW15TABLE_BEFORE
    BEFORE INSERT OR DELETE OR UPDATE ON LW15TABLE
    BEGIN
        IF INSERTING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: before insert');
        ELSIF DELETING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: before delete');
        ELSIF UPDATING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: before update');
        END IF;
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11';

--7.Разработайте AFTER-триггеры уровня оператора на события INSERT, DELETE и UPDATE.
CREATE OR REPLACE TRIGGER LW15TABLE_AFTER
    AFTER INSERT OR DELETE OR UPDATE ON LW15TABLE
    BEGIN
        IF INSERTING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after insert');
        ELSIF DELETING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after delete');
        ELSIF UPDATING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after update');
        END IF;
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11';

--8.Разработайте AFTER-триггеры уровня строки на события INSERT, DELETE и UPDATE.
CREATE OR REPLACE TRIGGER LW15TABLE_AFTER_FOREACHROW
    AFTER INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        IF INSERTING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after insert (for each row)');
        ELSIF DELETING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after delete (for each row)');
        ELSIF UPDATING
            THEN DBMS_OUTPUT.PUT_LINE(' LW15TABLE: after update (for each row)');
        END IF;
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText12');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11' OR TEXTBEGINSWITHB = 'BText12';

--9.Создайте таблицу с именем AUDIT. Таблица должна содержать поля: OperationDate,
-- OperationType (операция вставки, обновления и удаления),
-- TriggerName(имя триггера),
-- Data (строка с значениями полей до и после операции).
--ИМЯ AUDIT НЕДОСТУПНО
CREATE TABLE AUDIT_LOG
(
    ID numeric(10,0) GENERATED ALWAYS AS IDENTITY,
    OperationDate date NOT NULL,
    OperationType varchar(6) NOT NULL,
    TriggerName varchar(30) NOT NULL,
    OldData varchar(200) NULL,
    NewData varchar(200) NULL,
    PRIMARY KEY (ID)
);

--DROP TABLE AUDIT_LOG;

--10.Измените триггеры таким образом, чтобы они регистрировали все операции с исходной таблицей в таблице AUDIT.
CREATE OR REPLACE TRIGGER LW15TABLE_BEFORE_FOREACHROW
    BEFORE INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        IF INSERTING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'INSERT', 'LW15TABLE_BEFORE_FOREACHROW',
                     NULL,
                     'PK: ' || :NEW.PK ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        ELSIF DELETING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'DELETE', 'LW15TABLE_BEFORE_FOREACHROW',
                     'PK: ' || :OLD.PK ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB,
                     NULL);
            END;
        ELSIF UPDATING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'UPDATE', 'LW15TABLE_BEFORE_FOREACHROW',
                     'PK: ' || :OLD.PK ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB,
                     'PK: ' || :NEW.PK ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        END IF;
    END;

CREATE OR REPLACE TRIGGER LW15TABLE_AFTER_FOREACHROW
    AFTER INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        IF INSERTING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'INSERT', 'LW15TABLE_AFTER_FOREACHROW',
                     NULL,
                     'PK: ' || :NEW.PK ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        ELSIF DELETING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'DELETE', 'LW15TABLE_AFTER_FOREACHROW',
                     'PK: ' || :OLD.PK ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB,
                     NULL);
            END;
        ELSIF UPDATING THEN
            BEGIN
                INSERT INTO AUDIT_LOG(OPERATIONDATE, OPERATIONTYPE, TRIGGERNAME, OLDDATA, NEWDATA) VALUES
                    (SYSDATE, 'UPDATE', 'LW15TABLE_AFTER_FOREACHROW',
                     'PK: ' || :OLD.PK ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB,
                     'PK: ' || :NEW.PK ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        END IF;
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText12');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11' OR TEXTBEGINSWITHB = 'BText12';

SELECT * FROM AUDIT_LOG;

--11.Выполните операцию, нарушающую целостность таблицы по первичному ключу. Выясните, зарегистрировал ли триггер это событие.
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB) VALUES ('someText11', 'Text11');

--12.Удалите (drop) исходную таблицу. Объясните результат. Добавьте триггер, запрещающий удаление исходной таблицы.
DROP TABLE LW15TABLE; --удаляется
SELECT * FROM USER_TRIGGERS; --триггеры также удаляются

CREATE OR REPLACE TRIGGER LW15TABLE_CANNOT_BE_DELETED
    BEFORE DROP ON SCHEMA
    BEGIN
        IF ORA_DICT_OBJ_NAME = 'LW15TABLE'
            THEN RAISE_APPLICATION_ERROR(-20000, 'Unable to delete LW15TABLE');
        END IF;
    END;

--13.Удалите (drop) таблицу AUDIT. Просмотрите состояние триггеров. Объясните результат. Измените триггеры.
DROP TABLE AUDIT_LOG;

SELECT TRIGGER_NAME, STATUS FROM USER_TRIGGERS;

CREATE OR REPLACE TRIGGER LW15TABLE_BEFORE_FOREACHROW
    BEFORE INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        IF INSERTING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: INSERT');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_BEFORE_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: NULL');
                DBMS_OUTPUT.PUT_LINE('New data: ' ||
                     'PK: ' || CAST(:NEW.PK AS CHAR) ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        ELSIF DELETING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: DELETE');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_BEFORE_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: ' ||
                     'PK: ' || CAST(:OLD.PK AS CHAR) ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB ||
                     ' NULL');
                DBMS_OUTPUT.PUT_LINE('New data: NULL');
            END;
        ELSIF UPDATING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: UPDATE');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_BEFORE_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: ' ||
                     'PK: ' || CAST(:OLD.PK AS CHAR) ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB);
                DBMS_OUTPUT.PUT_LINE('New data: ' ||
                     'PK: ' || CAST(:NEW.PK AS CHAR) ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        END IF;
    END;

CREATE OR REPLACE TRIGGER LW15TABLE_AFTER_FOREACHROW
    AFTER INSERT OR DELETE OR UPDATE ON LW15TABLE
    FOR EACH ROW
    BEGIN
        IF INSERTING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: INSERT');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_AFTER_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: NULL');
                DBMS_OUTPUT.PUT_LINE('New data: ' ||
                     'PK: ' || CAST(:NEW.PK AS CHAR) ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        ELSIF DELETING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: DELETE');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_AFTER_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: ' ||
                     'PK: ' || CAST(:OLD.PK AS CHAR) ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB ||
                     ' NULL');
                DBMS_OUTPUT.PUT_LINE('New data: NULL');
            END;
        ELSIF UPDATING THEN
            BEGIN
                DBMS_OUTPUT.PUT_LINE('Operation date: ' || SYSDATE);
                DBMS_OUTPUT.PUT_LINE('Operation type: UPDATE');
                DBMS_OUTPUT.PUT_LINE('Trigger name: LW15TABLE_AFTER_FOREACHROW');
                DBMS_OUTPUT.PUT_LINE('Old data: ' ||
                     'PK: ' || CAST(:OLD.PK AS CHAR) ||
                     ', someTest: ' || :OLD.someText ||
                     ', TextBeginsWithB: ' || :OLD.TextBeginsWithB);
                DBMS_OUTPUT.PUT_LINE('New data: ' ||
                     'PK: ' || CAST(:NEW.PK AS CHAR) ||
                     ', someTest: ' || :NEW.someText ||
                     ', TextBeginsWithB: ' || :NEW.TextBeginsWithB);
            END;
        END IF;
    END;

INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText12');
UPDATE LW15TABLE SET someText = 'Hello World!' WHERE someText = 'someText11';
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11' OR TEXTBEGINSWITHB = 'BText12';

--14.Создайте представление над исходной таблицей. Разработайте INSTEADOF INSERT-триггер. Триггер должен добавлять строку в таблицу.
CREATE VIEW LW15TABLE_VIEW AS SELECT * FROM LW15TABLE;

CREATE TRIGGER VIEW_INSTEDOF
    INSTEAD OF INSERT ON LW15TABLE_VIEW
    FOR EACH ROW
    BEGIN
        INSERT INTO LW15TABLE(SOMETEXT, TEXTBEGINSWITHB) VALUES (:NEW.SOMETEXT, :NEW.TEXTBEGINSWITHB);
    END;

INSERT INTO LW15TABLE_VIEW(SOMETEXT, TEXTBEGINSWITHB)  VALUES ('someText11', 'BText11');
SELECT * FROM LW15TABLE;
SELECT * FROM LW15TABLE_VIEW;
DELETE LW15TABLE WHERE TEXTBEGINSWITHB = 'BText11';

--15.Продемонстрируйте, в каком порядке выполняются триггеры.
CREATE TABLE XXX (X NUMERIC (2, 0));
CREATE TRIGGER XXX_BEFORE
    BEFORE INSERT ON XXX
    BEGIN
        DBMS_OUTPUT.PUT_LINE('BEFORE');
    END;

CREATE TRIGGER XXX_BEFORE_FOREACHROW
    BEFORE INSERT ON XXX
    FOR EACH ROW
    BEGIN
        DBMS_OUTPUT.PUT_LINE('BEFORE FOR EACH ROW');
    END;

CREATE TRIGGER XXX_AFTER
    AFTER INSERT ON XXX
    BEGIN
        DBMS_OUTPUT.PUT_LINE('AFTER');
    END;

CREATE TRIGGER XXX_AFTER_FOREACHROW
    AFTER INSERT ON XXX
    FOR EACH ROW
    BEGIN
        DBMS_OUTPUT.PUT_LINE('AFTER FOR EACH ROW');
    END;

INSERT INTO XXX VALUES(1);

DROP TABLE XXX;