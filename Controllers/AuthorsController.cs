using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.Features.Authors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Authorize]
public class AuthorsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => HandleResult(await _mediator.Send(new GetAllAuthorsQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => HandleResult(await _mediator.Send(new GetAuthorByIdQuery(id)));

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
        => HandleResult(await _mediator.Send(new SearchAuthorsByNameQuery(name)));

    [HttpPost]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Create([FromBody] CreateAuthorDto dto)
    {
        var result = await _mediator.Send(new CreateAuthorCommand(dto));
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Value?.AuthorId });
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorDto dto)
        => HandleResult(await _mediator.Send(new UpdateAuthorCommand(id, dto)));

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Delete(int id)
        => HandleResult(await _mediator.Send(new DeleteAuthorCommand(id)));
}
