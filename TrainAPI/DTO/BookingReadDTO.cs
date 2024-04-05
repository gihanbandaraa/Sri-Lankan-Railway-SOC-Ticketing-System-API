
using System.Collections.Generic;
namespace TrainAPI.DTO
{
    public class BookingReadDTO
    {
        public int Id { get; set; }
        public string TrainId { get; set; }
        public string Date { get; set; }
        public List<string> Seats { get; set; }
    }
}
