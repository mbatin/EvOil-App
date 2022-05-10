using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EvOil.Business.DataTransferObjects.Organizers;
using EvOil.Business.Services.Abstractions;

namespace EvOil.WebApi.Controllers;

[ApiController]
public class OrganizersController : ControllerBase
{
    private readonly IOrganizerService _organizerService;
    private readonly IConfiguration _configuration;

    public OrganizersController(IOrganizerService organizerService, IConfiguration configuration)
    {
        _organizerService = organizerService;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("api/organizers")]
    public async Task<IActionResult> GetOrganizers(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var organizers = await _organizerService.GetOrganizers(
            take: take,
            skip: skip,
            cancellationToken: cancellationToken);

        return Ok(organizers);
    }

    [HttpGet]
    [Route("api/organizers/{id}")]
    public async Task<IActionResult> GetOrganizerDetails(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var organizerDetails = await _organizerService.GetOrganizerDetails(
            id: id,
            cancellationToken: cancellationToken);

        return Ok(organizerDetails);
    }

    [HttpPost]
    [Route("api/organizers")]
    public async Task<IActionResult> CreateOrganizer(
        [FromBody] CreateOrganizerDto createOrganizerDto,
        CancellationToken cancellationToken)
    {
        await _organizerService.CreateOrganizer(
            createOrganizerDto: createOrganizerDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(CreateOrganizer), createOrganizerDto);
    }
}
