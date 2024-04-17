using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging; // Import ILogger
using Microsoft.EntityFrameworkCore;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

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
	}


	public IActionResult OnGet([FromRoute] string param= null)
	{
		if (param == "MyFeed") {
			calendarEvent CalendarEvent = new calendarEvent();
			CalendarEvent.title = "happy";
			CalendarEvent.start = new DateTime(2024,4,11);
			CalendarEvent.end = new DateTime(2024,4,12);
			CalendarEvent.color = "#F78D7D";
			// string json = JsonConvert.SerializeObject(CalendarEvent);

			//return json;

			return new JsonResult(new[] { CalendarEvent });
		}
		else { 
			FileUpload = _context.FileUpload.ToList();
			return Page();
		}
	}
}
