using prueba_grupo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_grupo.Services
{
    public interface ITareaService
    {
        Tarea Create(Tarea tarea);
        Tarea Read(long id);
        IQueryable<Tarea> ReadAll();
        void Update(Tarea tarea);
        Tarea Delete(long id);
    }
}
