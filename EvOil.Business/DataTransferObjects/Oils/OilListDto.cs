using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Oils;

public class OilListDto
{
    private OilListDto()
    {
    }

    public string? CodeName { get; private set; } = null!;
    public string? FullName { get; private set; } = null!;

    public static Expression<Func<Oil, OilListDto>> Projection
    {
        get
        {
            return oil => new OilListDto
            {
                CodeName = oil.CodeName,
                FullName = oil.FullName,
            };
        }
    }
}
