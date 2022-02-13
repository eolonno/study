--IMPLICIT CURSORS
--1
declare
    IT faculty%rowtype;
begin
    select FACULTY, FACULTY_NAME
        into IT
        from faculty
        where faculty = 'IT';
    dbms_output.put_line('faculty: ' || IT.faculty);
    dbms_output.put_line('facluty_name: ' || IT.faculty_name);
    exception
        when others
            then dbms_output.put_line(sqlerrm);
end;

--2
--sqlcode/sqlerrm
declare
    IT faculty%rowtype;
begin
    select FACULTY, FACULTY_NAME 
        into IT 
        from faculty;
    dbms_output.put_line('faculty: ' || IT.faculty);
    dbms_output.put_line('facluty_name: ' || IT.faculty_name);
    exception 
        when others
            then dbms_output.put_line('error' || sqlcode || ': ' || sqlerrm);
end;


--3
--too_many_rows
declare
    IT faculty%rowtype;
begin
    select FACULTY, FACULTY_NAME 
        into IT 
        from faculty;
    dbms_output.put_line('faculty: ' || IT.faculty);
    dbms_output.put_line('facluty_name: ' || IT.faculty_name);
    exception 
        when too_many_rows
            then dbms_output.put_line('error' || sqlcode || ': ' || sqlerrm);
end;


--4
--no_data_found
declare
    IT faculty%rowtype;
begin
    select FACULTY, FACULTY_NAME 
        into IT 
        from faculty
        where FACULTY = 'PPS';
    dbms_output.put_line('faculty: ' || IT.faculty);
    dbms_output.put_line('facluty_name: ' || IT.faculty_name);
    exception 
        when no_data_found
            then dbms_output.put_line('error-' || sqlcode || ': no data found');
        when too_many_rows
            then dbms_output.put_line('error-' || sqlcode || ': too many rows');
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--5
--update with rollback/commit
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    update faculty 
        set faculty_name = 'TOV'
        where faculty = 'TOV'; --Tekhnologiya organicheskih veshchestv
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------ because i dont want to change smth in this table
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--6
--integrity constaint
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    update faculty 
        set faculty_name = 'TOV',
        faculty = 'Tekhnologiya organicheskih veshchestv' --HERE
        where faculty = 'TOV'; --Tekhnologiya organicheskih veshchestv
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;

--7
--insert with rollback/commit
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    insert into faculty values ('JSF', 'Just some faculty');
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--8
--integrity constaint
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    insert into faculty values ('Just some faculty', 'Just some faculty'); -- HERE
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--9
--delete with rollback/commit
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    delete auditorium where auditorium = '206-1';
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--10
--integrity constaint
declare
    is_found boolean;
    is_open boolean;
    is_notfound boolean;
    rowcount pls_integer;
begin
    delete faculty where faculty = 'TOV'; --HERE
    --rollback;------------------------------------------------------------
    is_found := sql%found;
    is_open := sql%isopen;
    is_notfound := sql%notfound;
    rowcount := sql%rowcount;
    if is_found 
        then dbms_output.put_line('is_found = true');
        else dbms_output.put_line('is_found = false');
    end if;
    if is_open 
        then dbms_output.put_line('is_open = true');
        else dbms_output.put_line('is_open = false');
    end if;
    if is_notfound 
        then dbms_output.put_line('is_notfound = true');
        else dbms_output.put_line('is_notfound = false');
    end if;
    dbms_output.put_line('rowcount = ' || rowcount);
    rollback;------------------------------------------------------------
    --commit
    exception
        when others
            then dbms_output.put_line('error-' || sqlcode || ': ' || sqlerrm);
end;


--EXPLICIT CURSORS
--11
--select * from teacher; its a task, but with %type variables and loop
declare
    cursor teacher_cur is select * from teacher;
    c_teacher teacher.teacher%type;
    c_teacher_name teacher.teacher_name%type;
    c_gender teacher.gender%type;
    c_pulput teacher.pulpit%type;
begin
    dbms_output.put_line('TEACHER    TEACHER_NAME                                                                                         G PULPIT              ');
    dbms_output.put_line('---------- ---------------------------------------------------------------------------------------------------- - --------------------');
    open teacher_cur;
    loop
        fetch teacher_cur into c_teacher, c_teacher_name, c_gender, c_pulput;
        exit when teacher_cur%notfound;
        dbms_output.put_line(rpad(c_teacher, 10) || ' ' || rpad(c_teacher_name, 100) || ' ' || c_gender || ' ' || rpad(c_pulput, 20));
    end loop;
    close teacher_cur;
end;


--12
--select * from subject; its a task, but with %rowtype variables and while loop
declare
    cursor subject_cur is select * from subject;
    c_subject subject%rowtype;
begin
    dbms_output.put_line('SUBJECT    SUBJECT_NAME                                                                                         PULPIT              ');
    dbms_output.put_line('---------- ---------------------------------------------------------------------------------------------------- --------------------');
    open subject_cur;
    fetch subject_cur into c_subject;
    while subject_cur%found
    loop
        dbms_output.put_line(rpad(c_subject.subject, 10) || ' ' || rpad(c_subject.subject_name, 100) || ' ' || rpad(c_subject.pulpit, 20));
        fetch subject_cur into c_subject;
    end loop;
    close subject_cur;
end;


--13
--select teacher, pulpit_name
--                                from teacher 
--                                join pulpit 
--                                on teacher.pulpit = pulpit.pulpit;  -- TASK
declare
    cursor teacher_pulpit is select teacher, pulpit_name
                                from teacher 
                                join pulpit 
                                on teacher.pulpit = pulpit.pulpit;
    c_teacher teacher.teacher%type;
    c_pulpit pulpit.pulpit_name%type;
begin
    dbms_output.put_line('TEACHER    PULPIT_NAME                                                                                         ');
    dbms_output.put_line('---------- ----------------------------------------------------------------------------------------------------');
    open teacher_pulpit;
    fetch teacher_pulpit into c_teacher, c_pulpit;
    while teacher_pulpit%found
    loop
        dbms_output.put_line(rpad(c_teacher, 11) || rpad(c_pulpit, 100));
        fetch teacher_pulpit into c_teacher, c_pulpit;
    end loop;
    close teacher_pulpit;
end;


--14
declare
    cursor sample_of_auditoriums (min_bound auditorium.auditorium_capacity%type, max_bound auditorium.auditorium_capacity%type)
        is select * 
            from auditorium
            where auditorium_capacity between min_bound and max_bound;
    c_auditorium auditorium%rowtype;
begin
    dbms_output.put_line('AUDITORIUMS CAPACITY LESS THAN 20');
    dbms_output.put_line('');
    dbms_output.put_line('AUDITORIUM           AUDITORIUM_TYPE AUDITORIUM_CAPACITY AUDITORIUM_NAME');
    dbms_output.put_line('-------------------- --------------- ------------------- ---------------');
    open sample_of_auditoriums(0, 20);
    loop
        fetch sample_of_auditoriums into c_auditorium;
        exit when sample_of_auditoriums%notfound;
        dbms_output.put_line(rpad(c_auditorium.auditorium, 21) || rpad(c_auditorium.auditorium_type, 16) || rpad(c_auditorium.auditorium_capacity, 20) || rpad(c_auditorium.auditorium_name, 15));
    end loop;
    close sample_of_auditoriums;
    
    dbms_output.put_line('');
    dbms_output.put_line('');
    
    dbms_output.put_line('AUDITORIUMS CAPACITY BETWEEN 20 AND 30');
    dbms_output.put_line('');
    dbms_output.put_line('AUDITORIUM           AUDITORIUM_TYPE AUDITORIUM_CAPACITY AUDITORIUM_NAME');
    dbms_output.put_line('-------------------- --------------- ------------------- ---------------');
    open sample_of_auditoriums(20, 30);
    fetch sample_of_auditoriums into c_auditorium;
    while sample_of_auditoriums%notfound
    loop
        dbms_output.put_line(rpad(c_auditorium.auditorium, 21) || rpad(c_auditorium.auditorium_type, 16) || rpad(c_auditorium.auditorium_capacity, 20) || rpad(c_auditorium.auditorium_name, 15));
        fetch sample_of_auditoriums into c_auditorium;
    end loop;
    close sample_of_auditoriums;
    
    dbms_output.put_line('');
    dbms_output.put_line('');
    
    dbms_output.put_line('AUDITORIUMS CAPACITY BETWEEN 30 AND 60');
    dbms_output.put_line('');
    dbms_output.put_line('AUDITORIUM           AUDITORIUM_TYPE AUDITORIUM_CAPACITY AUDITORIUM_NAME');
    dbms_output.put_line('-------------------- --------------- ------------------- ---------------');
    for c_auditorium in sample_of_auditoriums(30, 60)
    loop
        dbms_output.put_line(rpad(c_auditorium.auditorium, 21) || rpad(c_auditorium.auditorium_type, 16) || rpad(c_auditorium.auditorium_capacity, 20) || rpad(c_auditorium.auditorium_name, 15));
    end loop;
    
    dbms_output.put_line('');
    dbms_output.put_line('');
    
    dbms_output.put_line('AUDITORIUMS CAPACITY BETWEEN 60 AND 80');
    dbms_output.put_line('');
    dbms_output.put_line('AUDITORIUM           AUDITORIUM_TYPE AUDITORIUM_CAPACITY AUDITORIUM_NAME');
    dbms_output.put_line('-------------------- --------------- ------------------- ---------------');
    for c_auditorium in sample_of_auditoriums(60, 80)
    loop
        dbms_output.put_line(rpad(c_auditorium.auditorium, 21) || rpad(c_auditorium.auditorium_type, 16) || rpad(c_auditorium.auditorium_capacity, 20) || rpad(c_auditorium.auditorium_name, 15));
    end loop;
    
    dbms_output.put_line('');
    dbms_output.put_line('');
    
    dbms_output.put_line('AUDITORIUMS CAPACITY MORE THAN 80');
    dbms_output.put_line('');
    dbms_output.put_line('AUDITORIUM           AUDITORIUM_TYPE AUDITORIUM_CAPACITY AUDITORIUM_NAME');
    dbms_output.put_line('-------------------- --------------- ------------------- ---------------');
    for c_auditorium in sample_of_auditoriums(80, 100)
    loop
        dbms_output.put_line(rpad(c_auditorium.auditorium, 21) || rpad(c_auditorium.auditorium_type, 16) || rpad(c_auditorium.auditorium_capacity, 20) || rpad(c_auditorium.auditorium_name, 15));
    end loop;
end;
    

--15
--ref cursor
declare
    type t_faculty is ref cursor;
    cur_faculty t_faculty;
    d_faculty faculty.faculty%type;
begin
    open cur_faculty for select faculty from faculty;
    loop
        fetch cur_faculty into d_faculty;
        exit when cur_faculty%notfound;
        dbms_output.put_line(d_faculty);
    end loop;
    close cur_faculty;
end;


--16
--cursor subquery
declare 
  cursor curs_aut
    is select auditorium_type,
                            cursor(select auditorium
                                    from auditorium aum
                                    where aut.auditorium_type = aum.auditorium_type
                            ) 
        from auditorium_type aut;
    curs_aum sys_refcursor;
    aut auditorium_type.auditorium_type%TYPE;
    txt varchar2(1000);
    aum auditorium.auditorium%TYPE;
begin
    open curs_aut;
    fetch curs_aut into aut, curs_aum;
    while(curs_aut%found)
    loop
        txt := rtrim(aut)||':';
        loop
            fetch curs_aum into aum;
            exit when curs_aum%notfound;
            txt := txt||','||rtrim(aum);
        end loop;
        dbms_output.put_line(txt);
        fetch curs_aut into aut, curs_aum;
    end loop;
    close curs_aut;
    exception
        when others
            then dbms_output.put_line(sqlerrm);
end;


--17
--reduction of all the capacity of all auditoriums, with a capacity of 40-80 by 10%
declare
    cursor c_auditorum (min_bound auditorium.auditorium_capacity%type, max_bound auditorium.auditorium_capacity%type)
        is select auditorium_capacity 
            from auditorium
            where auditorium_capacity between min_bound and max_bound
            for update;
begin
    for aum_capacity in c_auditorum(40, 80)
    loop
        update auditorium set auditorium_capacity = auditorium_capacity * 0.9 where current of c_auditorum;\
    end loop;
    rollback; -- because i dont want to change smth in this table
end;


--18
--remove all auditoriums where capacity less than 20
declare
    cursor c_auditorum (min_bound auditorium.auditorium_capacity%type, max_bound auditorium.auditorium_capacity%type)
        is select auditorium_capacity 
            from auditorium
            where auditorium_capacity between min_bound and max_bound
            for update;
begin
    for aum_capacity in c_auditorum(0, 20)
    loop
        delete auditorium where current of c_auditorum;
    end loop;
    rollback; -- because i dont want to change smth in this table
end;


--19
create sequence S1
    start with 1
    increment by 10
    nominvalue
    nomaxvalue
    nocycle;

create table some_table (x numeric(30));

begin
    for x in 1..10
    loop
        insert into some_table values(S1.nextval);
    end loop;
end;

drop sequence S1;
select * from some_table;

declare
    cursor cur is select x, rowid from some_table;
begin
    for x in cur
    loop
        case
            when x.x >= 50
                then delete some_table where rowid = x.rowid;
            when x.x <= 50
                then update some_table set x = x + 5 where rowid = x.rowid;
        end case;
    end loop;
end;

select * from some_table;

drop table some_table;


--20
--print all teachers and put a separator after every third teacher
declare
    cursor teachers is select teacher_name from teacher;
    i numeric(5);
begin
    i := 0;
    for teacher in teachers
    loop
        dbms_output.put_line(teacher.teacher_name);
        i := i + 1;
        if mod(i, 3) = 0
            then dbms_output.put_line('-----------');
        end if;
    end loop;
end;








