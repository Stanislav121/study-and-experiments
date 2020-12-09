CREATE TABLE Persons
( Id int NOT NULL Primary key,
  Name varchar(20) NOT NULL,
  Ratio decimal(5,2) Default 0,
  Loyalty decimal(5,2),
  Surname varchar(30) Unique);
GO

INSERT INTO Persons (Id, Name, Surname) values 
(0, 'Jhon', 'Abraham'),
(1, 'Anna', 'Tompson');

INSERT INTO Persons (Id, Name, Ratio, Surname) values
(2, 'Bob', 17, 'Armstrong');

INSERT INTO Persons (Id, Name, Loyalty) values
(3, 'Phillip', 4);

INSERT INTO Persons (Id, Name, Surname) values 
(4, 'Jhon', 'Haa');

--INSERT INTO Persons (Id, Name, Loyalty) values
--(5, 'Lissy', 4);


CREATE TABLE Marks
( Id int NOT NULL Primary key IDENTITY(1,1),
 Person_id int NOT NULL,
 Value int CHECK (Value > 0 and Value <=5),
 Date date Default '2020-09-01',
 CONSTRAINT FK_PersonsId FOREIGN KEY (Person_id) REFERENCES Persons (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

INSERT INTO Marks (Person_id, Value, Date) VALUES
(1, 3, '2020-07-01'),
(1, 2, '2020-01-11'),
(1, 2, '2020-05-11'),
(1, 2, '2020-01-11'),
(1, 5, '2020-12-22'),
(2, 3, '2020-04-06'),
(2, 5, '2020-04-05'),
(3, 5, '2020-10-30'),
(3, 5, '2020-04-01'),
(3, 5, '2020-09-23');


SELECT *  FROM [master].[dbo].Marks

UPDATE  [master].[dbo].[Persons]
set Id = 10
where Id = 1

SELECT *  FROM [master].[dbo].Marks

