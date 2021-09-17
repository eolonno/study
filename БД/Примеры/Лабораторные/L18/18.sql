drop table lab18;

create table lab18
(
  integervalue INTEGER,
  charvalue char(20),
  datevalue date
)

DELETE FROM lab18;
select * from lab18;

spool C:\Users\admid\export.txt
select * from lab18;
spool off
