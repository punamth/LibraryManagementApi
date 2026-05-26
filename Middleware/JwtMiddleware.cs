using LibraryManagement.Domain.Interfaces.Services;

namespace LibraryManagementApi.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IJwtTokenService jwtTokenService)
    {
        var token = ExtractToken(context);

        if (!string.IsNullOrEmpty(token))
        {
            var userId = jwtTokenService.GetUserIdFromToken(token);
            if (userId.HasValue)
            {
                context.Items["UserId"] = userId.Value;
            }
        }

        await _next(context);
    }

    private static string? ExtractToken(HttpContext context)
    {
        var authorization = context.Request.Headers.Authorization.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(authorization))
            return null;

        if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return authorization["Bearer ".Length..].Trim();

        return authorization.Trim();
    }
}
