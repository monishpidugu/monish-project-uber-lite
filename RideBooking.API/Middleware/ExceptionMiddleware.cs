using System.Text.Json;
using RideBooking.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace RideBooking.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RideNotFoundException ex)
        {
            var rideId = context.Request.RouteValues["rideId"];

            _logger.LogWarning(
                ex,
                "Ride not found. RideId: {RideId}, Path: {Path}",
                rideId,
                context.Request.Path);

            await HandleExceptionAsync(
                context,
                StatusCodes.Status404NotFound,
                ex.Message);
        }
        catch (InvalidRideStateException ex)
        {
            _logger.LogWarning(
                ex,
                "Invalid ride state for request path {Path}",
                context.Request.Path);

            await HandleExceptionAsync(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message);
        }
        catch (NoDriversAvailableException ex)
        {
            _logger.LogWarning(
                ex,
                "No drivers available for request path {Path}",
                context.Request.Path);

            await HandleExceptionAsync(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unhandled exception occurred for request path {Path}",
                context.Request.Path);

            await HandleExceptionAsync(
                context,
                StatusCodes.Status500InternalServerError,
                "Something went wrong");
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        int statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            success = false,
            message,
            statusCode,
            timestamp = DateTime.UtcNow
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}