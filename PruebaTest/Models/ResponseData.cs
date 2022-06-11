using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTest.Models
{
    public class ResponseData<T>
    {
        public ResponseData() { }
        public RespuestaSimple Respuesta { get; set; }
        public T Datos { get; set; }
    }
}