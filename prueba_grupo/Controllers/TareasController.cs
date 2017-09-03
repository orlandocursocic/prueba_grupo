using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using prueba_grupo.Models;
using System.Web.Http.Cors;
using prueba_grupo.Services;
using prueba_grupo.Exceptions;

namespace prueba_grupo.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]

    public class TareasController : ApiController
    {
        private ITareaService tareaService;

        public TareasController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        // GET: api/Tareas
        public IQueryable<Tarea> GetTareas()
        {
            return tareaService.ReadAll();
        }

        // GET: api/Tareas/5
        [ResponseType(typeof(Tarea))]
        public IHttpActionResult GetTarea(long id)
        {
            Tarea tarea = tareaService.Read(id);
            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        // PUT: api/Tareas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarea(long id, Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarea.Id)
            {
                return BadRequest();
            }

            try
            {
                tareaService.Update(tarea);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tareas
        [ResponseType(typeof(Tarea))]
        public IHttpActionResult PostTarea(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tarea = tareaService.Create(tarea);

            return CreatedAtRoute("DefaultApi", new { id = tarea.Id }, tarea);
        }

        // DELETE: api/Tareas/5
        [ResponseType(typeof(Tarea))]
        public IHttpActionResult DeleteTarea(long id)
        {
            Tarea tarea;
            try
            {
                tarea = tareaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(tarea);
        }
    }
}