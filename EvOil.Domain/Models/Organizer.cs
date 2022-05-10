namespace EvOil.Domain.Models;
public class Organizer
{
    public const int MinValue = 001;
    public const int MaxValue = 100;

    public Organizer() { }
    public Organizer(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }

    //public ICollection<User> Users { get; private set; } = new List<User>();
    //public ICollection<Oil> Oils { get; private set; } = new List<Oil>();
    //public ICollection<Evaluation> Evaluations { get; private set; } = new List<Evaluation>();

    public static void AddUser()
    {
    }

    public static void AddOil()
    {
    }

    public static void GetEvaluationsForOil()
    {
    }

    public static void GetEvaluationsFromUser()
    {
    }
}
