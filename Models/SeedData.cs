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
                throw new ArgumentNullException("Null RazorPagesMovieContext");
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
                   Password = "Admin"
                },

                new Users
                {
                    Username = "Carson",
                    Password = "Admin2"
                },

                new Users
                {
                    Username = "Nabiha",
                    Password = "Admin3"
                },

                new Users
                {
                    Username = "Kofi",
                    Password = "Admin4"
                },

                new Users
                {
                    Username = "Justin",
                    Password = "Admin5"
                },

                new Users
                {
                    Username = "Salem",
                    Password = "Admin6"
                }
            );
            context.SaveChanges();
        }
    }
}