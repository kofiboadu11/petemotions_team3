using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging; // Import ILogger

namespace PetEmotionsApp.Pages;

public class HistoryModel : PageModel
{
  //  private readonly ILogger<HistoryModel> _logger;

  private readonly ILogger<HistoryModel> _logger; // Declare ILogger<T> field

        public HistoryModel(ILogger<HistoryModel> logger) // Inject ILogger<T> via constructor injection
        {
            _logger = logger;
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
        _logger.LogDebug("OnGetMyFeed method called.");
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
	return Page();
	}
    }
}
