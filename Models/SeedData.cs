using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;

namespace PetEmotionsApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PetEmotionsAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PetEmotionsAppContext>>()))
        {
            if (context == null || context.Users == null)
            {
                throw new ArgumentNullException("Null context");
            }

            // Look for any Users
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.AddRange(
                new Users
                {
                   Username = "Jarrod",
                   Password = "Admin",
                   Current = false
                },

                new Users
                {
                    Username = "Carson",
                    Password = "Admin2",
                    Current = false
                },

                new Users
                {
                    Username = "Nabiha",
                    Password = "Admin3",
                    Current = false
                },

                new Users
                {
                    Username = "Kofi",
                    Password = "Admin4",
                    Current = false
                },

                new Users
                {
                    Username = "Justin",
                    Password = "Admin5",
                    Current = false
                },

                new Users
                {
                    Username = "Salem",
                    Password = "Admin6",
                    Current = false
                }
            );
            context.SaveChanges();
        }
    }
}