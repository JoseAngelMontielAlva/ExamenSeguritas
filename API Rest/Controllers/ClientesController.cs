using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Rest.Controllers
{
    public class ClientesController : ApiController
    {
        // GET api/clientes
        [HttpGet]
        [Route("api/Clientes/GetAll")]
        public IHttpActionResult GetAll()
        {

            ENT.Clientes clientes = new ENT.Clientes();
            ENT.Result result = BLL.Clientes.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [HttpGet]
        [Route("api/Clientes/GetById/{IdClientes}")]
        public IHttpActionResult GetById(int IdClientes)
        {
            ENT.Clientes clientes = new ENT.Clientes();
            clientes.IdClientes = IdClientes;
            ENT.Result result = BLL.Clientes.GetById(clientes);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [HttpPost]
        [Route("api/Clientes/Add")]
        public IHttpActionResult Add([FromBody] ENT.Clientes clientes)
        {

            ENT.Result result = BLL.Clientes.Add(clientes);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Clientes/Update/{IdClientes}")]
        public IHttpActionResult Put(int IdClientes, [FromBody]ENT.Clientes clientes)
        {
            clientes.IdClientes = IdClientes;
            var result =BLL.Clientes.Update(clientes);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [HttpGet]
        [Route("api/Clientes/Delete/{IdClientes}")]
        public IHttpActionResult Delete(int IdClientes)
        {
            //ENT.Clientes clientes = new ENT.Clientes();
            //clientes.IdClientes = IdClientes;
            var result = BLL.Clientes.Delete(IdClientes);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
