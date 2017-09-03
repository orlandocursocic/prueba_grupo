using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Exceptions;
using System.Data.Entity;

namespace prueba_grupo.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        public Tarea Create(Tarea tarea)
        {
            return ApplicationDbContext.applicationDbContext.Tareas.Add(tarea);
        }

        public Tarea Delete(long Id)
        {
            Tarea tarea = ApplicationDbContext.applicationDbContext.Tareas.Find(Id);
            if (tarea == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Tareas.Remove(tarea);
            return tarea;
        }

        public Tarea Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Tareas.Find(Id);
        }

        public IQueryable<Tarea> ReadAll()
        {
            IList<Tarea> lista = new List<Tarea>(ApplicationDbContext.applicationDbContext.Tareas);

            return lista.AsQueryable();

        }

        public void Update(Tarea tarea)
        {
            if (ApplicationDbContext.applicationDbContext.Tareas.Count(t => t.Id == tarea.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(tarea).State = EntityState.Modified;
        }
    }
}