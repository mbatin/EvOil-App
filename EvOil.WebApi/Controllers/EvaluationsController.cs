using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EvOil.Business.DataTransferObjects.Evaluations;
using EvOil.Business.Services.Abstractions;

namespace EvOil.WebApi.Controllers;

[ApiController]
public class EvaluationsController : ControllerBase
{
    private readonly IEvaluationService _evaluationService;
    private readonly IConfiguration _configuration;

    public EvaluationsController(IEvaluationService evaluationService, IConfiguration configuration)
    {
        _evaluationService = evaluationService;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("api/evaluations")]
    public async Task<IActionResult> GetEvaluations(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var evaluations = await _evaluationService.GetEvaluations(
            take: take,
            skip: skip,
            cancellationToken: cancellationToken);

        return Ok(evaluations);
    }

    [HttpGet]
    [Route("api/evaluations/{id}")]
    public async Task<IActionResult> GetEvaluationDetails(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var evaluationDetails = await _evaluationService.GetEvaluationDetails(
            id: id,
            cancellationToken: cancellationToken);

        return Ok(evaluationDetails);
    }

    [HttpPost]
    [Route("api/evaluations")]
    public async Task<IActionResult> AddEvaluation(
        [FromBody] AddEvaluationDto addEvaluationDto,
        CancellationToken cancellationToken)
    {
        await _evaluationService.AddEvaluation(
            addEvaluationDto: addEvaluationDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddEvaluation), addEvaluationDto);
    }
}
