using Educa.Domain.Entities;
using Educa.Domain.Statics;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.DbContext
{
    public static class EducaDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "admin", Email = "admin@educa.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "aA@123456");
                await userManager.AddToRoleAsync(defaultUser, RoleNames.Admin);
            }
        }

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (FieldInfo field in typeof(RoleNames).GetFields())
            {
                var role = field.GetValue(null).ToString();
                if (roleManager.Roles.All(r => r.Name != role))
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = role });
                }
            }
        }

    }
}
