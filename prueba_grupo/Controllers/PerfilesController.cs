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

    public class PerfilesController : ApiController
    {
        private IPerfilService perfilService;

        public PerfilesController(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }

        // GET: api/Perfiles
        public IQueryable<Perfil> GetPerfiles()
        {
            return perfilService.ReadAll();
        }

        // GET: api/Perfiles/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult GetPerfil(long id)
        {
            Perfil perfil = perfilService.Read(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(long id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.Id)
            {
                return BadRequest();
            }

            try
            {
                perfilService.Update(perfil);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Perfiles
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            perfil = perfilService.Create(perfil);

            return CreatedAtRoute("DefaultApi", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfiles/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult DeletePerfil(long id)
        {
            Perfil perfil;
            try
            {
                perfil = perfilService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(perfil);
        }
    }
}