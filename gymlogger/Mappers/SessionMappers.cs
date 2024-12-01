using gymlogger.Dtos.Session;
using gymlogger.Models;

namespace gymlogger.Mappers
{
    public static class SessionMappers
    {
        public static SessionDto ToSessionDto(this Session session) => new SessionDto
        {
            Id = session.Id,
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            Sets = session.Sets.Select(s => s.ToSetDto()).ToList(),
        };
    }
}
