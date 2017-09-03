using prueba_grupo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_grupo.Services
{
    public interface IPerfilService
    {
        Perfil Create(Perfil perfil);
        Perfil Read(long id);
        IQueryable<Perfil> ReadAll();
        void Update(Perfil perfil);
        Perfil Delete(long id);
    }
}
