using Microsoft.AspNetCore.Mvc;
using VideoApp.Business.Abstract;
using VideoApp.Entities.DTOs;

namespace VideoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExists(userForRegisterDto.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var result = _authService.Register(userForRegisterDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var userToLoginResult = _authService.Login(userForLoginDto);
            if (!userToLoginResult.Success)
            {
                return BadRequest(userToLoginResult.Message);
            }

            var tokenResult = _authService.CreateAccessToken(userToLoginResult.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult.Message);
            }

            return Ok(tokenResult.Data);
        }
    }
}