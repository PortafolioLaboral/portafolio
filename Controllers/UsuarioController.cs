using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using DataAccesLayer;

namespace WebApiExamen.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuarios> Get()
        {
            using (PracticaEntities db = new PracticaEntities())
            {
                return db.Usuarios.ToList();
            }

        }


        // POST: api/Usuario
        public HttpResponseMessage Post([FromBody]Usuarios value)
        {
            // Declaramos una varible para nuestra respuesta 
            int resp = 0;

            //Creamos nustra varibale para el http Mesagge
            HttpResponseMessage mdg = null;
            //creamos nuestro metodo try para controllar las exceptiones
            try
            {
                //Abrimos la Conexion
                using (PracticaEntities entities = new PracticaEntities())
                {
                    //enviamos la peticion
                    entities.Entry(value).State = EntityState.Added;
                    resp = entities.SaveChanges();
                    mdg=Request.CreateResponse(HttpStatusCode.OK, resp);  
                }
            }
            catch(Exception ex )
            {
                mdg=Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return mdg;


        }

        // PUT: api/Usuario/5
        public HttpResponseMessage Put([FromBody] Usuarios value)
        {
            // Declaramos una varible para nuestra respuesta 
            int resp = 0;

            //Creamos nustra varibale para el http Mesagge
            HttpResponseMessage mdg = null;
            try { 
            using (PracticaEntities entities = new PracticaEntities())
            {
                //enviamos la peticion
                entities.Entry(value).State = EntityState.Modified;
                resp = entities.SaveChanges();
                mdg = Request.CreateResponse(HttpStatusCode.OK, resp);
            }
        }
            catch(Exception ex )
            {
                mdg=Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return mdg;
        }

        // DELETE: api/Usuario/5
        public HttpResponseMessage Delete([FromBody] Usuarios value)
        {
            int resp = 0;
            HttpResponseMessage mdg = null;
            try
            {
                using (PracticaEntities entities = new PracticaEntities())
                {
                    //enviamos la peticion
                    entities.Entry(value).State = EntityState.Deleted;
                    resp = entities.SaveChanges();
                    mdg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                mdg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return mdg;
        }
    }
}

