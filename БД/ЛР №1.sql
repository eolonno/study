CREATE TABLE ЗАКАЗЫ (
	[Номер заказа] INT IDENTITY(1,1),
	[Наименование товара] NVARCHAR(20) NOT NULL,
	[Цена продажи] REAL NOT NULL,
	[Количество] INT NOT NULL,
	[Дата поставки] DATE NOT NULL,
	[Заказчик] NVARCHAR(20),
	CONSTRAINT GOODS_PRIMARY_KEY PRIMARY KEY CLUSTERED ([Номер заказа])
)
GO

CREATE TABLE ЗАКАЗЧИКИ(
	[Наименование фирмы] NVARCHAR(20) NOT NULL,
	[Адрес] NVARCHAR(50) NOT NULL,
	[Расчетный счет] NVARCHAR(15),
	CONSTRAINT COSTOMERS_PRIMARY_KEY PRIMARY KEY CLUSTERED ([Наименование фирмы])
)
GO


USE [Аникеенко ПРОДАЖИ]
SELECT * FROM [ЗАКАЗЫ] WHERE [Дата поставки] > '20210101'

SELECT * FROM [ЗАКАЗЫ] WHERE [Цена продажи] BETWEEN 1 AND 100

SELECT [Заказчик] FROM [ЗАКАЗЫ] WHERE[Наименование товара] = 'Бумажный стаканчик' 

SELECT * FROM [ЗАКАЗЫ] WHERE [Заказчик] = 'IBA Group' ORDER BY [Дата поставки]
