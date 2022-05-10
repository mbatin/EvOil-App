using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EvOil.Business.DataTransferObjects.Oils;
using EvOil.Business.Services.Abstractions;

namespace EvOil.WebApi.Controllers;

[ApiController]
public class OilsController : ControllerBase
{
    private readonly IOilService _oilService;
    private readonly IConfiguration _configuration;

    public OilsController(IOilService oilService, IConfiguration configuration)
    {
        _oilService = oilService;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("api/oils")]
    public async Task<IActionResult> GetOils(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var oils = await _oilService.GetOils(
            take: take,
            skip: skip,
            cancellationToken: cancellationToken);

        return Ok(oils);
    }

    [HttpGet]
    [Route("api/oils/{codeName}")]
    public async Task<IActionResult> GetOilDetails(
        [FromRoute] string codeName,
        CancellationToken cancellationToken)
    {
        var oilDetails = await _oilService.GetOilDetails(
            codeName: codeName,
            cancellationToken: cancellationToken);

        return Ok(oilDetails);
    }

    [HttpPost]
    [Route("api/oils")]
    public async Task<IActionResult> AddOil(
        [FromBody] AddOilDto addOilDto,
        CancellationToken cancellationToken)
    {
        await _oilService.AddOil(
            addOilDto: addOilDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddOil), addOilDto);
    }
}
