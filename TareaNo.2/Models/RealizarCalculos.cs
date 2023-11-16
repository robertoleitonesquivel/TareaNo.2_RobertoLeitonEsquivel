using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TareaNo._2.Models
{
    public class RealizarCalculos
    {
        public List<ResultadosEncuesta> Calcular(List<Encuesta> encuestas)
        {
            if (encuestas == null || encuestas.Count == 0)
            {
                return new List<ResultadosEncuesta> { };
            }

            List<ResultadosEncuesta> resultadosEncuestas = new List<ResultadosEncuesta>();

            var lenguajes = GetLenguajes();
            var totalPuntos = encuestas.Sum(x => (x.LenguajeProgramacionPrimario + x.LenguajeProgramacionSecundario));

            //se agrupa
            encuestas.ForEach(enc =>
            {
                var lenguajePrimario = lenguajes.FirstOrDefault(x => x.Id == enc.CodigoLenguajePrimario);
                var lenguajeSecundario = lenguajes.FirstOrDefault(x => x.Id == enc.CodigoLenguajeSecundario);

                if (!resultadosEncuestas.Exists(x => x.Codigo == lenguajeSecundario.Id || x.Codigo == lenguajePrimario.Id))
                {

                    if (lenguajePrimario.Id == lenguajeSecundario.Id)
                    {
                        resultadosEncuestas.Add(new ResultadosEncuesta()
                        {
                            Posicion = 0,
                            Nombre = lenguajePrimario.Name,
                            Clasificacion = 0.0m,
                            DiferenciaPorcentual = 0.0m,
                            Codigo = lenguajePrimario.Id
                        });
                    }
                    else
                    {
                        resultadosEncuestas.Add(new ResultadosEncuesta()
                        {
                            Posicion = 0,
                            Nombre = lenguajePrimario.Name,
                            Clasificacion = 0.0m,
                            DiferenciaPorcentual = 0.0m,
                            Codigo = lenguajePrimario.Id
                        });

                        resultadosEncuestas.Add(new ResultadosEncuesta()
                        {
                            Posicion = 0,
                            Nombre = lenguajeSecundario.Name,
                            Clasificacion = 0.0m,
                            DiferenciaPorcentual = 0.0m,
                            Codigo = lenguajeSecundario.Id
                        });
                    }
                }

            });

            //Se calcula
          
            foreach (var item in resultadosEncuestas)
            {
                var SumPrimario = encuestas.Where(x => x.CodigoLenguajePrimario == item.Codigo).Sum(x => x.LenguajeProgramacionPrimario);
                var SumSecundario = encuestas.Where(x => x.CodigoLenguajeSecundario == item.Codigo).Sum(x => x.LenguajeProgramacionSecundario);
                item.Clasificacion = ((SumPrimario + SumSecundario) / totalPuntos) * 100;
             
            }

            resultadosEncuestas = resultadosEncuestas.OrderByDescending(x=>x.Clasificacion).ToList();

           
            for (int i = 0; i < resultadosEncuestas.Count; i++)
            {
                resultadosEncuestas[i].Posicion = i + 1;

                if (i > 0)
                {
                    resultadosEncuestas[i].DiferenciaPorcentual = resultadosEncuestas[i - 1].Clasificacion - resultadosEncuestas[i].Clasificacion;
                }
            }

            return resultadosEncuestas;
        }


        public List<LenguajesProgramacion> GetLenguajes()
        {
            return new List<LenguajesProgramacion>
            {
                new LenguajesProgramacion { Id = 1, Name = "C#" },
                new LenguajesProgramacion { Id = 2, Name = "Java" },
                new LenguajesProgramacion { Id = 3, Name = "Python" },
                new LenguajesProgramacion { Id = 4, Name = "JavaScript" },
                new LenguajesProgramacion { Id = 5, Name = "TypeScript" },
                new LenguajesProgramacion { Id = 6, Name = "Ruby" },
                new LenguajesProgramacion { Id = 7, Name = "Go" },
                new LenguajesProgramacion { Id = 8, Name = "Swift" },
                new LenguajesProgramacion { Id = 9, Name = "Kotlin" },
                new LenguajesProgramacion { Id = 10, Name = "Rust" },
                new LenguajesProgramacion { Id = 11, Name = "PHP" },
                new LenguajesProgramacion { Id = 12, Name = "C++" },
                new LenguajesProgramacion { Id = 13, Name = "C" },
                new LenguajesProgramacion { Id = 14, Name = "Objective-C" },
                new LenguajesProgramacion { Id = 15, Name = "Scala" },
                new LenguajesProgramacion { Id = 16, Name = "R" },
                new LenguajesProgramacion { Id = 17, Name = "Perl" },
                new LenguajesProgramacion { Id = 18, Name = "Haskell" },
                new LenguajesProgramacion { Id = 19, Name = "Shell" },
                new LenguajesProgramacion { Id = 20, Name = "Dart" },
            };
        }

    }
}