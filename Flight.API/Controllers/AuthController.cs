//using Flight.Core.Dtos;
//using Flight.Core.Interfaces;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;

//using System.Threading.Tasks;

//namespace Flight.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;
//        private readonly IConfiguration _configuration;

//        public AuthController(IAuthService authService,IConfiguration configuration)
//        {
//            _authService = authService;
//            _configuration = configuration;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login(CustomerLoginDto customerLoginDto)
//        {

//            var cusotmer = await _authService.Login(customerName: customerLoginDto.Name,
//                                                password: customerLoginDto.Password);

//            if (cusotmer == null)
//                return Unauthorized();
//            _authService.GenerateToken(_configuration, cusotmer);


//            return Ok(new
//            {
//                token = tokenHandler.WriteToken(token),
//                userToReturn
//            });
//        }
//    }
//}
