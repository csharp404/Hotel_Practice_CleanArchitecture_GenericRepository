using Application.Dtos;

namespace Application.Interfaces;

public interface IAuthServices
{
    public Task<string> Login(LoginDto usr);
    public Task<bool> SignUp(SignUpDto usr);
    public Task<CurrentUserDto> GetCurrentUser();

}