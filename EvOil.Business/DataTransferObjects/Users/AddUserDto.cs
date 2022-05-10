namespace EvOil.Business.DataTransferObjects.Users;

public class AddUserDto
{
    public AddUserDto(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; }

    public string Password { get; }
}
