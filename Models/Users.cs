using System.ComponentModel.DataAnnotations;

namespace PetEmotionsApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Current {  get; set; }
        public static List<FileUpload>? Files {get; set;}

        public static void AddFile(FileUpload file) {
            file.Id = Files.Length;
            Files.Add(file);
        }
    }
}
