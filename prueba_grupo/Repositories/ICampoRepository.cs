using prueba_grupo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_grupo.Repositories
{
    public interface ICampoRepository
    {
        Campo Create(Campo campo);
        Campo Read(long Id);
        IQueryable<Campo> ReadAll();
        void Update(Campo campo);
        Campo Delete(long Id);
    }
}
