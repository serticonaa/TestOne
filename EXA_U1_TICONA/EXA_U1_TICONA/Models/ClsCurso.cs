using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXA_U1_TICONA.Models
{
	public class ClsCurso
	{
		public string codigo { get; set; }
		public string nombre { get; set; }
		public double horas { get; set; }
		public int creditos { get; set; }
		public string prerequisito{get;set;}
	}
}