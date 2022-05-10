using System.ComponentModel.DataAnnotations;
using EvOil.Business.DataTransferObjects.Oils;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class OilValidatorService : IOilValidatorService
{
    public void ValidateOil(AddOilDto addOilDto)
    {
        ValidateCodeName(addOilDto.CodeName);
        ValidateFullName(addOilDto.FullName);
    }

    public static void ValidateCodeName(string? codeName)
    {
        if (string.IsNullOrWhiteSpace(codeName))
        {
            throw new ValidationException("Code name is empty!");
        }

        if (codeName.Length >= Oil.MaxCodeNameLength)
        {
            var message = $"Code name is too long! Username must be less than {Oil.MaxCodeNameLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateFullName(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ValidationException("Full name is empty!");
        }

        if (fullName.Length >= Oil.MaxFullNameLength)
        {
            var message = $"Full name is too long! Full name must be less than {Oil.MaxFullNameLength}";
            throw new ValidationException(message);
        }
    }
}