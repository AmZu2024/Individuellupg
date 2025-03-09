namespace OperationOOP.Api.Endpoints.Strength
{
    public class CreateStrengthWorkout:IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/workouts/strength", Handle)
            .WithSummary("Create a strength workout");
        public record Request(
            string Name,
            int Duration,
            WorkoutLevel Level
            );
        public record Response(int Id);
        private static Ok<Response> Handle(Request request, IDatabase db)
        {
            int nextWorkoutId = db.Workouts.Any() ? db.Workouts.Max(w => w.Id) + 1 : 1;
            var workout = new StrengthWorkout(request.Name, request.Duration, request.Level)
            {
                Id = nextWorkoutId
            };
            db.Workouts.Add(workout);
            return TypedResults.Ok(new Response(workout.Id));
        }


    }
}
    