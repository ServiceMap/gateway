namespace ServiceMap.Gateway.Endpoints;

public static class HealthEndpoints
{
    public static void MapHealthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/health")
            .WithTags("Health")
            .WithOpenApi();

        group.MapGet("/", () =>
            {
                var response = new
                {
                    status = "Healthy",
                    environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
                    time = DateTime.UtcNow
                };
                return Results.Ok(response);
            })
            .WithSummary("Check API health status")
            .WithDescription("Returns current health status of the API Gateway service.")
            .Produces(StatusCodes.Status200OK);
    }
}
