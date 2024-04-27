# KeyValueApiTest
if you want to use this crud Api for storing and retreiving key value pairs using .net 8, Efcore 8 and MSSQL, Please follow bellow steps :

1- my code consists of two module folder : first is common folder that consist from several classes and configs that may be used in whole of app
second is KeyValueService folder for doing crud operation, so before reading code care abut this

2- you must edit appsetting.json to enter your own databse connection credential for MSSQL in connection string section. note that you must create a databse with you own desired name and use the name in the connecton string.

3- you must call command "update-database" in pacakge manager console to apply migration files to your raw database. by this all entities will be made as tales in your database

4- for running app , you have two choise :

   1- install MSSQL and .Net 8 manually in your windows os then run the app

   or
   
   2- using docker file bellow in your project folder : 


   FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
   
   USER app
   
   WORKDIR /app
   
   EXPOSE 5000
   
   EXPOSE 5001

   
   
   FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
   
   ARG BUILD_CONFIGURATION=Release
   
   WORKDIR /src

   
   COPY ["AzarDataNetTestAPI/AzarDataNetTestAPI.csproj", "AzarDataNetTestAPI/"]
   
   RUN dotnet restore "./AzarDataNetTestAPI/./AzarDataNetTestAPI.csproj"
   
   COPY . .
   
   WORKDIR "/src/AzarDataNetTestAPI"
   
   RUN dotnet build "./AzarDataNetTestAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

   
   FROM build AS publish
   
   ARG BUILD_CONFIGURATION=Release
   
   RUN dotnet publish "./AzarDataNetTestAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
   
   
   FROM base AS final
   
   WORKDIR /app
   
   COPY --from=publish /app/publish .
   
   ENTRYPOINT ["dotnet", "AzarDataNetTestAPI.dll"]

   3- after preparing docker file run bellow command in the order written below:
   
    1-	Docker run with persistant storage : this is used for persistant storage for wwwroot and logs even after container die
    
         docker volume create wwwroot_volume
         
         docker volume create logs_volume

    2-   run the doker file via one of bellow approaches : after creating image via "docker image build ." you must run bellow command

         2.1 : docker run --name AzarDataNetTestAPI -d -p 5000:5000 -p 5001:5001 -v wwwroot_volume:/dotnetdata/wwwroot -v logs_volume:/dotnetdata/Logs  your_image_name

         2.2 : docker service create --name AzarDataNetTestAPI --publish 5000:5000 --publish 5001:5001 --mount type=volume,source=wwwroot_volume,target=/dotnetdata/wwwroot --mount type=volume,source=logs_volume,target=/dotnetdata/Logs your_image_name

now you can open swagger and test the app : [http://localhost:5000/dsdkhkhdihwfi/swagger](http://localhost:5000/dsdkhkhdihwfi/swagger/index.html)

note :my apis are all billingual so you must pass either "fa" or "en-US" as the value of Culture parameter of the apis 


