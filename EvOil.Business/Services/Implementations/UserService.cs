using Microsoft.EntityFrameworkCore;
using EvOil.Business.DataTransferObjects.Users;
using EvOil.Business.Exceptions;
using EvOil.Business.Infrastructure;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class UserService : IUserService
{
    private readonly IEvOilDatabaseContext _context;
    private readonly IUserValidatorService _userValidatorService;

    public UserService(
        IEvOilDatabaseContext context,
        IUserValidatorService userValidatorService)
    {
        _context = context;
        _userValidatorService = userValidatorService;
    }

    public async Task AddUser(
        AddUserDto addUserDto,
        CancellationToken cancellationToken)
    {
        _userValidatorService.ValidateUser(addUserDto);

        var user = new User(
            username: addUserDto.Username!,
            password: addUserDto.Password!);

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserDetailsDto> GetUserDetails(
        string username,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Select(UserDetailsDto.Projection)
            .FirstOrDefaultAsync(user => user.Username == username, cancellationToken);

        return user is null ? throw new NotFoundException($"User with {username} was not found!") : user;
    }

    public async Task<IEnumerable<UserListDto>> GetUsers(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .AsNoTracking()
            .Select(UserListDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return users;
    }
}
