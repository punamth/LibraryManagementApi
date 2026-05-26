using LibraryManagement.Application.DTOs.Transaction;
using LibraryManagement.Application.Features.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Authorize]
public class TransactionsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => HandleResult(await _mediator.Send(new GetTransactionByIdQuery(id)));

    [HttpGet("student/{studentId:int}")]
    public async Task<IActionResult> GetByStudent(int studentId)
        => HandleResult(await _mediator.Send(new GetTransactionsByStudentQuery(studentId)));

    [HttpGet("overdue")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff")]
    public async Task<IActionResult> GetOverdue()
        => HandleResult(await _mediator.Send(new GetOverdueTransactionsQuery()));

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveLoans()
        => HandleResult(await _mediator.Send(new GetActiveLoansQuery()));

    [HttpPost("issue")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff,Student")]
    public async Task<IActionResult> IssueBook([FromBody] CreateTransactionDto dto)
    {
        var result = await _mediator.Send(new IssueBookCommand(dto));
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Value?.TransactionId });
    }

    [HttpPost("return")]
    [Authorize(Roles = "Admin,Librarian,SuperAdmin,Staff,Student")]
    public async Task<IActionResult> ReturnBook([FromBody] ReturnBookDto dto)
        => HandleResult(await _mediator.Send(new ReturnBookCommand(dto)));
}
