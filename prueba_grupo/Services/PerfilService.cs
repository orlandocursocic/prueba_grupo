using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Repositories;

namespace prueba_grupo.Services
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            this.perfilRepository = perfilRepository;
        }

        public Perfil Create(Perfil perfil)
        {
            return perfilRepository.Create(perfil);
        }

        public Perfil Delete(long id)
        {
            return perfilRepository.Delete(id);
        }

        public Perfil Read(long id)
        {
            return perfilRepository.Read(id);
        }

        public IQueryable<Perfil> ReadAll()
        {
            return perfilRepository.ReadAll();
        }

        public void Update(Perfil perfil)
        {
            perfilRepository.Update(perfil);
        }
    }
}