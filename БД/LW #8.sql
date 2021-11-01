--1
--D:\app\admin\product\12.1.0\dbhome_1\NETWORK\ADMIN\SQLNET.ORA
--D:\app\admin\product\12.1.0\dbhome_1\NETWORK\ADMIN\TNSNAMES.ORA

--2
--show parameter instance

--3
--connect system/Pa$$w0rd@localhost:1521/AYV_PDB
--select * from v$pdbs;
--select * from v$tablespace;
--select * from dba_data_files;
--select * from all_users;
--select * from dba_role_privs;

--4
--regedit
--Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Oracle

--6
--conn U1_AYV_PDB/Pa$$w0rd@yegor_pdb

--7
--select * from AYV_TABLE;

--8
--help
--help timing
--set timing on;
--select * from AYV_TABLE;
--set timing off;

--9
--help describe
--describe AYV_TABLE;

--10
--conn system/Pa$$w0rd@yegor_pdb
--select * from dba_segments where owner = 'U1_AYV_PDB';

--11
--conn sys/Pa$$w0rd@yegor_pdb as sysdba
create view EXTENTS as select extents, blocks, bytes from dba_segments;
--select * from EXTENTS;















