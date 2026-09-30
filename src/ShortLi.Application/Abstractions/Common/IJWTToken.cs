public interface IJWTToken
{
    public string GenrateToken(Guid userId, string firstName, string lastName);
}