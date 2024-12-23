using gymlogger.Dtos.Exercise;
using gymlogger.Helpers;
using gymlogger.Interfaces;
using gymlogger.Mappers;
using Microsoft.AspNetCore.Authorization;
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

        // The methods inside a controller are named Action methods 

        // With IActionResult we can return any type 
        // With ActionResult / ActionResult<T> we enforce the type T we return 
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetExercisesQueryObject query)
        {
            var exercises = await _exerciseRepository.GetAllAsync(query);

            var exercisesDto = exercises.Select(e => e.ToExerciseDto());

            return Ok(exercisesDto);
        }

        [HttpGet("{id:int}")]
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exerciseModel = exerciseDto.ToExerciseFromCreateDto();
            await _exerciseRepository.CreateAsync(exerciseModel);
            return CreatedAtAction(nameof(GetById), new {id = exerciseModel.Id}, exerciseModel.ToExerciseDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateExerciseRequestDto exerciseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exerciseModel = await _exerciseRepository.UpdateAsync(id, exerciseDto);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            return Ok(exerciseModel.ToExerciseDto());
        }

        [HttpDelete("{id:int}")]
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
