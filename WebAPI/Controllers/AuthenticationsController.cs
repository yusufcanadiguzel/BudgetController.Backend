using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var result = _authenticationService.Login(userForLoginDto);

            if(!result.IsSuccess)
                return BadRequest();

            var tokenResult = _authenticationService.CreateAccessToken(result.Data);

            if (!tokenResult.IsSuccess)
                return BadRequest();

            return Ok(tokenResult.Data);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authenticationService.UserExists(userForRegisterDto.Email);

            if (!userExists.IsSuccess)
                return BadRequest(userExists.Message);

            var registerResult = _authenticationService.Register(userForRegisterDto);

            if(!registerResult.IsSuccess)
                return BadRequest();

            var result = _authenticationService.CreateAccessToken(registerResult.Data);

            if(!result.IsSuccess)
                return BadRequest();

            return Ok(result.Data);
        }
    }
}
