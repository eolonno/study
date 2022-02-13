--1
--Create dblink
--from system
create database link oracle2 connect to system identified by Pa$$w0rd
using
'(DESCRIPTION =
    (ADDRESS_LIST =
      (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.117)(PORT = 1521))
    )
    (CONNECT_DATA =
      (SERVICE_NAME = orcl)
    )
  )';

--drop database link oracle2;


--2
--select, insert, update, delete, function, procedure
select * from AAA@oracle2;

insert into AAA@oracle2 (x, y) values (1, 2);
insert into AAA@oracle2 (x, y) values (3, 4);
insert into AAA@oracle2 (x, y) values (5, 6);

update AAA@oracle2 set x = 2 where y = 2;

delete AAA@oracle2 where y > 0;
commit;

select custom_sum@oracle2(2, 4) from dual;

declare
  y number;
begin
  y := 0;
  return_10@oracle2(y);
  dbms_output.put_line(y);
end;

--3
--global dblink
create public database link oracle2_global connect to system identified by Pa$$w0rd
using
'(DESCRIPTION =
    (ADDRESS_LIST =
      (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.117)(PORT = 1521))
    )
    (CONNECT_DATA =
      (SERVICE_NAME = orcl)
    )
  )';

--drop database link oracle2_global;

--4
--select, insert, update, delete from global dblink
--from sys
select * from AAA@oracle2_global;

insert into AAA@oracle2_global (x, y) values (1, 2);
insert into AAA@oracle2_global (x, y) values (3, 4);
insert into AAA@oracle2_global (x, y) values (5, 6);

update AAA@oracle2_global set x = 2 where y = 2;

delete AAA@oracle2_global where y > 0;
commit;

select custom_sum@oracle2(2, 4) from dual;

declare
  y number;
begin
  y := 0;
  return_10@oracle2(y);
  dbms_output.put_line(y);
end;
