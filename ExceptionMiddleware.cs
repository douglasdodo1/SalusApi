public class ExceptionMiddleware {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        }
        catch (KeyNotFoundException exception) {
            _logger.LogError(exception, "Key not found");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Key not found");
        }
        catch (ArgumentNullException exception) {
            _logger.LogError(exception, "Argument null");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Argument null");
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occurred");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("An error occurred");
        }
    }
}