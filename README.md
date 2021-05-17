# PlanningPocker_Api
This is an example of RESTful API with .Net Core 3.1 and PostgreSQL

Hello

These are the endpoints that can be used to test the api:

/swagger

/swagger/v1/swagger.json

/api/users

/api/votes

/api/letters

/api/userhistory

/allvoteshub

To run the project, execute the command: dotnet run 

and access the path: http://localhost:5000/api/users

To change the database configuration it must be done from:

DefaultConnection of the appsettings.json file

To create the database you must use the commands:

dotnet tool install --global dotnet-ef --version 3.1.4

dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.4

dotnet ef migrations add InitialCreate

dotnet ef database update

thanks :)
