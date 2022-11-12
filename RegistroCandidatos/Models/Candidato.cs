using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCandidatos.Models
{
    public class Candidato
    {
        [Key, Required]
        public int ID_Candidato { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }
        [Required]
        [Display(Name ="Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }


        [Display(Name ="Trabajo Actual")]
        public string TrabajoActual{ get; set; }

        [Display(Name ="Expectativa Salarial")]
        public string ExpectativaSalarial { get; set; }
    }
}
