--1
-- from AYV
select * From dba_tablespaces;

--2
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
create table AYV_T1(
num int primary key,
desctiprion varchar(150))tablespace AYV_QDATA_5;

insert into AYV_T1
  values (1, 'one');
insert into AYV_T1
  values (2, 'two');
insert into AYV_T1 
  values (3, 'three');

select * from AYV_T1;

--3
select distinct * from user_segments where tablespace_name = 'AYV_QDATA_5';
select distinct * from user_segments where tablespace_name != 'AYV_QDATA_5';

--4
drop table AYV_T1;

select distinct * from user_segments where tablespace_name = 'AYV_QDATA_5';

select * from user_recyclebin;

--5
flashback table AYV_T1 to before drop;

select * from AYV_T1;

--6

declare i int:= 4;
begin loop i:=i+1;
  Insert into AYV_T1 values (i,'number');
  exit when(i = 10000);
end loop;
end;  
select * from AYV_T1;

--7--
select * from user_segments where tablespace_name = 'AYV_QDATA_5';

select * from user_extents where tablespace_name = 'AYV_QDATA_5';

--8--
--from AYV
drop tablespace AYV_QDATA_5 including contents and datafiles;

--9
select Group#,Status,Members from V$LOG;

--10
select * from V$LOGFILE;

--11
select * from V$LOG; -- 9:28 AM 10/10/2021

alter system switch logfile;
select GROUP#, SEQUENCE#,STATUS,FIRST_CHANGE#  From V$LOG;

--12--
alter database add logfile group 4 'C:\app\yegorka\oradata\orcl\REDO04.LOG'
  size 50m blocksize 512;

select GROUP#, SEQUENCE#,STATUS,FIRST_CHANGE#  From V$LOG;

alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO041.LOG' to group 4;
alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO042.LOG' to group 4;
alter database add logfile member 'C:\app\yegorka\oradata\orcl\REDO043.LOG' to group 4;

--13--
alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO041.LOG';
alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO042.LOG';
alter database drop logfile member 'C:\app\yegorka\oradata\orcl\REDO043.LOG';

alter database drop logfile group 4;

--14--
select GROUP#, ARCHIVED from V$LOG;

select name, Log_MODE from v$database;
select Archiver, Active_State From v$instance;

--15--
select * from (select * from v$archive_dest_status order by dest_id desc) 
  where rownum = 1;

--16--
--sysdba
SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER DATABASE ARCHIVELOG;
ALTER DATABASE OPEN;
archive log list;

--17--
alter system switch logfile;
select * From V$archived_log;

--18
--sysdba
SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER DATABASE NOARCHIVELOG;
ALTER DATABASE OPEN;
archive log list;

--19--
select * from v$controlfile;

--20--
select * from v$controlfile_record_section;

--21--
--Show Parameter control;

--C:\app\yegorka\product\12.1.0\dbhome_1\database
--C:\app\yegorka\admin\orcl\pfile

--22--
create pfile = 'AYV_PFILE.ORA' from spfile;
--C:\app\yegorka\product\12.1.0\dbhome_1\database

--23--
--C:\app\yegorka\product\12.1.0\dbhome_1\database

--24--
select * From v$diag_info;


