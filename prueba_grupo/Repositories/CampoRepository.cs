using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Exceptions;
using System.Data.Entity;

namespace prueba_grupo.Repositories
{
    public class CampoRepository : ICampoRepository
    {
        public Campo Create(Campo campo)
        {
            return ApplicationDbContext.applicationDbContext.Campos.Add(campo);
        }

        public Campo Delete(long Id)
        {
            Campo campo = ApplicationDbContext.applicationDbContext.Campos.Find(Id);
            if (campo == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Campos.Remove(campo);
            return campo;
        }

        public Campo Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Campos.Find(Id);
        }

        public IQueryable<Campo> ReadAll()
        {
            IList<Campo> lista = new List<Campo>(ApplicationDbContext.applicationDbContext.Campos);

            return lista.AsQueryable();
        }

        public void Update(Campo campo)
        {
            if (ApplicationDbContext.applicationDbContext.Campos.Count(c => c.Id == campo.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(campo).State = EntityState.Modified;
        }
    }
}