using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Seeds
{
    public class DefaultRole
    {
        public static async Task seedsRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] rolesNames = { "Admin", "Teacher", "Student" };
            foreach (var roleName in rolesNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
