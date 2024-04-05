using Microsoft.AspNetCore.Mvc;
using TrainAPI.Data;
using TrainAPI.Model;
using AutoMapper;
using TrainAPI.DTO;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedUserController : ControllerBase
    {
        private readonly BookedUserRepository _repository;
        private readonly IMapper _mapper;

        public BookedUserController(BookedUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("CheckIfExists")]
        public IActionResult CheckIfExists(string trainId, string date, string nic)
        {
            if (string.IsNullOrEmpty(trainId) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(nic))
            {
                return BadRequest("Train ID, date, and NIC are required parameters.");
            }

         
            bool userExists = _repository.CheckIfExists(trainId, date, nic);

            if (userExists)
            {
                return Ok(true); 
            }
            else
            {
                return Ok(false); 
            }
        }


        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] BookedUserCreateDTO bookedUserDto)
        {
            if (bookedUserDto == null)
            {
                return BadRequest();
            }
            var bookedUser = _mapper.Map<BookedUsers>(bookedUserDto);
           
            if (_repository.CreateBookedUser(bookedUser))
            {
                return CreatedAtAction(nameof(AddBooking), bookedUserDto);
            }
            else
            {
                return StatusCode(500, "Failed to create booked user.");
            }
        }
    }
}
