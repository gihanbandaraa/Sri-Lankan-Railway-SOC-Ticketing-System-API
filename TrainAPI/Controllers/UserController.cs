using Microsoft.AspNetCore.Mvc;
using TrainAPI.Model;
using TrainAPI.Data;
using TrainAPI.DTO;
using AutoMapper;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:Controller
    {
        private readonly IMapper mapper;
        private readonly UserRepository repository;

        public UserController(UserRepository userRepository, IMapper _mapper)
        {
            this.repository = userRepository;
            mapper = _mapper;
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDTO userCreate)
        {
            // Check if the NIC is already registered
            if (repository.IsNICAlreadyRegistered(userCreate.NIC))
            {
                return BadRequest("NIC is already registered.");
            }

            var user = mapper.Map<Users>(userCreate);
            if (repository.CreateUser(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("IsNICRegistered/{nic}")]
        public ActionResult<bool> IsNICRegistered(string nic)
        {
            return Ok(repository.IsNICAlreadyRegistered(nic));
        }

        [HttpGet("{UserID}", Name = "GetByUserID")]

        public ActionResult<UserReadDTO> GetUser(int UserID)
        {
            var user = repository.GetUser(UserID);
            if (user != null)
            {
                return Ok(mapper.Map<UserReadDTO>(user));
            }
            else
                return NotFound();
        }


        [HttpDelete("{UserID}")]
        public ActionResult DeleteUser(int UserID)
        {
            var user = repository.GetUser(UserID);
            if (user != null)
            {
                repository.RemoveUser(user);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{UserID}")]
        public ActionResult UpdateUser(int UserID, UserCreateDTO createDTO)
        {
            var user = mapper.Map<Users>(createDTO);
            user.UserID = UserID;
            if (repository.UpdateUser(user))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrWhiteSpace(loginDTO.Username) || string.IsNullOrWhiteSpace(loginDTO.Password))
            {
                return BadRequest("Username and password are required.");
            }

            bool isValidUser = repository.IsValidUser(loginDTO.Username, loginDTO.Password);

            if (isValidUser)
            {
                return Ok("Login successful.");
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }


    }
}
