using Microsoft.AspNetCore.Mvc;
using TrainAPI.Model;
using TrainAPI.Data;
using TrainAPI.DTO;
using AutoMapper;

namespace TrainAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly AdminRepository _adminRepository;

        public AdminController(AdminRepository adminRepository, IMapper _mapper)
        {
            this._adminRepository = adminRepository;
            mapper = _mapper;
        }

        [HttpPost]
        public ActionResult CreateAdmin(AdminCreateDTO adminCreate)
        {
            var admin = mapper.Map<Admin>(adminCreate);
            if (_adminRepository.CreateAdmin(admin))
                return Ok();
            else
                return BadRequest();
        }

     


        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrWhiteSpace(loginDTO.Username) || string.IsNullOrWhiteSpace(loginDTO.Password))
            {
                return BadRequest("Username and password are required.");
            }

            bool isValidUser = _adminRepository.IsValidUser(loginDTO.Username, loginDTO.Password);

            if (isValidUser)
            {
                return Ok("Login successful.");
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }

        [HttpPut("{UserID}")]
        public ActionResult UpdateUser(int UserID, AdminCreateDTO createDTO)
        {
            var user = mapper.Map<Admin>(createDTO);
            user.UserID = UserID;
            if (_adminRepository.UpdateUser(user))
                return Ok();
            else
                return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookingReadDTO>> GetAllAdmins()
        {
            var admin = _adminRepository.GetAllAdmins();
            return Ok(mapper.Map<IEnumerable<AdminReadDTO>>(admin));
        }

        [HttpDelete("{ID}")]
        public ActionResult DeleteBook(int ID)
        {
            var admin = _adminRepository.GetAdmin(ID);
            if (admin != null)
            {
                _adminRepository.RemoveBooking(admin);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
