using EvOil.Business.DataTransferObjects.Evaluations;

namespace EvOil.Business.Services.Abstractions;

public interface IEvaluationService
{
    public Task AddEvaluation(
        AddEvaluationDto addEvaluationDto,
        CancellationToken cancellationToken);

    public Task<EvaluationDetailsDto> GetEvaluationDetails(
        int id,
        CancellationToken cancellationToken);

    public Task<IEnumerable<EvaluationListDto>> GetEvaluations(
        int take,
        int skip,
        CancellationToken cancellationToken);
}
