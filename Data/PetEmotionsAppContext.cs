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

        public DbSet<Users> Users { get; set; }
    }
}
