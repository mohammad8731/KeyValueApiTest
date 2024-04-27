# KeyValueApiTest
if you want to use this crud Api for storing and retreiving key value pairs using .net 8, Efcore 8 and MSSQL, Please follow bellow steps :

1- my code consists of two module folder : first is common folder that consist from several classes and configs that may be used in whole of app
second is KeyValueService folder for doing crud operation, so before reading code care abut this

2- you must edit appsetting.json to enter your own databse connection credential for MSSQL in connection string section. note that you must create a databse with you own desired name and use the name in the connecton string.

3- you must call command "update-database" in pacakge manager console to apply migration files to your raw database. by this all entities will be made as tales in your database

4- for running app , you have two choise :

   1- install MSSQL and .Net 8 manually in your windows os then run the app
   
   2- using docker 
