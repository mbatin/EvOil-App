using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Organizers;

public class OrganizerListDto
{
    private OrganizerListDto()
    {
    }

    public int Id { get; private set; }

    public static Expression<Func<Organizer, OrganizerListDto>> Projection
    {
        get
        {
            return organizer => new OrganizerListDto
            {
                Id = organizer.Id,
            };
        }
    }
}