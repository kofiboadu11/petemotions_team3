using System.ComponentModel.DataAnnotations;

namespace PetEmotionsApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool Current {  get; set; }
    }
}
