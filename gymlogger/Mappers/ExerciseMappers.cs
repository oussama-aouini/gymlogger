using gymlogger.Dtos.Exercise;
using gymlogger.Models;

namespace gymlogger.Mappers
{
    public static class ExerciseMappers
    {
        public static ExerciseDto ToExerciseDto(this Exercise exercise)
        {
            return new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Muscles = exercise.Muscles,
            };
        }
    }
}
