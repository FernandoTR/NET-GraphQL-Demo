using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Repositories
{
    public class ProfesoreRepository :IProfesoreRepository
    {
        private readonly EscuelaDbContext _dbContext;

        public ProfesoreRepository(EscuelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profesore> GetByIdAsync(int id) => await _dbContext.Profesores.FindAsync(id);

        public async Task<IQueryable<Profesore>> GetAllAsync()
        {
            var profesores = await _dbContext.Profesores.ToListAsync();
            return profesores.AsQueryable();
        }

        public async Task<Profesore> AddAsync(Profesore profesore)
        {
            _dbContext.Profesores.Add(profesore);
            await _dbContext.SaveChangesAsync();
            return profesore;
        }

        public async Task<Profesore> UpdateAsync(Profesore profesore)
        {
            _dbContext.Profesores.Update(profesore);
            await _dbContext.SaveChangesAsync();
            return profesore;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profesore = await GetByIdAsync(id);
            if (profesore == null) return false;
            _dbContext.Profesores.Remove(profesore);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
