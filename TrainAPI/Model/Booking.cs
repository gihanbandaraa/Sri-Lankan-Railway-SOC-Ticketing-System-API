using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TrainId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public List<string> Seats { get; set; }
    }

    public class BookingResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
      
    }
}
