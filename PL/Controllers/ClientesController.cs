using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult GetAll()
        {
            return View();
        }
        public JsonResult Get()
        {
            ENT.Result result = BLL.Clientes.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetId(int IdClientes)
        {
            ENT.Clientes clientes = new ENT.Clientes();
            clientes.IdClientes = IdClientes;
            ENT.Result result = BLL.Clientes.GetById(clientes);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ENT.Clientes clientes)
        {
            ENT.Result result = BLL.Clientes.Add(clientes);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ENT.Clientes clientes)
        {
            ENT.Result result = BLL.Clientes.Update(clientes);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int IdClientes)
        {
            ENT.Result result = BLL.Clientes.Delete(IdClientes);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
