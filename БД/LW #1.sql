create table XXX_t(x number(3), s varchar2(50));

insert into XXX_t values (212, 'Hello');
insert into XXX_t values (132, 'World');
insert into XXX_t values (110, '!');
commit;

update XXX_t set x = 22 where s = '!' and s = 'Hello';
commit;

select * from XXX_t;
select sum(x) from xxx_t;

delete from xxx_t where x = 212;
commit;

alter table XXX_t add constraint pk_constraint primary key(x);

create table XXX_t1(
  y number(3),
  p varchar2(50),
  constraint fk_column foreign key (y) references XXX_t (x)
);
commit;

insert into XXX_t1 values (212, 'one');
insert into XXX_t1 values (22, 'two');
commit;

select * from xxx_t right join xxx_t1 on xxx_t.x = xxx_t1.y;
select * from xxx_t1 right join xxx_t1 on xxx_t.x = xxx_t1.y;
select * from xxx_t inner join xxx_t1 on xxx_t.x = xxx_t1.y;

drop table xxx_t1;
commit;
drop table xxx_t;
commit;

