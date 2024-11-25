using gymlogger.Data;
using gymlogger.Dtos.Session;
using gymlogger.Interfaces;
using gymlogger.Models;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public SessionRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WorkoutSession?> AddSessionAsync(WorkoutSession session)
        {
            await _dbContext.WorkoutSessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return session;
        }

        public async Task<List<WorkoutSession>> GetSessionsAsync(string AppUserId)
        {
            var Sessions = await _dbContext.WorkoutSessions.Where(s => s.AppUserId == AppUserId).ToListAsync();
            return Sessions;
        }

        public async Task<WorkoutSession?> UpdateSessionAsync(int sessionId, UpdateSessionRequestDto sessionDto)
        {
            var sessionModel = await _dbContext.WorkoutSessions.FirstOrDefaultAsync(s => s.Id == sessionId);

            if (sessionModel == null)
            {
                return null;
            }

            sessionModel.EndTime = sessionDto.EndTime;

            await _dbContext.SaveChangesAsync();

            return sessionModel;
        }
    }
}
