using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetEmotionsApp.Models;
using PetEmotionsApp.Data;
using System.Globalization;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace PetEmotionsApp.Pages
{
    public class FileUploadModel : PageModel
    {
        private readonly PetEmotionsAppContext _context;

        
        [BindProperty]
        public SingleFileUploadDb FileUpload { get; set; }

        public FileUploadModel(PetEmotionsAppContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var file = new FileUpload
                    {
                        FileContent = memoryStream.ToArray(),
                        fileDate = DateTime.UtcNow,
                    };
                // User = currentUser
                // _context.User.Add(file)
                    _context.Users.AddFile(file);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

        return Page();
        }
    }
    public class SingleFileUploadDb
    {
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }
    }
}
