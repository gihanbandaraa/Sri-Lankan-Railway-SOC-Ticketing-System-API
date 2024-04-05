using System.ComponentModel.DataAnnotations;

namespace TrainAPI.DTO
{
    public class BookedUserReadDTO
    {
        public int Id { get; set; }
        public string TrainId { get; set; }
        public string Date { get; set; }
        public string NIC { get; set; }
        public List<string> Seats { get; set; }
    }
}
