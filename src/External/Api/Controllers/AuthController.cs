using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (IAuthServices auth): ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async  Task<IActionResult> Login(LoginDto usr)
        {
            var data =await auth.Login(usr);
            return Ok(data);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto usr)
        {
            var data =await auth.SignUp(usr);
            return Ok(data);
        }
    }
}
