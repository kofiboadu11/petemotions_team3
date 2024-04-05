using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

namespace PetEmotionsApp.Pages_FileUploader
{
    public class EditModel : PageModel
    {
        private readonly PetEmotionsApp.Data.PetEmotionsAppContext _context;

        public EditModel(PetEmotionsApp.Data.PetEmotionsAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileupload =  await _context.FileUpload.FirstOrDefaultAsync(m => m.Id == id);
            if (fileupload == null)
            {
                return NotFound();
            }
            FileUpload = fileupload;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FileUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileUploadExists(FileUpload.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FileUploadExists(int id)
        {
            return _context.FileUpload.Any(e => e.Id == id);
        }
    }
}