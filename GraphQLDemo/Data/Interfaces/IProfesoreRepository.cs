using GraphQLDemo.Data.Entities;

namespace GraphQLDemo.Data.Interfaces
{
    public interface IProfesoreRepository
    {
        Task<Profesore> GetByIdAsync(int id);
        Task<IQueryable<Profesore>> GetAllAsync();
        Task<Profesore> AddAsync(Profesore profesore);
        Task<Profesore> UpdateAsync(Profesore profesore);
        Task<bool> DeleteAsync(int id);
    }
}
