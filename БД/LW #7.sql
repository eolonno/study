--1
--list of the background tasks
select * from v$bgprocess;

--2
--tasks that are working now
select * from v$bgprocess where paddr != '00';

--3
--count of DBWn processes working now
select count(*) from v$bgprocess where paddr!= '00' and name like 'DBW%';

--4, 5
--connections with instance and its modes
select username, status, server from v$session where username is not null;

--6
select * from v$services;

--7
show parameter dispatcher;

--8
--show listener
select * from v$services;
-- orcl

--9
--connections with instance
select * from v$session where username is not null;

--10
--LISTENER.ORA
--D:\app\admin\product\12.1.0\dbhome_1\NETWORK\ADMIN\listener.ora

--11--
--start LSNRCTL.exe

--12--
--LSNRCTL -> services


