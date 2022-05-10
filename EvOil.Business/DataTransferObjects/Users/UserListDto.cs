using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Users;

public class UserListDto
{
    private UserListDto()
    {
    }

    public string? Username { get; private set; } = null!;
    public string? Password { get; private set; } = null!;

    public static Expression<Func<User, UserListDto>> Projection
    {
        get
        {
            return user => new UserListDto
            {
                Username = user.Username,
                Password = user.Password,
            };
        }
    }
}
