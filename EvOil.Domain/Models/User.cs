namespace EvOil.Domain.Models;

public class User
{
    public const int MaxUsernameLength = 100;
    public const int MaxPasswordLength = 100;

    public User() { }
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public string Username { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    //public ICollection<Oil> Oils { get; set; } = new List<Oil>();
    //public ICollection<Evaluation> Evaluations { get; private set; } = new List<Evaluation>();

    public static void LogIn()
    {
    }

    public static void EvaluateOil()
    {
    }
}
