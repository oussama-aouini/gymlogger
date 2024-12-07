using gymlogger.Data;
using gymlogger.Interfaces;
using gymlogger.Models;
using Microsoft.EntityFrameworkCore;

namespace gymlogger.Repository
{
    public class SetRepository : ISetRepository
    {
        private readonly ApplicationDBContext _context;
        public SetRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Set> AddAsync(Set set)
        {
            await _context.Sets.AddAsync(set);
            await _context.SaveChangesAsync();
            return set;
        }

        public async Task<Set?> UpdateAsync(int id, Set set)
        {
            var setModel = await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);

            if (setModel == null)
            {
                return null;
            }

            setModel.Repetitions = set.Repetitions;
            setModel.Weight = set.Weight;
            setModel.SetType = set.SetType;

            await _context.SaveChangesAsync();

            return setModel;
        }

        public async Task<List<Set>> GetSetsByExerciseIdAsync(string userId, int exerciseId)
        {
            return await _context.Sets.Where(s => s.ExerciseId == exerciseId && s.AppUser.Id == userId).ToListAsync();
        }

        public async Task<List<Set>> GetSetsBySessionIdAsync(string userId, int SessionId)
        {
            return await _context.Sets.Where(s => s.SessionId == SessionId && s.AppUser.Id == userId).ToListAsync();
        }

        public async Task<Set?> DeleteAsync(int id)
        {
            var set = await _context.Sets.FirstOrDefaultAsync(set => set.Id == id);

            if (set == null)
            {
                return null;
            }

            _context.Sets.Remove(set);
            await _context.SaveChangesAsync();
            return set;
        }
    }
}
