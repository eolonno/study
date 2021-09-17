--1--
select count (*) from v$bgprocess;
--2--
select name, description from v$bgprocess where paddr!=hextoraw('00') order by name;
--3--
select * from v$bgprocess where name like 'DBWn' order by name;
--4--
select * from v$session;
--5--
select username, sid, serial#, server, paddr, status from v$session where username is not null;
--6--
select paddr, username, service_name, server, osuser, machine, program from v$session where username is not null;
--7--
--select addr, spid, pname from v$process where background is null order by pname;
show parameter dispatcher;
--8--
select *from v$services;
--9--
select paddr, username, service_name, server, osuser, machine, program from v$session where username is not null;
--10-
--11--
--12--
select *from v$process where PNAME like 'LREG'