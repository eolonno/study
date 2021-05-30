if NOT EXISTS(SELECT * FROM sys.databases WHERE [name] = N'University')
--if db_id('[University]') is null

Begin
	create database University;
End

	use University;

	create table Student(
		ID int primary key identity(100,1),
		NAME nvarchar(100) not null,
		SPECIALITY nvarchar(200) not null,
		AGE int check(AGE between 17 and 40) not null,
		BIRTHDAY date not null,
		COURSE int check (COURSE between 1 and 5) not null,
		SEX nchar(1) check(SEX in ('ì', 'æ')) not null,
		AVGSCORE float check(AVGSCORE between 4 and 10) not null,
		FOTO varbinary(max) default null
	)

	create table [Address](
		ID int primary key identity(1,1),
		StudentID int foreign key references [Student](ID),
		Town nvarchar(20) not null,
		[Index] int check ([Index] between 100000 and 999999) not null,
		Street nvarchar(30) not null,
		House int check(House between 1 and 1000) not null,
		Flat int check(Flat between 1 and 2000) null
	)


--drop table Student
--drop table [Address]