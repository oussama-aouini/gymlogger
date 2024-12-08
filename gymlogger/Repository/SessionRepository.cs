using gymlogger.Data;
using gymlogger.Dtos.Session;
using gymlogger.Helpers;
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

        public async Task<List<Session>> GetSessionsAsync(string AppUserId, GetUserSessionsQueryObject query)
        {
            var Sessions = _dbContext.Sessions.Include(s => s.Sets).Where(s => s.AppUserId == AppUserId).AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("StartTime", StringComparison.OrdinalIgnoreCase))
                {
                    Sessions = query.IsDecsending ? Sessions.OrderByDescending(s => s.StartTime) : Sessions.OrderBy(s => s.StartTime);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await Sessions.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<bool> SessionExists(int id)
        {
            return await _dbContext.Sessions.AnyAsync(s => s.Id == id);
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
