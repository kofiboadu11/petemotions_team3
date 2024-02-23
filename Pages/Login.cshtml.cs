using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public required string Username { get; set; }

    [BindProperty]
    public required string Password { get; set; }

    public IActionResult OnPost()
    {
       
        if (IsValidUser(Username, Password))
        {
           
            return RedirectToPage("/Dashboard");
        }
        else
        {
            
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }

    private bool IsValidUser(string username, string password)
    {
       
        return username == "admin" && password == "admin123";
    }
}
