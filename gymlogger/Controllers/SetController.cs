using gymlogger.Dtos.Set;
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
        private readonly ISessionRepository _sessionRepository;
        public SetController(ISetRepository setRepository, ISessionRepository sessionRepository)
        {
            _setRepository = setRepository;
            _sessionRepository = sessionRepository;
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
            

        [HttpPost]
        public async Task<IActionResult> Create(CreateSetDto createSetDto)
        {
            if(!await _sessionRepository.SessionExists(createSetDto.SessionId))
            {
                return BadRequest("Session not found");
            }

            var setModel = createSetDto.ToSetFromCreate();

            var set = await _setRepository.AddAsync(setModel);

            return Ok(set.ToSetDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateSetRequestDto updateSetDto)
        {
            var set = await _setRepository.UpdateAsync(id, updateSetDto.ToSetFromUpdate());
            
            if (set == null)
            {
                return NotFound("Set not found");
            }

            return Ok(set.ToSetDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var set = await _setRepository.DeleteAsync(id);

            if (set == null)
            {
                return NotFound("Set not found");
            }

            return Ok(set);
        }
    }
}
