using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class CursoQuery
    {
        [Authorize]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Curso>> GetAllCourses([Service] ICursoRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [Authorize]
        public async Task<Curso> GetCourseById([Service] ICursoRepository repository, int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
