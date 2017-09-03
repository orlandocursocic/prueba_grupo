using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Repositories;

namespace prueba_grupo.Services
{
    public class TareaService : ITareaService
    {
        private ITareaRepository tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            this.tareaRepository = tareaRepository;
        }

        public Tarea Create(Tarea tarea)
        {
            return tareaRepository.Create(tarea);
        }

        public Tarea Delete(long id)
        {
            return tareaRepository.Delete(id);
        }

        public Tarea Read(long id)
        {
            return tareaRepository.Read(id);
        }

        public IQueryable<Tarea> ReadAll()
        {
            return tareaRepository.ReadAll();
        }

        public void Update(Tarea tarea)
        {
            tareaRepository.Update(tarea);
        }
    }
}