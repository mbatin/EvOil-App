using EvOil.Business.DataTransferObjects.Oils;

namespace EvOil.Business.Services.Abstractions;

public interface IOilValidatorService
{
    public void ValidateOil(AddOilDto addOilDto);
}