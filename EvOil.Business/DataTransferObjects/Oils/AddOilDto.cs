namespace EvOil.Business.DataTransferObjects.Oils;

public class AddOilDto
{
    public AddOilDto(string codeName, string fullName)
    {
        CodeName = codeName;
        FullName = fullName;
    }

    public string CodeName { get; }

    public string FullName { get; }
}
