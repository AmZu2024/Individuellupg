namespace OperationOOP.Api.Endpoints.Cardio
{
    public class GetAllCardioWorkouts:IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/workouts/cardio", Handle)
            .WithSummary("Get all cardio workouts");
        public record Response(
            int Id,
            string Name,
            int Duration,
            WorkoutLevel Level,
            CardioType Type,
            List<CardioExercise> Exercises
            );
        private static List<Response> Handle(IDatabase db)
        {
            return db.Workouts
              .OfType<CardioWorkout>()
                .Select(workout => new Response(
                    Id: workout.Id,
                    Name: workout.Name,
                    Duration: workout.Duration,
                    Level: workout.Level,
                    Type: workout.Type,
                    Exercises: workout.CardioExercises
                )).ToList();
        }


    }
}
