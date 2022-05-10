using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Organizers;

public class OrganizerDetailsDto
{
    private OrganizerDetailsDto()
    {
    }

    public int Id { get; private set; }

    public static Expression<Func<Organizer, OrganizerDetailsDto>> Projection
    {
        get
        {
            return organizer => new OrganizerDetailsDto
            {
                Id = organizer.Id,
            };
        }
    }
}