using ShortLi.Application.Services.Authentication;
using ShortLi.Contracts.Authentication;

namespace ShortLi.Application.Services;

public class AuthenticationService : IAuthService
{
    public AuthenticationResponse Login(LoginRequest loginRequest)
    {
       return new AuthenticationResponse
       (
        new Guid(),
            "dhumal",
           "shubham",
           ""
       );
    }

    public AuthenticationResponse Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }
}