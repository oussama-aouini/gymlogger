using gymlogger.Data;
using gymlogger.Dtos.Exercise;
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

        [HttpPost]
        public IActionResult Create(CreateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = exerciseDto.ToExerciseFromCreateDto();
            _context.Exercises.Add(exerciseModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = exerciseModel.Id}, exerciseModel.ToExerciseDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id ,[FromBody] UpdateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = _context.Exercises.FirstOrDefault(e => e.Id == id);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            exerciseModel.Name = exerciseDto.Name;
            exerciseModel.Muscles = exerciseDto.Muscles;

            _context.SaveChanges();
            
            return Ok(exerciseModel.ToExerciseDto());
        }
    }
}
