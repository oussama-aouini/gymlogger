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

        public async Task<Session?> AddSessionAsync(string AppUserId)
        {
            var sessionModel = new Session { AppUserId = AppUserId };
            await _dbContext.Sessions.AddAsync(sessionModel);
            await _dbContext.SaveChangesAsync();
            return sessionModel;
        }

        public async Task<List<Session>> GetSessionsAsync(string AppUserId)
        {
            var Sessions = await _dbContext.Sessions.Where(s => s.AppUserId == AppUserId).ToListAsync();
            return Sessions;
        }

        public async Task<Session?> UpdateSessionAsync(int sessionId, UpdateSessionRequestDto sessionDto)
        {
            var sessionModel = await _dbContext.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId);

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
