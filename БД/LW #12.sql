--1
-- add two columns (birthday, salary) to the teacher table
alter table teacher add
    (
        birthday date,
        salary number(6)
    );
    
select * from teacher;

alter session set nls_date_format='dd/mm/yyyy';
    
declare
    cursor c_teacher is select teacher from teacher for update;
    birth date;
    sal number(6);
begin
    for r_teach in c_teacher
    loop
        birth := to_date(trunc(
        dbms_random.value(to_char(date '1950-01-01','j') ,to_char(date '1999-12-31','j'))), 'j');
        sal := dbms_random.value(500,1500);
        update teacher set salary = sal, birthday = birth where current of c_teacher;
    end loop;
end;
    
select * from teacher;


--2
--LastName N. S.
declare
    cursor c_teach is select teacher_name from teacher;
    v_array apex_application_global.vc_arr2;
    v_string varchar2(50);
begin
    for r_teach in c_teach
    loop
        v_array := apex_util.string_to_table(r_teach.teacher_name, ' ');
        if v_array.count = 3 
            then v_string := v_array(1)||' '||substr(v_array(2), 1, 1)||'.'||substr(v_array(3), 1, 1)||'.';
        end if;
        dbms_output.put_line(v_string);
    end loop;
end;


--3
--teachers born in monday
select * from teacher where to_char(birthday, 'd') = '6';


--4
--teachers born in november
create view teacher_next as
  select * from teacher where to_char(birthday, 'mm') = to_char(add_months(sysdate, 1), 'mm');
  
select * from teacher_next;

drop view teacher_next;


--5
--count of teachers born in every month
create view teachers_months as
  select to_char(birthday, 'mm') month, count(*) count 
    from teacher 
    group by to_char(birthday, 'mm') 
    order by to_char(birthday, 'mm');
  
select * from teachers_months;

drop view teachers_months;


--6
--list of teachers who have an anniversary next year
declare
    cursor c_teach is select teacher_name, birthday from teacher;
begin
    for r_teach in c_teach
    loop
        if mod(to_number(extract(year from r_teach.birthday)) - to_number(extract(year from (add_months(sysdate, 12)))), 5) = 0 
            then dbms_output.put_line(r_teach.teacher_name||' '||r_teach.birthday);
        end if;
    end loop;
end;

--7
--print salary report
declare
    cursor c_pulp is select pulpit, faculty from pulpit;
    cursor c_fac is select faculty from faculty;
    avgsal number(6);
begin
    dbms_output.put_line('pulpits:');
    for r_pulp in c_pulp
    loop
        select floor(avg(salary)) into avgsal from teacher where pulpit = r_pulp.pulpit;
        dbms_output.put_line(rpad(r_pulp.pulpit, 20) || ' ' || avgsal);
    end loop;
    
    dbms_output.put_line('faculties:');
    for r_fac in c_fac
    loop
        select floor(avg(salary)) into avgsal from teacher where pulpit in (select pulpit from pulpit where faculty = r_fac.faculty);
        dbms_output.put_line(rpad(r_fac.faculty, 20) || ' ' || avgsal);
    end loop;
    
    select floor(avg(salary)) into avgsal from teacher;
    dbms_output.put_line(rpad('all', 20) || avgsal);
end;

--8
--record
declare
  type small_teacher is record (
    teacher char(50),
    salary number(6)
  );

  type all_teachers is record
    (biggest_sal# small_teacher,
    smallest_sal# small_teacher,
    any_sal# small_teacher
  );
  
  tchrs all_teachers;
begin
    select teacher_name, salary into tchrs.biggest_sal# from teacher where salary = (select max(salary) from teacher);
    select teacher_name, salary into tchrs.smallest_sal# from teacher where salary = (select min(salary) from teacher);
    tchrs.any_sal# := tchrs.biggest_sal#;
    
    tchrs.any_sal#.salary := (tchrs.biggest_sal#.salary + tchrs.smallest_sal#.salary) / 2;
    select teacher_name into tchrs.any_sal#.teacher from teacher where teacher_name = 'Urbanovich Pavel Pavlovich';
    
    dbms_output.put_line('Biggest salary: ' || rtrim(tchrs.biggest_sal#.teacher) || ' ' || tchrs.biggest_sal#.salary);
    dbms_output.put_line('Smallest salary: ' || rtrim(tchrs.smallest_sal#.teacher) || ' ' || tchrs.smallest_sal#.salary);
    dbms_output.put_line('Any salary: ' || rtrim(tchrs.any_sal#.teacher) || ' ' || tchrs.any_sal#.salary);
end;


--DROP EXTRA COLUMNS
alter table teacher drop (salary, birthday);
