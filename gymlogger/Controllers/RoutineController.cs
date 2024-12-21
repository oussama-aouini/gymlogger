using gymlogger.Dtos.Routine;
using gymlogger.Extensions;
using gymlogger.Interfaces;
using gymlogger.Mappers;
using gymlogger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gymlogger.Controllers
{
    [ApiController]
    [Route("api/routine")]
    public class RoutineController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRoutineRepository _routineRepository;
        private readonly IExerciseRepository _exerciseRepository;

        public RoutineController(UserManager<AppUser> userManager, IRoutineRepository routineRepository, IExerciseRepository exerciseRepository)
        {
            _userManager = userManager;
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoutineExercises([FromRoute] int id)
        {
            var exercises = await _routineRepository.GetRoutineExercicesAsync(id);

            var exerciesDto = exercises.Select(e => e.ToExerciseDto());

            return Ok(exerciesDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRoutines()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var routines = await _routineRepository.GetUserRoutines(appUser.Id);

            return Ok(routines);
        }

        [HttpPost("{routineId}")]
        public async Task<IActionResult> AddExerciseToRoutine([FromRoute] int routineId, [FromBody] AddExerciseToRoutineDto request)
        {
            // test if exercise exists
            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId);

            if (exercise == null)
            {
                return BadRequest("Exercise not found");
            }

            // test if exercise isn't already in the routine 
            var RoutineExercises = await _routineRepository.GetRoutineExercicesAsync(routineId);

            if (RoutineExercises.Any(e => e.Id == request.ExerciseId))
            {
                return BadRequest("Exercise already in routine");
            }
            await _routineRepository.AddExerciseToRoutine(routineId, request.ExerciseId);

            return Created();
        }
    }
}
