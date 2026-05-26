using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.Features.Books;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Authorize]
public class BooksController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => HandleResult(await _mediator.Send(new GetAllBooksQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => HandleResult(await _mediator.Send(new GetBookByIdQuery(id)));

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
        => HandleResult(await _mediator.Send(new GetAvailableBooksQuery()));

    [HttpGet("search")]
    public async Task<IActionResult> SearchByTitle([FromQuery] string title)
        => HandleResult(await _mediator.Send(new SearchBooksByTitleQuery(title)));

    [HttpPost]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
    {
        var result = await _mediator.Send(new CreateBookCommand(dto));
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Value?.BookId });
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto dto)
        => HandleResult(await _mediator.Send(new UpdateBookCommand(id, dto)));

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> Delete(int id)
        => HandleResult(await _mediator.Send(new DeleteBookCommand(id)));
}
