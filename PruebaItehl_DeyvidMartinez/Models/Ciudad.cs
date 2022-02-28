using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaItehl_DeyvidMartinez.Models
{
    public class Ciudad
    {
        [Key]
        public int Ciud_Id { get; set; }
        [Display(Name = "Ciudad")]
        public string Ciud_Nom { get; set; }

        // Permite a Curso acceder a la Data
        public ICollection<Curso> Cursos { get; set; }
    }
}