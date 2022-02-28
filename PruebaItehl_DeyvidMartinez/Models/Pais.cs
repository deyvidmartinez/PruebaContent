using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaItehl_DeyvidMartinez.Models
{
    public class Pais
    {
        [Key]
        public int Pais_Id { get; set; }

        [Display(Name = "Pais")]
        public string Pais_Nom { get; set; }

        // Permite a Curso acceder a la Data
        public ICollection<Curso> Cursos { get; set; }

    }
}