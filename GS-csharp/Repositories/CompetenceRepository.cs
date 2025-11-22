using GS_csharp.Data;
using GS_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace GS_csharp.Repositories
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private readonly AppDbContext _context;

        public CompetenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Competence>> GetAllAsync()
        {
            return await _context.Competences.ToListAsync();
        }

        public async Task<Competence?> GetByIdAsync(int id)
        {
            return await _context.Competences.FindAsync(id);
        }

        public async Task CreateAsync(Competence competence)
        {
            await _context.Competences.AddAsync(competence);
        }

        public async Task UpdateAsync(Competence competence)
        {
            _context.Entry(competence).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var competence = await GetByIdAsync(id);
            if (competence != null)
            {
                _context.Competences.Remove(competence);
            }
        }
    }
}