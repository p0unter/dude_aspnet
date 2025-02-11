using Microsoft.EntityFrameworkCore;
using _7_storepp.Data.Abstract;
using _7_storepp.Data.Concrete;
using _7_storepp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"], b =>b.MigrationsAssembly("_7_storepp.Web"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute("products_in_category", "products/{category?}", new { controller = "Home", action = "Index" });

app.MapControllerRoute("product_details", "{name}", new { controller = "Home", action = "Details" });

app.MapDefaultControllerRoute();

app.Run();
