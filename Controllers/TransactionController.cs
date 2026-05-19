using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_transactionService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpGet("student/{studentId}")]
        public IActionResult GetByStudentId(int studentId)
        {
            return Ok(_transactionService.GetTransactionsByStudentId(studentId));
        }

        [HttpPost("issue")]
        public IActionResult IssueBook(Transaction transaction)
        {
            var result = _transactionService.IssueBook(transaction);
            if (result.Contains("successfully"))
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("return/{id}")]
        public IActionResult ReturnBook(int id)
        {
            var result = _transactionService.ReturnBook(id);
            if (result.Contains("successfully"))
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Transaction transaction)
        {
            _transactionService.Update(transaction);
            return Ok("Transaction updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _transactionService.Delete(id);
            return Ok("Transaction deleted successfully.");
        }
    }
}