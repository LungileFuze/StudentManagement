using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models.Identity;
using StudentManagement.Repositories.Implementation;
using StudentManagement.Repositories.Interfaces;
using StudentManagement.Seed;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentManagementDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
     options.Password.RequireDigit = true;
     options.Password.RequireUppercase = true;
     options.Password.RequireLowercase = true;
     options.Password.RequireNonAlphanumeric = false;
     options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<StudentManagementDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();

// Configure pipeline
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(name: "default",pattern: "{controller=Student}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await IdentitySeeder.SeedAsync(services);
}

app.Run();