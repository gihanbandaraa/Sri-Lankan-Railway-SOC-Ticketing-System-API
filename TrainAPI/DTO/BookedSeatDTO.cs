namespace TrainAPI.DTO
{
    public class BookedSeatDTO
    {
        public List<string> SeatNumbers { get; set; }
        public BookedSeatDTO()
        {
            SeatNumbers = new List<string>();
        }
    }
}
