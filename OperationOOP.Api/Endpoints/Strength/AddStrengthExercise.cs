namespace OperationOOP.Api.Endpoints.Strength
{
    public class AddStrengthExercise:IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/workouts/strength/{workoutId}/exercises", Handle)
            .WithSummary("Add an exercise to a strength workout");
        public record Request(
            string ExerciseName,
            string ExerciseDescription,
            string MuscleGroup,
            int Repetition,
            int Sets,
            int Weight
            );
        public record Response(int Id);
        private static IResult Handle(int workoutId, Request request, IDatabase db)
        {
            var workout = db.Workouts.FirstOrDefault(w => w.Id == workoutId &&w.Type == WorkoutType.Strength);
            if (workout == null)
            {
                return TypedResults.NotFound($"Workout with ID {workoutId} not found.");
            }
            int nextExerciseId = db.Exercises.OfType<StrengthExercise>().Any()
                ? db.Exercises.OfType<StrengthExercise>().Max(e => e.Id) + 1
                : 1;
            var exercise = new StrengthExercise(request.ExerciseName, request.ExerciseDescription,request.MuscleGroup, request.Sets, request.Repetition, request.Weight)
            {
                Id = nextExerciseId
            };

            
            workout.Exercises.Add(exercise);
            db.Exercises.Add(exercise);
            db.Workouts = db.Workouts.Select(w => w.Id == workout.Id ? workout : w).ToList();


            return TypedResults.Ok(new Response(exercise.Id));
        }

    }
}
