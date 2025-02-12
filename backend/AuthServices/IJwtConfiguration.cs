namespace backend.AuthServices;

public interface IJwtConfiguration
{
    string GenerateJwtToken(string email, string role);
    string EncryptPassword(string password);
}