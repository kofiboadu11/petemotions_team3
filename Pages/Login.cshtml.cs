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
		//grab data
		//var users = from u in _context.Users select u;

		//foreach(var u in users)
		//{
		//    u.Current = false;
		//    _context.SaveChanges();
		//}

		////Check Username
		//if (!string.IsNullOrWhiteSpace(username))
		//    users = users.Where(u => u.Username.ToLower().Contains(username.ToLower()));
		////If Username found then check password
		//if (!string.IsNullOrWhiteSpace(password) && users.Any())
		//    users = users.Where(u => u.Password.ToLower().Contains(password.ToLower()));
		////return true if user found
		//if (users.Any())
		//{
		//    users.First().Current = true;
		//    _context.SaveChanges();
		//    return true;
		//}
		//else return false;
		return false;
	}
}
