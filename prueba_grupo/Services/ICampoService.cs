using prueba_grupo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_grupo.Services
{
    public interface ICampoService
    {
        Campo Create(Campo campo);
        Campo Read(long id);
        IQueryable<Campo> ReadAll();
        void Update(Campo campo);
        Campo Delete(long id);
    }
}
