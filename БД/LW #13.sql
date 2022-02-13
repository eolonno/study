alter database AYV_PDB open;

--1
--this procedure should print list of teachers working at a given pulpit
create or replace procedure get_teachers(pcode in teacher.pulpit%type)
    is
    cursor teacher_cur is select * from teacher where pulpit = pcode;
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
end get_teachers;

begin
    get_teachers('ISiT');
end;


--2-3
--this function should return number of teacher that working at a given pulput
create or replace function get_num_teachers(pcode teacher.pulpit%type)
    return number is rc number(2);
    begin
        select count(*) into rc from teacher where pulpit = pcode;
        return rc;
    exception 
        when others then return -1;
end get_num_teachers;


select get_num_teachers('ISiT') from dual;


--4
create or replace procedure get_teachers_by_faculty(fcode faculty.faculty%type)
    is
    cursor teacher_cur 
        is select t.teacher, t.teacher_name, t.gender, t.pulpit 
            from teacher t
            join pulpit on t.pulpit = pulpit.pulpit
            join faculty on faculty.faculty = pulpit.faculty
            where faculty.faculty = fcode;
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
end get_teachers_by_faculty;

begin
    get_teachers_by_faculty('IDiP');
end;

--this procedure should print all subjects pinned by given pulpit
create or replace procedure get_subjects(pcode subject.pulpit%type)
    is
    cursor subject_cur 
        is select * 
        from subject 
        where pulpit = pcode;
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
end get_subjects;

begin
    get_subjects('ISiT');
end;


--5
--this functions should return number of teachers that working at a given pulpit
create or replace function get_num_teachers_by_faculty(fcode faculty.faculty%type)
    return number is rc number(2);
    begin
        select count(*)
            into rc
            from teacher t
            join pulpit on t.pulpit = pulpit.pulpit
            join faculty on faculty.faculty = pulpit.faculty
            where faculty.faculty = fcode;
        return rc;
    exception
        when others then return -1;
end get_num_teachers_by_faculty;

select get_num_teachers_by_faculty('IDiP') from dual;

--this fuctions should return return number of subjects pinned by given pulpit
create or replace function get_num_subjects(pcode subject.pulpit%type)
    return number is rc number(2);
    begin
    select count(*)
        into rc
        from subject 
        where pulpit = pcode;
    return rc;
    exception
        when others then return -1;
end get_num_subjects;

select get_num_subjects('ISiT') from dual;


--6
--create package 'teachers'
create or replace package teachers is
    procedure get_teachers_by_faculty(fcode faculty.faculty%type);
    procedure get_subjects(pcode subject.pulpit%type);
    function get_num_teachers_by_faculty(fcode faculty.faculty%type) return number;
    function get_num_subjects(pcode subject.pulpit%type) return number;
end teachers;

create or replace package body teachers is
    procedure get_teachers_by_faculty(fcode faculty.faculty%type)
        is
        cursor teacher_cur 
            is select t.teacher, t.teacher_name, t.gender, t.pulpit 
                from teacher t
                join pulpit on t.pulpit = pulpit.pulpit
                join faculty on faculty.faculty = pulpit.faculty
                where faculty.faculty = fcode;
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
    end get_teachers_by_faculty;
    
    procedure get_subjects(pcode subject.pulpit%type)
        is
        cursor subject_cur 
            is select * 
            from subject 
            where pulpit = pcode;
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
    end get_subjects;

    function get_num_teachers_by_faculty(fcode faculty.faculty%type)
        return number is rc number(2);
        begin
            select count(*)
                into rc
                from teacher t
                join pulpit on t.pulpit = pulpit.pulpit
                join faculty on faculty.faculty = pulpit.faculty
                where faculty.faculty = fcode;
            return rc;
        exception
            when others then return -1;
    end get_num_teachers_by_faculty;
    
    function get_num_subjects(pcode subject.pulpit%type)
        return number is rc number(2);
        begin
        select count(*)
            into rc
            from subject 
            where pulpit = pcode;
        return rc;
        exception
            when others then return -1;
    end get_num_subjects;
    
    begin
        null;
    exception 
        when others then dbms_output.put_line(sqlerrm);
end teachers;

--7
--demo of teachers
declare 
    num_by_fac number(2);
    num_by_sub number(2);
begin
    select teachers.get_num_teachers_by_faculty('IDiP') into num_by_fac from dual;
    teachers.get_teachers_by_faculty('IDiP');
    dbms_output.put_line('Number of teachers at IDiP: ' || num_by_fac);
    dbms_output.new_line();
    teachers.get_subjects('ISiT');
    select teachers.get_num_subjects('ISiT') into num_by_sub from dual;
    dbms_output.put_line('Number of teachers at ISiT: ' || num_by_sub);
end;