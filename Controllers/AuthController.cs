using LibraryManagement.Application.DTOs.Student;
using LibraryManagement.Application.Features.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[AllowAnonymous]
public class AuthController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        return HandleResult(await _mediator.Send(new LoginCommand(dto)));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        return HandleResult(await _mediator.Send(new RegisterCommand(dto)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return HandleResult(await _mediator.Send(new GetUserByIdQuery(id)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return HandleResult(await _mediator.Send(new DeleteUserCommand(id)));
    }
}