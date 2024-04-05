using Microsoft.AspNetCore.Mvc;
using TrainAPI.Model;
using TrainAPI.Data;
using TrainAPI.DTO;
using AutoMapper;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : Controller
    {
        private readonly IMapper mapper;
        private readonly TrainRepository repository;

        public TrainController(TrainRepository trainRepository,IMapper _mapper)
        {
            this.repository = trainRepository;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateTrain(TrainCreateDTO trainCreate)
        {
            var train =mapper.Map<Train>(trainCreate);
            if (repository.CreateTrain(train))
                return Ok();
            else
                return BadRequest();

        }


        [HttpGet("{TrainId}",Name ="GetByID")]

        public ActionResult<TrainReadDTO> GetTrain(int TrainId)
        {
            var train = repository.GetTrain(TrainId);
            if (train != null)
            {
                return Ok(mapper.Map<TrainReadDTO>(train));
            }
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainReadDTO>> GetAllTrains()
        {
            var trains = repository.GetAllTrains();
            return Ok(mapper.Map<IEnumerable<TrainReadDTO>>(trains));
        }

        [HttpDelete("{TrainId}")]
        public ActionResult DeleteTrain(int TrainId)
        {
            var train = repository.GetTrain(TrainId);
            if (train != null)
            {
                repository.RemoveTrain(train);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{TrainId}")]
        public ActionResult UpdateTrain(int TrainId, TrainCreateDTO createDTO)
        {
            var train = mapper.Map<Train>(createDTO);
            train.TrainId = TrainId;
            if (repository.UpdateTrain(train))
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("Search")]
        public ActionResult<IEnumerable<TrainReadDTO>> FindTrain([FromQuery] string date, [FromQuery] string startStation, [FromQuery] string destinationStation)
        {
            var train = repository.FindTrain(date, startStation, destinationStation);
            if (train != null)
            {
                return Ok(new List<TrainReadDTO> { mapper.Map<TrainReadDTO>(train) });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Stations")]
        public ActionResult<StationsDTO> GetStations()
        {
            var (startStations, destStations) = repository.GetStations();

            if (startStations != null && destStations != null)
            {
                var stationsDto = new StationsDTO
                {
                    StartStations = startStations,
                    DestinationStations = destStations
                };

                return Ok(stationsDto);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
    