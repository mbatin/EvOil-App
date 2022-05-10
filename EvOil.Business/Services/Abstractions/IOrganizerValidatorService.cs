using EvOil.Business.DataTransferObjects.Organizers;

namespace EvOil.Business.Services.Abstractions;

public interface IOrganizerValidatorService
{
    public void ValidateOrganizer(CreateOrganizerDto createOrganizerDto);
}