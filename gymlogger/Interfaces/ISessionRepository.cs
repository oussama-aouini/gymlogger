using gymlogger.Dtos.Session;
using gymlogger.Helpers;
using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<Session>> GetSessionsAsync(string AppUserId, GetUserSessionsQueryObject query);
        Task<Session?> AddSessionAsync(string AppUserId);
        Task<Session?> UpdateSessionAsync(int sessionId, UpdateSessionRequestDto sessionDto);
        Task<bool> SessionExists(int id);
    }
}
