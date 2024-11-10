using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using GraphQLDemo.GraphQL.Types;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class AlumnoMutation
    {
        [Authorize]
        public async Task<Alumno> AddStudent([Service] IAlumnoRepository repository, AlumnoInput input)
        {
            var alumno = new Alumno { 
                Nombre = input.Nombre, 
                Apellido = input.Apellido, 
                FechaNacimiento = input.FechaNacimiento ,
                Direccion = input.Direccion,
                Telefono = input.Telefono,
                Email = input.Email
            };
            return await repository.AddAsync(alumno);
        }

        [Authorize]
        public async Task<Alumno> UpdateStudent([Service] IAlumnoRepository repository, int id, AlumnoInput input)
        {
            var alumno = await repository.GetByIdAsync(id);
            if (alumno == null) return null;

            alumno.Nombre = input.Nombre;
            alumno.Apellido = input.Apellido;
            alumno.FechaNacimiento = input.FechaNacimiento;
            alumno.Direccion = input.Direccion;
            alumno.Telefono = input.Telefono;
            alumno.Email = input.Email;

            return await repository.UpdateAsync(alumno);
        }

        [Authorize]
        public async Task<bool> DeleteStudent([Service] IAlumnoRepository repository, int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
