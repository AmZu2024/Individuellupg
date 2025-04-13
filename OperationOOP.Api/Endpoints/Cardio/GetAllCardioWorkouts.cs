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
            List<CardioExerciseResponse> Exercises
            );
        public record CardioExerciseResponse(
            int Id,
            string ExerciseName,
            string ExerciseDescription,
            int Duration,
            int CaloriesBurned
        );
        private static List<Response> Handle(IDatabase db)
        {
            return db.Workouts
              .Where(workout => workout.Type == WorkoutType.Cardio)
                .Select(workout => new Response(
                    Id: workout.Id,
                    Name: workout.Name,
                    Duration: workout.Duration,
                    Level: workout.Level,
                    Exercises: workout.Exercises
                    .OfType<CardioExercise>()
                        .Select(exercise => new CardioExerciseResponse(
                            Id: exercise.Id,
                            ExerciseName: exercise.ExcersiseName,
                            ExerciseDescription: exercise.ExcersiseDescription,
                            Duration: exercise.Duration,
                            CaloriesBurned: exercise.CaloriesBurned
                )).ToList()
                )).ToList();
        }


    }
}
