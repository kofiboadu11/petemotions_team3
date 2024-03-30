using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

namespace PetEmotionsApp.Pages_FileUploader
{
    public class CreateModel : PageModel
    {
        private readonly PetEmotionsApp.Data.PetEmotionsAppContext _context;

        public CreateModel(PetEmotionsApp.Data.PetEmotionsAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FileUpload.Add(FileUpload);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
