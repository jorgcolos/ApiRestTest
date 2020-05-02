using Domain;

namespace Aplication.Interfaces
{
    public interface IJwtGenerator
    {
         string CreateToken(AppUser user);
    }
}