using Microsoft.EntityFrameworkCore;
using EvOil.Business.DataTransferObjects.Oils;
using EvOil.Business.Exceptions;
using EvOil.Business.Infrastructure;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class OilService : IOilService
{
    private readonly IEvOilDatabaseContext _context;
    private readonly IOilValidatorService _oilValidatorService;

    public OilService(
        IEvOilDatabaseContext context,
        IOilValidatorService oilValidatorService)
    {
        _context = context;
        _oilValidatorService = oilValidatorService;
    }

    public async Task AddOil(
        AddOilDto addOilDto,
        CancellationToken cancellationToken)
    {
        _oilValidatorService.ValidateOil(addOilDto);

        var oil = new Oil(
            codeName: addOilDto.CodeName!,
            fullName: addOilDto.FullName!);

        _context.Oils.Add(oil);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<OilDetailsDto> GetOilDetails(
        string codeName,
        CancellationToken cancellationToken)
    {
        var oil = await _context.Oils
            .AsNoTracking()
            .Select(OilDetailsDto.Projection)
            .FirstOrDefaultAsync(oil => oil.CodeName == codeName, cancellationToken);

        return oil is null ? throw new NotFoundException($"Oil with {codeName} was not found!") : oil;
    }

    public async Task<IEnumerable<OilListDto>> GetOils(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var oils = await _context.Oils
            .AsNoTracking()
            .Select(OilListDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return oils;
    }
}
