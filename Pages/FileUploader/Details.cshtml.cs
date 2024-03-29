using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

namespace PetEmotionsApp.Pages_FileUploader
{
    public class DetailsModel : PageModel
    {
        private readonly PetEmotionsApp.Data.PetEmotionsAppContext _context;

        public DetailsModel(PetEmotionsApp.Data.PetEmotionsAppContext context)
        {
            _context = context;
        }

        public FileUpload FileUpload { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileupload = await _context.FileUpload.FirstOrDefaultAsync(m => m.Id == id);
            if (fileupload == null)
            {
                return NotFound();
            }
            else
            {
                FileUpload = fileupload;
            }
            return Page();
        }
    }
}
