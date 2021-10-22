--1
--SGA Size
select sum(value) from v$sga;

--2--
--main pools

select * from v$sga_dynamic_components where current_size > 0;

--3
--Granule size
select component, granule_size from v$sga_dynamic_components where current_size > 0;

--4
--amount of free memory available in the SGA
select current_size from v$sga_dynamic_free_memory;

--5
--KEEP, DEFAULT and RECYCLE
select * from v$sga_dynamic_components where component like '%cache%';

--6
--KEEP
create table T1(
  num int primary key,
  str varchar(150)) storage(buffer_pool KEEP);

select * from user_segments where segment_name = 'T1';

--7
--DEFAULT
create table T1_CACHE(
  num int primary key,
  str varchar(150))cache storage(buffer_pool default);

select * from user_segments where segment_name = 'T1_CACHE';

--8
--Size of the log buffer
show parameter log_buffer;

--9
--10 biggest items in the shared pool
select * from (select * from v$sgastat where pool='shared pool' order by bytes desc) where rownum <= 10;

--10
--Free memory in the large pool
select * from v$sgastat where pool = 'large pool' and name = 'free memory';

--11, 12
--Current connections with instance, connection modes
select username, service_name, server from v$session where username is not null;

--13
select * from v$db_object_cache Order by executions desc;