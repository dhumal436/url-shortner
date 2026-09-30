using ShortLi.Application.Services.Authentication;
using ShortLi.Contracts.Authentication;

namespace ShortLi.Application.Services;

public class AuthenticationService : IAuthService
{
    IJWTToken _jWTToken;
    public AuthenticationService(IJWTToken jWTToken)
    {
        _jWTToken=jWTToken;
    }
    public AuthenticationResponse Login(LoginRequest loginRequest)
    {
       return new AuthenticationResponse
       (
        new Guid(),
            "dhumal",
           "shubham",
           _jWTToken.GenrateToken(new Guid(), "passwod","email")
       );
    }

    public AuthenticationResponse Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }
}