using gymlogger.Data;
using gymlogger.Dtos.Exercise;
using gymlogger.Interfaces;
using gymlogger.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace gymlogger.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseRepository.GetAllAsync();

            var exercisesDto = exercises.Select(e => e.ToExerciseDto());

            return Ok(exercisesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);

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
            await _exerciseRepository.CreateAsync(exerciseModel);
            return CreatedAtAction(nameof(GetById), new {id = exerciseModel.Id}, exerciseModel.ToExerciseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateExerciseRequestDto exerciseDto)
        {
            var exerciseModel = await _exerciseRepository.UpdateAsync(id, exerciseDto);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            return Ok(exerciseModel.ToExerciseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        { 
            var exerciseModel = await _exerciseRepository.DeleteAsync(id);
            
            if (exerciseModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
