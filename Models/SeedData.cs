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
            if (context == null || context.FileUpload == null)
            {
                throw new ArgumentNullException("Null context");
            }

            // Look for any Users
            if (context.FileUpload.Any())
            {
                return;   // DB has been seeded
            }

            context.SaveChanges();
        }
    }
}