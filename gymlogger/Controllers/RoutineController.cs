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

        public RoutineController(UserManager<AppUser> userManager, IRoutineRepository routineRepository)
        {
            _userManager = userManager;
            _routineRepository = routineRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoutineExercises([FromRoute] int id)
        {
            var exercises = await _routineRepository.GetRoutineExercices(id);

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
    }
}
