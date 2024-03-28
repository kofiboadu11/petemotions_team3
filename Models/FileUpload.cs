namespace PetEmotionsApp.Models
{
    public class FileUpload {
        public int Id {get; set;}
        public byte[] FileContent {get; set;}
        public DateTime fileDate {get; set;}
        // TODO: Enum/obj for tagged emotion
    }
}