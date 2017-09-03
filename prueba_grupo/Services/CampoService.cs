using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_grupo.Models;
using prueba_grupo.Repositories;

namespace prueba_grupo.Services
{
    public class CampoService : ICampoService
    {
        private ICampoRepository campoRepository;

        public CampoService(ICampoRepository campoRepository)
        {
            this.campoRepository = campoRepository;
        }

        public Campo Create(Campo campo)
        {
            return campoRepository.Create(campo);
        }

        public Campo Delete(long id)
        {
            return campoRepository.Delete(id);
        }

        public Campo Read(long id)
        {
            return campoRepository.Read(id);
        }

        public IQueryable<Campo> ReadAll()
        {
            return campoRepository.ReadAll();
        }

        public void Update(Campo campo)
        {
            campoRepository.Update(campo);
        }
    }
}