using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TrainAPI.DTO
{
    public class BookingCreateDTO
    {
     
        public string TrainId { get; set; }

        public string Date { get; set; }

        public List<string> Seats { get; set; }
    }
}
