using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using GraphQLDemo.GraphQL.Types;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProfesoreMutation
    {
        [Authorize]
        public async Task<Profesore> AddProfessor([Service] IProfesoreRepository repository, ProfesoreInput input)
        {
            var profesore = new Profesore
            {
                Nombre = input.Nombre,
                Apellido = input.Apellido,
                Email = input.Email,
                Telefono = input.Telefono
            };
            return await repository.AddAsync(profesore);
        }

        [Authorize]
        public async Task<Profesore> UpdateProfessor([Service] IProfesoreRepository repository, int id, ProfesoreInput input)
        {
            var profesore = await repository.GetByIdAsync(id);
            if (profesore == null) return null;

            profesore.Nombre = input.Nombre;
            profesore.Apellido = input.Apellido;
            profesore.Telefono = input.Telefono;
            profesore.Email = input.Email;

            return await repository.UpdateAsync(profesore);
        }

        [Authorize]
        public async Task<bool> DeleteProfessor([Service] IProfesoreRepository repository, int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
