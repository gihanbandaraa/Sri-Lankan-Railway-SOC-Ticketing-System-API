using System.ComponentModel.DataAnnotations;

namespace TrainAPI.DTO
{
    public class BookedUserCreateDTO
    {

        public string TrainId { get; set; }
        public string Date { get; set; }
        public string NIC { get; set; }
        public List<string> Seats { get; set; }
    }
}
