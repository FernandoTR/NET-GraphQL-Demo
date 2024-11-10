using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProfesoreQuery
    {
        [Authorize]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Profesore>> GetAllProfessors([Service] IProfesoreRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [Authorize]
        public async Task<Profesore> GetProfessorById([Service] IProfesoreRepository repository, int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
