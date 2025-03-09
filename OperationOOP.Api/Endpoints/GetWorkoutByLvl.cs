using OperationOOP.Core.DTOs;
using OperationOOP.Core.Services;


namespace OperationOOP.Api.Endpoints
{
    public class GetWorkoutByLvl : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/workouts/{level}", Handle)
            .WithSummary("Get a workout by level");
        public record Response(List<WorkoutDTO> Workouts);
        private static IResult Handle(int level, IDatabase db)
        {
            var test = new WorkoutService(db);
            var orderdByLvl = test.GetWorkoutsByLvl(level);

            return TypedResults.Ok(new Response(orderdByLvl));
        }

    }
}
