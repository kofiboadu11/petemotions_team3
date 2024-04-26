using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Models;

namespace PetEmotionsApp.Data
{
    public class PetEmotionsAppContext : DbContext
    {
        public PetEmotionsAppContext (DbContextOptions<PetEmotionsAppContext> options)
            : base(options)
        {
        }

        public DbSet<FileUpload> FileUpload { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<FileUpload>()
                .Property(e => e.emotion)
                .HasConversion(
                    v => v.ToString(),
                    v => (Emotions)Enum.Parse(typeof(Emotions), v));
        }
    }
}
