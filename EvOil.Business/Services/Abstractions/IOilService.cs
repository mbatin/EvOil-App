using EvOil.Business.DataTransferObjects.Oils;

namespace EvOil.Business.Services.Abstractions;

public interface IOilService
{
    public Task AddOil(
        AddOilDto addOilDto,
        CancellationToken cancellationToken);

    public Task<OilDetailsDto> GetOilDetails(
        string codeName,
        CancellationToken cancellationToken);

    public Task<IEnumerable<OilListDto>> GetOils(
        int take,
        int skip,
        CancellationToken cancellationToken);
}
