using gymlogger.Data;
using gymlogger.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace gymlogger.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ExerciseController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exercises = _context.Exercises.ToList()
                .Select(e => e.ToExerciseDto());

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var exercise = _context.Exercises.Find(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise.ToExerciseDto());
        }
    }
}
