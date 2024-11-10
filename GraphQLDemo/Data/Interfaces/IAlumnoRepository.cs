using GraphQLDemo.Data.Entities;

namespace GraphQLDemo.Data.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<Alumno> GetByIdAsync(int id);
        Task<IQueryable<Alumno>> GetAllAsync();
        Task<Alumno> AddAsync(Alumno alumno);
        Task<Alumno> UpdateAsync(Alumno alumno);
        Task<bool> DeleteAsync(int id);
    }
}
