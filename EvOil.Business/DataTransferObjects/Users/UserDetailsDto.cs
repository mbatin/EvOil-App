using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Users;

public class UserDetailsDto
{
    private UserDetailsDto()
    {
    }

    public string? Username { get; private set; } = null!;
    public string? Password { get; private set; } = null!;

    public static Expression<Func<User, UserDetailsDto>> Projection
    {
        get
        {
            return user => new UserDetailsDto
            {
                Username = user.Username,
                Password = user.Password,
            };
        }
    }
}
