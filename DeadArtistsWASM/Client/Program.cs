global using System.Net.Http.Json;
global using DeadArtistsWASM.Shared;
global using DeadArtistsWASM.Client.Services.ProductService;
global using DeadArtistsWASM.Client.Services.CategoryService;
global using DeadArtistsWASM.Client.Services.AuthService;
global using DeadArtistsWASM.Client.Services.CartService;
global using DeadArtistsWASM.Client.Services.OrderService;
global using DeadArtistsWASM.Client.Services.AddressService;
global using DeadArtistsWASM.Client.Services.ProductTypeService;

global using Microsoft.AspNetCore.Components.Authorization;
using DeadArtistsWASM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
