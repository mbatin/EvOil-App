using Microsoft.EntityFrameworkCore;
using EvOil.Business.DataTransferObjects.Organizers;
using EvOil.Business.Exceptions;
using EvOil.Business.Infrastructure;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class OrganizerService : IOrganizerService
{
    private readonly IEvOilDatabaseContext _context;
    private readonly IOrganizerValidatorService _organizerValidatorService;

    public OrganizerService(
        IEvOilDatabaseContext context,
        IOrganizerValidatorService organizerValidatorService)
    {
        _context = context;
        _organizerValidatorService = organizerValidatorService;
    }

    public async Task CreateOrganizer(
        CreateOrganizerDto createOrganizerDto,
        CancellationToken cancellationToken)
    {
        _organizerValidatorService.ValidateOrganizer(createOrganizerDto);

        var organizer = new Organizer(
            id: createOrganizerDto.Id!);

        _context.Organizers.Add(organizer);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<OrganizerDetailsDto> GetOrganizerDetails(
        int id,
        CancellationToken cancellationToken)
    {
        var organizer = await _context.Organizers
            .AsNoTracking()
            .Select(OrganizerDetailsDto.Projection)
            .FirstOrDefaultAsync(organizer => organizer.Id == id, cancellationToken);

        return organizer is null ? throw new NotFoundException($"Organizer with {id} was not found!") : organizer;
    }

    public async Task<IEnumerable<OrganizerListDto>> GetOrganizers(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var organizers = await _context.Organizers
            .AsNoTracking()
            .Select(OrganizerListDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return organizers;
    }
}
