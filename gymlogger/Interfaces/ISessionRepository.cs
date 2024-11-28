using gymlogger.Dtos.Session;
using gymlogger.Models;

namespace gymlogger.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<WorkoutSession>> GetSessionsAsync(string AppUserId);
        Task<WorkoutSession?> AddSessionAsync(string AppUserId);
        Task<WorkoutSession?> UpdateSessionAsync(int sessionId, UpdateSessionRequestDto sessionDto);
    }
}
