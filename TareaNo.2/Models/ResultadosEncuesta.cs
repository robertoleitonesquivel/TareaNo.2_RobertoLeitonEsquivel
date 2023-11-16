using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TareaNo._2.Models
{
    public class ResultadosEncuesta
    {
        public int Posicion { get; set; }
        public string Nombre { get; set; }
        public decimal Clasificacion { get; set; }
        public decimal DiferenciaPorcentual { get; set; }
        public decimal Codigo { get; set; }
    }


}