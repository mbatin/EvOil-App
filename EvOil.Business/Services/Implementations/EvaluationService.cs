using Microsoft.EntityFrameworkCore;
using EvOil.Business.DataTransferObjects.Evaluations;
using EvOil.Business.Exceptions;
using EvOil.Business.Infrastructure;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class EvaluationService : IEvaluationService
{
    private readonly IEvOilDatabaseContext _context;
    private readonly IEvaluationValidatorService _evaluationValidatorService;

    public EvaluationService(
        IEvOilDatabaseContext context,
        IEvaluationValidatorService evaluationValidatorService)
    {
        _context = context;
        _evaluationValidatorService = evaluationValidatorService;
    }

    public async Task AddEvaluation(
        AddEvaluationDto addEvaluationDto,
        CancellationToken cancellationToken)
    {
        _evaluationValidatorService.ValidateEvaluation(addEvaluationDto);

        var evaluation = new Evaluation(
            id: addEvaluationDto.Id!,
            username: addEvaluationDto.Username!,
            codeName: addEvaluationDto.CodeName!,
            inflamed: addEvaluationDto.Inflamed!,
            moldy: addEvaluationDto.Moldy!,
            sour: addEvaluationDto.Sour!,
            frosted: addEvaluationDto.Frosted!,
            burned: addEvaluationDto.Burned!,
            fruity: addEvaluationDto.Fruity!,
            spicy: addEvaluationDto.Spicy!,
            bitter: addEvaluationDto.Bitter!);

        _context.Evaluations.Add(evaluation);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<EvaluationDetailsDto> GetEvaluationDetails(
        int id,
        CancellationToken cancellationToken)
    {
        var evaluation = await _context.Evaluations
            .AsNoTracking()
            .Select(EvaluationDetailsDto.Projection)
            .FirstOrDefaultAsync(evaluation => evaluation.Id == id, cancellationToken);

        return evaluation is null ? throw new NotFoundException($"Evaluation with Id {id} was not found!") : evaluation;
    }

    public async Task<IEnumerable<EvaluationListDto>> GetEvaluations(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var evaluations = await _context.Evaluations
            .AsNoTracking()
            .Select(EvaluationListDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return evaluations;
    }
}
