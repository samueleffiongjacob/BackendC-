using CollectDataWeblab.Services;

namespace CollectDataWeblab.Routing;

public static class UserRoute
{
    public static IEndpointRouteBuilder MapUserRoute(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/api/users/export").WithTags("User Export");

        routeGroup.MapGet("/json", QueueSerializer("json"))
            .WithName("ExportUsersAsJson")
            .WithSummary("Export users as JSON");

        routeGroup.MapGet("/xml", QueueSerializer("xml"))
            .WithName("ExportUsersAsXml")
            .WithSummary("Export users as XML");

        routeGroup.MapGet("/dat", QueueSerializer("dat"))
            .WithName("ExportUsersAsDat")
            .WithSummary("Export users as DAT");

        routeGroup.MapGet("/binary", QueueSerializer("binary"))
            .WithName("ExportUsersAsBinary")
            .WithSummary("Export users as binary");

        return app;
    }

    private static Delegate QueueSerializer(string format)
    {
        return (HttpContext context, IUserService userService) =>
        {
            context.Items["serialize-format"] = format;
            context.Items["serialize-data"] = userService.GetAll();
        };
    }
}
