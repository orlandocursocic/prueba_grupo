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

    public class CamposController : ApiController
    {
        private ICampoService campoService;

        public CamposController(ICampoService campoService)
        {
            this.campoService = campoService;
        }

        // GET: api/Campos
        public IQueryable<Campo> GetCampos()
        {
            return campoService.ReadAll();
        }

        // GET: api/Campos/5
        [ResponseType(typeof(Campo))]
        public IHttpActionResult GetCampo(long id)
        {
            Campo campo = campoService.Read(id);
            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }

        // PUT: api/Campos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampo(long id, Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campo.Id)
            {
                return BadRequest();
            }

            try
            {
                campoService.Update(campo);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Campos
        [ResponseType(typeof(Campo))]
        public IHttpActionResult PostCampo(Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            campo = campoService.Create(campo);

            return CreatedAtRoute("DefaultApi", new { id = campo.Id }, campo);
        }

        // DELETE: api/Campos/5
        [ResponseType(typeof(Campo))]
        public IHttpActionResult DeleteCampo(long id)
        {
            Campo campo;
            try
            {
                campo = campoService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(campo);
        }
    }
}