using LibraryManagement.Application.DTOs.Admin;
using LibraryManagement.Application.Features.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Authorize(Roles = "Admin,SuperAdmin")]
public class AdminController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => HandleResult(await _mediator.Send(new GetAllAdminsQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => HandleResult(await _mediator.Send(new GetAdminByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAdminDto dto)
    {
        var result = await _mediator.Send(new CreateAdminCommand(dto));
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Value?.AdminId });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AdminDto dto)
        => HandleResult(await _mediator.Send(new UpdateAdminCommand(id, dto)));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => HandleResult(await _mediator.Send(new DeleteAdminCommand(id)));
}
