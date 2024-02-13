using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var services = builder.Services;
services.AddDbContext<HotelProjectDbContext>();
services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelProjectDbContext>();
services.AddControllersWithViews().AddRazorRuntimeCompilation();
services.AddHttpClient();
services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//Route ayarinda areanin ?area=Admin olarak gidilmesinden kaynaklanan hata; area controllerinin one alýnmasýyla cozulur.
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Staff}/{action=Index}/{id?}"
        );

    endpoints.MapAreaControllerRoute(
        name: "areas",
    areaName: "User",
    pattern: "User/{controller=Profile}/{action=Index}/{id?}"
        );


    endpoints.MapControllerRoute(
       name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
