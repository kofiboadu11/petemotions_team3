using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging; // Import ILogger
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;
using System.Globalization;

namespace PetEmotionsApp.Pages;

public class HistoryModel : PageModel
{
	//  private readonly ILogger<HistoryModel> _logger;

	private readonly PetEmotionsApp.Data.PetEmotionsAppContext _context;
	public IList<FileUpload> FileUpload { get;set; } = default!;

	public HistoryModel(PetEmotionsApp.Data.PetEmotionsAppContext context)
	{
		_context = context;
	}


	public class calendarEvent {
		public string title {get; set;}
		public DateTime start {get; set;}
		public DateTime end {get; set;}
		public string color {get; set;}
		public string imageUrl {get; set;}
	}


	public IActionResult OnGet([FromRoute] string param= null)
	{
		if(param=="MyFeed")
		{
			FileUpload=_context.FileUpload.ToList();
			var calendarEvents=FileUpload.Select(fu=>new calendarEvent
			{
				title=fu.name,
				start=fu.fileDate,
				imageUrl=Convert.ToBase64String(fu.FileContent) ,
				color=fu.emotion switch
				{
					 	Emotions.Happy => "#F78D7D",
                        Emotions.Sad => "#9BB9C3",
                        Emotions.Angry => "#CB9897",
                        Emotions.Other => "#FFCCBB",
                        _ => "#FFFFFF"
				}
			}).ToList();

			return new JsonResult(calendarEvents);
		}
		else { 
			FileUpload = _context.FileUpload.ToList();
			return Page();
		}
		
	}
	
}

