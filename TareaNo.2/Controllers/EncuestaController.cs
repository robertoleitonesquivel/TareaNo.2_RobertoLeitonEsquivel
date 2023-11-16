using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TareaNo._2.Models;

namespace TareaNo._2.Controllers
{
    public class EncuestaController : Controller
    {

        RealizarCalculos realizarCalculos = new RealizarCalculos();

        [HttpGet]
        public ActionResult Index()
        {

            List<Encuesta> encuestas = Session["Encuesta"] as List<Encuesta>;

            var result = realizarCalculos.Calcular(encuestas);

            return View(result);
        }

        [HttpGet]
        public ActionResult Encuesta()
        {
            ViewBag.Paises = GetPaises();
            ViewBag.Lenguajes = GetLenguajes();
            ViewBag.Roles = GetRoles();

            return View(new Encuesta());
        }

        [HttpPost]
        public ActionResult Add(Encuesta encuesta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Encuesta> encuestas = Session["Encuesta"] as List<Encuesta>;

                    if (encuestas == null)
                    {
                        encuestas = new List<Encuesta>();
                    }

                    encuestas.Add(encuesta);

                    Session["Encuesta"] = encuestas;

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Encuesta");
                }
               
            }
            catch (Exception)
            {

                return RedirectToAction("Encuesta");
            }
        }

        private SelectList GetPaises()
        {
            List<Paises> pais = new List<Paises>
            {
                new Paises { Id = 1, Pais = "Argentina" },
                new Paises { Id = 2, Pais = "Brasil" },
                new Paises { Id = 3, Pais = "Canadá" },
                new Paises { Id = 4, Pais = "Estados Unidos" },
                new Paises { Id = 5, Pais = "México" },
                new Paises { Id = 6, Pais = "Chile" },
                new Paises { Id = 7, Pais = "Colombia" },
                new Paises { Id = 8, Pais = "Perú" },
                new Paises { Id = 9, Pais = "Venezuela" },
                new Paises { Id = 10, Pais = "Ecuador" },
                new Paises { Id = 11, Pais = "Bolivia" },
                new Paises { Id = 12, Pais = "Paraguay" },
                new Paises { Id = 13, Pais = "Uruguay" },
                new Paises { Id = 14, Pais = "Panamá" },
                new Paises { Id = 15, Pais = "Costa Rica" },
                new Paises { Id = 16, Pais = "Nicaragua" },
                new Paises { Id = 17, Pais = "Honduras" },
                new Paises { Id = 18, Pais = "El Salvador" },
                new Paises { Id = 19, Pais = "Guatemala" },
                new Paises { Id = 20, Pais = "Cuba" }
            };

            return new SelectList(pais, "Pais", "Pais");
        }

        private SelectList GetLenguajes()
        {
            List<LenguajesProgramacion> lenguajesProgramacions = realizarCalculos.GetLenguajes();

            return new SelectList(lenguajesProgramacions, "Id", "Name");
        }

        private SelectList GetRoles()
        {
            List<Roles> roles = new List<Roles>
            {
                new Roles{Rol = "Programador Front-end"},
                new Roles{Rol = "Programador Back-end"},
                new Roles{Rol = "Analista de sistemas"},
                new Roles{Rol = "Diseñador gráfico"},
                new Roles{Rol = "Administrador de proyectos de TI"}
            };

            return new SelectList(roles, "Rol", "Rol");
        }
    }

}