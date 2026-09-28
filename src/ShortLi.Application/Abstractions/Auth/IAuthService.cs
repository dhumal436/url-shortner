using ShortLi.Contracts.Authentication;

namespace ShortLi.Application.Services.Authentication;
public interface IAuthService
{
    public AuthenticationResponse Register(RegisterRequest registerRequest);    
    public AuthenticationResponse Login(LoginRequest loginRequest );    
}