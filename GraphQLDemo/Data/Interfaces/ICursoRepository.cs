using GraphQLDemo.Data.Entities;

namespace GraphQLDemo.Data.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> GetByIdAsync(int id);
        Task<IQueryable<Curso>> GetAllAsync();
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<bool> DeleteAsync(int id);
    }
}
