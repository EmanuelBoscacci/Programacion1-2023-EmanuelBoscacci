using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAPISatelite.Models
{
    public class InfoSateliteOut
    {

        public string nombre { get; set; }

        public string mensaje { get; set; }

        public double distancia { get; set; }
        public Coordenadas ubicacion { get; set; }


    }
}
