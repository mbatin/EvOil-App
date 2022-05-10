namespace EvOil.Domain.Models;

public class Evaluation
{
    public const int MinValue = 0001;
    public const int MaxValue = 1000;
    public const int MaxUsernameLength = 100;
    public const int MaxCodeNameLength = 100;
    public const float MinGradeLength = 0.0f;
    public const float MaxGradeLength = 10.0f;

    public Evaluation() { }
    public Evaluation(int id, string username, string codeName, float inflamed, float moldy,
    float sour, float frosted, float burned, float fruity, float spicy, float bitter)
    {
        Id = id;
        Username = username;
        CodeName = codeName;
        Inflamed = inflamed;
        Moldy = moldy;
        Sour = sour;
        Frosted = frosted;
        Burned = burned;
        Fruity = fruity;
        Spicy = spicy;
        Bitter = bitter;
    }

    public int Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string CodeName { get; private set; } = null!;
    public float Inflamed { get; private set; }
    public float Moldy { get; private set; }
    public float Sour { get; private set; }
    public float Frosted { get; private set; }
    public float Burned { get; private set; }
    public float Fruity { get; private set; }
    public float Spicy { get; private set; }
    public float Bitter { get; private set; }

    //edit function
    public static float CalculateAvgGrade(float inflamed, float moldy,
    float sour, float frosted, float burned, float fruity, float spicy, float bitter, float numberOfUsers)
    {
        var propertyGrades = inflamed + moldy + sour + frosted + burned + fruity + spicy + bitter;
        var avgGrade = propertyGrades / numberOfUsers;
        return avgGrade;
    }
}
