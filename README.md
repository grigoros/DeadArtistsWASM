# DeadArtistsWASM

Introduction:

Welcome to my Code Louisville C# project!
This Blazor WASM website is a barebones demonstration of my proficiency in the C# programming language,
.NET 6.0, Entity Framework, and the repository-based architecture pattern in web development. The back-end
database is configured to use Microsoft SQL Server and the payment processor is configured to utilize
Stripe webhooks.

My website, Dead Artists, is an e-commerce site specializing in the sale of media produced only by artists
(musicians, film-makers, and writers), who are dead.

This ReadMe will discuss: <br/>

(1) The completion of project requirements <br/>
(2) How to set up Microsoft SQL Server Management Studio <br/>
(3) How to seed the SQL database <br/>
(4) How to set up a Stripe account & CLI <br/>
(5) How to utilize a Stripe Web API to checkout & create orders <br/>
(6) How to register site users/administrators <br/>
(7) How to navigate/use the site. <br/>

**(1) Project Requirements**

Several Code Louisville Requirements have been satisfied in this project:

1. Create an additional class which inherits one or more properties from its parent
2. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
3. Read data from an external file, such as text, JSON, CSV, etc and use that data in your application **(SQL Server stores
the data and sends data to the client as JSON)**
4. Connect to an external/3rd party API and read data into your app. ***(To test this functionality user will have to create a Stripe account and use their own test APIs, as I am not comfortable sharing my Stripe/bank account information online.)**

EXAMPLE CODE shows the pathway through several classes whereby the client "gets" products from the SQL Database:

1. My class, DataContext, inherits from the EF DbContext class to act as the "data layer" and model builder for
my SQL database. Example code found in DeadArtistsWASM\Server\Data\DataContext.cs **(Requirement 1 satisfied)**

public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });
            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.ProductTypeId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

        ...

------------------------------------------------------------------------------------------------------------------

2. For clarity, the Product model code and ServiceResponse value object code are shown below. The ServiceResponse class encapsulate all objects as results that are given to the client. One such encapsulated object the client receives is the object of type Product.

**ServiceResponse:**

public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }

**Product:** 

![image](https://user-images.githubusercontent.com/35633314/181606289-18c6af81-485b-4679-926a-84e64abb995e.png)

2. Using an instantiation of the DataContext object, the ServiceResponse value object, and object models, the back-end/server services generate and return a response of type [OBJECT]. The example below shows the method whereby the back-end service retrieves products from the SQL database. Moreover, the example shows the first instantiation of a List. Example code found in DeadArtistsWASM\Server\Services\ProductService\ProductService.cs **(Requirements 2 and 3 partially satisfied; this data will be used  in the client)

![image](https://user-images.githubusercontent.com/35633314/181602363-f814d9e8-6e9a-478c-947f-8853c0823867.png)

3. The ProductController manages HTTP requests between back and front ends. Example code found in DeadArtistsWASM\Server\Controllers\ProductController.cs

![image](https://user-images.githubusercontent.com/35633314/181602009-997128e5-5a6c-4625-952b-71e96447e838.png)

4. The front-end/client ProductService initializes the list of products and gets the data from the controller. Example code found in DeadArtistsWASM\Client\Services\ProductService\ProductService.cs

![image](https://user-images.githubusercontent.com/35633314/181601661-1bea0bb4-cae9-4066-b31e-9473bed2933b.png)

![image](https://user-images.githubusercontent.com/35633314/181601849-80192cff-fedd-4c89-a234-35bd1d396a11.png)

5. The ProductList razor component then injects the ProductService to organize the product properties in HTML. Example code found in DeadArtistsWASM\Client\Shared\ProductList.razor

![image](https://user-images.githubusercontent.com/35633314/181611589-47f5e750-c97b-4f2a-b7c8-f616b4db95b2.png)

6. Finally the ProductService is injected and the ProductList Razor component added to the HTML on the Index page. Example code found in DeadArtistsWASM\Client\Pages\Index.razor **(Requirements 2 and 3 are now fully satisfied)**.

![image](https://user-images.githubusercontent.com/35633314/181613109-77bc3486-8e78-4308-800f-90e302f8e504.png)

----------------------------------------------------------------------------------------------------------------------------------------














**(2) Installing Microsoft SQL Server Express -->**

To install Microsoft SQL Sever Express, navigate to URL: 

https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Install the Express version. Follow recommended instructions. ***IF YOU DO NOT PERFORM A DEFAULT INSTALLATION,
YOU WILL HAVE TO CONFIGURE THE CONNECTION STRINGS YOURSELF***.

***THIS IS AN IMAGE:***

![image](https://user-images.githubusercontent.com/35633314/181590260-068f6ce2-a99f-4fd8-92cc-53a685dc0d58.png)

-------------------------------------------------------------------------------------------------------------

**(2) Install Microsoft SQL Server Management Studio -->**

To install Microsoft SQL Server Management Studio, navigate to URL:

https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Install SSMS. It is possible that the version has changed. This is fine.

***THIS IS AN IMAGE:***

![image](https://user-images.githubusercontent.com/35633314/181591051-85d498b0-9d57-4673-ae00-d6338e4df9cc.png)

-------------------------------------------------------------------------------------------------------------

**(3) Seed the database (using Visual Studio) -->**

Open the DeadArtistsWASM.sln file in Visual Studio. Then, to seed the SQL database, navigate to the Package Manager Console (PMC):

![image](https://user-images.githubusercontent.com/35633314/181593468-0a8767a2-3d64-4072-b7d9-3c566c1265b2.png)

Using the PMC, navigate to the "/DeadArtistsWASM/Server" directory with the command: **cd DeadArtistsWASM/Server**.

![image](https://user-images.githubusercontent.com/35633314/181593980-693e7faf-b7e8-4406-bc4b-51e824b1ec90.png)

The Entity Framework migrations exist within the solution, so you will only need to execute the "Update" command.
In the PMC, please type the command: **dotnet ef database update**.

![image](https://user-images.githubusercontent.com/35633314/181594993-c632cbdb-b57d-4e49-9938-d2649dc668ef.png)

With this step complete you should be able to run the application by clicking the "play" button:

![image](https://user-images.githubusercontent.com/35633314/181596901-d10f93fe-d8f0-4436-8ecc-819f3940969d.png)

-------------------------------------------------------------------------------------------------------------

***If you wish to test the Payment Processor/Order creation functionality.***
**(4)  





