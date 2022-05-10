namespace EvOil.Business.DataTransferObjects.Organizers;

public class CreateOrganizerDto
{
    public CreateOrganizerDto(int id)
    {
        Id = id;
    }

    public int Id { get; }
}