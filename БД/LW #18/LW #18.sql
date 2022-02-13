DROP TABLE HUMANS;
CREATE TABLE Humans
(
    Id NUMERIC,
    Name VARCHAR(20),
    Mark NUMBER(4,2),
    Birthday DATE
);

SELECT * FROM Humans;

--cd "D:\Учеба\БД\LW #18"
--sqlldr userid='PDB_ADMIN/Pa$$w0rd@yegor_pdb' "control='D:\Учеба\БД\LW #18\LoadHumans.ctl'"

--conn PDB_ADMIN/Pa$$w0rd@yegor_pdb
-- spool humans.txt
-- select * from Humans;
-- spool off;

--https://www.foxinfotech.in/2015/11/how-to-export-data-into-csv-file-in-oracle-using-pl-sql-procedure.html