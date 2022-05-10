namespace EvOil.Business.DataTransferObjects.Evaluations;

public class AddEvaluationDto
{
    public AddEvaluationDto(int id, string username, string codeName, float inflamed, float moldy,
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

    public int Id { get; }
    public string Username { get; }
    public string CodeName { get; }
    public float Inflamed { get; }
    public float Moldy { get; }
    public float Sour { get; }
    public float Frosted { get; }
    public float Burned { get; }
    public float Fruity { get; }
    public float Spicy { get; }
    public float Bitter { get; }
}
