using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
	[BindProperty]
	public string Username { get; set; }

	[BindProperty]
	public string Password { get; set; }

	public IActionResult OnPost()
	{
		
		if (SaveUser(Username, Password))
		{
			
			return RedirectToPage("/Login");
		}
		else
		{
			
			ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
			return Page();
		}
	}

	private bool SaveUser(string username, string password)
	{
		
		try
		{
			
			return true; 
		}
		catch (Exception ex)
		{
			
			Console.WriteLine(ex.Message);
			return false; // Registration failed
		}
	}
}