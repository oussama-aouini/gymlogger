using gymlogger.Dtos.Session;
using gymlogger.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gymlogger.Controllers
{
    [Route("/api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSessions([FromRoute] string id)
        {
            var sessions  = await _sessionRepository.GetSessionsAsync(id);

            return Ok(sessions);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateSession([FromRoute] string id)
        {
            var session = await _sessionRepository.AddSessionAsync(id);

            return Ok(session);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateSession([FromRoute] int id, UpdateSessionRequestDto requestDto)
        {
            var session = await _sessionRepository.UpdateSessionAsync(id, requestDto);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }
    }
}
