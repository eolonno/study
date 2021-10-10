--1--
-- from AYV
select * From dba_tablespaces;

--2--
create tablespace AYV_QDATA_5
  datafile 'Z:\LW #5\AYV_QDATA.dbf'
  size 10 m
  autoextend on next 5 m
  maxsize 30 m
  extent management local
  offline;

alter tablespace AYV_QDATA_5 online;  

--Drop tablespace AYV_QDATA_5

alter user AYVCORE
  default tablespace AYV_QDATA_5 quota 2m on AYV_QDATA_5;


--from AYVCORE
Create table AYV_T1(
num int primary key,
desctiprion varchar(150))tablespace AYV_QDATA_5;

Insert into AYV_T1
values (1, 'one');
Insert into AYV_T1
values (2, 'two');
Insert into AYV_T1 
values (3, 'three');

Select * From AYV_T1;

--3--
Select Distinct * From user_segments Where tablespace_name = 'AYV_QDATA_5';
Select Distinct * From user_segments Where tablespace_name != 'AYV_QDATA_5';

--4--
Drop table AYV_T1;

Select Distinct * From user_segments Where tablespace_name = 'AYV_QDATA_5';

Select * From user_recyclebin

--5--
Flashback table AYV_T1 to before drop;

select * from AYV_T1;

--6--

declare i int:= 4;
begin loop i:=i+1;
  Insert into AYV_T1 values (i,'number');
  exit when(i == 10000);
end loop;
end;  
Select * From AYV_T1;

--7--
Select * From user_segments Where tablespace_name = 'AYV_QDATA_5';

Select * From user_extents Where tablespace_name = 'AYV_QDATA_5';

--8--
--from AYV
Drop tablespace AYV_QDATA including contents and datafiles;

--9--
Select Group#,Status,Members From V$LOG;

--10--
Select * From V$LOGFILE;

--11--
Select * From V$LOG; -- 9:28 AM 10/10/2021

Alter system switch logfile;
Select GROUP#, SEQUENCE#,STATUS,FIRST_CHANGE#  From V$LOG;

--12--
Alter database add logfile group 4 'C:\app\yegorka\oradata\orcl\REDO04.LOG'
  Size 50m Blocksize 512;

Select GROUP#, SEQUENCE#,STATUS,FIRST_CHANGE#  From V$LOG;

Alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO041.LOG' To Group 4;
Alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO042.LOG' To Group 4;
Alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO043.LOG' To Group 4;

--13--
Alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO041.LOG';
Alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO042.LOG';
Alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO043.LOG';

Alter database drop logfile Group 4;

--14--
Select GROUP#, ARCHIVED From V$LOG;

Select Name, Log_MODE From v$database;
Select Archiver, Active_State From v$instance;

--15--
select * from (select * from v$archive_dest_status order by dest_id desc) 
  where rownum = 1;

--16--
--=sysdba
SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER DATABASE ARCHIVELOG;
ALTER DATABASE OPEN;
archive log list;

--17--
Alter system switch logfile;
Select * From V$archived_log;

--18
--sysdba
SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER DATABASE NOARCHIVELOG;
ALTER DATABASE OPEN;
archive log list;

--19--
Select * From v$controlfile;

--20--
Select * From v$controlfile_record_section;

--21--
--Show Parameter control;

--C:\app\yegorka\product\12.1.0\dbhome_1\database
--C:\app\yegorka\admin\orcl\pfile

--22--
-- SQLPLUS
Create pfile = 'AYV_PFILE.ORA' From spfile;
--C:\app\yegorka\product\12.1.0\dbhome_1\database

--23--
--C:\app\yegorka\product\12.1.0\dbhome_1\database

--24--
Select * From v$diag_info;


