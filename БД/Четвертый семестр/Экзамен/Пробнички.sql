use exam;
--print 'ERROR #' + cast(error_number() as varchar) + ': ' + error_message();
--Изменить таблицу CUSTOMERS, добавив столбец типа XML. Создать процедуру, которая собирает XML-файл из
--всех заказов покупателя N (номер, дата, сумма заказа, сотрудник) и помещает этот XML-файл в созданный столбец. 

alter table CUSTOMERS add ORDERS_INFO XML null;

create procedure OrdersToXML @CUST_ID int
as begin
	begin try
	update CUSTOMERS set ORDERS_INFO = (select * from ORDERS where CUST = @CUST_ID for xml path('ORDER'), ROOT('ORDERS')) where CUST_NUM = @CUST_ID;
	end try
	begin catch
	print 'ERROR #' + cast(error_number() as varchar) + ': ' + error_message();
	end catch;
end;

drop procedure OrdersToXML;

exec OrdersToXML 2103;
select * from CUSTOMERS;


--Создать процедуру, которая выводит по алфавиту имена сотрудников, у которых есть заказ стоимостью выше N. N – параметр. Предусмотреть выдачу сообщений при ошибках.

create procedure NamesUnderN @N int 
as begin
	begin try
		declare @name varchar(20);
		declare cur cursor for select distinct NAME from SALESREPS inner join ORDERS on EMPL_NUM = REP
														  inner join PRODUCTS on PRODUCT_ID = PRODUCT
														  where PRICE > @N
														  order by name;
		open cur;
		fetch cur into @name;
		while @@FETCH_STATUS = 0
		begin
			print rtrim(@name);
			fetch cur into @name;
		end
	end try
	begin catch
		print 'ERROR #' + cast(error_number() as varchar) + ': ' + error_message();
	end catch;
end;

drop procedure NamesUnderN;

exec NamesUnderN 2000;

--Создать процедуру, которая выводит названия офисов, в которых не было заказов в период с D1 по D2. D1, D2– параметры. Предусмотреть выдачу сообщений при ошибках.

create procedure OfficesWithoutOrdersInDate @date1 date, @date2 date
as begin
	begin try
		select REP_OFFICE, COUNT(REP_OFFICE)[COUNT] from SALESREPS join ORDERS on EMPL_NUM = REP
										 where ORDER_DATE between @date1 and @date2
										 group by REP_OFFICE;

	end try
	begin catch
		print 'ERROR #' + cast(error_number() as varchar) + ': ' + error_message();
	end catch;
end;

exec OfficesWithoutOrdersInDate '2007-12-01', '2008-01-01';

--Создать процедуру, которая выводит названия N покупателей с кредитным лимитом больше P, которые приобрели меньше всех товаров. N, P – параметры.
--Предусмотреть выдачу сообщений при ошибках.

create procedure PR @N int, @P decimal(9,2)
as begin
	begin try
		select top (@N) COMPANY, COUNT(ORDER_NUM)[COUNT] from CUSTOMERS join ORDERS on CUST = CUST_NUM
								where CREDIT_LIMIT > @P
								group by COMPANY
								order by [COUNT] desc;								
	end try
	begin catch
		print 'ERROR #' + cast(error_number() as varchar) + ': ' + error_message();
	end catch;
end;

exec PR 8, 55000;

--Создать триггер, который позволяет убрать ошибки при переназначении менеджера сотруднику.
--Если сотрудник 103 подчиняется сотруднику 104, а операция обновления хочет назначить начальником сотруднику 104 сотрудника 103,
--то заодно поменять начальника сотруднику 103, чтобы не было зацикливания.
--???
create trigger TR on SALESREPS instead of UPDATE
as begin
	if (select MANAGER from inserted) != (select MANAGER from deleted)
	begin
		update SALESREPS set MANAGER = (select EMPL_NUM from inserted) where EMPL_NUM = (select EMPL_NUM from deleted);
		update SALESREPS set EMPL_NUM = (select MANAGER from inserted) where EMPL_NUM = (select MANAGER from deleted);
	end
	else 
		
end;

--Создать XML, который содержит данные о количестве сотрудников в офисах, внешний узел имеет атрибуты название,
--расположение, количество сотрудников, вложенный узел имеет атрибуты имя сотрудника, должность.

select 
	REP_OFFICE as [@REP_OFFICE],
	CITY as [@CITY],
	REGION as [@REGION],
	COUNT(EMPL_NUM) as [@COUNT],
	(select NAME as [@NAME],
			TITLE as [@TITLE]
			from SALESREPS where REP_OFFICE = SR.REP_OFFICE for xml PATH('SALESREP'), TYPE)
	from SALESREPS SR
	join OFFICES on REP_OFFICE = OFFICE
	group by REP_OFFICE, CITY, REGION
	for xml PATH('OFFICE'), TYPE;


--Создать процедуру, которая обновляет данные о товаре по коду товара и коду производителя, если такой товар существует,
--и добавляет такой товар, если такой товар не существует.

create procedure PR1 @MFR_ID char(3), @PRODUCT_ID char(5), @DESCRIPTION varchar(20), @PRICE money, @QTY_ON_HAND int
as begin
	if (select COUNT(*) from PRODUCTS where MFR_ID = @MFR_ID and PRODUCT_ID = @PRODUCT_ID) = 1
		update PRODUCTS set PRODUCT_ID = @PRODUCT_ID, DESCRIPTION = @DESCRIPTION, PRICE = @PRICE, QTY_ON_HAND = @QTY_ON_HAND
			where MFR_ID = @MFR_ID and PRODUCT_ID = @PRODUCT_ID;
	else if (select COUNT(*) from PRODUCTS where MFR_ID = @MFR_ID and PRODUCT_ID = @PRODUCT_ID) = 0
		insert into PRODUCTS values(@MFR_ID, @PRODUCT_ID, @DESCRIPTION, @PRICE, @QTY_ON_HAND);
	else
		print 'ERROR';
end;

--Создать функцию, которая возвращает среднюю цену заказа по наименованию покупателя. Если такого покупателя нет, возвращается -1.

create function func (@COMPANY varchar(20)) returns int
as begin
	declare @r int;
	if (select COUNT(*) from CUSTOMERS join ORDERS on CUST_NUM = CUST where COMPANY = @COMPANY) = 1
		set @r = (select AVG(PRICE * AMOUNT) from CUSTOMERS join ORDERS on CUST_NUM = CUST
										   join PRODUCTS on PRODUCT = PRODUCT_ID
										   where COMPANY = @COMPANY)
	else set @r = -1;
	return @r;
end;

print dbo.func('Jones Mfg.');

--ИНДЕКСЫ--

exec sp_helpindex 'OFFICES'

select * from OFFICES where TARGET > 700000;

create index IND on OFFICES(OFFICE, TARGET) where TARGET > 700000;

drop index IND on OFFICES;
