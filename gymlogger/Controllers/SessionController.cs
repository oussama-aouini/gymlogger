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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserSessions([FromRoute] string userId)
        {
            var sessions  = await _sessionRepository.GetSessionsAsync(userId);

            return Ok(sessions);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateSession([FromRoute] string userId)
        {
            var session = await _sessionRepository.AddSessionAsync(userId);

            return Ok(session);
        }

        [HttpPut("{sessionId}")] 
        public async Task<IActionResult> UpdateSession([FromRoute] int sessionId, UpdateSessionRequestDto requestDto)
        {
            var session = await _sessionRepository.UpdateSessionAsync(sessionId, requestDto);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }
    }
}
