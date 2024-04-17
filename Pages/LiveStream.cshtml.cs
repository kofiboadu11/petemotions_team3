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


namespace PetEmotionsApp.Pages;
public class LiveSteamModel : PageModel
{
	private readonly PetEmotionsAppContext _context;

	public LiveSteamModel(PetEmotionsAppContext context)
	{
		_context = context;
	}
}
