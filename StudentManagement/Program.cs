using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentManagementDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();