using gymlogger.Interfaces;
using gymlogger.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace gymlogger.Controllers
{
    [Route("/api/set")]
    [ApiController]
    public class SetController : ControllerBase
    {
        private readonly ISetRepository _setRepository;
        public SetController(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }

        [HttpGet("{usedId}/session/{sessionId}")]
        public async Task<IActionResult> GetSessionSets([FromRoute] string usedId, [FromRoute] int sessionId)
        {
            var sets = await _setRepository.GetSetsBySessionIdAsync(usedId, sessionId);

            if (sets == null)
            {
                return NotFound();
            }

            var setsDto = sets.Select(set => set.ToSetDto());

            return Ok(setsDto);
        }

        [HttpGet("{usedId}/exercise/{exerciseId}")]
        public async Task<IActionResult> GetExerciseSets([FromRoute] string usedId, [FromRoute] int exerciseId)
        {
            var sets = await _setRepository.GetSetsByExerciseIdAsync(usedId, exerciseId);

            if (sets == null)
            {
                return NotFound();
            }

            var setsDto = sets.Select(set => set.ToSetDto());

            return Ok(setsDto);
        }
    }
}
