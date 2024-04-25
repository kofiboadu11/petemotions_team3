using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetEmotionsApp.Data;

public class LoginModel : PageModel
{
	private readonly PetEmotionsAppContext _context;

	[BindProperty]
		public required string Username { get; set; }

	[BindProperty]
		public required string Password { get; set; }

	public LoginModel(PetEmotionsAppContext context)
	{
		_context = context;
	}

	public IActionResult OnPost()
	{

		if (IsValidUser(Username, Password))
		{

			return RedirectToPage("/History");
		}
		else
		{

			ModelState.AddModelError(string.Empty, "Invalid username or password.");
			return Page();
		}
	}

	private bool IsValidUser(string username, string password)
	{
		return false;
	}
}
