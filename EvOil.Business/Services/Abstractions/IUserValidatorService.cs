using EvOil.Business.DataTransferObjects.Users;

namespace EvOil.Business.Services.Abstractions;

public interface IUserValidatorService
{
    public void ValidateUser(AddUserDto addUserDto);
}