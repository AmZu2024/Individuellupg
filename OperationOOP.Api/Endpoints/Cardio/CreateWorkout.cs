namespace OperationOOP.Api.Endpoints.Cardio
{
    public class CreateCardioWorkout:IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/workouts/cardio", Handle)
            .WithSummary("Create a cardio workout");
        public record Request(
            string Name,
            int Duration,
            WorkoutLevel Level,
            CardioType type
            );
        public record Response(int Id);
        private static Ok<Response> Handle(Request request, IDatabase db)
        {
            int nextWorkoutId = db.Workouts.Any() ? db.Workouts.Max(w => w.Id) + 1 : 1;

            var workout = new CardioWorkout(request.Name, request.Duration, request.Level, request.type, new List<CardioExercise>())
            {
                Id = nextWorkoutId
            };

            db.Workouts.Add(workout);

            return TypedResults.Ok(new Response(workout.Id));
        }


    }
}
