using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos;
using Application.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public class AuthServices (UserManager<IdentityUser> userManager,IHttpContextAccessor contextAccessor,SignInManager<IdentityUser> signInManager , IConfiguration configuration): IAuthServices
{
    public async Task<string> Login(LoginDto usr)
    {
        var user = await userManager.FindByEmailAsync(usr.Email);
        if(user != null)
        {
      
            var res = await signInManager.CheckPasswordSignInAsync(user, usr.Password, true);
            if (res.Succeeded)
            {
                return GenerateToken(user);

            }
        }

        return "Falied Login...!";
    }

    public async Task<bool> SignUp(SignUpDto usr)
    {
        try
        {
            var user = usr.Adapt<IdentityUser>();
            var result = await userManager.CreateAsync(user,usr.Password);
            if (result.Succeeded)
            {
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return false;
    }

    public async Task<CurrentUserDto> GetCurrentUser()
    {
        var user =  contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x=>x.Type=="Id");
        if (user != null)
        {

            var usr = await userManager.FindByIdAsync(user.Value);
            var data = usr.Adapt<CurrentUserDto>();
            return data;
        }

        return new CurrentUserDto();
    }

    private string  GenerateToken(IdentityUser usr)
    {
        var jwt = Encoding.ASCII.GetBytes(configuration.GetSection("JWTsecret").Value);
        List<Claim> Claims = new()
        {
            new Claim("Id", usr.Id),
            new Claim("Email", usr.Email)
        };
        var descriptor = new SecurityTokenDescriptor()
        {
            Issuer = "Us",
            Audience = "Us",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwt), SecurityAlgorithms.HmacSha256),
            Expires = DateTime.Now.AddDays(1),
            Subject = new ClaimsIdentity(Claims)

        };
        var token = new JwtSecurityTokenHandler();
        var tok = token.CreateToken(descriptor);
        return token.WriteToken(tok);
    }
}