# DeadArtistsWASM

Welcome to my Code Louisville C# project!
This Blazor WASM website is a barebones demonstration of my proficiency in the C# programming language,
.NET 6.0, Entity Framework, and the repository-based architecture pattern in web development. The back-end
database is configured to use Microsoft SQL Server and the payment processor is configured to utilize
Stripe webhooks.

This ReadMe will detail how to set up Microsoft SQL Server Management Studio, how to seed the SQL database,
how to set up a Stripe account & CLI, and how to utilize a Stripe Web API to checkout & create orders.

My website, Dead Artists, is an e-commerce site specializing in the sale of media produced only by artists
(musicians, film-makers, and writers), who are dead.

(1) Installing Microsoft SQL Server Express -->

To install Microsoft SQL Sever Express, navigate to URL: 

https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Install the Express version. Follow recommended instructions. ***IF YOU DO NOT PERFORM A DEFAULT INSTALLATION,
YOU WILL HAVE TO CONFIGURE THE CONNECTION STRINGS YOURSELF***.

![image](https://user-images.githubusercontent.com/35633314/181590260-068f6ce2-a99f-4fd8-92cc-53a685dc0d58.png)

-------------------------------------------------------------------------------------------------------------

(2) Install Microsoft SQL Server Management Studio -->

To install Microsoft SQL Server Management Studio, navigate to URL:

https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Install SSMS. It is possible that the version has changed. This is fine.

![image](https://user-images.githubusercontent.com/35633314/181591051-85d498b0-9d57-4673-ae00-d6338e4df9cc.png)

-------------------------------------------------------------------------------------------------------------

(3) Seed the database (using Visual Studio) -->

To seed the SQL database, navigate to the Package Manager Console (PMC):

![image](https://user-images.githubusercontent.com/35633314/181593468-0a8767a2-3d64-4072-b7d9-3c566c1265b2.png)

-------------------------------------------------------------------------------------------------------------

Using the PMC, navigate to the "/DeadArtistsWASM/Server" directory with the command: **cd DeadArtistsWASM/Server**.

![image](https://user-images.githubusercontent.com/35633314/181593980-693e7faf-b7e8-4406-bc4b-51e824b1ec90.png)

-------------------------------------------------------------------------------------------------------------

The Entity Framework migrations exist within the solution, so you will only need to execute the "Update" command.
In the PMC, please type the command: **dotnet ef database update**.

![image](https://user-images.githubusercontent.com/35633314/181594993-c632cbdb-b57d-4e49-9938-d2649dc668ef.png)

-------------------------------------------------------------------------------------------------------------





