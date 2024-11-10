using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using GraphQLDemo.GraphQL.Types;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]

    public class CursoMutation
    {
        [Authorize]
        public async Task<Curso> AddCourse([Service] ICursoRepository repository, CursoInput input)
        {
            var curso = new Curso
            {
                NombreCurso = input.NombreCurso,
                Descripcion = input.Descripcion
            };
            return await repository.AddAsync(curso);
        }

        [Authorize]
        public async Task<Curso> UpdateCourse([Service] ICursoRepository repository, int id, CursoInput input)
        {
            var curso = await repository.GetByIdAsync(id);
            if (curso == null) return null;

            curso.NombreCurso = input.NombreCurso;
            curso.Descripcion = input.Descripcion;
            return await repository.UpdateAsync(curso);
        }

        [Authorize]
        public async Task<bool> DeleteCourse([Service] ICursoRepository repository, int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
