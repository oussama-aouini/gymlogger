using gymlogger.Dtos.Set;
using gymlogger.Models;

namespace gymlogger.Mappers
{
    public static class SetMapper
    {
        public static SetDto ToSetDto(this Set set)
        {
            return new SetDto
            {
                Id = set.Id,
                Repetitions = set.Repetitions,
                Weight = set.Weight,
                SetType = set.SetType,
                ExerciseId = set.ExerciseId,
                SessionId = set.SessionId,
            };
        }

        public static Set ToSetFromCreate(this CreateSetDto setDto)
        {
            return new Set
            {
                Repetitions = setDto.Repetitions,
                Weight = setDto.Weight,
                SetType = setDto.SetType,
                SessionId = setDto.SessionId,
                AppUserId = setDto.UserId,
                ExerciseId = setDto.ExerciseId
            };
        }
    }
}
