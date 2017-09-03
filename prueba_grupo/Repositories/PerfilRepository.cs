using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Exceptions;
using System.Data.Entity;

namespace prueba_grupo.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        public Perfil Create(Perfil perfil)
        {
            return ApplicationDbContext.applicationDbContext.Perfiles.Add(perfil);
        }

        public Perfil Delete(long Id)
        {
            Perfil perfil = ApplicationDbContext.applicationDbContext.Perfiles.Find(Id);
            if (perfil == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Perfiles.Remove(perfil);
            return perfil;
        }

        public Perfil Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Perfiles.Find(Id);
        }

        public IQueryable<Perfil> ReadAll()
        {
            IList<Perfil> lista = new List<Perfil>(ApplicationDbContext.applicationDbContext.Perfiles);

            return lista.AsQueryable();
        }

        public void Update(Perfil perfil)
        {
            if (ApplicationDbContext.applicationDbContext.Perfiles.Count(p => p.Id == perfil.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(perfil).State = EntityState.Modified;
        }
    }
}