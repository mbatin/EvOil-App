using EvOil.Business.DataTransferObjects.Evaluations;

namespace EvOil.Business.Services.Abstractions;

public interface IEvaluationValidatorService
{
    public void ValidateEvaluation(AddEvaluationDto addEvaluationDto);
}