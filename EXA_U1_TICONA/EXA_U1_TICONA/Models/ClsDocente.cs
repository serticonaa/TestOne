using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EXA_U1_TICONA.Models
{
	public class ClsDocente
	{
		public string codigo { get; set; }
		public string nombre { get;set; }
		public string apellido { get; set; }
		public string email { get; set; }
	}
}