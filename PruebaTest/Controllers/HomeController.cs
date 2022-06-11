using PruebaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;
using System.Text;
using NPOI.SS.Formula.Functions;
using System.Net;
using Newtonsoft.Json;

namespace PruebaTest.Controllers
{
    public class HomeController : Controller
    {
        public  ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetCatalogos(FiltroRequest _request) 
        {
            var _result = new object();
            var url = Properties.Settings.Default.Url;
            ClienteRest<ResponseData<List<CatalogoResponse>>> cliente = new ClienteRest<ResponseData<List<CatalogoResponse>>>();

            try
            {
                FiltroRequest request = new FiltroRequest()
                {
                    NombreCatalogo ="Marca",
                    Filtro = "2",
                    IdAplication = 1
                };


             

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al consumir el api");
            }

            return Json(_result);

        }
       
    }
}