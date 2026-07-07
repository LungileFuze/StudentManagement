using Microsoft.AspNetCore.Identity;
using StudentManagement.Helpers;
using StudentManagement.Models.Identity;
using System.Security.Claims;

namespace StudentManagement.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles =
            {
                Roles.Admin,
                Roles.Lecturer
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = await userManager.FindByEmailAsync(DefaultUsers.AdminEmail);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    FirstName = DefaultUsers.AdminFirstName,
                    LastName = DefaultUsers.AdminLastName,
                    UserName = DefaultUsers.AdminUserName,
                    Email = DefaultUsers.AdminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, DefaultUsers.AdminPassword);


                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin);
                }

            }

            var lecturer = await userManager.FindByEmailAsync(DefaultUsers.LecturerEmail);

            if (lecturer == null)
            {
                lecturer = new ApplicationUser
                {
                    FirstName = DefaultUsers.LecturerFirstName,
                    LastName = DefaultUsers.LecturerLastName,
                    UserName = DefaultUsers.LecturerUserName,
                    Email = DefaultUsers.LecturerEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(lecturer, DefaultUsers.LecturerPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(lecturer, Roles.Lecturer);
                }
            }
        }
    }
}