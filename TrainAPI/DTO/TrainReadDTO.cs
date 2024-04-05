namespace TrainAPI.DTO
{
    public class TrainReadDTO
    {
        public int TrainId { get; set; }

  
        public string Name { get; set; } = "";

        public string StartStation { get; set; } = "";

        public string DestinationStation { get; set; } = "";

        public int Capacity { get; set; }

        public string DepartureTime { get; set; } = "";


        public string ArrivalTime { get; set; } = "";

 
        public string Date { get; set; }
    }
}
