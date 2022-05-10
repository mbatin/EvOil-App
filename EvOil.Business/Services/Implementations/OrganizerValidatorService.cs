using System.ComponentModel.DataAnnotations;
using EvOil.Business.DataTransferObjects.Organizers;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class OrganizerValidatorService : IOrganizerValidatorService
{
    public void ValidateOrganizer(CreateOrganizerDto createOrganizerDto)
    {
        ValidateId(createOrganizerDto.Id);
    }

    public static void ValidateId(int id)
    {
        if (id == 000)
        {
            throw new ValidationException("Id is empty!");
        }

        if (id < Organizer.MinValue || id > Organizer.MaxValue)
        {
            var message = $"Id must be number between {Organizer.MinValue} and {Organizer.MaxValue}!";
            throw new ValidationException(message);
        }
    }
}
