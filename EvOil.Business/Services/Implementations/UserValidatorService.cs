using System.ComponentModel.DataAnnotations;
using EvOil.Business.DataTransferObjects.Users;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class UserValidatorService : IUserValidatorService
{
    public void ValidateUser(AddUserDto addUserDto)
    {
        ValidateUsername(addUserDto.Username);
        ValidatePassword(addUserDto.Password);
    }

    public static void ValidateUsername(string? username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ValidationException("Username is empty!");
        }

        if (username.Length >= User.MaxUsernameLength)
        {
            var message = $"Username is too long! Username must be less than {User.MaxUsernameLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidatePassword(string? password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ValidationException("Password is empty!");
        }

        if (password.Length >= User.MaxPasswordLength)
        {
            var message = $"Password is too long! Password must be less than {User.MaxPasswordLength}";
            throw new ValidationException(message);
        }
    }
}