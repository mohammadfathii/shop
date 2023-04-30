using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ( Dependecny Injection Container )
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebMarket_DB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// there is 3 ways to register Services In DI Container :
// Make only 1 instance of service with all requests and use it
//      builder.Services.AddSingleton<ICategoryRepository,CategoryRepository>();
// make instance in any request ( so dangerous for application )
//      builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();

// the best way to register Service
//      builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
// builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CoverTypeService>();

/*builder.Services.AddDbContext<WebMarket_DB>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
