namespace OperationOOP.Api.Endpoints.Strength
{
    public class CreateWorkout:IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/workouts", Handle)
            .WithSummary("Create a workout");
        public record Request(
            string Name,
            int Duration,
            WorkoutLevel Level,
            WorkoutType Type
            );
        public record Response(int Id);
        private static Ok<Response> Handle(Request request, IDatabase db)
        {
            int nextWorkoutId = db.Workouts.Any() ? db.Workouts.Max(w => w.Id) + 1 : 1;
            var workout = new Workout(request.Name, request.Duration, request.Level,request.Type,new List<Exercise>())
            {
                Id = nextWorkoutId
            };
            db.Workouts.Add(workout);
            return TypedResults.Ok(new Response(workout.Id));
        }


    }
}
    