using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQLDemo.Data.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly EscuelaDbContext _dbContext;

        public AlumnoRepository(EscuelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Alumno> GetByIdAsync(int id) => await _dbContext.Alumnos.FindAsync(id);

        public async Task<IQueryable<Alumno>> GetAllAsync()
        {
            var students = await _dbContext.Alumnos.ToListAsync();
            return students.AsQueryable();
        }

        public async Task<Alumno> AddAsync(Alumno alumno)
        {
            _dbContext.Alumnos.Add(alumno);
            await _dbContext.SaveChangesAsync();
            return alumno;
        }

        public async Task<Alumno> UpdateAsync(Alumno alumno)
        {
            _dbContext.Alumnos.Update(alumno);
            await _dbContext.SaveChangesAsync();
            return alumno;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alumno = await GetByIdAsync(id);
            if (alumno == null) return false;
            _dbContext.Alumnos.Remove(alumno);
            await _dbContext.SaveChangesAsync();
            return true;
        }      

       
        
    }
}
