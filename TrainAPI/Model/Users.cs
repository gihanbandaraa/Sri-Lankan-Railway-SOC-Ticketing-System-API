using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Model
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string NIC { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
