using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Oils;

public class OilDetailsDto
{
    private OilDetailsDto()
    {
    }

    public string? CodeName { get; private set; } = null!;
    public string? FullName { get; private set; } = null!;

    public static Expression<Func<Oil, OilDetailsDto>> Projection
    {
        get
        {
            return oil => new OilDetailsDto
            {
                CodeName = oil.CodeName,
                FullName = oil.FullName,
            };
        }
    }
}
