using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCandidatos.Models
{
	public enum NombreGenero
	{
		Masculino,
		Femenino,
		Otros

	}
    //Este codigo activa el campo Cedula como unico aplicandole un indice
    [Index(nameof(Cedula), IsUnique = true)]
    public class Candidato
    {
        [Key, Required]
        public int ID_Candidato { get; set; }

        [Required(ErrorMessage = "La cedula es requerida.")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los nombres son requeridos.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "El genero es requerido.")]
        public NombreGenero Genero { get; set; }

        [Display(Name ="Trabajo Actual")]
        public string TrabajoActual{ get; set; }


        //Este campo se manejara como un campo de moneda
        [Display(Name ="Expectativa Salarial")]
        public string ExpectativaSalarial { get; set; }
    }
}
