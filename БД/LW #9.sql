--2
create sequence S1
    start with 1000
    increment by 10
    nominvalue
    nomaxvalue
    nocycle
    nocache
    noorder;


select S1.nextval from dual; --more times
select S1.currval from dual;

--drop sequence s1;


--3-4
create sequence S2
    start with 10
    increment by 10
    maxvalue 100
    nocycle;

select S2.nextval from dual; --more times
select S2.currval from dual;

--drop sequence s2;


--5
create sequence S3
    start with 10
    increment by -10
    minvalue -100
    maxvalue 20
    nocycle
    order;

select S3.nextval from dual; --more times
select S3.currval from dual;

--drop sequence s3;


--6
create sequence S4
    start with 1
    increment by 1
    maxvalue 10
    cycle
    cache 5
    noorder;

select S4.nextval from dual; --more times
select S4.currval from dual;

--drop sequence s4;


--7
select * from sys.dba_sequences where sequence_owner = 'SYS';


--8
create table T1
(
    n1 number(20),
    n2 number(20),
    n3 number(20),
    n4 number(20)
) storage(buffer_pool KEEP);

declare x number:=0;
begin
    loop
        insert into T1(n1,n2,n3,n4) values(S1.nextval,S2.nextval,S3.nextval,S4.nextval);
        x:= x + 1;
        exit when x = 7;
    end loop;
end;

select * from T1;

drop table T1;


--9
create cluster ABC
(
    x number(10),
    v varchar(12)
)hashkeys 200;


--10
create table A
(
    xa number(10),
    va varchar(12),
    aint int
)cluster ABC(xa,va);


--11
create table B
(
    xb number(10),
    vb varchar(12),
    bint int
)cluster ABC(xb,vb);


--12
create table C
(
    xc number(10),
    vc varchar(12),
    cint int
)cluster ABC(xc,vc);

--drop table A;
--drop table B;
--drop table C;

--13
select cluster_name, owner, tablespace_name, cluster_type, cache from dba_clusters;

select * from dba_tables where table_name = 'A' OR table_name = 'B' OR table_name = 'C';


--14
create synonym CSYN for sys.C;

insert into CSYN values (10, 'sometext', 25);
select * from CSYN;

--drop synonym SYN;


--15
create public synonym GLOBALBSYN for sys.B;

insert into GLOBALBSYN values (10, 'sometext', 25);
select * from GLOBALBSYN;

--drop public synonym GLOBALBSYN;

--16
create table A1
(
    x number(10),
    y varchar(12),
    constraint x_pk primary key (x)
);

insert into A1 (x, y) values (1,'a');
insert into A1 (x, y) values (2,'b');
insert into A1 (x, y) values (3,'c');
insert into A1 (x, y) values (4,'d');
insert into A1 (x, y) values (5,'e');
insert into A1 (x, y) values (6,'f');

select * from A1;


create table B1
(
    xB number(10),
    yB varchar(12),
    CONSTRAINT xB_fk FOREIGN KEY (xB) REFERENCES A1(x)
);

insert into B1 (xB, yB) values (1,'one');
insert into B1 (xB, yB) values (2,'two');
insert into B1 (xB, yB) values (3,'three');
insert into B1 (xB, yB) values (4,'four');
insert into B1 (xB, yB) values (5,'five');
insert into B1 (xB, yB) values (6,'six');

select * from B1;


create view v1
    as select A1.x, A1.y, B1.yB
    from A1 inner join B1 on A1.x = B1.xB;

select * from v1;


--17
create materialized view MV
    refresh complete on demand next sysdate + numtodsinterval(2, 'minute')
    as select A1.x, A1.y, B1.yB
    from A1 inner join B1 on A1.x = B1.xB;

select * from MV;


--drop materialized view MV;
