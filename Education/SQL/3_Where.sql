/****** Script for SelectTopNRows command from SSMS  ******/
SELECT COUNT( DISTINCT [Value] )
  FROM [master].[dbo].[Marks]

  SELECT (  [Value] )
  FROM [master].[dbo].[Marks] where value BETWEEN 3 and 5 

    SELECT (  Name )
  FROM [master].[dbo].[Persons] where Name Like 'nn'