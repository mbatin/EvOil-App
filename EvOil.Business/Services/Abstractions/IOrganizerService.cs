using EvOil.Business.DataTransferObjects.Organizers;

namespace EvOil.Business.Services.Abstractions;

public interface IOrganizerService
{
    public Task CreateOrganizer(
        CreateOrganizerDto createOrganizerDto,
        CancellationToken cancellationToken);

    public Task<OrganizerDetailsDto> GetOrganizerDetails(
        int id,
        CancellationToken cancellationToken);

    public Task<IEnumerable<OrganizerListDto>> GetOrganizers(
        int take,
        int skip,
        CancellationToken cancellationToken);
}