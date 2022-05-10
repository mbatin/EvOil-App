namespace EvOil.Domain.Models;

public class Oil
{
    public const int MaxCodeNameLength = 100;
    public const int MaxFullNameLength = 100;

    public Oil() { }
    public Oil(string codeName, string fullName)
    {
        CodeName = codeName;
        FullName = fullName;
    }

    public string CodeName { get; private set; } = null!;
    public string FullName { get; private set; } = null!;

    //public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
}
