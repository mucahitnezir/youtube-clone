using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoApp.Business.Abstract;
using VideoApp.Entities.DTOs;

namespace VideoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var userExistResult = _authService.UserExists(userForRegisterDto.Email);
            if (userExistResult.Success)
            {
                return BadRequest(userExistResult);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult);
            }

            var tokenResult = _authService.CreateAccessToken(registerResult.Data);
            return Ok(tokenResult.Data);
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

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.FindFirst(ClaimTypes.Email)?.Value;
            var user = _userService.GetByEmail(email);

            var userDto = _mapper.Map<CurrentUserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("change-password")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var currentUser = HttpContext.User;
            var userId = new Guid(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);

            var result = _userService.ChangePassword(userId, changePasswordDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
