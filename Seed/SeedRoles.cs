using Microsoft.AspNetCore.Identity;

namespace PrintingOrder.Seed
{
    public static class SeedRoles
    {
        public static async Task Initialize(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "ProductionManager", "commerical_user", "GeneralManager", "Administrator" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
