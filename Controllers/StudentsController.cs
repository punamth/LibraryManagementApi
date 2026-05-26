using LibraryManagement.Application.DTOs.Student;
using LibraryManagement.Application.Features.Students;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Authorize]
public class StudentsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => HandleResult(await _mediator.Send(new GetAllStudentsQuery()));

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
        => HandleResult(await _mediator.Send(new GetActiveStudentsQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => HandleResult(await _mediator.Send(new GetStudentByIdQuery(id)));

    [HttpPost]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
    {
        var result = await _mediator.Send(new CreateStudentCommand(dto));
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Value?.StudentId });
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentDto dto)
        => HandleResult(await _mediator.Send(new UpdateStudentCommand(id, dto)));

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Delete(int id)
        => HandleResult(await _mediator.Send(new DeleteStudentCommand(id)));
}
