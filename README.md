# DeadArtistsWASM

**SECTION I. Introduction:**

Welcome to my Code Louisville C# project!
This Blazor WASM website is a barebones demonstration of my proficiency in the C# programming language,
.NET 6.0, Entity Framework, and the repository-based architecture pattern in web development. The back-end
database is configured to use Microsoft SQL Server and the payment processor is configured to utilize
Stripe webhooks.

My website, Dead Artists, is an e-commerce site specializing in the sale of media produced only by artists
(musicians, film-makers, and writers) who are dead.

This ReadMe is broken down into three sections:<br/>
&emsp; I. Introduction (you are **here**) <br/>
&emsp; II. Project Requirements <br/>
&emsp; III. Setup <br/>

The Project Requirements section will guide the user through the logic of Back-end -> Controller -> Front-end and demonstrate how the requirements for the Code Louisville Software Development Course I were met.

The Setup section will go over the following steps:
1. Installing Microsoft SQL Server Express <br/>
2. Installing Microsoft SQL Server Management Studio <br/>
3. Seeding the SQL database <br/>
4. Registering users and adding an administrator <br/>
5. Setting up a Stripe account<br/>
6. Setting up a Stripe CLI <br/>
7. How to navigate/use the site. <br/>

Let us begin!

------------------------------------------------------------------------------------------------------------------

**SECTION II. Project Requirements**

Several Code Louisville Requirements have been satisfied in this project:

1. Create an additional class which inherits one or more properties from its parent <br/>
2. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program. <br/>
3. Read data from an external file, such as text, JSON, CSV, etc and use that data in your application **(SQL Server stores
the data and sends data to the client as JSON)** <br/>
4. Connect to an external/3rd party API and read data into your app. **(To test this functionality, a user will have to create a Stripe account and use their own test API key, as I am not comfortable sharing my Stripe account information.)** <br/>

**This project incorporates many other features such as JSON Web Token Creation and HMAC512 password encryption, but these features will not be discussed in the ReadMe.**

------------------------------------------------------------------------------------------------------------------

***EXAMPLE CODE below shows the pathway through several classes whereby the client "gets" and displays products from the SQL Database:***

------------------------------------------------------------------------------------------------------------------

(1) The class, DataContext, inherits from the EF DbContext class to act as the "data layer" and model builder for
my SQL database. Example incomplete block code snippet found at DeadArtistsWASM\Server\Data\DataContext.cs **(Requirement 1 satisfied)** <br/>

```cs
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
```
        ...


------------------------------------------------------------------------------------------------------------------

(2) For clarity, the Product model code and ServiceResponse value object code are shown below. The ServiceResponse class encapsulate all objects as results that are given to the client. One such encapsulated object the client receives is the object of type Product. <br/>

**ServiceResponse (example code found at DeadArtistsWASM\DeadArtistsWASM\Shared\ServiceResponse.cs):**

```cs
public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
```

**Product (example code found at DeadArtistsWASM\DeadArtistsWASM\Shared\Product.cs):**

```cs
public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
```
------------------------------------------------------------------------------------------------------------------

(3) Using an instantiation of the DataContext object, the ServiceResponse value object, and object models, the back-end/server services generate and return a response of type OBJECT. The example below shows the method whereby the back-end service retrieves products from the SQL database. Moreover, the example shows the first instantiation of a List in a method. Example code found at DeadArtistsWASM\DeadArtistsWASM\Server\Services\ProductService\ProductService.cs **(Requirements 2 and 3 partially satisfied; this data will be used in the client)** <br/>

```cs
public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(p => p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ToListAsync()
        };
        return response;
    }
```

------------------------------------------------------------------------------------------------------------------

(4) The ProductController manages HTTP requests between back and front ends. Example code found at DeadArtistsWASM\DeadArtistsWASM\Server\Controllers\ProductController.cs <br/>

```cs
[HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var result = await _productService.GetProductsAsync();
        return Ok(result);
    }
```

------------------------------------------------------------------------------------------------------------------

(5) The front-end/client ProductService initializes the list of products and gets the data from the controller. Example incomplete block code snippet and GetProducts() method found at DeadArtistsWASM\DeadArtistsWASM\Client\Services\ProductService\ProductService.cs <br/>

```cs
public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<Product> AdminProducts { get; set; }

        public event Action ProductsChanged;

        ...
```

```cs
public  async Task GetProducts(string? categoryUrl = null)
    {
        var result = categoryUrl == null ? 
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
        if (result != null && result.Data != null)
            Products = result.Data;

        CurrentPage = 1;
        PageCount = 0;

        if (Products.Count == 0)
            Message = "No products found...";

        ProductsChanged.Invoke();
    }
```
------------------------------------------------------------------------------------------------------------------

(6) The ProductList razor component then injects the ProductService to organize the product properties in HTML. Example code found in DeadArtistsWASM\DeadArtistsWASM\Client\Shared\ProductList.razor <br>

```cs
@inject IProductService ProductService
@implements IDisposable

@if (ProductService.Products == null || ProductService.Products.Count == 0)
{
    <span>@ProductService.Message</span>
}
else 
{
    <ul class="list-unstyled">
        @foreach (var product in ProductService.Products)
        {
            <li class="media my-3">
                <div class="media-img-wrapper mr-2">
                    <a href="/product/@product.Id">
                        <img class="media-img" src="@product.ImageUrl" alt="@product.Title" />                
                    </a>
                </div>
                <div class="media-body">
                    <a href="/product/@product.Id">
                        <h4 class="mb-8">@product.Title</h4>
                    </a>
                    <p>@product.Description</p>
                    <h5 class="price">
                        @GetPriceText(product)
                    </h5>
                </div>
            </li>
        }
    </ul>
```

------------------------------------------------------------------------------------------------------------------

(7) Finally the ProductService is injected and the ProductList Razor component added to the HTML on the Index page. Code found at DeadArtistsWASM\DeadArtistsWASM\Client\Pages\Index.razor **(Requirements 2 and 3 are now fully satisfied)**. <br/>

```cs
@page "/"
@page "/search/{searchText}/{page:int}"
@page "/{categoryUrl}"
@inject IProductService ProductService

<PageTitle>Dead Artists</PageTitle>

@if(SearchText == null && CategoryUrl == null)
{
    <FeaturedProducts />
}
else
{
    <ProductList />
}

@code {
    [Parameter]
    public string? CategoryUrl { get; set; } = null;

    [Parameter]
    public string? SearchText { get; set; } = null;

    [Parameter]
    public int Page { get; set; } = 1;

    protected override async Task OnParametersSetAsync()
    {
        if(SearchText != null)
        {
            await ProductService.SearchProducts(SearchText, Page);
        }
        else {
            await ProductService.GetProducts(CategoryUrl);
        }
    }
}
```

----------------------------------------------------------------------------------------------------------------------------------------

***Reminder: to test Stripe API functionality, you will have to set up a Stripe account and CLI. This process is covered in the set-up section of this document.*** <br/>

(8) The PaymentService pathway is summarized using the code snippets below. To utilize the Stripe API you will have to replace the "secret" string and test API key with ones keyed to your account.

**BACK-END (example code found at DeadArtistsWASM\DeadArtistsWASM\Server\Services\PaymentService\PaymentService.cs):**

```cs
using Stripe;
using Stripe.Checkout;

namespace DeadArtistsWASM.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "***SECRET OMITTED***";

        public PaymentService(ICartService cartService,
            IAuthService authService,
            IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "***SECRET KEY OMITTED***";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        ...

public async Task<Session> CreatCheckoutSession()
    {
        var products = (await _cartService.GetDbCartProducts()).Data;
        var lineItems = new List<SessionLineItemOptions>();
        products.ForEach(product => lineItems.Add(new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmountDecimal = product.Price * 100,
                Currency = "usd",
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = product.Title,
                    Images = new List<string> { product.ImageUrl }
                }

            },
            Quantity = product.Quantity
        }));

        var options = new SessionCreateOptions
        {
            CustomerEmail = _authService.GetUserEmail(),
            ShippingAddressCollection =
                new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "US" }
                },
            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            LineItems = lineItems,
            Mode = "payment",
            SuccessUrl = "https://localhost:7230/order-success",
            CancelUrl = "https://localhost:7230"
        };

        var service = new SessionService();
        Session session = service.Create(options);
        return session;
    }
```

**CONTROLLER (example code found at DeadArtistsWASM\DeadArtistsWASM\Server\Controllers\PaymentController.cs):**

```cs
[HttpPost("checkout"), Authorize]
    public async Task<ActionResult<string>>CreateCheckoutSession()
    {
        var session = await _paymentService.CreatCheckoutSession();
        return Ok(session.Url);
    }
```

**FRONT-END (example code found at DeadArtistsWASM\DeadArtistsWASM\Client\Services\OrderService\OrderService.cs):** 

```cs
public async Task<string> PlaceOrder()
    {
        if (await IsUserAuthenticated())
        {
            var result = await _http.PostAsync("api/payment/checkout", null);
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }
        else
        {
            return "login";
        }
    }
```

//***HTML implementation ommitted for brevity***//<br/>

----------------------------------------------------------------------------------------------------------------------------------------

**SECTION III. Setup**

If you have already utilized SQL software before and would like to set up the database in your own fashion, feel free to do so.

**(1) Installing Microsoft SQL Server Express**

To install Microsoft SQL Sever Express, navigate to URL: 

https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Install the Express version. Follow recommended instructions. ***IF YOU DO NOT PERFORM A DEFAULT INSTALLATION,
YOU WILL HAVE TO CONFIGURE THE CONNECTION STRINGS YOURSELF***.

***THIS IS AN IMAGE:***

![image](https://user-images.githubusercontent.com/35633314/181590260-068f6ce2-a99f-4fd8-92cc-53a685dc0d58.png)

-------------------------------------------------------------------------------------------------------------

**(2) Installing Microsoft SQL Server Management Studio**

To install Microsoft SQL Server Management Studio, navigate to URL:

https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Install SSMS. It is possible that the version has changed. This is fine.

***THIS IS AN IMAGE:***

![image](https://user-images.githubusercontent.com/35633314/181591051-85d498b0-9d57-4673-ae00-d6338e4df9cc.png)

-------------------------------------------------------------------------------------------------------------

**(3) Seed the database (using Visual Studio)**

Open the DeadArtistsWASM.sln file in Visual Studio. Then, to seed the SQL database, navigate to the Package Manager Console (PMC):

![image](https://user-images.githubusercontent.com/35633314/181593468-0a8767a2-3d64-4072-b7d9-3c566c1265b2.png)

Using the PMC, navigate to the "/DeadArtistsWASM/Server" directory with the command: **cd DeadArtistsWASM/Server**.

![image](https://user-images.githubusercontent.com/35633314/181593980-693e7faf-b7e8-4406-bc4b-51e824b1ec90.png)

The Entity Framework migrations exist within the solution, so you will only need to execute the "Update" command.
In the PMC, please enter the following command: 

    dotnet ef database update

![image](https://user-images.githubusercontent.com/35633314/181594993-c632cbdb-b57d-4e49-9938-d2649dc668ef.png)

With this step complete you should be able to run the application by clicking the "play" button:

![image](https://user-images.githubusercontent.com/35633314/181596901-d10f93fe-d8f0-4436-8ecc-819f3940969d.png)

-------------------------------------------------------------------------------------------------------------

**(4) Registering users and adding an administrator**
    
Now that you've seeded the database, run the solution and try adding a user on the registration page. Feel free to use a dummy email address, like, admin@gmail.com. And make sure to follow passsword requirements when setting up a password.

![image](https://user-images.githubusercontent.com/35633314/181630801-d404fd3d-adc4-40de-97b5-d3b0ab92368c.png)

You should now be able to login using your username and password. By default you have the role of "Customer." If you wish to gain added access to site functions like CRUD operations for all of the different objects the site uses, navigate to the database in SQL Server Management Studio and update the Role of your user to "Admin".

![image](https://user-images.githubusercontent.com/35633314/181631687-8391662c-e74a-4684-82f5-352e254adb35.png)

Now, you should be able to see new buttons on the dropdown user-button. Using these pages you should be able to edit the data for these object types in the database directly.

![image](https://user-images.githubusercontent.com/35633314/181632440-1b4d4373-c03e-4aed-a386-e93a5b1c3e49.png)

-------------------------------------------------------------------------------------------------------------

**(5) Setting up a Stripe account**

Navigate to the following URL: https://dashboard.stripe.com/register and follow the instructions given by the site to make an accounty. **NOTE: You will have to enter bank account information and an affiliated website URL to setup an account.**
    
Once your account has been setup make sure to turn on TEST MODE in the upper right hand corner of the dashboard:

![image](https://user-images.githubusercontent.com/35633314/181625567-73061710-4eb9-44ab-9f85-5698452aaa77.png)

Next, find your TEST API key located on the TEST dashboard page:

![image](https://user-images.githubusercontent.com/35633314/181626045-eb934c79-b0c4-43ff-830e-8dbd7218bc63.png)

Copy/paste this key to the following location in double quotes in the back-end PaymentService at DeadArtistsWASM\DeadArtistsWASM\Server\Services\PaymentService\PaymentService.cs:

![image](https://user-images.githubusercontent.com/35633314/181626420-1b541ffd-b11e-411b-a534-4642176f82aa.png)

-------------------------------------------------------------------------------------------------------------

**(6) Setting up a Stripe CLI**

Navigate to the following URL: https://stripe.com/docs/stripe-cli and follow the instructions for your machine to install the CLI. For example, the windows instructions look like so:

![image](https://user-images.githubusercontent.com/35633314/181626849-ad3ac462-9ea4-44d9-9323-09f0f01888ef.png)

-------------------------------------------------------------------------------------------------------------

Once the CLI is installed, navigate to your console. For this example, I will use the Windows Command Prompt. Navigate to the location where you have extracted and installed the Stripe CLI, like so:

![image](https://user-images.githubusercontent.com/35633314/181627282-8c9d9224-afb5-47c7-b327-fdedc858449c.png)

Then, enter the following command: 

    stripe login

![image](https://user-images.githubusercontent.com/35633314/181628704-b78874ba-34c9-45c5-9740-fe78f26c95ae.png)

Press enter and login to stripe using your account information.

Now, enter the following command:

    stripe listen --forward-to https://localhost:7230/api/payment

![image](https://user-images.githubusercontent.com/35633314/181628349-3f147e97-eb1e-443b-88b0-709404e83c98.png)

Copy the secret provided and paste it into the secret string field within the double quotes at DeadArtistsWASM\DeadArtistsWASM\Server\Services\PaymentService\PaymentService.cs:

![image](https://user-images.githubusercontent.com/35633314/181629219-be2996b8-a562-45b9-be3e-201519b84c97.png)
    
***Remember to save the solution!***

-------------------------------------------------------------------------------------------------------------
    
You should now be able to checkout items from the store. When you are redirected to the Stripe website, feel free to use the following credit card dummy data:

![image](https://user-images.githubusercontent.com/35633314/181629881-d177c3bb-a654-4f27-b04c-2f41fc7787dd.png)

Successful calls to the API will yield HTTP requests that resemble the following:

![image](https://user-images.githubusercontent.com/35633314/181631925-bc2f9bf8-918b-4383-8f19-a8a8e840c93a.png)

-------------------------------------------------------------------------------------------------------------

**(7) Now that you've done all that, feel free to mess around the site at your leisure! Other features to test include the site's search function, pagination, cart functions, and order functions. 










   





