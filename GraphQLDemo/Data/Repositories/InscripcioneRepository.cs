using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Repositories
{
    public class InscripcioneRepository : IInscripcioneRepository
    {
        private readonly EscuelaDbContext _dbContext;

        public InscripcioneRepository(EscuelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Inscripcione> GetByIdAsync(int id) => await _dbContext.Inscripciones.FindAsync(id);

        public async Task<IQueryable<Inscripcione>> GetAllAsync()
        {
            var inscripciones = await _dbContext.Inscripciones.ToListAsync();
            return inscripciones.AsQueryable();
        }

        public async Task<Inscripcione> AddAsync(Inscripcione inscripcione)
        {
            _dbContext.Inscripciones.Add(inscripcione);
            await _dbContext.SaveChangesAsync();
            return inscripcione;
        }

        public async Task<Inscripcione> UpdateAsync(Inscripcione inscripcione)
        {
            _dbContext.Inscripciones.Update(inscripcione);
            await _dbContext.SaveChangesAsync();
            return inscripcione;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inscripcione = await GetByIdAsync(id);
            if (inscripcione == null) return false;
            _dbContext.Inscripciones.Remove(inscripcione);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
