--1--
select * from v$sga;
select sum(value) from v$sga;
--2--
select component, current_size, min_size, last_oper_mode, last_oper_time, granule_size, current_size as Ratio from v$sga_dynamic_components where current_size > 0;
--3--
select component, current_size, min_size, last_oper_mode, last_oper_time, granule_size, current_size as Ratio from v$sga_dynamic_components where current_size > 0;
--4--
select current_size from v$sga_dynamic_free_memory;
--5--
select component, min_size, current_size from v$sga_dynamic_components;
--6--
create table Laba6 (k int) storage(buffer_pool keep) tablespace users;
insert into Laba6 values (1);
insert into Laba6 values (1);
commit;
select * from Laba6;
select segment_name, segment_type, tablespace_name, buffer_pool from user_segments
where segment_name in('Laba6');
--7--
create table Laba6_C (k int) cache tablespace users;
insert into Laba6_C values(1);
commit;
select segment_name, segment_type, tablespace_name, buffer_pool from user_segments
where segment_name in('Laba6_C');
--8--
show parameter log_buffer;
--9--
select pool, bytes from v$sgastat where pool like 'shared pool' and rownum<=10 order by bytes desc;
--10--
show parameter shared_pool;
select pool,name,bytes from v$sgastat where pool = 'large pool';
--11--
select name, network_name, pdb from v$services;
select username, service_name, server, osuser, machine, program from v$session where username is not null;