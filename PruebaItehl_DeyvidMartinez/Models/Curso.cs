using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaItehl_DeyvidMartinez.Models
{
    public class Curso
    {
        [Key]
        public int Curs_Id { get; set; }
        
        [Display(Name = "Nombre Curso")]
        public string Curs_Nom { get; set; }
        
        [Display(Name = "Descripción")]
        public string Curs_Desc { get; set; }

        [ForeignKey("Modalidad")]
        [Display(Name = "Modalidad")]
        public int IdModalidad { get; set; }
        public Modalidad Modalidad { get; set; }
        
        [Display(Name = "Costo del Curso")]
        public int Curs_Costo {get; set;}

        [ForeignKey("Pais")]
        [Display(Name = "Pais")]
        public int IdPais { get; set; }
        public Pais Pais { get; set; }

        [ForeignKey("Ciudad")]
        [Display(Name = "Ciudad")]
        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
        [Display(Name = "Dirección")]
        public string Curs_Direc { get; set; }
    }
}