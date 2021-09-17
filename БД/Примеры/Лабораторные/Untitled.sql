
set serveroutput on;
begin
dbms_output.put_line('?');
end;

drop table employee;
drop table departments;

create table departments
(
    id int primary key,
    name nvarchar2(100),
    address nvarchar2(100),
    telephone char(14),
    employeesCount int,
    salaryAVG float
)

truncate table employee;
insert into departments 
values (1, 'bstu', 'minsk', '111', 5, 500);
insert into departments 
values (2, 'belstu', 'minsk', '111', 5, 1000);

create table employee
(
    id int primary key,
    FIO nvarchar2 (50),
    address nvarchar2(100),
    telephone char(14),
    depId int,
    roleUser nvarchar2(20),
    birthDate date,
    salary float,
    CONSTRAINT fk_departments FOREIGN KEY (depId)
        REFERENCES departments (id)
)

insert into employee 
    values (1, 'andrei', 'minsk', '111', 1, 'a', '01-01-2017', 400);
insert into employee 
    values (2, 'bogdan', 'brest', '222', 1, 'b', '01-01-2016', 1000);
insert into employee 
    values (10, 'vlad', 'brest', '222', 2, 'b', '01-01-2016', 200);
    
create or replace procedure NewEmployee 
(id1 employee.id%type, FIO1 employee.FIO%type, address1 employee.address%type, telephone1 employee.telephone%type, 
    depId1 employee.depId%type, roleUser1 employee.roleUser%type, birthDate1 employee.birthDate%type)
    is
        salary float;
        countS int;
        countemp int;
        depempcount int;
begin
    select count(*) into countS from employee   where employee.roleUser = roleUser1 and employee.depId = depId1;
    dbms_output.put_line(countS);
    if (countS > 0)
        then
        
            select salary into salary from employee where roleUser = roleUser1 and rownum = 1;
            
           
        else
         select salaryAVG into salary 
                from departments 
                    where id = depId1 and rownum = 1;
    end if;
    select count(*) into countemp from employee where depId = depId1;
    select employeesCount into depempcount from departments where id = depId1;
    dbms_output.put_line(countemp);
    dbms_output.put_line(depempcount);
    dbms_output.put_line(depId1);
    if (countemp < depempcount)
        then
        begin
            insert into employee 
                values (id1, FIO1, address1, telephone1, depId1, roleUser1, birthDate1, salary);
                end;
    else
        RAISE_APPLICATION_ERROR(-20130, 'Max count of employees');
    end if;
    exception
        when others
        then
            dbms_output.put_line(SQLERRM);
            dbms_output.put_line(sqlcode);
end;

select * from employee;
select * from departments;

exec NewEmployee(1, 'andrei', 'minsk', '111', 1, 'a', '01.01.2017');
exec NewEmployee(2, 'bogdan', 'brest', '222', 1, 'b', '01-01-2016');

update departments
    set salaryAVG = 1000
    where id  = 2;

exec NewEmployee(3, 'Yarik', 'klichev', '32', 1, 'a', '01-01-2016');
 exec NewEmployee(4, 'Max', 'borisov', '22212', 1, 'c', '01-01-2016');
  exec NewEmployee(5, 'vanya', 'pinsk', '111', 1, 'd', '01-01-2016');
  
  
exec NewEmployee(6, 'Yarik', 'klichev', '32', 1, 'a', '01-01-2016');
 exec NewEmployee(7, 'Max', 'borisov', '22212', 2, 'c', '01-01-2016');
  exec NewEmployee(5, 'vanya', 'pinsk', '111', 1, 'd', '01-01-2016');
     

begin
dbms_scheduler.create_schedule(
    schedule_name => 'exschedule',
    start_date => '11/01/2019 12:00:00',
    repeat_interval => 'FREQ=WEEKLY',
    comments => 'comm');
end;
begin
    dbms_scheduler.create_program(
        program_name => 'updateSalary',
        program_type => 'stored_procedure',
        program_action => 'UpdateSalaryAVG'
        );
end;


select * from user_schedules;
create or replace procedure UpdateSalaryAVG
is
begin
    update departments
        set salaryAVG = (select AVG(salary) from employee
            where employee.depId = departments.id);
end;
    
