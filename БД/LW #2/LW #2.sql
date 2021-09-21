create tablespace TS_AYV
  datafile 'Z:\LW #2\Tablespaces\TS_AYV.dbf'
  size 7m
  autoextend on next 5m
  maxsize 20m
  extent management local;
  
create temporary tablespace TS_AYV_TEMP
  tempfile 'Z:\LW #2\Tablespaces\TS_AYV_TEMP.dbf'
  size 5m
  autoextend on next 3m
  maxsize 30m
  extent management local;
commit;
  
select tablespace_name from SYS.DBA_TABLESPACES;

--StackOverflow
alter session set "_ORACLE_SCRIPT"=true;  

create role RLAYV_CORE;
drop role RLAVY_CORE;
grant create session,
      create table,
      create view,
      create procedure to RLAYV_CORE;
  
grant drop table,
      drop view,
      drop procedure to RLAYV_CORE;
commit;

select * from dba_roles where ROLE = 'RLAYV_CORE';
select * from dba_roles where ROLE != 'RLAYV_CORE';
select * from dba_sys_privs;
select * from dba_sys_privs where grantee = 'RLAYV_CORE';

create profile PF_AYVCORE limit
  password_life_time 180
  sessions_per_user 3
  failed_login_attempts 7
  password_lock_time 1
  password_reuse_time 10
  password_grace_time default
  connect_time 180
  idle_time 30;
  
select * from dba_profiles where PROFILE = 'PF_AYVCORE';
select * from dba_profiles where PROFILE = 'DEFAULT';
select * from dba_profiles;

create user AYVCORE identified by 123
  default tablespace TS_AYV quota unlimited on TS_AYV
  temporary tablespace TS_AYV_TEMP
  profile PF_AYVCORE
  account unlock
  password expire;
  
grant RLAYV_CORE to AYVCORE;
commit;

create tablespace AYV_QDATA
  datafile 'Z:\LW #2\Tablespaces\AYV_QDATA.dbf'
  size 10m
  autoextend on next 5m
  maxsize 20m
  extent management local
  offline;
  
alter tablespace AYV_QDATA online;

alter user AYVCORE quota 2m on AYV_QDATA;

--AYVCORE

alter user AYVCORE default tablespace AYV_QDATA;

create table AYV_T1
  (x number(3), 
  y varchar(10));
  
insert into AYV_T1 values (1, 'one');
insert into AYV_T1 values (2, 'two');
insert into AYV_T1 values (3, 'three');

select * from AYV_t1;

  
