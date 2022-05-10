using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EvOil.Business.DataTransferObjects.Users;
using EvOil.Business.Services.Abstractions;

namespace EvOil.WebApi.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UsersController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("api/test")]
    public static string Test() => "Jupiii!";

    [HttpGet]
    [Route("api/users")]
    public async Task<IActionResult> GetUsers(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var users = await _userService.GetUsers(
            take: take,
            skip: skip,
            cancellationToken: cancellationToken);

        return Ok(users);
    }

    [HttpGet]
    [Route("api/users/{username}")]
    public async Task<IActionResult> GetUserDetails(
        [FromRoute] string username,
        CancellationToken cancellationToken)
    {
        var userDetails = await _userService.GetUserDetails(
            username: username,
            cancellationToken: cancellationToken);

        return Ok(userDetails);
    }

    [HttpPost]
    [Route("api/users")]
    public async Task<IActionResult> AddUser(
        [FromBody] AddUserDto addUserDto,
        CancellationToken cancellationToken)
    {
        await _userService.AddUser(
            addUserDto: addUserDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(AddUser), addUserDto);
    }
}
