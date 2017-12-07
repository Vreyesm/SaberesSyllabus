using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaberesySoluciones.Models;

namespace SaberesSyllabus.Models
{
    public class Saber
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public EnumLogros Logro { get; set; }
        public EnumEstado Estado { get; set; }
        public int PorcentajeLogro { get; set; }
    }
}