using gymlogger.Data;
using gymlogger.Dtos.Exercise;
using gymlogger.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _context.Exercises.ToListAsync();

            var exercisesDto = exercises.Select(e => e.ToExerciseDto());

            return Ok(exercisesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise.ToExerciseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = exerciseDto.ToExerciseFromCreateDto();
            await _context.Exercises.AddAsync(exerciseModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = exerciseModel.Id}, exerciseModel.ToExerciseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            exerciseModel.Name = exerciseDto.Name;
            exerciseModel.Muscles = exerciseDto.Muscles;

            await _context.SaveChangesAsync();
            
            return Ok(exerciseModel.ToExerciseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        { 
            var exerciseModel = await _context.Exercises.FirstOrDefaultAsync(e => e.Id==id);
            
            if (exerciseModel == null)
            {
                return NotFound();
            }

            _context.Remove(exerciseModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
