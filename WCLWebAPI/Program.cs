using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WCLWebAPI.AutoMapper;
using WCLWebAPI.EF;
using WCLWebAPI.Interfaces;
using WCLWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Open connect to SqlServer
builder.Services.AddDbContext<WCLManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDepartment, DepartmentRepository>();
builder.Services.AddTransient<IEmployee, EmployeeRepository>();
builder.Services.AddTransient<ITimeSheet, TimeSheetRepository>();


//Setup automapper
var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
