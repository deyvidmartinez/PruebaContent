using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaItehl_DeyvidMartinez.Models
{
    public class Modalidad
    {
        [Key]
        public int Moda_Id { get; set; }
        [Display(Name = "Modalidad")]
        public string Moda_Nom { get; set; }

        // Permite a Curso acceder a la Data
        public ICollection<Curso> Cursos { get; set; }
    }
}