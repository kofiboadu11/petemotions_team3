using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetEmotionsApp.Models;
using PetEmotionsApp.Data;

namespace PetEmotionsApp.Pages
{
    public class FileUploadModel : PageModel
    {
        private readonly PetEmotionsAppContext _context;

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
                    var file = new FileUpload();
                    {
                        FileContent = memoryStream.ToArray();
                    };
                // User = currentUser
                // _context.User.Add(file)
                    _context.Users.Add(file);

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
}
