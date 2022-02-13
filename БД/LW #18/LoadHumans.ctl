LOAD DATA
INFILE 'humans.dat'
TRUNCATE
INTO TABLE Humans
FIELDS TERMINATED BY ','
TRAILING NULLCOLS
(
    Id          ,
    Name        TERMINATED BY WHITESPACE "UPPER(:Name)",
    Mark        POSITION(19:27) DECIMAL EXTERNAL "ROUND(:Mark, 2)",
    Birthday    POSITION(33) DATE "dd-mm-yyyy"
)