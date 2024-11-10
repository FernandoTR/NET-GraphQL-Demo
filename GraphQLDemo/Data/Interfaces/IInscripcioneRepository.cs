using GraphQLDemo.Data.Entities;

namespace GraphQLDemo.Data.Interfaces
{
    public interface IInscripcioneRepository
    {
        Task<Inscripcione> GetByIdAsync(int id);
        Task<IQueryable<Inscripcione>> GetAllAsync();
        Task<Inscripcione> AddAsync(Inscripcione inscripcione);
        Task<Inscripcione> UpdateAsync(Inscripcione inscripcione);
        Task<bool> DeleteAsync(int id);
    }
}
