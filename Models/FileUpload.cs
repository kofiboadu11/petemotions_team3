using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PetEmotionsApp.Models
{
    public class FileUpload {
        
        public int Id {get; set;}

        [Display(Name = "File Contents")]
        public byte[] FileContent {get; set;}
        [Display(Name = "File Date")]
        public DateTime fileDate {get; set;}

        [Display(Name = "Emotions")]
        public Emotions emotion {get; set;}

        [Display(Name = "FileType")]
        public string type {get; set;}

        [Display(Name = "FileName")]
        public string name {get; set;}
    }
    //for whatever reason its overcomplicated to do enums for me
    public enum Emotions
    {
        Happy,
        Sad,
        Angry,
        Other
    }
}