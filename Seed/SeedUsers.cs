using Microsoft.AspNetCore.Identity;

namespace PrintingOrder.Seed
{
    public static class SeedUsers
    {
        public static async Task Initialize(UserManager<IdentityUser> userManager)
        {
            await CreateUser(userManager, "solaima", "Solaima@12345", "ProductionManager");
            await CreateUser(userManager, "rahaf", "Rahaf@12345", "commerical_user");
            await CreateUser(userManager, "ceo", "Ceo@12345", "GeneralManager");
            await CreateUser(userManager, "ola", "O!a@12345", "Administrator");
        }

        private static async Task CreateUser(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new IdentityUser
                {
                    UserName = username,
                    Email = username + "@example.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
