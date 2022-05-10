using System.Linq.Expressions;
using EvOil.Domain.Models;

namespace EvOil.Business.DataTransferObjects.Evaluations;

public class EvaluationDetailsDto
{
    private EvaluationDetailsDto()
    {
    }

    public int Id { get; private set; }
    public string? Username { get; private set; } = null!;
    public string? CodeName { get; private set; } = null!;
    public float Inflamed { get; private set; }
    public float Moldy { get; private set; }
    public float Sour { get; private set; }
    public float Frosted { get; private set; }
    public float Burned { get; private set; }
    public float Fruity { get; private set; }
    public float Spicy { get; private set; }
    public float Bitter { get; private set; }

    public static Expression<Func<Evaluation, EvaluationDetailsDto>> Projection
    {
        get
        {
            return evaluation => new EvaluationDetailsDto
            {
                Id = evaluation.Id,
                Username = evaluation.Username,
                CodeName = evaluation.CodeName,
                Inflamed = evaluation.Inflamed,
                Moldy = evaluation.Moldy,
                Sour = evaluation.Sour,
                Frosted = evaluation.Frosted,
                Burned = evaluation.Burned,
                Fruity = evaluation.Fruity,
                Spicy = evaluation.Spicy,
                Bitter = evaluation.Bitter,
            };
        }
    }
}
