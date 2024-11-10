using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using GraphQLDemo.GraphQL.Types;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class InscripcioneMutation
    {
        [Authorize]
        public async Task<Inscripcione> AddInscription([Service] IInscripcioneRepository repository, InscripcioneInput input)
        {
            var inscripcione = new Inscripcione
            {
                AlumnoId = input.AlumnoId,
                CursoId = input.CursoId,
                FechaInscripcion = input.FechaInscripcion
            };
            return await repository.AddAsync(inscripcione);
        }

        [Authorize]
        public async Task<Inscripcione> UpdateInscription([Service] IInscripcioneRepository repository, int id, InscripcioneInput input)
        {
            var inscripcione = await repository.GetByIdAsync(id);
            if (inscripcione == null) return null;

            inscripcione.AlumnoId = input.AlumnoId;
            inscripcione.CursoId = input.CursoId;
            inscripcione.FechaInscripcion = input.FechaInscripcion;
            return await repository.UpdateAsync(inscripcione);
        }

        [Authorize]
        public async Task<bool> DeleteInscription([Service] IInscripcioneRepository repository, int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
