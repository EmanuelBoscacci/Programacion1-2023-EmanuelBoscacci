using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAPISatelite.Models
{
    public class InfoSateliteIn
    {

        [Required(ErrorMessage = "El nombre del satélite es obligatorio.")]
        public string name { get; set; }


        [Required(ErrorMessage = "El mensaje es obligatorio. Y debe ser de la forma [,,,]")]
        [RegularExpression(@"^[A-Za-z\d\s]*$")]
        public string message { get; set; }



        [Required(ErrorMessage = "La distancia es obligatoria.")]
        public double distance { get; set; }





    }
}
