CREATE TABLE AUDITORIUM_TYPE 
(
AUDITORIUM_TYPE  varchar(10) PRIMARY KEY,  
AUDITORIUM_TYPENAME  varchar(30)        
);

INSERT INTO AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)        
VALUES ('ЛК', 'Лекционная');
INSERT INTO AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)        
VALUES ('ЛБ-К', 'Компьютерный класс');
INSERT INTO AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)        
VALUES ('ЛК-К', 'Лекционная с уст. проектором');
INSERT INTO AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)        
VALUES ('ЛБ-X', 'Химическая лаборатория');
INSERT INTO AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)        
VALUES ('ЛБ-СК', 'Спец. компьютерный класс');

CREATE TABLE AUDITORIUM 
( 
AUDITORIUM   varchar(20)   PRIMARY KEY,              
AUDITORIUM_TYPE varchar(10),  FOREIGN KEY(AUDITORIUM_TYPE) REFERENCES AUDITORIUM_TYPE(AUDITORIUM_TYPE), 
AUDITORIUM_CAPACITY int  DEFAULT 1 CHECK(AUDITORIUM_CAPACITY BETWEEN 1 AND 300),
AUDITORIUM_NAME varchar(50)                                     
);


INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('206-1', '206-1','ЛБ-К', 15);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('301-1', '301-1', 'ЛБ-К', 15);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('236-1', '236-1', 'ЛК', 60);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('313-1', '313-1', 'ЛК-К', 60);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('324-1', '324-1', 'ЛК-К', 50);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('413-1', '413-1', 'ЛБ-К', 15);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('423-1', '423-1', 'ЛБ-К', 90);   
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('408-2', '408-2', 'ЛК', 90);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('103-4', '103-4', 'ЛК', 90);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('105-4', '105-4', 'ЛК', 90);   
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('107-4', '107-4', 'ЛК', 90);  
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('110-4', '110-4', 'ЛК', 30);   
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('111-4', '111-4', 'ЛК', 30);
INSERT INTO  AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
VALUES ('114-4', '114-4', 'ЛК-К', 90 );


CREATE TABLE FACULTY
(  
FACULTY varchar(10) PRIMARY KEY,
FACULTY_NAME varchar(50) DEFAULT 'Неизвестно'
);


INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ИДиП', 'Издателькое дело и полиграфия');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ХТиТ', 'Химическая технология и техника');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ЛХФ', 'Лесохозяйственный факультет');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ИЭФ', 'Инженерно-экономический факультет');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ТТЛП', 'Технология и техника лесной промышленности');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ТОВ', 'Технология органических веществ');
INSERT INTO FACULTY(FACULTY, FACULTY_NAME)
VALUES ('ИТ', 'Факультет информационных технологий');


CREATE TABLE PULPIT 
( 
PULPIT varchar(20) PRIMARY KEY,
PULPIT_NAME varchar(100), 
FACULTY varchar(10), FOREIGN KEY(FACULTY) REFERENCES FACULTY(FACULTY) 
);


INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES ('ИСиТ', 'Информационных систем и технологий', 'ИДиП');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ПОиСОИ','Полиграфического оборудования и систем обработки информа-ции ', 'ИДиП');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('БФ', 'Белорусской филологии','ИДиП');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('РИТ', 'Редакционно-издательских тенологий', 'ИДиП')  ;         
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ПП', 'Полиграфических производств', 'ИДиП')    ;                         
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛВ', 'Лесоводства','ЛХФ'); 
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ОВ', 'Охотоведения','ЛХФ')  ;  
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛУ', 'Лесоустройства','ЛХФ')     ;     
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛЗиДВ', 'Лесозащиты и древесиноведения', 'ЛХФ');                
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛКиП', 'Лесных культур и почвоведения', 'ЛХФ') ;
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТиП', 'Туризма и природопользования', 'ЛХФ')        ;      
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛПиСПС', 'Ландшафтного проектирования и садово-паркового строительства', 'ЛХФ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТЛ', 'Транспорта леса', 'ТТЛП');                        
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЛМиЛЗ', 'Лесных машин и технологии лесозаготовок', 'ТТЛП') ;
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТДП', 'Технологий деревообрабатывающих производств', 'ТТЛП') ;  
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТиДИД', 'Технологии и дизайна изделий из древесины', 'ТТЛП')  ;  
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ОХ', 'Органической химии', 'ТОВ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТНХСиППМ', 'Технологии нефтехимического синтеза и переработки поли-мерных материалов', 'ТОВ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ХПД', 'Химической переработки древесины', 'ТОВ') ;          
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ТНВиОХТ', 'Технологии неорганических веществ и общей химической технологии ', 'ХТиТ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ХТЭПиМЭЕ', 'Химии, технологии электрохимических производств и мате-риалов электронной техники', 'ХТиТ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('МиАХиСП', 'Машин и аппаратов химических и силикатных производств', 'ХТиТ');           
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ПиАХП', 'Процессов и аппаратов химических производств', 'ХТиТ') ;                                            
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('ЭТиМ', 'Экономической теории и маркетинга', 'ИЭФ');
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('МиЭП', 'Менеджмента и экономики природопользования', 'ИЭФ')  ;
INSERT INTO PULPIT(PULPIT, PULPIT_NAME, FACULTY)
VALUES('СБУАиА', 'Статистики, бухгалтерского учета, анализа и аудита', 'ИЭФ');


CREATE TABLE TEACHER
(   
TEACHER varchar(10)  PRIMARY KEY,
TEACHER_NAME varchar(100), 
GENDER nchar(1) CHECK (GENDER in ('м', 'ж')),
PULPIT varchar(20) ,FOREIGN KEY(PULPIT) REFERENCES PULPIT(PULPIT) 
);


INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('СМЛВ', 'Смелов Владимир Владиславович', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('АКНВЧ', 'Акунович Станислав Иванович', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('КЛСНВ', 'Колесников Виталий Леонидович', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('БРКВЧ', 'Бракович Андрей Игоревич', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ДТК', 'Дятко Александр Аркадьевич', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('УРБ', 'Урбанович Павел Павлович', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ГРН', 'Гурин Николай Иванович', 'м', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ЖЛК', 'Жиляк Надежда Александровна', 'ж', 'ИСиТ');                  
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('МРЗ', 'Мороз Елена Станиславовна',  'ж', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('БРТШВЧ', 'Барташевич Святослав Александрович', 'м','ПОиСОИ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('АРС', 'Арсентьев Виталий Арсентьевич', 'м', 'ПОиСОИ') ;                    
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('БРНВСК', 'Барановский Станислав Иванович', 'м', 'ЭТиМ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('НВРВ', 'Неверов Александр Васильевич', 'м', 'МиЭП');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('РВКЧ', 'Ровкач Андрей Иванович', 'м', 'ОВ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ДМДК', 'Демидко Марина Николаевна', 'ж', 'ЛПиСПС');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('БРГ', 'Бурганская Татьяна Минаевна', 'ж', 'ЛПиСПС');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('МШКВСК', 'Машковский Владимир Петрович', 'м', 'ЛУ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('АТР', 'Атрощенко Олег Александрович', 'м', 'ЛУ')  ;                   
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('РЖК', 'Рожков Леонид Николаевич ', 'м', 'ЛВ');                    
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ЗВГЦВ', 'Звягинцев Вячеслав Борисович', 'м', 'ЛЗиДВ') ;
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('БЗБРДВ', 'Безбородов Владимир Степанович', 'м', 'ОХ') ;
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('НСКВЦ', 'Насковец Михаил Трофимович', 'м', 'ТЛ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('МХВ', 'Мохов Сергей Петрович', 'м', 'ЛМиЛЗ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('ЕЩНК', 'Ещенко Людмила Семеновна',  'ж', 'ТНВиОХТ');


CREATE TABLE SUBJECT
(     
SUBJECT varchar(10) PRIMARY KEY, 
SUBJECT_NAME varchar(100) unique,
PULPIT varchar(20), FOREIGN KEY(PULPIT) REFERENCES PULPIT(PULPIT)
);


INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('СУБД', 'Системы управления базами данных', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('БД', 'Базы данных', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ИНФ', 'Информационные технологии', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ОАиП', 'Основы алгоритмизации и программирования', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ПЗ', 'Представление знаний в компьютерных системах', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ПСП', 'Программирование сетевых приложений', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('МСОИ', 'Моделирование систем обработки информации', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ПИС', 'Проектирование информационных систем', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('КГ', 'Компьютерная геометрия', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ПМАПЛ', 'Полиграф. машины, автоматы и поточные линии', 'ПОиСОИ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('КМС', 'Компьютерные мультимедийные системы', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ОПП', 'Организация полиграф. производства', 'ПОиСОИ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ДМ', 'Дискретная математика', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('МП', 'Математическое программирование', 'ИСиТ') ;
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ЛЭВМ', 'Логические основы ЭВМ', 'ИСиТ') ;             
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ООП', 'Объектно-ориентированное программирование', 'ИСиТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ЭП', 'Экономика природопользования', 'МиЭП');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ЭТ', 'Экономическая теория', 'ЭТиМ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('БЛЗиПсOO', 'Биология лесных зверей и птиц с осн. охотов.', 'ОВ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ОСПиЛПХ', 'Основы садово-паркового и лесопаркового хозяйства', 'ЛПиСПС');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ИГ', 'Инженерная геодезия ', 'ЛУ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ЛВ', 'Лесоводство', 'ЛЗиДВ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ОХ', 'Органическая химия', 'ОХ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ТРИ', 'Технология резиновых изделий', 'ТНХСиППМ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ВТЛ', 'Водный транспорт леса', 'ТЛ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ТиОЛ', 'Технология и оборудование лесозаготовок', 'ЛМиЛЗ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ТОПИ', 'Технология обогащения полезных ископаемых', 'ТНВиОХТ');
INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
VALUES('ПЭХ',  'Прикладная электрохимия', 'ХТЭПиМЭЕ');


--1--
BEGIN
null;
end;

--2--
BEGIN
DBMS_OUTPUT.PUT_LINE('HELLO WORLD');
END;

--3--
DECLARE 
  x number(3):=3;
  y number(3):=0;
  z number(10,2);
BEGIN
  DBMS_OUTPUT.PUT_LINE('x:= '||x||' , y:=' ||y);
  z:=x/y;
  DBMS_OUTPUT.put_line('z:= '||z);
EXCEPTION
  when others
  then dbms_output.put_line('error= '||sqlerrm||' , code '||sqlcode);
END;

--4--
DECLARE 
  x number(3):=3;
  y number(3):=0;
  z number(10,2);
BEGIN
  DBMS_OUTPUT.PUT_LINE('x:= '||x||' , y:=' ||y);
  begin
    z:=x/y;
  EXCEPTION
    when others
    then dbms_output.put_line('error= '||sqlerrm||' , code '||sqlcode);
  end;
  DBMS_OUTPUT.put_line('z:= '||z);
END;

--5--
show parameter plsql_warnings;

select name,value from v$parameter where name='plsql_warnings';

--6--
SELECT keyword FROM v$reserved_words where length=1 and keyword!='A';

--7--
SELECT keyword FROM v$reserved_words where length>2 and keyword!='A' order by keyword;

--8--
show parameter plsql

--9--

DECLARE
  x number(3):=15;--10--
  y number(3):=6;
  z number(10,2);
  r number(5,2):=123.12;--12--
  u number(5,-2):=123.12; --13--
  i binary_float:=456789.123456782345678;--14--
  ii binary_double:=456789.123456782345678;--15--
  uu number(10,2):=5e3;--16--
  b BOOLEAN :=false; --17-- 
BEGIN 
  z:=x/y;
  DBMS_OUTPUT.put_line('z:= '||z);
  DBMS_OUTPUT.put_line('r:= '||r);
  DBMS_OUTPUT.put_line('u:= '||u);
  DBMS_OUTPUT.put_line('i:= '||i);
  DBMS_OUTPUT.put_line('ii:= '||ii);
  DBMS_OUTPUT.put_line('uu:= '||uu);
  
  if b
  then DBMS_OUTPUT.put_line('b:= true');
  else   DBMS_OUTPUT.put_line('b:= false');
  end if;
END;

--18--
DECLARE
  n1 constant number(5):=5;
  c1 constant char(15):='Hello world';
  v1 constant varchar2(15):='Im the greatest';
BEGIN
  v1:='Hello';
EXCEPTION
  when others
    then DBMS_OUTPUT.put_line('error'||v1);
END;
  
--19,20--
DECLARE
  subject1 subject.subject%type;
  pulpit1 pulpit.pulpit%type;
  faculty_rec faculty%rowtype;
BEGIN
  subject1:='ПИС';
  pulpit1:='ИСиТ';
  faculty_rec.faculty:='ИДиП';
  faculty_rec.faculty_name:='Факультет издательского дела и полиграфии';
  DBMS_OUTPUT.put_line(subject1);
  DBMS_OUTPUT.put_line(pulpit1);
  DBMS_OUTPUT.put_line(rtrim(faculty_rec.faculty)||':'||faculty_rec.faculty_name);
EXCEPTION
  when others
    then DBMS_OUTPUT.put_line('error= ' ||sqlerrm);
END;

--21,22--
DECLARE 
  x int:=17;
BEGIN
  if 8>x
  then DBMS_OUTPUT.put_line('8>'||x);
  elsif 8=x
   then DBMS_OUTPUT.put_line('8='||x);
  elsif 17>x
    then DBMS_OUTPUT.put_line('17>'||x);
  elsif 17=x
    then DBMS_OUTPUT.put_line('17='||x); 
  else
     DBMS_OUTPUT.put_line('17!='||x);
  end if;
END;  

--23--
DECLARE
  x int:=17;
BEGIN
  CASE
  when 12>x 
    then DBMS_OUTPUT.put_line('12>'||x);
  when x between 13 and 20
    then DBMS_OUTPUT.put_line('13=<'||x||'<=20');
  else
    DBMS_OUTPUT.put_line('not of all');
  END CASE;
END; 


--24,25,26--
DECLARE 
  x int:=0;
BEGIN
  --24--
  loop
    x:=x+1;
    DBMS_OUTPUT.put_line(x);
  exit when x>10;
  end loop;
  --25--
  for k in 1..10
  loop
    DBMS_OUTPUT.put_line(k);
  end loop;
  --26--
  while(x>0)
  loop
    x:=x-1;
    DBMS_OUTPUT.put_line(x);
  end loop;
END;

ALTER DATABASE OPEN