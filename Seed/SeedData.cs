using Microsoft.AspNetCore.Identity;

namespace PrintingOrder.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // 1️⃣ تعريف الأدوار
            string[] roles = new[] { "commerical_user", "ProductionManager", "GeneralManager", "Administrator" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2️⃣ تعريف المستخدمين (اسم، كلمة مرور، الدور)
            var users = new List<(string Username, string Password, string Role)>
            {
                ("solaima", "Solaima@12345", "ProductionManager"),
                ("rahaf",   "Rahaf@12345",   "commerical_user"),
                ("ceo",     "Ceo@12345",     "GeneralManager"),
                ("ola",     "Ola@12345",     "Administrator")
            };

            // 3️⃣ إنشاء المستخدمين
            foreach (var (username, password, role) in users)
            {
                var existingUser = await userManager.FindByNameAsync(username);
                if (existingUser == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = username,
                        Email = $"{username}@local", // إيميل افتراضي
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);

                    if (!result.Succeeded)
                    {
                        throw new Exception($"فشل إنشاء المستخدم {username}: " +
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }

                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}