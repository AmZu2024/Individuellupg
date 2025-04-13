namespace OperationOOP.Api.Endpoints.Strength
{
    public class GetAllStrengthworkouts : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/workouts/strength", Handle)
            .WithSummary("Get all strength workouts");

        public record Response(
            int Id,
            string Name,
            int Duration,
            WorkoutLevel Level,
            List<StrengthExerciseResponse> Exercises
        );

        public record StrengthExerciseResponse(
            int Id,
            string ExerciseName,
            string ExerciseDescription,
            string MuscleGroup,
            int Repetitions,
            int Sets,
            int Weight
        );

        private static List<Response> Handle(IDatabase db)
        {
            return db.Workouts
                .Where(workout=>workout.Type==WorkoutType.Strength)
                .Select(workout => new Response(
                    Id: workout.Id,
                    Name: workout.Name,
                    Duration: workout.Duration,
                    Level: workout.Level,
                    Exercises: workout.Exercises
                    .OfType<StrengthExercise>()
                        .Select(exercise => new StrengthExerciseResponse(
                            Id: exercise.Id,
                            ExerciseName: exercise.ExcersiseName,
                            ExerciseDescription: exercise.ExcersiseDescription,
                            MuscleGroup: exercise.MuscleGroup,
                            Repetitions: exercise.Repetitions,
                            Sets: exercise.Sets,
                            Weight: exercise.Weight
                        )).ToList()
                ))
                .ToList();
        }
    }
}
