using gymlogger.Dtos.Session;
using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<Session>> GetSessionsAsync(string AppUserId);
        Task<Session?> AddSessionAsync(string AppUserId);
        Task<Session?> UpdateSessionAsync(int sessionId, UpdateSessionRequestDto sessionDto);
    }
}
