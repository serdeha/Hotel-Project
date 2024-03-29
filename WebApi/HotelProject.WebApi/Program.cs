using HotelProject.Business.Abstract;
using HotelProject.Business.Concrete;
using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Data.Concrete.EntityFramework.Repositories;
using HotelProject.Data.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddDbContext<HotelProjectDbContext>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IStaffRepository, EfStaffRepository>();
services.AddScoped<IStaffService, StaffManager>();
services.AddScoped<IRoomRepository, EfRoomRepository>();
services.AddScoped<IRoomService, RoomManager>();
services.AddScoped<IServiceRepository, EfServiceRepository>();
services.AddScoped<IServiceService, ServiceManager>();
services.AddScoped<ISubscribeRepository, EfSubscribeRepository>();
services.AddScoped<ISubscribeService, SubscribeManager>();
services.AddScoped<ITestimonialRepository, EfTestimonialRepository>();
services.AddScoped<ITestimonialService, TestimonialManager>();
services.AddScoped<IAboutRepository, EfAboutRepository>();
services.AddScoped<IAboutService, AboutManager>();
services.AddScoped<IVideoRepository, EfVideoRepository>();
services.AddScoped<IVideoService, VideoManager>();

services.AddAutoMapper(Assembly.GetExecutingAssembly());

services.AddCors(options =>
{
    options.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("OtelApiCors");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
