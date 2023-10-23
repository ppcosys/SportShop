using Microsoft.EntityFrameworkCore;
using Shop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ShopConnection"]);
});

builder.Services.AddScoped<IShopRepository, EFShopRepository>(); //wstrzykiwanie na poziomie pojedynczego ¿¹dania
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var app = builder.Build();


app.UseStaticFiles();

app.UseSession();

app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new { controller = "Home", action = "Index" }
    );

app.MapControllerRoute("category",
    "{category}",
    new { controller = "Home", action = "Index", productPage = 1 }
    );

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new {controller ="Home", action="Index", productPage = 1}
    );

app.MapControllerRoute("all",
    "",
    new { controller = "Home", action = "Index"}
    );


app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
