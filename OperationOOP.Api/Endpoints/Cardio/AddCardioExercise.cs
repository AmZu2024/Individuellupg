namespace OperationOOP.Api.Endpoints.Cardio
{
    public class AddCardioExercise:IEndpoint  
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/workouts/cardio/{workoutId}/exercises", Handle)
            .WithSummary("Add an exercise to a cardio workout");
        public record Request(
            string Name,
            string Description,
            int Duration,
            int CaloriesBurned
            );
        public record Response(int Id);
        private static IResult Handle(int workoutId, Request request, IDatabase db)
        {
            var workout = db.Workouts.OfType<CardioWorkout>().FirstOrDefault(w => w.Id == workoutId);
            if (workout == null)
            {
                return TypedResults.NotFound($"Workout with ID {workoutId} not found.");
            }
           int nextExerciseId = db.Exercises.OfType<CardioExercise>().Any()
                ? db.Exercises.OfType<CardioExercise>().Max(e => e.Id) + 1
                : 1;
            var exercise = new CardioExercise(request.Name,request.Description,request.Duration,request.CaloriesBurned)
            { 
                Id = nextExerciseId 

            };
            
            workout.CardioExercises.Add(exercise);
            workout.Exercises.Add(exercise);
            db.Exercises.Add(exercise);
            db.Workouts = db.Workouts.Select(w => w.Id == workout.Id ? workout : w).ToList();
            return TypedResults.Ok(new Response(exercise.Id));
        }
    }
}
