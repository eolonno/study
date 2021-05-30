--производительность, расшир.возм-сти программир.
--(м.вызвать в люб.момент-> модульность и повт.исп-ние кода)
--поддерживают ф-ции без-сти д-х
CREATE PROCEDURE [dbo].[sp_InsertStudent]
	@NAME nvarchar(100),
	@SPECIALITY nvarchar(200),
	@AGE int,
	@BIRTHDAY date,
	@COURSE int,
	@SEX nchar(1),
	@AVGSCORE float
AS
insert 
into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE) 
VALUES (@NAME, @SPECIALITY, @AGE, @BIRTHDAY, @COURSE, @SEX, @AVGSCORE)
SELECT SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[sp_InsertAddress]
	@StudentID int,
	@Town nvarchar(20),
	@Index int,
	@Street nvarchar(30),
	@House int,
	@Flat int
AS
insert 
into Address(StudentID, Town, [Index], Street, House, Flat)  
VALUES (@StudentID, @Town, @Index, @Street, @House,	@Flat)
SELECT SCOPE_IDENTITY()
GO


--drop procedure sp_InsertStudent
--drop procedure sp_InsertAddress