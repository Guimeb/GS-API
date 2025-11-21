using GS_csharp.Models;

namespace GS_csharp.Repositories
{
    public interface ICompetenceRepository
    {
        Task<IEnumerable<Competence>> GetAllAsync();
        Task<Competence?> GetByIdAsync(int id);
        Task CreateAsync(Competence competence);
        Task UpdateAsync(Competence competence);
        Task DeleteAsync(int id);
    }
}