using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Model
{
    public class BookedUsers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TrainId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string NIC { get; set; }
        [Required]
        public List<string> Seats { get; set; }
    }
}
