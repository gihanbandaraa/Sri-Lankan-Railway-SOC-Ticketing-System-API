namespace TrainAPI.DTO
{
    public class StationsDTO
    {
        public IEnumerable<string> StartStations { get; set; }
        public IEnumerable<string> DestinationStations { get; set; }
    }
}
