using LibraryManagement.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Ok(result.Value);

        if (IsNotFound(result.Error))
            return NotFound(new { error = result.Error });

        return BadRequest(new { error = result.Error });
    }

    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
            return NoContent();

        if (IsNotFound(result.Error))
            return NotFound(new { error = result.Error });

        return BadRequest(new { error = result.Error });
    }

    protected IActionResult HandleCreatedResult<T>(Result<T> result, string actionName, object routeValues)
    {
        if (result.IsSuccess)
            return CreatedAtAction(actionName, routeValues, result.Value);

        if (IsNotFound(result.Error))
            return NotFound(new { error = result.Error });

        return BadRequest(new { error = result.Error });
    }

    private static bool IsNotFound(string? error) =>
        !string.IsNullOrEmpty(error) &&
        error.Contains("not found", StringComparison.OrdinalIgnoreCase);
}
