using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCandidatos.Models
{
    //Este codigo activa el campo Cedula como unico aplicandole un indice
    [Index(nameof(Cedula), IsUnique = true)]
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

        //Relacion con la tabla genero Uno a Muchos
        [ForeignKey("Genero")]
        public int ID_Genero { get; set; }
        public Genero Genero { get; set; }


        [Display(Name ="Trabajo Actual")]
        public string TrabajoActual{ get; set; }


        //Este campo se manejara como un campo de moneda
        [Display(Name ="Expectativa Salarial")]
        public string ExpectativaSalarial { get; set; }
    }
}
