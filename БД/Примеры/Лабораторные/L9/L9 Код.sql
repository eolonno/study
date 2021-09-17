
--2--
create sequence S1
      increment by 10
      start with 1000
      nomaxvalue
      nominvalue
      nocycle
      nocache
      noorder;

select S1.nextval from dual;
select S1.currval from dual;

drop sequence S1;


--3--
create sequence S2
      increment by 10
      start with 10
      maxvalue 100
      nominvalue
      nocycle
      nocache
      noorder;
      
select S2.nextval from dual;
select S2.currval from dual;

drop sequence S2;


--4--
create sequence S3
      start with -10
      increment by -10
      minvalue -100
      nocycle
      order;
      
select S3.nextval from dual;
select S3.currval from dual;

drop sequence S3;


--5--
create sequence S4
      start with 1
      increment by 1
      maxvalue 10
      cycle
      cache 5
      noorder;
      
select S4.nextval from dual;
select S4.currval from dual;   

drop sequence S4;


--6--
select * from sys.dba_sequences where sequence_owner='C##U3_PKM_PDB_D';


--7--
create table T1 (a1 number(20),a2 number(20),a3 number(20),a4 number(20)) cache;
alter table T1 storage (buffer_pool keep);
declare
x number:=0;
begin
loop
insert into T1 (a1, a2, a3, a4) values (S1.nextval, S2.nextval,S3.nextval,S4.nextval);
x:=x+1;
exit when x=6;
end loop;
end;
select * from T1;


--8--
create cluster ABC
  (
    x number(10),
    v varchar2(12)
  )
  hashkeys 200;
  
  
--9--
create table A
  (
    xa number(10),
    va varchar2(12),
    ca int
  )
  cluster ABC(xa, va);
  insert into A (xa, va, ca) values (100, 'ABC', 10);
  select * from A;
  
  
--10--
  create table B
  (
    xb number(10),
    vb varchar2(12),
    cb int
  )
  cluster ABC(xb, vb);
  insert into B (xb, vb, cb) values (120, 'ABC1', 20);
  select * from B;


--11--
create table C
  (
    xc number(10),
    vc varchar2(12),
    cc int
  )
  cluster ABC(xc, vc); 
  insert into C (xc, vc, cc) values (140, 'ABC2', 40);
  select * from C;


--12--
select * from dba_clusters;
select * from dba_tables where owner = 'U3_VAG_PDB';


--13--
create synonym sin_a for U3_VAG_PDB.C;
select * from sin_a;


--14--
create public synonym sin_b for U3_VAG_PDB.B;
select * from sin_b;


--15--
create table A_1(a1 number(10),b1 varchar(12),constraint a1_pk primary key (a1))
insert into A_1 (a1, b1) values (1,'a');
insert into A_1 (a1, b1) values (2,'b');
insert into A_1 (a1, b1) values (3,'c');
insert into A_1 (a1, b1) values (4,'d');

create table B_1(a2 number(10),b2 varchar(12), CONSTRAINT a2_fk FOREIGN KEY (a2) REFERENCES A_1(a1))
insert into B_1 (a2, b2) values (1,'a1');
insert into B_1 (a2, b2) values (2,'b2');
insert into B_1 (a2, b2) values (3,'c3');
insert into B_1 (a2, b2) values (4,'d4');
commit;
create view v1 as select A_1.b1, B_1.b2 from A_1  inner join B_1 on A_1.a1=B_1.a2;
select * from v1;


--16--
insert into A_1 (a1, b1) values (5,'e');
insert into A_1 (a1, b1) values (6,'f');
create materialized view mv1
build immediate 
refresh complete on demand next sysdate + numtodsinterval(2, 'minute') 
as select * from A_1;
select * from mv1;
