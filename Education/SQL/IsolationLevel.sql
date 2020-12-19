Declare @T table (Options varchar(100),Value varchar(100))Insert Into @T Exec('DBCC USEROPTIONS')
Select *  From @T  Where Options ='isolation level'



