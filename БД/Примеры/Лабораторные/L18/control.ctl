LOAD DATA
INFILE 'C:\Users\admid\data.txt'
DISCARDFILE 'C:\Users\admid\data.dis'
INTO TABLE lab18 
FIELDS TERMINATED BY ","
(
integervalue "round(:integervalue, 2)",
charvalue "upper(:charvalue)",
datevalue date "YYYY-MM-DD"
)

