using Microsoft.AspNetCore.Identity;
using ETicaretWebApp.Models;

namespace ETicaretWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category()
                    {
                        Name = "Mobile Phones",
                        Description = "Category Description"
                    });
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Product 1",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 1",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         },
                        new Product()
                        {
                            Name = "Product 2",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 2",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         },
                        new Product()
                        {
                            Name = "Product 3",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 3",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         },
                        new Product()
                        {
                            Name = "Product 4",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 4",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         },
                        new Product()
                        {
                            Name = "Product 5",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 5",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         },
                        new Product()
                        {
                            Name = "Product 6",
                            Image = "https://productimages.hepsiburada.net/s/49/550/10995125452850.jpg",
                            Description = "This is the description of Product 6",
                            CategoryId = 1,
                            Price = 10,
                            UnitsInStock = 100,
                            UnitsOnOrder = 0,
                            Discontinued = false
                         }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("SysAdmin"))
                    await roleManager.CreateAsync(new IdentityRole("SysAdmin"));
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("Customer"))
                    await roleManager.CreateAsync(new IdentityRole("Customer"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string adminUserEmail = "sysadmin@mail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new IdentityUser()
                    {
                        UserName = "sysadmin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, "SysAdmin");
                }
            }
        }
    }
}