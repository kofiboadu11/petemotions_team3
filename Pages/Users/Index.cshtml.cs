using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

namespace PetEmotionsApp.Pages_Users
{
    public class IndexModel : PageModel
    {
        private readonly PetEmotionsApp.Data.PetEmotionsAppContext _context;

        public IndexModel(PetEmotionsApp.Data.PetEmotionsAppContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
