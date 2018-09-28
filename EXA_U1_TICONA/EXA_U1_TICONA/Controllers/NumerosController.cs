using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXA_U1_TICONA.Models;

namespace EXA_U1_TICONA.Controllers
{
    public class NumerosController : Controller
    {
        // GET: Numeros
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OperacionNumeros(ClsNumeros ObjNumeros)
        {
            ObjNumeros.Lnumero = new List<int>();
            string num = Convert.ToString(ObjNumeros.numero);
            string sumatoria="";
            int countL = 1;
            int itemA = 0;
            foreach (int item in num)
            {
                if (item == 0)
                {
                    break;
                }
                else {
                    if (num.ToArray().Count() > countL)
                    {
                        itemA = item - 48;
                        sumatoria += item - 48 + " + ";
                    }
                    else
                    {
                        itemA = item - 48;
                        sumatoria += item - 48 + " = ";
                    }
                    itemA = 0;
                    countL++;
                    ObjNumeros.Lnumero.Add(item - 48);
                }
            }

            ViewBag.ResultadoP = sumatoria;
            ViewBag.ResultadoT = ObjNumeros.Lnumero.Sum();
            return View();
        }
    }
}