Basic application to import csv into MS SQL database and creating JSON file.

How to open the solution :
-- Please use the IRECKONU.sln file inside IRECKONU folder to open the solution. Build the solution.

How to install database (Code first approach) (MS SQL):

-- Run update-database IRECKONU

-- A table named Articles will be created inside Database IRECKONU. 
Imporvements that can be done - It can be divided into different tables with ColorCodes, ArticleCodes etc.

Make IRECKONU project as startup project and run it. 
There are 2 API end points :-

1. Import -- Upload the csv file and Execute. 
It will insert values in Articles table and also create <filename>.json file inside "jsonfiles" folder inside the same project.

2. Get --  Fetches all values from the Articles table to test whether it is uploaded.

Created DAL and BLL layers folders inside same project ( to save time) but they should be in different projects in real world.
Created UNIT Tests project to showcase DI usage. However I have written only 1 test case as an example due to time constraint.
We can mock the data for services and controllers to make unit tests, different positive and negative scenarios can be covered.
Moreover, we can write performance tests to check big files processing.
More improvements that can be done are proper error handling with codes to api, validations, logging.
Interface FileOperationsService can be divided further into JsonFileOperations and CSVFIleOperations.

I have used CsvHelper to read CSV file and convert to the object.
Also, to save data in database, I previously tried with _dbCOntext.AddRange(articleslist), but then it doesn't take care of the new rows if we add them afterwards.
Then I used the library to do bulkInsert.

Also to make it faster we can add indexes to the table.




