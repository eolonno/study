--1
--anonimous block without operators
begin
    null;
end;


--2
--just print hello world!
begin
    dbms_output.put_line('Hello World!');
end;


--3
--sqlcode, sqlerrm
declare
x number(3) := 3;
y number(3) := 0;
z number(10,2);
begin
    dbms_output.put_line('x = ' || x || ' , y:=' || y);
    z:=x/y;
    dbms_output.put_line('z = ' || z);
    exception
        when others
        then dbms_output.put_line('error: ' || sqlerrm || ' , code ' || sqlcode);
end;


--4
--nested block
declare
x number(3) := 3;
y number(3) := 0;
z number(10,2) := null;
begin
    dbms_output.put_line('x = ' || x || ' , y = ' || y);
    begin
        z:=x/y;
        exception
            when others
            then dbms_output.put_line('error= ' || sqlerrm || ' , code ' || sqlcode);
    end;
    dbms_output.put_line('z:= ' || z);
end;


--5
--Types of warnings that supports now (two ways)
show parameter plsql_warnings;
select name,value from v$parameter where name='plsql_warnings';


--6
--All reserved symbols
select keyword from v$reserved_words where length=1 and keyword!='A';


--7
--All reserved words
select keyword from v$reserved_words where length > 2 and keyword!='A' order by keyword;


--8
--All parameters connected with PL/SQL
show parameter plsql;


--9-17
--many variables of different types
declare
    x number(2):= 10;
    y number(2):= 7;
    z number(6,2);
    ab number(6,2):= 123.45;
    bc number(6,-2):= 123.45;
    bin_f binary_float := 12345.6789;
    bin_d binary_double := 12345.6789;
    step number(6,2) := 1e3;
    isTrue boolean := true;
begin
    z:= x/y;
    dbms_output.put_line('x = ' || x);
    dbms_output.put_line('y = ' || y);
    dbms_output.put_line('z = ' || z);
    dbms_output.put_line('ab = ' || ab);
    dbms_output.put_line('bc = ' || bc);
    dbms_output.put_line('bin_f = ' || bin_f);
    dbms_output.put_line('bin_d = ' || bin_d);
    dbms_output.put_line('step = ' || step);
    if isTrue
        then dbms_output.put_line('isTrue = true');
        else dbms_output.put_line('isTrue = false');
    end if;
end;


--18
--const
declare
    firstString constant varchar2(10):='Hello';
    secondString constant char(10):='world';
    someNumber constant number(5):= 11.11;
begin
    dbms_output.put_line('firstString = ' || firstString || ', length(firstString) = ' || length(firstString));
    dbms_output.put_line('secondString = ' || secondString || ', length(secondString) = ' || length(secondString));
    dbms_output.put_line('someNumber / 11 * 100 = ' || someNumber / 11 * 100);
end;


--19-20
--%type, %rowtype
declare
    subject sys.subject.subject%type;
    pulpit sys.pulpit.pulpit%type;
    faculty_rec sys.faculty%rowtype;
begin
    subject := 'INF';
    pulpit := 'ISiT';
    faculty_rec.faculty :='IT';
    faculty_rec.faculty_name := 'Fakul`tet informacionnyh tekhnologij';
    dbms_output.put_line(subject);
    dbms_output.put_line(pulpit);
    dbms_output.put_line(rtrim(faculty_rec.faculty) || ': ' || faculty_rec.faculty_name);
    exception
        when others
        then dbms_output.put_line('error = ' || sqlerrm);
end;


--21-22
--if elsif else
declare
    x int := 99;
begin
    if 50 > x
        then dbms_output.put_line('50 > ' || x);
    elsif 50 = x
        then dbms_output.put_line('50 = '||x);
    elsif 100 > x
        then dbms_output.put_line('100 > ' || x);
    elsif 100 = x
        then dbms_output.put_line('100 = ' || x);
    else dbms_output.put_line('100 <> ' || x);
    end if;
end;


--23
--case
declare
x int := 99;
begin
    case
        when 50 > x
            then dbms_output.put_line('100 > ' || x);
        when x between 50 and 100
            then dbms_output.put_line('50 =< ' || x || ' <= 100');
        else dbms_output.put_line('not of all');
    end case;
end;


--24-26
--loops
declare
x int := 0;
begin
    dbms_output.put_line('LOOP:');
    loop
        x := x + 1;
        dbms_output.put_line(x);
        exit when x > 5;
    end loop;
    
    dbms_output.put_line('FOR:');
    for k in 1..6
    loop
        dbms_output.put_line(k);
    end loop;
    
    dbms_output.put_line('WHILE:');
    while x > 0
    loop
        x := x-1;
        dbms_output.put_line(x);
    end loop;
end;