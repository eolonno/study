--1 задание
USE TMPAN_UNIVER;
EXEC SP_HELPINDEX 'AUDITORIUM_TYPE';

CREATE table #TMP
(
	SomeInt int,
	SomeText nvarchar(50)
);

SET nocount on;
DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

SELECT * FROM #TMP WHERE SomeInt between 1000 and 15000 ORDER BY SomeInt;

checkpoint;
DBCC DROPCLEANBUFFERS;

DROP TABLE #TMP;

CREATE CLUSTERED INDEX #TMP_CL ON #TMP(SomeInt asc);

--2 задание
CREATE table #TMP2
(
	SomeInt int,
	SomeInt2 int,
	SomeText2 nvarchar(50)
);

SET nocount on;
DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP2 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

SELECT * FROM #TMP2 WHERE SomeInt between 1000 and 15000 and SomeInt2 = 500 ORDER BY SomeInt, SomeInt2;
SELECT * FROM #TMP2 WHERE SomeInt between 1000 and 15000 and SomeInt2 > 700 ORDER BY SomeInt, SomeInt2;

CREATE INDEX  #TMP2_NONCL on #TMP2(SomeInt, SomeInt2);

--3 задание
CREATE table #TMP3
(
	SomeInt int,
	SomeInt2 int,
	SomeText2 nvarchar(50)
);

SET nocount on;
DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP3 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

SELECT * FROM #TMP3 WHERE  SomeInt2 > 700;

CREATE INDEX  #TMP3_NONCL on #TMP3(SomeInt)INCLUDE(SomeInt2);

DROP TABLE #TMP3;

--4 задание
CREATE table #TMP4
(
	SomeInt int,
	SomeInt2 int,
	SomeText2 nvarchar(50)
);

SET nocount on;
DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP4 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

SELECT SomeInt FROM #TMP4 WHERE SomeInt > 5000 and SomeInt < 15000;

CREATE INDEX #TMP4_WHERE on #TMP4(SomeInt) WHERE (SomeInt > 5000 and SomeInt < 15000);

--5 задание
CREATE table #TMP5
(
	SomeInt int,
	SomeInt2 int,
	SomeText2 nvarchar(50)
);

SET nocount on;
DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP5 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

CREATE INDEX #TMP5_IND ON #TMP5(SomeInt);

SET @i = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP5 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;
DROP TABLE #TMP5;
--tempdb->Reports->Standart Reports->Index Physical Statistics

--а это не хочет рабоать
--SELECT name[Index], avg_fragmentation_in_percent[%]
--	FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), OBJECT_ID(N'#TMP5'), NULL, NULL, NULL) ss
--	JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
--	WHERE name is not null;

ALTER INDEX #TMP5_IND on #TMP5 reorganize;
ALTER INDEX #TMP5_IND on #TMP5 rebuild;

--6 задание
DROP INDEX #TMP5_IND ON #TMP5;
CREATE INDEX #TMP5_IND ON #TMP5(SomeInt) with (fillfactor = 65);

DECLARE @i int = 10000;
WHILE @i != 0
BEGIN
	INSERT #TMP5 values (FLOOR(20000*RAND()), CAST(FLOOR(20000*RAND()) as nvarchar(50)), CAST(FLOOR(20000*RAND()) as nvarchar(50)));
	SET @i = @i - 1;
END;

--7 задание
USE An_MyBase;

CREATE INDEX T_SORT on Преподаватели(Фамилия) INCLUDE(Имя);
SELECT Имя FROM Преподаватели WHERE Фамилия like 'П%';

CREATE INDEX G_FILTER on Группы([Номер группы]) WHERE [Номер группы] > 2;
SELECT * FROM Группы WHERE [Номер группы] > 2;

DROP INDEX T_SORT on Преподаватели;
DROP INDEX G_FILTER on Группы;