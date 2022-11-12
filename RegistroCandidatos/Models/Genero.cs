
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroCandidatos.Models
{
    public class Genero
    {
        [Key, Required]
        public int ID_Genero { get; set; }

        public string Nombre { get; set; }


        //Propiedad de navegacion que me permite acceder al modelo de candidato
        public List<Candidato> Candidato { get; set; }
    }
}
