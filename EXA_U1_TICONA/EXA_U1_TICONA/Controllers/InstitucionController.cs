using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXA_U1_TICONA.Models;

namespace EXA_U1_TICONA.Controllers
{
    public class InstitucionController : Controller
    {
		
        // GET: Institucion
        public ActionResult Index(ClsCarga ObjCarga ,string criterio,string radio)
        {
            if ( criterio == "" || criterio == null) {
                return View(ObjCarga.ListarTablas());
            }
            else {
                if (radio.Equals("Docente"))
                {
                    //docente
                    return View(ObjCarga.ObtenerPorDocente(criterio));
                }
                if (radio.Equals("Curso"))
                {
                    //curso
                    return View(ObjCarga.ObtenerPorCurso(criterio));
                }
                return View();
            }
        }
    }
}