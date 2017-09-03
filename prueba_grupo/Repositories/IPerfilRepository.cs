using prueba_grupo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_grupo.Repositories
{
    public interface IPerfilRepository
    {
        Perfil Create(Perfil perfil);
        Perfil Read(long Id);
        IQueryable<Perfil> ReadAll();
        void Update(Perfil perfil);
        Perfil Delete(long Id);
    }
}
