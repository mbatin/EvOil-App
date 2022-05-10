using EvOil.Business.DataTransferObjects.Users;

namespace EvOil.Business.Services.Abstractions;

public interface IUserService
{
    public Task AddUser(
        AddUserDto addUserDto,
        CancellationToken cancellationToken);

    public Task<UserDetailsDto> GetUserDetails(
        string username,
        CancellationToken cancellationToken);

    public Task<IEnumerable<UserListDto>> GetUsers(
        int take,
        int skip,
        CancellationToken cancellationToken);
}
