using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EXA_U1_TICONA.Models
{
    public class ClsNumeros
    {
        [Required]
        public int numero { get; set; }
        public List<int> Lnumero{get;set;}
    }
}