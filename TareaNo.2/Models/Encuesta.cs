using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TareaNo._2.Models
{
    public class Encuesta
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public int CodigoLenguajePrimario { get; set; }
        [Required]
        public int CodigoLenguajeSecundario { get; set; }
        [Required]
        public decimal LenguajeProgramacionPrimario { get; set; } = 1;
        [Required]
        public decimal LenguajeProgramacionSecundario { get; set; } = 0.5m;
    }
}