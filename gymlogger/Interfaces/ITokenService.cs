using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
