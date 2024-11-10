using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EscuelaDbContext _dbContext;

        public CursoRepository(EscuelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Curso> GetByIdAsync(int id) => await _dbContext.Cursos.FindAsync(id);

        public async Task<IQueryable<Curso>> GetAllAsync()
        {
            var cursos = await _dbContext.Cursos.ToListAsync();
            return cursos.AsQueryable();
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            _dbContext.Cursos.Add(curso);
            await _dbContext.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> UpdateAsync(Curso curso)
        {
            _dbContext.Cursos.Update(curso);
            await _dbContext.SaveChangesAsync();
            return curso;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var curso = await GetByIdAsync(id);
            if (curso == null) return false;
            _dbContext.Cursos.Remove(curso);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
