using TrainAPI.Model;
namespace TrainAPI.Data
{
    public class TrainRepository
    {
        private AppDBContext _dbContext;

        public TrainRepository(AppDBContext context) 
        {
          _dbContext = context;
        }

        public bool CreateTrain(Train train)
        {
            if (train != null) 
            {
                _dbContext.trains.Add(train);
                return Save();
            }
            else
                return false;
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0) 
            { 
            return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTrain(Train train)
        {
            _dbContext.trains.Update(train);
            return Save();
        }

        public bool RemoveTrain(Train train) 
        { 
            _dbContext.trains.Remove(train);
            return Save();
        }

        public Train GetTrain(int id)
        {
            return _dbContext.trains.FirstOrDefault(train => train.TrainId == id);
        }

        public Train FindTrain(string date, string startStation, string destinationStation)
        {
            return _dbContext.trains.FirstOrDefault(train =>
                train.Date == date &&
                train.StartStation.ToLower() == startStation.ToLower() &&
                train.DestinationStation.ToLower() == destinationStation.ToLower()
            );
        }

        public (IEnumerable<string> startStations, IEnumerable<string> destStations) GetStations()
        {
            var startStations = _dbContext.trains.Select(train => train.StartStation).Distinct().OrderBy(station => station);
            var destStations = _dbContext.trains.Select(train => train.DestinationStation).Distinct().OrderBy(station => station);

            return (startStations, destStations);
        }


        public IEnumerable<Train> GetAllTrains()
        {
            return _dbContext.trains.ToList();  
        }
    }
}
