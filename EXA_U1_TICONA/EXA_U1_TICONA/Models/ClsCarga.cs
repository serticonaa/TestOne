using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Xml.Linq;

namespace EXA_U1_TICONA.Models
{
	public class ClsCarga
	{
		public string id { get; set; }
		public string nombresDocentes { get; set; }
		public string apellidosDocentes { get; set; }
		public string nombreCurso { get; set; }
		public int horasCurso { get; set; }
		public int creditosCurso { get; set; }
		public string codigoCurso { get; set; }
		public string codigoDocente { get; set; }

        //Definir el origen de datos
        //1
        XDocument xmlData1 = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/cursos.xml"));
        //2
        XDocument xmlData2 = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/cargas.xml"));
        //3
        XDocument xmlData3 = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/docentes.xml"));

        public List<ClsCarga> ListarTablas()
		{
            List<ClsCarga> ObjCarga = new List<ClsCarga>();
            ObjCarga = (from d1 in xmlData1.Descendants("curso")
                        join d2 in xmlData2.Descendants("carga") on (d1.Element("codigo").Value) equals (d2.Element("codigoCurso").Value)
                        join d3 in xmlData3.Descendants("docente") on(d2.Element("codigoDocente").Value) equals(d3.Element("codigo").Value)
                        select new ClsCarga()
                       {
                           id = d2.Element("id").Value,
                           nombresDocentes = d3.Element("nombre").Value,
                           apellidosDocentes = d3.Element("apellido").Value,
                           nombreCurso = d1.Element("nombre").Value,
                           horasCurso = Convert.ToInt32(d1.Element("horas").Value),
                           creditosCurso = Convert.ToInt32(d1.Element("creditos").Value)
                       }).ToList();

			//Devuelva los registros
			return ObjCarga;
		}
        public List<ClsCarga> ObtenerPorDocente(string criterio)
        {

            List<ClsCarga> ObjCarga = new List<ClsCarga>();
            ObjCarga = (from d1 in xmlData1.Descendants("curso")
                        join d2 in xmlData2.Descendants("carga") on (d1.Element("codigo").Value) equals (d2.Element("codigoCurso").Value)
                        join d3 in xmlData3.Descendants("docente") on (d2.Element("codigoDocente").Value) equals (d3.Element("codigo").Value)
                        where d3.Element("codigo").Value == (criterio)
                        select new ClsCarga()
                        {
                            id = d2.Element("id").Value,
                            nombresDocentes = d3.Element("nombre").Value,
                            apellidosDocentes = d3.Element("apellido").Value,
                            nombreCurso = d1.Element("nombre").Value,
                            horasCurso = Convert.ToInt32(d1.Element("horas").Value),
                            creditosCurso = Convert.ToInt32(d1.Element("creditos").Value)
                        }).ToList();

            //Devuelva los registros
            return ObjCarga;
        }
        public List<ClsCarga> ObtenerPorCurso(string criterio)
        {
            List<ClsCarga> ObjCarga = new List<ClsCarga>();
            ObjCarga = (from d1 in xmlData1.Descendants("curso")
                        join d2 in xmlData2.Descendants("carga") on (d1.Element("codigo").Value) equals (d2.Element("codigoCurso").Value)
                        join d3 in xmlData3.Descendants("docente") on (d2.Element("codigoDocente").Value) equals (d3.Element("codigo").Value)
                        where d1.Element("codigo").Value == (criterio)
                        select new ClsCarga()
                        {
                            id = d2.Element("id").Value,
                            nombresDocentes = d3.Element("nombre").Value,
                            apellidosDocentes = d3.Element("apellido").Value,
                            nombreCurso = d1.Element("nombre").Value,
                            horasCurso = Convert.ToInt32(d1.Element("horas").Value),
                            creditosCurso = Convert.ToInt32(d1.Element("creditos").Value)
                        }).ToList();

            //Devuelva los registros
            return ObjCarga;
        }
    }
}