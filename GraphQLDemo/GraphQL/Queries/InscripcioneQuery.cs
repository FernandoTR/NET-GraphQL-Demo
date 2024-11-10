using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class InscripcioneQuery
    {
        [Authorize]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Inscripcione>> GetAllInscriptions([Service] IInscripcioneRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [Authorize]
        public async Task<Inscripcione> GetInscriptionById([Service] IInscripcioneRepository repository, int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
